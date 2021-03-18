using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxDataGridTemplateColumn : IRxDataGridColumn
    {
        PropertyValue<DataTemplate>? CellTemplate { get; set; }
        PropertyValue<DataTemplate>? CellEditingTemplate { get; set; }
    }

    public partial class RxDataGridTemplateColumn<T>
    {
        PropertyValue<DataTemplate>? IRxDataGridTemplateColumn.CellTemplate { get; set; }
        PropertyValue<DataTemplate>? IRxDataGridTemplateColumn.CellEditingTemplate { get; set; }

        partial void OnBeginUpdate()
        {
            var thisAsIRxDataGridTemplateColumn = (IRxDataGridTemplateColumn)this;
            NativeControl.CellTemplate = thisAsIRxDataGridTemplateColumn.CellTemplate?.Value;
            NativeControl.CellEditingTemplate = thisAsIRxDataGridTemplateColumn.CellEditingTemplate?.Value;
        }
    }

    public static partial class RxDataGridTextColumnExtensions
    {
        public static T CellTemplate<T>(this T datagridtemplatecolumn, DataTemplate datatemplate) where T : IRxDataGridTemplateColumn
        {
            datagridtemplatecolumn.CellTemplate = new PropertyValue<DataTemplate>(datatemplate);
            return datagridtemplatecolumn;
        }
        
        public static T CellEditingTemplate<T>(this T datagridtemplatecolumn, DataTemplate datatemplate) where T : IRxDataGridTemplateColumn
        {
            datagridtemplatecolumn.CellEditingTemplate = new PropertyValue<DataTemplate>(datatemplate);
            return datagridtemplatecolumn;
        }
    }
}
