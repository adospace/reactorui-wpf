using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.DemoApp.Pages
{
    public class DataGridPage : RxComponent
    {
        public override VisualNode Render() 
            => new RxPage()
            {
                new RxDataGrid()
                {
                    new RxDataGridTextColumn()
                        .Header("Column 1")
                        .Binding("Item1"),
                    new RxDataGridTextColumn()
                        .Header("Column 2")
                        .Binding("Item2"),
                    new RxDataGridTextColumn()
                        .Header("Column 3")
                        .Binding("Item3")
                }
                .AutoGenerateColumns(false)
                .ItemsSource(new[]
                {
                    new Tuple<string, string, string>("Row1 Column1", "Row1 Column2", "Row1 Column3"),
                    new Tuple<string, string, string>("Row2 Column1", "Row2 Column2", "Row2 Column3"),
                })
            }
            .Title("DataGrid Page");
    }
}
