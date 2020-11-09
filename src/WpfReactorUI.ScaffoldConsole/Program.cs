using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfReactorUI.ScaffoldApp;

namespace WpfReactorUI.ScaffoldConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args == null ||
                args.Length == 0)
            {
                Console.WriteLine("AvaloniaReactorUI folder not specified");
                return;
            }

            var uIElement = new UIElement();
            var button = new Button();
            var types = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                         // alternative: from domainAssembly in domainAssembly.GetExportedTypes()
                         from assemblyType in domainAssembly.GetTypes()
                         where typeof(Visual).IsAssignableFrom(assemblyType)
                         // alternative: where assemblyType.IsSubclassOf(typeof(B))
                         // alternative: && ! assemblyType.IsAbstract
                         select assemblyType)
                .ToDictionary(_ => _.FullName, _ => _);

            foreach (var classNameToGenerate in File.ReadAllLines("WidgetList.txt"))
            {
                var typeToGenerate = types[classNameToGenerate];
                var targetPath = Path.Combine(args[0], $"Rx{typeToGenerate.Name}.cs");
                Console.WriteLine($"Generating {typeToGenerate.FullName} to {targetPath}...");

                var generator = new TypeSourceGenerator(typeToGenerate);
                File.WriteAllText(targetPath, generator.TransformAndPrettify());
            }

        }
    }
}
