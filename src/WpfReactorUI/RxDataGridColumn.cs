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
    public partial interface IRxDataGridColumn : IVisualNode
    {
        PropertyValue<bool>? CanUserReorder { get; set; }
        PropertyValue<bool>? CanUserResize { get; set; }
        PropertyValue<bool>? CanUserSort { get; set; }
        PropertyValue<Style>? CellStyle { get; set; }
        PropertyValue<int>? DisplayIndex { get; set; }
        PropertyValue<Style>? DragIndicatorStyle { get; set; }
        PropertyValue<object>? Header { get; set; }
        PropertyValue<string>? HeaderStringFormat { get; set; }
        PropertyValue<Style>? HeaderStyle { get; set; }
        PropertyValue<bool>? IsReadOnly { get; set; }
        PropertyValue<double>? MaxWidth { get; set; }
        PropertyValue<double>? MinWidth { get; set; }
        PropertyValue<string>? SortMemberPath { get; set; }
        PropertyValue<Visibility>? Visibility { get; set; }
        PropertyValue<DataGridLength>? Width { get; set; }

    }

    public partial class RxDataGridColumn<T> : VisualNode<T>, IRxDataGridColumn where T : DataGridColumn, new()
    {
        public RxDataGridColumn()
        {

        }

        public RxDataGridColumn(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxDataGridColumn.CanUserReorder { get; set; }
        PropertyValue<bool>? IRxDataGridColumn.CanUserResize { get; set; }
        PropertyValue<bool>? IRxDataGridColumn.CanUserSort { get; set; }
        PropertyValue<Style>? IRxDataGridColumn.CellStyle { get; set; }
        PropertyValue<int>? IRxDataGridColumn.DisplayIndex { get; set; }
        PropertyValue<Style>? IRxDataGridColumn.DragIndicatorStyle { get; set; }
        PropertyValue<object>? IRxDataGridColumn.Header { get; set; }
        PropertyValue<string>? IRxDataGridColumn.HeaderStringFormat { get; set; }
        PropertyValue<Style>? IRxDataGridColumn.HeaderStyle { get; set; }
        PropertyValue<bool>? IRxDataGridColumn.IsReadOnly { get; set; }
        PropertyValue<double>? IRxDataGridColumn.MaxWidth { get; set; }
        PropertyValue<double>? IRxDataGridColumn.MinWidth { get; set; }
        PropertyValue<string>? IRxDataGridColumn.SortMemberPath { get; set; }
        PropertyValue<Visibility>? IRxDataGridColumn.Visibility { get; set; }
        PropertyValue<DataGridLength>? IRxDataGridColumn.Width { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxDataGridColumn = (IRxDataGridColumn)this;
            SetPropertyValue(NativeControl, DataGridColumn.CanUserReorderProperty, thisAsIRxDataGridColumn.CanUserReorder);
            SetPropertyValue(NativeControl, DataGridColumn.CanUserResizeProperty, thisAsIRxDataGridColumn.CanUserResize);
            SetPropertyValue(NativeControl, DataGridColumn.CanUserSortProperty, thisAsIRxDataGridColumn.CanUserSort);
            SetPropertyValue(NativeControl, DataGridColumn.CellStyleProperty, thisAsIRxDataGridColumn.CellStyle);
            SetPropertyValue(NativeControl, DataGridColumn.DisplayIndexProperty, thisAsIRxDataGridColumn.DisplayIndex);
            SetPropertyValue(NativeControl, DataGridColumn.DragIndicatorStyleProperty, thisAsIRxDataGridColumn.DragIndicatorStyle);
            SetPropertyValue(NativeControl, DataGridColumn.HeaderProperty, thisAsIRxDataGridColumn.Header);
            SetPropertyValue(NativeControl, DataGridColumn.HeaderStringFormatProperty, thisAsIRxDataGridColumn.HeaderStringFormat);
            SetPropertyValue(NativeControl, DataGridColumn.HeaderStyleProperty, thisAsIRxDataGridColumn.HeaderStyle);
            SetPropertyValue(NativeControl, DataGridColumn.IsReadOnlyProperty, thisAsIRxDataGridColumn.IsReadOnly);
            SetPropertyValue(NativeControl, DataGridColumn.MaxWidthProperty, thisAsIRxDataGridColumn.MaxWidth);
            SetPropertyValue(NativeControl, DataGridColumn.MinWidthProperty, thisAsIRxDataGridColumn.MinWidth);
            SetPropertyValue(NativeControl, DataGridColumn.SortMemberPathProperty, thisAsIRxDataGridColumn.SortMemberPath);
            SetPropertyValue(NativeControl, DataGridColumn.VisibilityProperty, thisAsIRxDataGridColumn.Visibility);
            SetPropertyValue(NativeControl, DataGridColumn.WidthProperty, thisAsIRxDataGridColumn.Width);

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
    public static partial class RxDataGridColumnExtensions
    {
        public static T CanUserReorder<T>(this T datagridcolumn, bool canUserReorder) where T : IRxDataGridColumn
        {
            datagridcolumn.CanUserReorder = new PropertyValue<bool>(canUserReorder);
            return datagridcolumn;
        }
        public static T CanUserReorder<T>(this T datagridcolumn, Func<bool> canUserReorderFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.CanUserReorder = new PropertyValue<bool>(canUserReorderFunc);
            return datagridcolumn;
        }
        public static T CanUserResize<T>(this T datagridcolumn, bool canUserResize) where T : IRxDataGridColumn
        {
            datagridcolumn.CanUserResize = new PropertyValue<bool>(canUserResize);
            return datagridcolumn;
        }
        public static T CanUserResize<T>(this T datagridcolumn, Func<bool> canUserResizeFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.CanUserResize = new PropertyValue<bool>(canUserResizeFunc);
            return datagridcolumn;
        }
        public static T CanUserSort<T>(this T datagridcolumn, bool canUserSort) where T : IRxDataGridColumn
        {
            datagridcolumn.CanUserSort = new PropertyValue<bool>(canUserSort);
            return datagridcolumn;
        }
        public static T CanUserSort<T>(this T datagridcolumn, Func<bool> canUserSortFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.CanUserSort = new PropertyValue<bool>(canUserSortFunc);
            return datagridcolumn;
        }
        public static T CellStyle<T>(this T datagridcolumn, Style cellStyle) where T : IRxDataGridColumn
        {
            datagridcolumn.CellStyle = new PropertyValue<Style>(cellStyle);
            return datagridcolumn;
        }
        public static T CellStyle<T>(this T datagridcolumn, Func<Style> cellStyleFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.CellStyle = new PropertyValue<Style>(cellStyleFunc);
            return datagridcolumn;
        }
        public static T DisplayIndex<T>(this T datagridcolumn, int displayIndex) where T : IRxDataGridColumn
        {
            datagridcolumn.DisplayIndex = new PropertyValue<int>(displayIndex);
            return datagridcolumn;
        }
        public static T DisplayIndex<T>(this T datagridcolumn, Func<int> displayIndexFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.DisplayIndex = new PropertyValue<int>(displayIndexFunc);
            return datagridcolumn;
        }
        public static T DragIndicatorStyle<T>(this T datagridcolumn, Style dragIndicatorStyle) where T : IRxDataGridColumn
        {
            datagridcolumn.DragIndicatorStyle = new PropertyValue<Style>(dragIndicatorStyle);
            return datagridcolumn;
        }
        public static T DragIndicatorStyle<T>(this T datagridcolumn, Func<Style> dragIndicatorStyleFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.DragIndicatorStyle = new PropertyValue<Style>(dragIndicatorStyleFunc);
            return datagridcolumn;
        }
        public static T Header<T>(this T datagridcolumn, object header) where T : IRxDataGridColumn
        {
            datagridcolumn.Header = new PropertyValue<object>(header);
            return datagridcolumn;
        }
        public static T Header<T>(this T datagridcolumn, Func<object> headerFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.Header = new PropertyValue<object>(headerFunc);
            return datagridcolumn;
        }
        public static T HeaderStringFormat<T>(this T datagridcolumn, string headerStringFormat) where T : IRxDataGridColumn
        {
            datagridcolumn.HeaderStringFormat = new PropertyValue<string>(headerStringFormat);
            return datagridcolumn;
        }
        public static T HeaderStringFormat<T>(this T datagridcolumn, Func<string> headerStringFormatFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.HeaderStringFormat = new PropertyValue<string>(headerStringFormatFunc);
            return datagridcolumn;
        }
        public static T HeaderStyle<T>(this T datagridcolumn, Style headerStyle) where T : IRxDataGridColumn
        {
            datagridcolumn.HeaderStyle = new PropertyValue<Style>(headerStyle);
            return datagridcolumn;
        }
        public static T HeaderStyle<T>(this T datagridcolumn, Func<Style> headerStyleFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.HeaderStyle = new PropertyValue<Style>(headerStyleFunc);
            return datagridcolumn;
        }
        public static T IsReadOnly<T>(this T datagridcolumn, bool isReadOnly) where T : IRxDataGridColumn
        {
            datagridcolumn.IsReadOnly = new PropertyValue<bool>(isReadOnly);
            return datagridcolumn;
        }
        public static T IsReadOnly<T>(this T datagridcolumn, Func<bool> isReadOnlyFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.IsReadOnly = new PropertyValue<bool>(isReadOnlyFunc);
            return datagridcolumn;
        }
        public static T MaxWidth<T>(this T datagridcolumn, double maxWidth) where T : IRxDataGridColumn
        {
            datagridcolumn.MaxWidth = new PropertyValue<double>(maxWidth);
            return datagridcolumn;
        }
        public static T MaxWidth<T>(this T datagridcolumn, Func<double> maxWidthFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.MaxWidth = new PropertyValue<double>(maxWidthFunc);
            return datagridcolumn;
        }
        public static T MinWidth<T>(this T datagridcolumn, double minWidth) where T : IRxDataGridColumn
        {
            datagridcolumn.MinWidth = new PropertyValue<double>(minWidth);
            return datagridcolumn;
        }
        public static T MinWidth<T>(this T datagridcolumn, Func<double> minWidthFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.MinWidth = new PropertyValue<double>(minWidthFunc);
            return datagridcolumn;
        }
        public static T SortMemberPath<T>(this T datagridcolumn, string sortMemberPath) where T : IRxDataGridColumn
        {
            datagridcolumn.SortMemberPath = new PropertyValue<string>(sortMemberPath);
            return datagridcolumn;
        }
        public static T SortMemberPath<T>(this T datagridcolumn, Func<string> sortMemberPathFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.SortMemberPath = new PropertyValue<string>(sortMemberPathFunc);
            return datagridcolumn;
        }
        public static T Visibility<T>(this T datagridcolumn, Visibility visibility) where T : IRxDataGridColumn
        {
            datagridcolumn.Visibility = new PropertyValue<Visibility>(visibility);
            return datagridcolumn;
        }
        public static T Visibility<T>(this T datagridcolumn, Func<Visibility> visibilityFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.Visibility = new PropertyValue<Visibility>(visibilityFunc);
            return datagridcolumn;
        }
        public static T Width<T>(this T datagridcolumn, DataGridLength width) where T : IRxDataGridColumn
        {
            datagridcolumn.Width = new PropertyValue<DataGridLength>(width);
            return datagridcolumn;
        }
        public static T Width<T>(this T datagridcolumn, Func<DataGridLength> widthFunc) where T : IRxDataGridColumn
        {
            datagridcolumn.Width = new PropertyValue<DataGridLength>(widthFunc);
            return datagridcolumn;
        }
    }
}
