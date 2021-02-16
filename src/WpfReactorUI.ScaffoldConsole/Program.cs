using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfReactorUI.ScaffoldApp;

namespace WpfReactorUI.ScaffoldConsole
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            var basePath = @"..\..\..\..\";
            var baseWpfReactorUIPath = basePath + "WpfReactorUI";
            var baseWpfReactorUIModernThemePath = basePath + "WpfReactorUI.ModernTheme";

            //force assemblies loading
            var uIElement = new UIElement();
            var button = new Button();
            var shape = new Rectangle();
            
            var simplePanel = new ModernWpf.Controls.NumberBox();
            
            
            var types = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                         // alternative: from domainAssembly in domainAssembly.GetExportedTypes()
                         from assemblyType in domainAssembly.GetTypes()
                         where typeof(DependencyObject).IsAssignableFrom(assemblyType)
                         // alternative: where assemblyType.IsSubclassOf(typeof(B))
                         // alternative: && ! assemblyType.IsAbstract
                         select assemblyType)
                .ToDictionary(_ => _.FullName, _ => _);

            foreach (var classNameToGenerate in File.ReadAllLines("WidgetList.txt").Where(_ => !string.IsNullOrWhiteSpace(_)))
            {
                var typeToGenerate = types[classNameToGenerate];
                var targetPath = System.IO.Path.Combine(baseWpfReactorUIPath, $"Rx{typeToGenerate.Name}.cs");
                var generator = new TypeSourceGenerator(typeToGenerate);

                if (classNameToGenerate.StartsWith("ModernWpf"))
                {
                    targetPath = System.IO.Path.Combine(baseWpfReactorUIModernThemePath, $"Rx{typeToGenerate.Name}.cs");
                    generator = new TypeSourceGenerator(typeToGenerate, new[] { "ModernWpf.Controls", "ModernWpf.Controls.Primitives" }, "WpfReactorUI.ModernTheme");
                }

                Console.WriteLine($"Generating {typeToGenerate.FullName} to {targetPath}...");                
                File.WriteAllText(targetPath, generator.TransformAndPrettify());
            }

        }
    }
}
