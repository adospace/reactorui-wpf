using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using WpfReactorUI.Internals;

namespace WpfReactorUI.Host
{
    class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            if (args == null ||
                args.Length == 0)
            {
                Trace.WriteLine("[WpfReactorUI] Specify the assembly path to load");
                return -1;
            }

            var assemblyPath = args[0];

            if (!Path.IsPathRooted(assemblyPath))
            {
                var currentAssemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                    ?? throw new InvalidOperationException("Unable to get current assembly folder path");

                assemblyPath = Path.Combine(currentAssemblyFolder, assemblyPath);
            }

            if (!File.Exists(assemblyPath))
            {
                Trace.WriteLine($"[WpfReactorUI] The assembly '{assemblyPath}' doesn't exist");
                return -1;
            }

            string folderPath = Path.GetDirectoryName(assemblyPath) ?? throw new InvalidOperationException("Unable to get path of the assembly to hot-reload");
            string assemblyName = Path.GetFileNameWithoutExtension(assemblyPath);

            Trace.WriteLine($"[WpfReactorUI] Loading assembly '{assemblyPath}'");

            //<assemblyName>.deps.json --> WpfReactorUI.Host.deps.json
            Trace.WriteLine($"[WpfReactorUI] Copying assembly '{Path.Combine(folderPath, assemblyName + ".deps.json")}' to '{Path.Combine(folderPath, "WpfReactorUI.Host.deps.json")}'");
            File.Copy(Path.Combine(folderPath, assemblyName + ".deps.json"), Path.Combine(folderPath, "WpfReactorUI.Host.deps.json"), true);

            //var assemblyPdbPath = Path.Combine(folderPath, assemblyName + ".pdb");

            //Assembly assembly;
            //if (!File.Exists(assemblyPdbPath))
            //{
            //    assembly = Assembly.Load(Utils.ReadFileBytesWithoutLock(assemblyPath));
            //}
            //else
            //{
            //    //var ghostAssemblyFilePath = Path.Combine(folderPath, assemblyName + "_ghost.pdb");
            //    //File.Move(assemblyPdbPath, ghostAssemblyFilePath, true);
            //    //Trace.WriteLine($"[WpfReactorUI] Assembly pdb '{assemblyPdbPath}' loaded from {ghostAssemblyFilePath}");
            //    Trace.WriteLine($"[WpfReactorUI] Assembly pdb '{assemblyPdbPath}' loaded");
            //    assembly = Assembly.Load(Utils.ReadFileBytesWithoutLock(assemblyPath), Utils.ReadFileBytesWithoutLock(assemblyPdbPath));
            //}

            var assembly = Utils.LoadAssemblyWithoutLock(assemblyPath);

            ComponentLoader.Instance = new AssemblyFileComponentLoader(assemblyPath);

            AppDomain currentDomain = AppDomain.CurrentDomain;

            currentDomain.AssemblyResolve += (object? sender, ResolveEventArgs args) =>
            {
                string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
                
                if (!File.Exists(assemblyPath))
                {
                    Trace.WriteLine($"[WpfReactorUI] Unable to load '{assemblyPath}'");
                    return null;
                }

                var assembly = Utils.LoadAssemblyWithoutLock(assemblyPath);
                Trace.WriteLine($"[WpfReactorUI] Loaded '{assemblyPath}'");
                return assembly;
                //Assembly assembly = Assembly.LoadFrom(assemblyPath);
                //Trace.WriteLine($"[WpfReactorUI] Loaded '{assemblyPath}'");
                //return assembly;
            };

            var mainMethod = assembly
                .GetTypes()
                .First(_ => typeof(System.Windows.Application).IsAssignableFrom(_))
                .GetMethod("Main")
                ?? throw new InvalidOperationException("Application doesn't have a static Main method");

            //Utils.CreateEmptyDummyPdbFile(assemblyPath);
            //Trace.WriteLine($"[WpfReactorUI] Set empty pdb for '{assemblyPath}'");

            mainMethod.Invoke(null, null);

            return 0;
        }

        

    }
}
