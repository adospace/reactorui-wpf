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
#if DEBUG
            if (args == null ||
                args.Length == 0)
            {
                args = new[] { @"AvaloniaReactorUI.DemoApp.dll" };
            }
#endif
            if (args == null ||
                args.Length == 0)
            {
                Console.WriteLine("Specify the assembly path to load");
                return -1;
            }

            var assemblyPath = args[0];

            if (!Path.IsPathRooted(assemblyPath))
            {
                assemblyPath = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), assemblyPath);
            }

            if (!File.Exists(assemblyPath))
            {
                Console.WriteLine($"The assembly '{assemblyPath}' doesn't exist");
                return -1;
            }

            var assemblyPdbPath = Path.Combine(Path.GetDirectoryName(assemblyPath), Path.GetFileNameWithoutExtension(assemblyPath) + ".pdb");

            var assembly = File.Exists(assemblyPdbPath) ?
                Assembly.Load(File.ReadAllBytes(assemblyPath))
                :
                Assembly.Load(File.ReadAllBytes(assemblyPath), File.ReadAllBytes(assemblyPdbPath));

            ComponentLoader.Instance = new AssemblyFileComponentLoader(assemblyPath);

            AppDomain currentDomain = AppDomain.CurrentDomain;
            string folderPath = Path.GetDirectoryName(assemblyPath);

            currentDomain.AssemblyResolve += (object sender, ResolveEventArgs args) =>
            {
                string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
                if (!File.Exists(assemblyPath)) return null;
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                return assembly;
            };

            assembly
                .GetTypes()
                .First(_ => typeof(System.Windows.Application).IsAssignableFrom(_))
                .GetMethod("Main")
                .Invoke(null, null);

            return 0;
        }

    }
}
