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
using System.Linq;
using System.Globalization;

namespace WpfReactorUI
{
    public partial interface IRxGrid : IRxPanel
    {
        PropertyValue<IList<ColumnDefinition>>? Columns { get; set; }

        PropertyValue<IList<RowDefinition>>? Rows { get; set; }
    }

    public partial class RxGrid<T> : RxPanel<T>, IRxGrid where T : Grid, new()
    {
        public RxGrid(string rows, string columns)
        {
            ((IRxGrid)this).Rows = new PropertyValue<IList<RowDefinition>>(RxGridUtils.ConvertStringToRowDefinitions(rows));
            ((IRxGrid)this).Columns = new PropertyValue<IList<ColumnDefinition>>(RxGridUtils.ConvertStringToColumnDefinitions(columns));
        }

        public RxGrid(IEnumerable<RowDefinition> rows, IEnumerable<ColumnDefinition> columns)
        {
            var thisAsIRxGrid = (IRxGrid)this;
            thisAsIRxGrid.Rows = new PropertyValue<IList<RowDefinition>>(rows.ToList());
            thisAsIRxGrid.Columns = new PropertyValue<IList<ColumnDefinition>>(columns.ToList());
        }


        PropertyValue<IList<ColumnDefinition>>? IRxGrid.Columns { get; set; }
        PropertyValue<IList<RowDefinition>>? IRxGrid.Rows { get; set; }

        partial void OnBeginUpdate()
        {
            var thisAsIRxGrid = (IRxGrid)this;
            
            //TODO: check if rows/columns changed before replace them
            NativeControl.RowDefinitions.Clear();
            if (thisAsIRxGrid.Rows != null && thisAsIRxGrid.Rows.Value != null)
            {
                foreach (var row in thisAsIRxGrid.Rows.Value)
                {
                    NativeControl.RowDefinitions.Add(row);
                }
            }

            NativeControl.ColumnDefinitions.Clear();
            if (thisAsIRxGrid.Columns != null && thisAsIRxGrid.Columns.Value != null)
            {
                foreach (var column in thisAsIRxGrid.Columns.Value)
                {
                    NativeControl.ColumnDefinitions.Add(column);
                }
            }
        }
    }

    public partial class RxGrid : RxGrid<Grid>
    {
        public RxGrid(string rows, string columns)
            : base(rows, columns)
        { 
        }

        public RxGrid(IEnumerable<RowDefinition> rows, IEnumerable<ColumnDefinition> columns)
            : base(rows, columns)
        { 
        }

    }


    public static partial class RxGridExtensions
    {
        public static T Rows<T>(this T grid, string rows) where T : IRxGrid
        {
            grid.Rows = new PropertyValue<IList<RowDefinition>>(RxGridUtils.ConvertStringToRowDefinitions(rows));
            return grid;
        }

        public static T Columns<T>(this T grid, string columns) where T : IRxGrid
        {
            grid.Columns = new PropertyValue<IList<ColumnDefinition>>(RxGridUtils.ConvertStringToColumnDefinitions(columns));
            return grid;
        }

        public static T ColumnDefinition<T>(this T grid) where T : IRxGrid
        {
            grid.Columns ??= new PropertyValue<IList<ColumnDefinition>>(new List<ColumnDefinition>());
            grid.Columns.Value!.Add(new ColumnDefinition());
            return grid;
        }

        public static T ColumnDefinition<T>(this T grid, double width) where T : IRxGrid
        {
            grid.Columns ??= new PropertyValue<IList<ColumnDefinition>>(new List<ColumnDefinition>());
            grid.Columns.Value!.Add(new ColumnDefinition() { Width = new GridLength(width) });
            return grid;
        }

        public static T ColumnDefinitionAuto<T>(this T grid) where T : IRxGrid
        {
            grid.Columns ??= new PropertyValue<IList<ColumnDefinition>>(new List<ColumnDefinition>());
            grid.Columns.Value!.Add(new ColumnDefinition() { Width = GridLength.Auto });
            return grid;
        }

        public static T ColumnDefinitionStar<T>(this T grid, double starValue) where T : IRxGrid
        {
            grid.Columns ??= new PropertyValue<IList<ColumnDefinition>>(new List<ColumnDefinition>());
            grid.Columns.Value!.Add(new ColumnDefinition() { Width = new GridLength(starValue, GridUnitType.Star) });
            return grid;
        }

        public static T ColumnDefinition<T>(this T grid, GridLength width) where T : IRxGrid
        {
            grid.Columns ??= new PropertyValue<IList<ColumnDefinition>>(new List<ColumnDefinition>());
            grid.Columns.Value!.Add(new ColumnDefinition() { Width = width });
            return grid;
        }

