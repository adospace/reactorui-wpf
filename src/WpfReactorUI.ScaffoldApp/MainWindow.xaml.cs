using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfReactorUI.ScaffoldApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DiscoverWpfTypes();
        }

        private void DiscoverWpfTypes()
        {
            var listOfElements = (
                from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                    // alternative: from domainAssembly in domainAssembly.GetExportedTypes()
                from assemblyType in domainAssembly.GetTypes()
                where typeof(UIElement).IsAssignableFrom(assemblyType)
                // alternative: where assemblyType.IsSubclassOf(typeof(B))
                // alternative: && ! assemblyType.IsAbstract
                select assemblyType)
                    .OrderBy(_ => _.Name)
                    .ToList();

            lstTypes.ItemsSource = listOfElements;
        }

        private void lstTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var typeToScaffold = lstTypes.SelectedItem as Type;
            if (typeToScaffold == null)
                return;

            var sourceGenerator = new TypeSourceGenerator(typeToScaffold);
            tbGeneratedSource.Text = sourceGenerator.TransformText();
        }

        private void BrowseForCustomAssembly_Clicked(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Filter = "File Assembly (*.dll, *.exe)|*.dll;*.exe"
            };
            if (dlg.ShowDialog() == true)
            {
                customAssemblyPathTextBox.Text = dlg.FileName;
                var assembly = Assembly.LoadFrom(dlg.FileName);

                var listOfElements = (
                    from assemblyType in assembly.GetTypes()
                    where typeof(UIElement).IsAssignableFrom(assemblyType)
                    // alternative: where assemblyType.IsSubclassOf(typeof(B))
                    // alternative: && ! assemblyType.IsAbstract
                    select assemblyType)
                        .OrderBy(_ => _.Name)
                        .ToList();

                lstTypes.ItemsSource = listOfElements;
            }
        }
    }
}
