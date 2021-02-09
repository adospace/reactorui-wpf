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
        private static string _assemblyPdbPath;

        static void Main(string[] args)
        {
            _folderToMonitor = args[0];
            _assemblyPdbPath = args[1];

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
                Console.WriteLine($"Creating empty pdb file {_assemblyPdbPath}...");
                File.Delete(_assemblyPdbPath);
                File.WriteAllBytes(_assemblyPdbPath, Array.Empty<byte>());
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

        private static bool TryBuildProject()
        {
            try
            {
                Run("dotnet", $"build --no-restore --no-dependencies", _folderToMonitor);
                return true;
            }
            catch (Exception)
            {
                //error while running dotnet build...
                return false;
            }
        }
    }
}