        public static T RowDefinition<T>(this T grid) where T : IRxGrid
        {
            grid.Rows ??= new PropertyValue<IList<RowDefinition>>(new List<RowDefinition>());
            grid.Rows.Value!.Add(new RowDefinition());
            return grid;
        }

        public static T RowDefinition<T>(this T grid, double height) where T : IRxGrid
        {
            grid.Rows ??= new PropertyValue<IList<RowDefinition>>(new List<RowDefinition>());
            grid.Rows.Value!.Add(new RowDefinition() { Height = new GridLength(height) });
            return grid;
        }

        public static T RowDefinitionAuto<T>(this T grid) where T : IRxGrid
        {
            grid.Rows ??= new PropertyValue<IList<RowDefinition>>(new List<RowDefinition>());
            grid.Rows.Value!.Add(new RowDefinition() { Height = GridLength.Auto });
            return grid;
        }

        public static T RowDefinitionStar<T>(this T grid, double starValue) where T : IRxGrid
        {
            grid.Rows ??= new PropertyValue<IList<RowDefinition>>(new List<RowDefinition>());
            grid.Rows.Value!.Add(new RowDefinition() { Height = new GridLength(starValue, GridUnitType.Star) });
            return grid;
        }

        public static T RowDefinition<T>(this T grid, GridLength width) where T : IRxGrid
        {
            grid.Rows ??= new PropertyValue<IList<RowDefinition>>(new List<RowDefinition>());
            grid.Rows.Value!.Add(new RowDefinition() { Height = width });
            return grid;
        }

        public static T GridRow<T>(this T element, int rowIndex) where T : VisualNodeWithAttachedProperties
        {
            element.SetAttachedProperty(Grid.RowProperty, rowIndex);
            return element;            
        }

        public static T GridRowSpan<T>(this T element, int rowSpan) where T : VisualNodeWithAttachedProperties
        {
            element.SetAttachedProperty(Grid.RowSpanProperty, rowSpan);
            return element;
        }

        public static T GridColumn<T>(this T element, int columnIndex) where T : VisualNodeWithAttachedProperties
        {
            element.SetAttachedProperty(Grid.ColumnProperty, columnIndex);
            return element;
        }

        public static T GridColumnSpan<T>(this T element, int columnSpan) where T : VisualNodeWithAttachedProperties
        {
            element.SetAttachedProperty(Grid.ColumnSpanProperty, columnSpan);
            return element;
        }
    }

    internal static class RxGridUtils
    { 
        public static GridLength ConvertStringToGridLength(string stringValue)
        {
            stringValue = stringValue.Trim();

            if (stringValue.Equals("Auto", StringComparison.OrdinalIgnoreCase))
            {
                return GridLength.Auto;
            }

            if (stringValue.Equals("*", StringComparison.OrdinalIgnoreCase))
            {
                return new GridLength(1.0, GridUnitType.Star);
            }

            if (stringValue.EndsWith("*"))
            {
                if (!double.TryParse(stringValue[0..^1], NumberStyles.Any, CultureInfo.InvariantCulture, out var starValue))
                {
                    throw new InvalidOperationException();
                }

                return new GridLength(starValue, GridUnitType.Star);
            }

            if (!double.TryParse(stringValue, NumberStyles.Any, CultureInfo.InvariantCulture, out var pixels))
            {
                throw new InvalidOperationException();
            }

            return new GridLength(pixels, GridUnitType.Pixel);
        }

        public static IEnumerable<GridLength> ConvertStringToGridLenghts(string stringValue)
        {
            return stringValue.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(_ => ConvertStringToGridLength(_));
        }

        public static IList<RowDefinition> ConvertStringToRowDefinitions(string stringValue)
        {
            var rowDefinitions = new List<RowDefinition>();
            foreach (var rowDefinition in ConvertStringToGridLenghts(stringValue)
                .Select(_ => new RowDefinition() { Height = _ }))
            {
                rowDefinitions.Add(rowDefinition);
            }

            return rowDefinitions;
        }

        public static IList<ColumnDefinition> ConvertStringToColumnDefinitions(string stringValue)
        {
            var columnDefinitions = new List<ColumnDefinition>();
            foreach (var columnDefinition in ConvertStringToGridLenghts(stringValue)
                .Select(_ => new ColumnDefinition() { Width = _ }))
            {
                columnDefinitions.Add(columnDefinition);
            }

            return columnDefinitions;
        }
    }

}
