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
using System.Windows.Navigation;

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxDataGrid : IRxMultiSelector
    {
        PropertyValue<Brush>? AlternatingRowBackground { get; set; }
        PropertyValue<bool>? AreRowDetailsFrozen { get; set; }
        PropertyValue<bool>? AutoGenerateColumns { get; set; }
        PropertyValue<bool>? CanUserAddRows { get; set; }
        PropertyValue<bool>? CanUserDeleteRows { get; set; }
        PropertyValue<bool>? CanUserReorderColumns { get; set; }
        PropertyValue<bool>? CanUserResizeColumns { get; set; }
        PropertyValue<bool>? CanUserResizeRows { get; set; }
        PropertyValue<bool>? CanUserSortColumns { get; set; }
        PropertyValue<Style>? CellStyle { get; set; }
        PropertyValue<DataGridClipboardCopyMode>? ClipboardCopyMode { get; set; }
        PropertyValue<double>? ColumnHeaderHeight { get; set; }
        PropertyValue<Style>? ColumnHeaderStyle { get; set; }
        PropertyValue<DataGridLength>? ColumnWidth { get; set; }
        PropertyValue<DataGridCellInfo>? CurrentCell { get; set; }
        PropertyValue<DataGridColumn>? CurrentColumn { get; set; }
        PropertyValue<object>? CurrentItem { get; set; }
        PropertyValue<Style>? DragIndicatorStyle { get; set; }
        PropertyValue<Style>? DropLocationIndicatorStyle { get; set; }
        PropertyValue<bool>? EnableColumnVirtualization { get; set; }
        PropertyValue<bool>? EnableRowVirtualization { get; set; }
        PropertyValue<int>? FrozenColumnCount { get; set; }
        PropertyValue<DataGridGridLinesVisibility>? GridLinesVisibility { get; set; }
        PropertyValue<DataGridHeadersVisibility>? HeadersVisibility { get; set; }
        PropertyValue<Brush>? HorizontalGridLinesBrush { get; set; }
        PropertyValue<ScrollBarVisibility>? HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool>? IsReadOnly { get; set; }
        PropertyValue<double>? MaxColumnWidth { get; set; }
        PropertyValue<double>? MinColumnWidth { get; set; }
        PropertyValue<double>? MinRowHeight { get; set; }
        PropertyValue<Brush>? RowBackground { get; set; }
        PropertyValue<DataGridRowDetailsVisibilityMode>? RowDetailsVisibilityMode { get; set; }
        PropertyValue<Style>? RowHeaderStyle { get; set; }
        PropertyValue<double>? RowHeaderWidth { get; set; }
        PropertyValue<double>? RowHeight { get; set; }
        PropertyValue<Style>? RowStyle { get; set; }
        PropertyValue<DataGridSelectionMode>? SelectionMode { get; set; }
        PropertyValue<DataGridSelectionUnit>? SelectionUnit { get; set; }
        PropertyValue<Brush>? VerticalGridLinesBrush { get; set; }
        PropertyValue<ScrollBarVisibility>? VerticalScrollBarVisibility { get; set; }

    }

    public partial class RxDataGrid<T> : RxMultiSelector<T>, IRxDataGrid where T : DataGrid, new()
    {
        public RxDataGrid()
        {

        }

        public RxDataGrid(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxDataGrid.AlternatingRowBackground { get; set; }
        PropertyValue<bool>? IRxDataGrid.AreRowDetailsFrozen { get; set; }
        PropertyValue<bool>? IRxDataGrid.AutoGenerateColumns { get; set; }
        PropertyValue<bool>? IRxDataGrid.CanUserAddRows { get; set; }
        PropertyValue<bool>? IRxDataGrid.CanUserDeleteRows { get; set; }
        PropertyValue<bool>? IRxDataGrid.CanUserReorderColumns { get; set; }
        PropertyValue<bool>? IRxDataGrid.CanUserResizeColumns { get; set; }
        PropertyValue<bool>? IRxDataGrid.CanUserResizeRows { get; set; }
        PropertyValue<bool>? IRxDataGrid.CanUserSortColumns { get; set; }
        PropertyValue<Style>? IRxDataGrid.CellStyle { get; set; }
        PropertyValue<DataGridClipboardCopyMode>? IRxDataGrid.ClipboardCopyMode { get; set; }
        PropertyValue<double>? IRxDataGrid.ColumnHeaderHeight { get; set; }
        PropertyValue<Style>? IRxDataGrid.ColumnHeaderStyle { get; set; }
        PropertyValue<DataGridLength>? IRxDataGrid.ColumnWidth { get; set; }
        PropertyValue<DataGridCellInfo>? IRxDataGrid.CurrentCell { get; set; }
        PropertyValue<DataGridColumn>? IRxDataGrid.CurrentColumn { get; set; }
        PropertyValue<object>? IRxDataGrid.CurrentItem { get; set; }
        PropertyValue<Style>? IRxDataGrid.DragIndicatorStyle { get; set; }
        PropertyValue<Style>? IRxDataGrid.DropLocationIndicatorStyle { get; set; }
        PropertyValue<bool>? IRxDataGrid.EnableColumnVirtualization { get; set; }
        PropertyValue<bool>? IRxDataGrid.EnableRowVirtualization { get; set; }
        PropertyValue<int>? IRxDataGrid.FrozenColumnCount { get; set; }
        PropertyValue<DataGridGridLinesVisibility>? IRxDataGrid.GridLinesVisibility { get; set; }
        PropertyValue<DataGridHeadersVisibility>? IRxDataGrid.HeadersVisibility { get; set; }
        PropertyValue<Brush>? IRxDataGrid.HorizontalGridLinesBrush { get; set; }
        PropertyValue<ScrollBarVisibility>? IRxDataGrid.HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool>? IRxDataGrid.IsReadOnly { get; set; }
        PropertyValue<double>? IRxDataGrid.MaxColumnWidth { get; set; }
        PropertyValue<double>? IRxDataGrid.MinColumnWidth { get; set; }
        PropertyValue<double>? IRxDataGrid.MinRowHeight { get; set; }
        PropertyValue<Brush>? IRxDataGrid.RowBackground { get; set; }
        PropertyValue<DataGridRowDetailsVisibilityMode>? IRxDataGrid.RowDetailsVisibilityMode { get; set; }
        PropertyValue<Style>? IRxDataGrid.RowHeaderStyle { get; set; }
        PropertyValue<double>? IRxDataGrid.RowHeaderWidth { get; set; }
        PropertyValue<double>? IRxDataGrid.RowHeight { get; set; }
        PropertyValue<Style>? IRxDataGrid.RowStyle { get; set; }
        PropertyValue<DataGridSelectionMode>? IRxDataGrid.SelectionMode { get; set; }
        PropertyValue<DataGridSelectionUnit>? IRxDataGrid.SelectionUnit { get; set; }
        PropertyValue<Brush>? IRxDataGrid.VerticalGridLinesBrush { get; set; }
        PropertyValue<ScrollBarVisibility>? IRxDataGrid.VerticalScrollBarVisibility { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxDataGrid = (IRxDataGrid)this;
            SetPropertyValue(NativeControl, DataGrid.AlternatingRowBackgroundProperty, thisAsIRxDataGrid.AlternatingRowBackground);
            SetPropertyValue(NativeControl, DataGrid.AreRowDetailsFrozenProperty, thisAsIRxDataGrid.AreRowDetailsFrozen);
            SetPropertyValue(NativeControl, DataGrid.AutoGenerateColumnsProperty, thisAsIRxDataGrid.AutoGenerateColumns);
            SetPropertyValue(NativeControl, DataGrid.CanUserAddRowsProperty, thisAsIRxDataGrid.CanUserAddRows);
            SetPropertyValue(NativeControl, DataGrid.CanUserDeleteRowsProperty, thisAsIRxDataGrid.CanUserDeleteRows);
            SetPropertyValue(NativeControl, DataGrid.CanUserReorderColumnsProperty, thisAsIRxDataGrid.CanUserReorderColumns);
            SetPropertyValue(NativeControl, DataGrid.CanUserResizeColumnsProperty, thisAsIRxDataGrid.CanUserResizeColumns);
            SetPropertyValue(NativeControl, DataGrid.CanUserResizeRowsProperty, thisAsIRxDataGrid.CanUserResizeRows);
            SetPropertyValue(NativeControl, DataGrid.CanUserSortColumnsProperty, thisAsIRxDataGrid.CanUserSortColumns);
            SetPropertyValue(NativeControl, DataGrid.CellStyleProperty, thisAsIRxDataGrid.CellStyle);
            SetPropertyValue(NativeControl, DataGrid.ClipboardCopyModeProperty, thisAsIRxDataGrid.ClipboardCopyMode);
            SetPropertyValue(NativeControl, DataGrid.ColumnHeaderHeightProperty, thisAsIRxDataGrid.ColumnHeaderHeight);
            SetPropertyValue(NativeControl, DataGrid.ColumnHeaderStyleProperty, thisAsIRxDataGrid.ColumnHeaderStyle);
            SetPropertyValue(NativeControl, DataGrid.ColumnWidthProperty, thisAsIRxDataGrid.ColumnWidth);
            SetPropertyValue(NativeControl, DataGrid.CurrentCellProperty, thisAsIRxDataGrid.CurrentCell);
            SetPropertyValue(NativeControl, DataGrid.CurrentColumnProperty, thisAsIRxDataGrid.CurrentColumn);
            SetPropertyValue(NativeControl, DataGrid.CurrentItemProperty, thisAsIRxDataGrid.CurrentItem);
            SetPropertyValue(NativeControl, DataGrid.DragIndicatorStyleProperty, thisAsIRxDataGrid.DragIndicatorStyle);
            SetPropertyValue(NativeControl, DataGrid.DropLocationIndicatorStyleProperty, thisAsIRxDataGrid.DropLocationIndicatorStyle);
            SetPropertyValue(NativeControl, DataGrid.EnableColumnVirtualizationProperty, thisAsIRxDataGrid.EnableColumnVirtualization);
            SetPropertyValue(NativeControl, DataGrid.EnableRowVirtualizationProperty, thisAsIRxDataGrid.EnableRowVirtualization);
            SetPropertyValue(NativeControl, DataGrid.FrozenColumnCountProperty, thisAsIRxDataGrid.FrozenColumnCount);
            SetPropertyValue(NativeControl, DataGrid.GridLinesVisibilityProperty, thisAsIRxDataGrid.GridLinesVisibility);
            SetPropertyValue(NativeControl, DataGrid.HeadersVisibilityProperty, thisAsIRxDataGrid.HeadersVisibility);
            SetPropertyValue(NativeControl, DataGrid.HorizontalGridLinesBrushProperty, thisAsIRxDataGrid.HorizontalGridLinesBrush);
            SetPropertyValue(NativeControl, DataGrid.HorizontalScrollBarVisibilityProperty, thisAsIRxDataGrid.HorizontalScrollBarVisibility);
            SetPropertyValue(NativeControl, DataGrid.IsReadOnlyProperty, thisAsIRxDataGrid.IsReadOnly);
            SetPropertyValue(NativeControl, DataGrid.MaxColumnWidthProperty, thisAsIRxDataGrid.MaxColumnWidth);
            SetPropertyValue(NativeControl, DataGrid.MinColumnWidthProperty, thisAsIRxDataGrid.MinColumnWidth);
            SetPropertyValue(NativeControl, DataGrid.MinRowHeightProperty, thisAsIRxDataGrid.MinRowHeight);
            SetPropertyValue(NativeControl, DataGrid.RowBackgroundProperty, thisAsIRxDataGrid.RowBackground);
            SetPropertyValue(NativeControl, DataGrid.RowDetailsVisibilityModeProperty, thisAsIRxDataGrid.RowDetailsVisibilityMode);
            SetPropertyValue(NativeControl, DataGrid.RowHeaderStyleProperty, thisAsIRxDataGrid.RowHeaderStyle);
            SetPropertyValue(NativeControl, DataGrid.RowHeaderWidthProperty, thisAsIRxDataGrid.RowHeaderWidth);
            SetPropertyValue(NativeControl, DataGrid.RowHeightProperty, thisAsIRxDataGrid.RowHeight);
            SetPropertyValue(NativeControl, DataGrid.RowStyleProperty, thisAsIRxDataGrid.RowStyle);
            SetPropertyValue(NativeControl, DataGrid.SelectionModeProperty, thisAsIRxDataGrid.SelectionMode);
            SetPropertyValue(NativeControl, DataGrid.SelectionUnitProperty, thisAsIRxDataGrid.SelectionUnit);
            SetPropertyValue(NativeControl, DataGrid.VerticalGridLinesBrushProperty, thisAsIRxDataGrid.VerticalGridLinesBrush);
            SetPropertyValue(NativeControl, DataGrid.VerticalScrollBarVisibilityProperty, thisAsIRxDataGrid.VerticalScrollBarVisibility);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();
        partial void OnAttachingNewEvents();
        partial void OnDetachingNewEvents();

        protected override void OnAttachNativeEvents()
        {
            OnAttachingNewEvents();


            base.OnAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();


            base.OnDetachNativeEvents();
        }

    }
    public partial class RxDataGrid : RxDataGrid<DataGrid>
    {
        public RxDataGrid()
        {

        }

        public RxDataGrid(Action<DataGrid?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxDataGridExtensions
    {
        public static T AlternatingRowBackground<T>(this T datagrid, Brush alternatingRowBackground) where T : IRxDataGrid
        {
            datagrid.AlternatingRowBackground = new PropertyValue<Brush>(alternatingRowBackground);
            return datagrid;
        }
        public static T AlternatingRowBackground<T>(this T datagrid, Func<Brush> alternatingRowBackgroundFunc) where T : IRxDataGrid
        {
            datagrid.AlternatingRowBackground = new PropertyValue<Brush>(alternatingRowBackgroundFunc);
            return datagrid;
        }
        public static T AreRowDetailsFrozen<T>(this T datagrid, bool areRowDetailsFrozen) where T : IRxDataGrid
        {
            datagrid.AreRowDetailsFrozen = new PropertyValue<bool>(areRowDetailsFrozen);
            return datagrid;
        }
        public static T AreRowDetailsFrozen<T>(this T datagrid, Func<bool> areRowDetailsFrozenFunc) where T : IRxDataGrid
        {
            datagrid.AreRowDetailsFrozen = new PropertyValue<bool>(areRowDetailsFrozenFunc);
            return datagrid;
        }
        public static T AutoGenerateColumns<T>(this T datagrid, bool autoGenerateColumns) where T : IRxDataGrid
        {
            datagrid.AutoGenerateColumns = new PropertyValue<bool>(autoGenerateColumns);
            return datagrid;
        }
        public static T AutoGenerateColumns<T>(this T datagrid, Func<bool> autoGenerateColumnsFunc) where T : IRxDataGrid
        {
            datagrid.AutoGenerateColumns = new PropertyValue<bool>(autoGenerateColumnsFunc);
            return datagrid;
        }
        public static T CanUserAddRows<T>(this T datagrid, bool canUserAddRows) where T : IRxDataGrid
        {
            datagrid.CanUserAddRows = new PropertyValue<bool>(canUserAddRows);
            return datagrid;
        }
        public static T CanUserAddRows<T>(this T datagrid, Func<bool> canUserAddRowsFunc) where T : IRxDataGrid
        {
            datagrid.CanUserAddRows = new PropertyValue<bool>(canUserAddRowsFunc);
            return datagrid;
        }
        public static T CanUserDeleteRows<T>(this T datagrid, bool canUserDeleteRows) where T : IRxDataGrid
        {
            datagrid.CanUserDeleteRows = new PropertyValue<bool>(canUserDeleteRows);
            return datagrid;
        }
        public static T CanUserDeleteRows<T>(this T datagrid, Func<bool> canUserDeleteRowsFunc) where T : IRxDataGrid
        {
            datagrid.CanUserDeleteRows = new PropertyValue<bool>(canUserDeleteRowsFunc);
            return datagrid;
        }
        public static T CanUserReorderColumns<T>(this T datagrid, bool canUserReorderColumns) where T : IRxDataGrid
        {
            datagrid.CanUserReorderColumns = new PropertyValue<bool>(canUserReorderColumns);
            return datagrid;
        }
        public static T CanUserReorderColumns<T>(this T datagrid, Func<bool> canUserReorderColumnsFunc) where T : IRxDataGrid
        {
            datagrid.CanUserReorderColumns = new PropertyValue<bool>(canUserReorderColumnsFunc);
            return datagrid;
        }
        public static T CanUserResizeColumns<T>(this T datagrid, bool canUserResizeColumns) where T : IRxDataGrid
        {
            datagrid.CanUserResizeColumns = new PropertyValue<bool>(canUserResizeColumns);
            return datagrid;
        }
        public static T CanUserResizeColumns<T>(this T datagrid, Func<bool> canUserResizeColumnsFunc) where T : IRxDataGrid
        {
            datagrid.CanUserResizeColumns = new PropertyValue<bool>(canUserResizeColumnsFunc);
            return datagrid;
        }
        public static T CanUserResizeRows<T>(this T datagrid, bool canUserResizeRows) where T : IRxDataGrid
        {
            datagrid.CanUserResizeRows = new PropertyValue<bool>(canUserResizeRows);
            return datagrid;
        }
        public static T CanUserResizeRows<T>(this T datagrid, Func<bool> canUserResizeRowsFunc) where T : IRxDataGrid
        {
            datagrid.CanUserResizeRows = new PropertyValue<bool>(canUserResizeRowsFunc);
            return datagrid;
        }
        public static T CanUserSortColumns<T>(this T datagrid, bool canUserSortColumns) where T : IRxDataGrid
        {
            datagrid.CanUserSortColumns = new PropertyValue<bool>(canUserSortColumns);
            return datagrid;
        }
        public static T CanUserSortColumns<T>(this T datagrid, Func<bool> canUserSortColumnsFunc) where T : IRxDataGrid
        {
            datagrid.CanUserSortColumns = new PropertyValue<bool>(canUserSortColumnsFunc);
            return datagrid;
        }
        public static T CellStyle<T>(this T datagrid, Style cellStyle) where T : IRxDataGrid
        {
            datagrid.CellStyle = new PropertyValue<Style>(cellStyle);
            return datagrid;
        }
        public static T CellStyle<T>(this T datagrid, Func<Style> cellStyleFunc) where T : IRxDataGrid
        {
            datagrid.CellStyle = new PropertyValue<Style>(cellStyleFunc);
            return datagrid;
        }
        public static T ClipboardCopyMode<T>(this T datagrid, DataGridClipboardCopyMode clipboardCopyMode) where T : IRxDataGrid
        {
            datagrid.ClipboardCopyMode = new PropertyValue<DataGridClipboardCopyMode>(clipboardCopyMode);
            return datagrid;
        }
        public static T ClipboardCopyMode<T>(this T datagrid, Func<DataGridClipboardCopyMode> clipboardCopyModeFunc) where T : IRxDataGrid
        {
            datagrid.ClipboardCopyMode = new PropertyValue<DataGridClipboardCopyMode>(clipboardCopyModeFunc);
            return datagrid;
        }
        public static T ColumnHeaderHeight<T>(this T datagrid, double columnHeaderHeight) where T : IRxDataGrid
        {
            datagrid.ColumnHeaderHeight = new PropertyValue<double>(columnHeaderHeight);
            return datagrid;
        }
        public static T ColumnHeaderHeight<T>(this T datagrid, Func<double> columnHeaderHeightFunc) where T : IRxDataGrid
        {
            datagrid.ColumnHeaderHeight = new PropertyValue<double>(columnHeaderHeightFunc);
            return datagrid;
        }
        public static T ColumnHeaderStyle<T>(this T datagrid, Style columnHeaderStyle) where T : IRxDataGrid
        {
            datagrid.ColumnHeaderStyle = new PropertyValue<Style>(columnHeaderStyle);
            return datagrid;
        }
        public static T ColumnHeaderStyle<T>(this T datagrid, Func<Style> columnHeaderStyleFunc) where T : IRxDataGrid
        {
            datagrid.ColumnHeaderStyle = new PropertyValue<Style>(columnHeaderStyleFunc);
            return datagrid;
        }
        public static T ColumnWidth<T>(this T datagrid, DataGridLength columnWidth) where T : IRxDataGrid
        {
            datagrid.ColumnWidth = new PropertyValue<DataGridLength>(columnWidth);
            return datagrid;
        }
        public static T ColumnWidth<T>(this T datagrid, Func<DataGridLength> columnWidthFunc) where T : IRxDataGrid
        {
            datagrid.ColumnWidth = new PropertyValue<DataGridLength>(columnWidthFunc);
            return datagrid;
        }
        public static T CurrentCell<T>(this T datagrid, DataGridCellInfo currentCell) where T : IRxDataGrid
        {
            datagrid.CurrentCell = new PropertyValue<DataGridCellInfo>(currentCell);
            return datagrid;
        }
        public static T CurrentCell<T>(this T datagrid, Func<DataGridCellInfo> currentCellFunc) where T : IRxDataGrid
        {
            datagrid.CurrentCell = new PropertyValue<DataGridCellInfo>(currentCellFunc);
            return datagrid;
        }
        public static T CurrentColumn<T>(this T datagrid, DataGridColumn currentColumn) where T : IRxDataGrid
        {
            datagrid.CurrentColumn = new PropertyValue<DataGridColumn>(currentColumn);
            return datagrid;
        }
        public static T CurrentColumn<T>(this T datagrid, Func<DataGridColumn> currentColumnFunc) where T : IRxDataGrid
        {
            datagrid.CurrentColumn = new PropertyValue<DataGridColumn>(currentColumnFunc);
            return datagrid;
        }
        public static T CurrentItem<T>(this T datagrid, object currentItem) where T : IRxDataGrid
        {
            datagrid.CurrentItem = new PropertyValue<object>(currentItem);
            return datagrid;
        }
        public static T CurrentItem<T>(this T datagrid, Func<object> currentItemFunc) where T : IRxDataGrid
        {
            datagrid.CurrentItem = new PropertyValue<object>(currentItemFunc);
            return datagrid;
        }
        public static T DragIndicatorStyle<T>(this T datagrid, Style dragIndicatorStyle) where T : IRxDataGrid
        {
            datagrid.DragIndicatorStyle = new PropertyValue<Style>(dragIndicatorStyle);
            return datagrid;
        }
        public static T DragIndicatorStyle<T>(this T datagrid, Func<Style> dragIndicatorStyleFunc) where T : IRxDataGrid
        {
            datagrid.DragIndicatorStyle = new PropertyValue<Style>(dragIndicatorStyleFunc);
            return datagrid;
        }
        public static T DropLocationIndicatorStyle<T>(this T datagrid, Style dropLocationIndicatorStyle) where T : IRxDataGrid
        {
            datagrid.DropLocationIndicatorStyle = new PropertyValue<Style>(dropLocationIndicatorStyle);
            return datagrid;
        }
        public static T DropLocationIndicatorStyle<T>(this T datagrid, Func<Style> dropLocationIndicatorStyleFunc) where T : IRxDataGrid
        {
            datagrid.DropLocationIndicatorStyle = new PropertyValue<Style>(dropLocationIndicatorStyleFunc);
            return datagrid;
        }
        public static T EnableColumnVirtualization<T>(this T datagrid, bool enableColumnVirtualization) where T : IRxDataGrid
        {
            datagrid.EnableColumnVirtualization = new PropertyValue<bool>(enableColumnVirtualization);
            return datagrid;
        }
        public static T EnableColumnVirtualization<T>(this T datagrid, Func<bool> enableColumnVirtualizationFunc) where T : IRxDataGrid
        {
            datagrid.EnableColumnVirtualization = new PropertyValue<bool>(enableColumnVirtualizationFunc);
            return datagrid;
        }
        public static T EnableRowVirtualization<T>(this T datagrid, bool enableRowVirtualization) where T : IRxDataGrid
        {
            datagrid.EnableRowVirtualization = new PropertyValue<bool>(enableRowVirtualization);
            return datagrid;
        }
        public static T EnableRowVirtualization<T>(this T datagrid, Func<bool> enableRowVirtualizationFunc) where T : IRxDataGrid
        {
            datagrid.EnableRowVirtualization = new PropertyValue<bool>(enableRowVirtualizationFunc);
            return datagrid;
        }
        public static T FrozenColumnCount<T>(this T datagrid, int frozenColumnCount) where T : IRxDataGrid
        {
            datagrid.FrozenColumnCount = new PropertyValue<int>(frozenColumnCount);
            return datagrid;
        }
        public static T FrozenColumnCount<T>(this T datagrid, Func<int> frozenColumnCountFunc) where T : IRxDataGrid
        {
            datagrid.FrozenColumnCount = new PropertyValue<int>(frozenColumnCountFunc);
            return datagrid;
        }
        public static T GridLinesVisibility<T>(this T datagrid, DataGridGridLinesVisibility gridLinesVisibility) where T : IRxDataGrid
        {
            datagrid.GridLinesVisibility = new PropertyValue<DataGridGridLinesVisibility>(gridLinesVisibility);
            return datagrid;
        }
        public static T GridLinesVisibility<T>(this T datagrid, Func<DataGridGridLinesVisibility> gridLinesVisibilityFunc) where T : IRxDataGrid
        {
            datagrid.GridLinesVisibility = new PropertyValue<DataGridGridLinesVisibility>(gridLinesVisibilityFunc);
            return datagrid;
        }
        public static T HeadersVisibility<T>(this T datagrid, DataGridHeadersVisibility headersVisibility) where T : IRxDataGrid
        {
            datagrid.HeadersVisibility = new PropertyValue<DataGridHeadersVisibility>(headersVisibility);
            return datagrid;
        }
        public static T HeadersVisibility<T>(this T datagrid, Func<DataGridHeadersVisibility> headersVisibilityFunc) where T : IRxDataGrid
        {
            datagrid.HeadersVisibility = new PropertyValue<DataGridHeadersVisibility>(headersVisibilityFunc);
            return datagrid;
        }
        public static T HorizontalGridLinesBrush<T>(this T datagrid, Brush horizontalGridLinesBrush) where T : IRxDataGrid
        {
            datagrid.HorizontalGridLinesBrush = new PropertyValue<Brush>(horizontalGridLinesBrush);
            return datagrid;
        }
        public static T HorizontalGridLinesBrush<T>(this T datagrid, Func<Brush> horizontalGridLinesBrushFunc) where T : IRxDataGrid
        {
            datagrid.HorizontalGridLinesBrush = new PropertyValue<Brush>(horizontalGridLinesBrushFunc);
            return datagrid;
        }
        public static T HorizontalScrollBarVisibility<T>(this T datagrid, ScrollBarVisibility horizontalScrollBarVisibility) where T : IRxDataGrid
        {
            datagrid.HorizontalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(horizontalScrollBarVisibility);
            return datagrid;
        }
        public static T HorizontalScrollBarVisibility<T>(this T datagrid, Func<ScrollBarVisibility> horizontalScrollBarVisibilityFunc) where T : IRxDataGrid
        {
            datagrid.HorizontalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(horizontalScrollBarVisibilityFunc);
            return datagrid;
        }
        public static T IsReadOnly<T>(this T datagrid, bool isReadOnly) where T : IRxDataGrid
        {
            datagrid.IsReadOnly = new PropertyValue<bool>(isReadOnly);
            return datagrid;
        }
        public static T IsReadOnly<T>(this T datagrid, Func<bool> isReadOnlyFunc) where T : IRxDataGrid
        {
            datagrid.IsReadOnly = new PropertyValue<bool>(isReadOnlyFunc);
            return datagrid;
        }
        public static T MaxColumnWidth<T>(this T datagrid, double maxColumnWidth) where T : IRxDataGrid
        {
            datagrid.MaxColumnWidth = new PropertyValue<double>(maxColumnWidth);
            return datagrid;
        }
        public static T MaxColumnWidth<T>(this T datagrid, Func<double> maxColumnWidthFunc) where T : IRxDataGrid
        {
            datagrid.MaxColumnWidth = new PropertyValue<double>(maxColumnWidthFunc);
            return datagrid;
        }
        public static T MinColumnWidth<T>(this T datagrid, double minColumnWidth) where T : IRxDataGrid
        {
            datagrid.MinColumnWidth = new PropertyValue<double>(minColumnWidth);
            return datagrid;
        }
        public static T MinColumnWidth<T>(this T datagrid, Func<double> minColumnWidthFunc) where T : IRxDataGrid
        {
            datagrid.MinColumnWidth = new PropertyValue<double>(minColumnWidthFunc);
            return datagrid;
        }
        public static T MinRowHeight<T>(this T datagrid, double minRowHeight) where T : IRxDataGrid
        {
            datagrid.MinRowHeight = new PropertyValue<double>(minRowHeight);
            return datagrid;
        }
        public static T MinRowHeight<T>(this T datagrid, Func<double> minRowHeightFunc) where T : IRxDataGrid
        {
            datagrid.MinRowHeight = new PropertyValue<double>(minRowHeightFunc);
            return datagrid;
        }
        public static T RowBackground<T>(this T datagrid, Brush rowBackground) where T : IRxDataGrid
        {
            datagrid.RowBackground = new PropertyValue<Brush>(rowBackground);
            return datagrid;
        }
        public static T RowBackground<T>(this T datagrid, Func<Brush> rowBackgroundFunc) where T : IRxDataGrid
        {
            datagrid.RowBackground = new PropertyValue<Brush>(rowBackgroundFunc);
            return datagrid;
        }
        public static T RowDetailsVisibilityMode<T>(this T datagrid, DataGridRowDetailsVisibilityMode rowDetailsVisibilityMode) where T : IRxDataGrid
        {
            datagrid.RowDetailsVisibilityMode = new PropertyValue<DataGridRowDetailsVisibilityMode>(rowDetailsVisibilityMode);
            return datagrid;
        }
        public static T RowDetailsVisibilityMode<T>(this T datagrid, Func<DataGridRowDetailsVisibilityMode> rowDetailsVisibilityModeFunc) where T : IRxDataGrid
        {
            datagrid.RowDetailsVisibilityMode = new PropertyValue<DataGridRowDetailsVisibilityMode>(rowDetailsVisibilityModeFunc);
            return datagrid;
        }
        public static T RowHeaderStyle<T>(this T datagrid, Style rowHeaderStyle) where T : IRxDataGrid
        {
            datagrid.RowHeaderStyle = new PropertyValue<Style>(rowHeaderStyle);
            return datagrid;
        }
        public static T RowHeaderStyle<T>(this T datagrid, Func<Style> rowHeaderStyleFunc) where T : IRxDataGrid
        {
            datagrid.RowHeaderStyle = new PropertyValue<Style>(rowHeaderStyleFunc);
            return datagrid;
        }
        public static T RowHeaderWidth<T>(this T datagrid, double rowHeaderWidth) where T : IRxDataGrid
        {
            datagrid.RowHeaderWidth = new PropertyValue<double>(rowHeaderWidth);
            return datagrid;
        }
        public static T RowHeaderWidth<T>(this T datagrid, Func<double> rowHeaderWidthFunc) where T : IRxDataGrid
        {
            datagrid.RowHeaderWidth = new PropertyValue<double>(rowHeaderWidthFunc);
            return datagrid;
        }
        public static T RowHeight<T>(this T datagrid, double rowHeight) where T : IRxDataGrid
        {
            datagrid.RowHeight = new PropertyValue<double>(rowHeight);
            return datagrid;
        }
        public static T RowHeight<T>(this T datagrid, Func<double> rowHeightFunc) where T : IRxDataGrid
        {
            datagrid.RowHeight = new PropertyValue<double>(rowHeightFunc);
            return datagrid;
        }
        public static T RowStyle<T>(this T datagrid, Style rowStyle) where T : IRxDataGrid
        {
            datagrid.RowStyle = new PropertyValue<Style>(rowStyle);
            return datagrid;
        }
        public static T RowStyle<T>(this T datagrid, Func<Style> rowStyleFunc) where T : IRxDataGrid
        {
            datagrid.RowStyle = new PropertyValue<Style>(rowStyleFunc);
            return datagrid;
        }
        public static T SelectionMode<T>(this T datagrid, DataGridSelectionMode selectionMode) where T : IRxDataGrid
        {
            datagrid.SelectionMode = new PropertyValue<DataGridSelectionMode>(selectionMode);
            return datagrid;
        }
        public static T SelectionMode<T>(this T datagrid, Func<DataGridSelectionMode> selectionModeFunc) where T : IRxDataGrid
        {
            datagrid.SelectionMode = new PropertyValue<DataGridSelectionMode>(selectionModeFunc);
            return datagrid;
        }
        public static T SelectionUnit<T>(this T datagrid, DataGridSelectionUnit selectionUnit) where T : IRxDataGrid
        {
            datagrid.SelectionUnit = new PropertyValue<DataGridSelectionUnit>(selectionUnit);
            return datagrid;
        }
        public static T SelectionUnit<T>(this T datagrid, Func<DataGridSelectionUnit> selectionUnitFunc) where T : IRxDataGrid
        {
            datagrid.SelectionUnit = new PropertyValue<DataGridSelectionUnit>(selectionUnitFunc);
            return datagrid;
        }
        public static T VerticalGridLinesBrush<T>(this T datagrid, Brush verticalGridLinesBrush) where T : IRxDataGrid
        {
            datagrid.VerticalGridLinesBrush = new PropertyValue<Brush>(verticalGridLinesBrush);
            return datagrid;
        }
        public static T VerticalGridLinesBrush<T>(this T datagrid, Func<Brush> verticalGridLinesBrushFunc) where T : IRxDataGrid
        {
            datagrid.VerticalGridLinesBrush = new PropertyValue<Brush>(verticalGridLinesBrushFunc);
            return datagrid;
        }
        public static T VerticalScrollBarVisibility<T>(this T datagrid, ScrollBarVisibility verticalScrollBarVisibility) where T : IRxDataGrid
        {
            datagrid.VerticalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(verticalScrollBarVisibility);
            return datagrid;
        }
        public static T VerticalScrollBarVisibility<T>(this T datagrid, Func<ScrollBarVisibility> verticalScrollBarVisibilityFunc) where T : IRxDataGrid
        {
            datagrid.VerticalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(verticalScrollBarVisibilityFunc);
            return datagrid;
        }
    }
}
