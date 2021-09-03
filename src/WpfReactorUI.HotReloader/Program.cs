using System;
using System.IO;
using System.Threading;
using static SimpleExec.Command;

namespace WpfReactorUI.HotReloader
{
    class Program
    {
        private static string _folderToMonitor;
        private static FileSystemWatcher _fileSystemWatcher;
        private static string _assemblyPath;

        static void Main(string[] args)
        {
            if (args == null || args.Length != 2)
            {
                Console.WriteLine("Command line arguments required: <folder-to-monitor> <assembly-dll-path>");
                return;
            }

            _folderToMonitor = args[0];
            _assemblyPath = args[1];

            TryBuildProject(true);

            _fileSystemWatcher = new FileSystemWatcher(
                _folderToMonitor,
                "*.cs")
            {
                NotifyFilter = NotifyFilters.Attributes |
                    NotifyFilters.CreationTime |
                    NotifyFilters.FileName |
                    NotifyFilters.LastAccess |
                    NotifyFilters.LastWrite |
                    NotifyFilters.Size |
                    NotifyFilters.Security,
                IncludeSubdirectories = true
            };

            _fileSystemWatcher.Changed += OnFileChanged;
            _fileSystemWatcher.Error += OnFileError;

            _fileSystemWatcher.EnableRaisingEvents = true;

            var exitEvent = new AutoResetEvent(false);
            Console.CancelKeyPress += (s, e) => exitEvent.Set();

            Console.WriteLine($"Waiting for file changes in {_folderToMonitor} ...");

            exitEvent.WaitOne();
            

            _fileSystemWatcher.EnableRaisingEvents = false;
            _fileSystemWatcher.Changed -= OnFileChanged;
            _fileSystemWatcher.Error -= OnFileError;
            _fileSystemWatcher.Dispose();
            _fileSystemWatcher = null;
        }

        private static void OnFileError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"Unable to continue monitoring folder {_folderToMonitor}");
        }

        private static void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File changed {e.ChangeType} '{e.FullPath}'");

            if (_fileSystemWatcher == null)
            {
                return;
            }

            _fileSystemWatcher.EnableRaisingEvents = false;

            try
            {
                //if (!File.Exists(_assemblyPdbPath))
                //{
                var pdbAssemblyName = Path.GetFileNameWithoutExtension(_assemblyPath) + ".pdb";
                var pdbAssemblyPath = Path.Combine(Path.GetDirectoryName(_assemblyPath), pdbAssemblyName);

                Console.WriteLine($"Creating empty pdb file {pdbAssemblyPath}...");
                File.Delete(pdbAssemblyPath);
                File.WriteAllBytes(pdbAssemblyPath, Array.Empty<byte>());
                //}

                if (!TryBuildProject())
                {
                    TryBuildProject();
                }
            }
            finally
            {
                Console.WriteLine("Waiting for file changes...");
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        private static bool TryBuildProject(bool fullBuild = false)
        {
            try
            {
                var outputFolder = Path.Combine(_folderToMonitor, $"bin/WpfReactorUI/temp_generated");

                var cmdLine = $"build {(!fullBuild ? "--no-restore --no-dependencies" : "")} --output \"{outputFolder}\"";
                Console.WriteLine($"Executing '{cmdLine}'");
                Run("dotnet", cmdLine, _folderToMonitor);

                var pdbAssemblyName = Path.GetFileNameWithoutExtension(_assemblyPath) + ".pdb";
                var pdbAssemblyPath = Path.Combine(Path.GetDirectoryName(_assemblyPath), pdbAssemblyName);
                var generatedPdbFilePath = Path.Combine(outputFolder, pdbAssemblyName);

                Console.WriteLine($"Copy from {generatedPdbFilePath} to {pdbAssemblyPath}");
                File.Copy(generatedPdbFilePath, pdbAssemblyPath, true);

                var assemblyName = Path.GetFileName(_assemblyPath);
                var generatedFilePath = Path.Combine(outputFolder, assemblyName);

                Console.WriteLine($"Copy from {generatedFilePath} to {_assemblyPath}");
                File.Copy(generatedFilePath, _assemblyPath, true);


                return true;
            }
            catch (Exception ex)
            {
                //error while running dotnet build...
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
