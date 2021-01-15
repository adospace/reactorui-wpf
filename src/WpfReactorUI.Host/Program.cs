using System;
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
                Console.WriteLine("Specify the assembly path to load");
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
                Console.WriteLine($"The assembly '{assemblyPath}' doesn't exist");
                return -1;
            }

            string folderPath = Path.GetDirectoryName(assemblyPath) ?? throw new InvalidOperationException("Unable to get path of the assembly to hot-reload");
            var assemblyPdbPath = Path.Combine(folderPath, Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            var assembly = File.Exists(assemblyPdbPath) ?
                Assembly.Load(File.ReadAllBytes(assemblyPath))
                :
                Assembly.Load(File.ReadAllBytes(assemblyPath), File.ReadAllBytes(assemblyPdbPath));

            ComponentLoader.Instance = new AssemblyFileComponentLoader(assemblyPath);

            AppDomain currentDomain = AppDomain.CurrentDomain;

            currentDomain.AssemblyResolve += (object? sender, ResolveEventArgs args) =>
            {
                string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
                if (!File.Exists(assemblyPath)) return null;
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                return assembly;
            };

            var mainMethod = assembly
                .GetTypes()
                .First(_ => typeof(System.Windows.Application).IsAssignableFrom(_))
                .GetMethod("Main")
                ?? throw new InvalidOperationException("Application doesn't have a static Main method");

            mainMethod.Invoke(null, null);

            return 0;
        }

    }
}
