using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Reflection;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Controls.Primitives;

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxDataGridBoundColumn : IRxDataGridColumn
    {
        PropertyValue<Style>? EditingElementStyle { get; set; }
        PropertyValue<Style>? ElementStyle { get; set; }

    }

    public partial class RxDataGridBoundColumn<T> : RxDataGridColumn<T>, IRxDataGridBoundColumn where T : DataGridBoundColumn, new()
    {
        public RxDataGridBoundColumn()
        {

        }

        public RxDataGridBoundColumn(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Style>? IRxDataGridBoundColumn.EditingElementStyle { get; set; }
        PropertyValue<Style>? IRxDataGridBoundColumn.ElementStyle { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxDataGridBoundColumn = (IRxDataGridBoundColumn)this;
            SetPropertyValue(NativeControl, DataGridBoundColumn.EditingElementStyleProperty, thisAsIRxDataGridBoundColumn.EditingElementStyle);
            SetPropertyValue(NativeControl, DataGridBoundColumn.ElementStyleProperty, thisAsIRxDataGridBoundColumn.ElementStyle);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {

            base.OnAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxDataGridBoundColumnExtensions
    {
        public static T EditingElementStyle<T>(this T datagridboundcolumn, Style editingElementStyle) where T : IRxDataGridBoundColumn
        {
            datagridboundcolumn.EditingElementStyle = new PropertyValue<Style>(editingElementStyle);
            return datagridboundcolumn;
        }
        public static T EditingElementStyle<T>(this T datagridboundcolumn, Func<Style> editingElementStyleFunc) where T : IRxDataGridBoundColumn
        {
            datagridboundcolumn.EditingElementStyle = new PropertyValue<Style>(editingElementStyleFunc);
            return datagridboundcolumn;
        }
        public static T ElementStyle<T>(this T datagridboundcolumn, Style elementStyle) where T : IRxDataGridBoundColumn
        {
            datagridboundcolumn.ElementStyle = new PropertyValue<Style>(elementStyle);
            return datagridboundcolumn;
        }
        public static T ElementStyle<T>(this T datagridboundcolumn, Func<Style> elementStyleFunc) where T : IRxDataGridBoundColumn
        {
            datagridboundcolumn.ElementStyle = new PropertyValue<Style>(elementStyleFunc);
            return datagridboundcolumn;
        }
    }
}
