using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxDataGridBoundColumn : IRxDataGridColumn
    {
        PropertyValue<BindingBase>? Binding { get; set; }
    }

    public partial class RxDataGridBoundColumn<T>
    {
        PropertyValue<BindingBase>? IRxDataGridBoundColumn.Binding { get; set; }

        partial void OnBeginUpdate()
        {
            var thisAsIRxDataGridBoundColumn = (IRxDataGridBoundColumn)this;
            NativeControl.Binding = thisAsIRxDataGridBoundColumn.Binding?.Value;
        }
    }

    public static partial class RxDataGridBoundColumnExtensions
    {
        public static T Binding<T>(this T datagridboundcolumn, BindingBase binding) where T : IRxDataGridBoundColumn
        {
            datagridboundcolumn.Binding = new PropertyValue<BindingBase>(binding);
            return datagridboundcolumn;
        }

        public static T Binding<T>(this T datagridboundcolumn, string bindingPropertyName) where T : IRxDataGridBoundColumn
        {
            datagridboundcolumn.Binding = new PropertyValue<BindingBase>(new Binding(bindingPropertyName));
            return datagridboundcolumn;
        }
    }
}
