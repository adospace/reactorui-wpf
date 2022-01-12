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
            
            int iRow = 0;
            if (thisAsIRxGrid.Rows != null && thisAsIRxGrid.Rows.Value != null)
            {
                foreach (var row in thisAsIRxGrid.Rows.Value)
                {
                    if (iRow < NativeControl.RowDefinitions.Count)
                    {
                        if (!(row.Height.IsAbsolute && NativeControl.RowDefinitions[iRow].Height.IsAbsolute)
                            && (row.Height != NativeControl.RowDefinitions[iRow].Height))
                        {
                            NativeControl.RowDefinitions[iRow].Height = row.Height;
                        }
                        if (row.MinHeight != NativeControl.RowDefinitions[iRow].MinHeight)
                        {
                            NativeControl.RowDefinitions[iRow].MinHeight = row.MinHeight;
                        }
                    }
                    else
                    {
                        NativeControl.RowDefinitions.Add(row);
                    }

                    iRow++;
                }
            }
            while (iRow < NativeControl.RowDefinitions.Count)
            {
                NativeControl.RowDefinitions.RemoveAt(iRow);
            }

            int iColumn = 0;
            if (thisAsIRxGrid.Columns != null && thisAsIRxGrid.Columns.Value != null)
            {
                foreach (var column in thisAsIRxGrid.Columns.Value)
                {
                    if (iColumn < NativeControl.ColumnDefinitions.Count)
                    {
                        if (!(column.Width.IsAbsolute && NativeControl.ColumnDefinitions[iColumn].Width.IsAbsolute)
                            && (column.Width != NativeControl.ColumnDefinitions[iColumn].Width))
                        {
                            NativeControl.ColumnDefinitions[iColumn].Width = column.Width;
                        }
                        if (column.MinWidth != NativeControl.ColumnDefinitions[iColumn].MinWidth)
                        {
                            NativeControl.ColumnDefinitions[iColumn].MinWidth = column.MinWidth;
                        }
                    }
                    else
                    {
                        NativeControl.ColumnDefinitions.Add(column);
                    }

                    iColumn++;
                }
            }
            while (iColumn < NativeControl.ColumnDefinitions.Count)
            {
                NativeControl.ColumnDefinitions.RemoveAt(iColumn);
            }

            //NativeControl.ColumnDefinitions.Clear();
            //if (thisAsIRxGrid.Columns != null && thisAsIRxGrid.Columns.Value != null)
            //{
            //    foreach (var column in thisAsIRxGrid.Columns.Value)
            //    {
            //        NativeControl.ColumnDefinitions.Add(column);
            //    }
            //}
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

        public static T Rows<T>(this T grid, int rowCount, double rowHeight) where T : IRxGrid
        {
            grid.Rows = new PropertyValue<IList<RowDefinition>>(Enumerable.Range(1, rowCount).Select(_ => new RowDefinition() { Height = new GridLength(rowHeight) }).ToList());
            return grid;
        }

        public static T Rows<T>(this T grid, int rowCount, GridLength rowHeight) where T : IRxGrid
        {
            grid.Rows = new PropertyValue<IList<RowDefinition>>(Enumerable.Range(1, rowCount).Select(_ => new RowDefinition() { Height = rowHeight }).ToList());
            return grid;
        }

        public static T Columns<T>(this T grid, string columns) where T : IRxGrid
        {
            grid.Columns = new PropertyValue<IList<ColumnDefinition>>(RxGridUtils.ConvertStringToColumnDefinitions(columns));
            return grid;
        }

        public static T Columns<T>(this T grid, int columnCount, double columnWidth) where T : IRxGrid
        {
            grid.Columns = new PropertyValue<IList<ColumnDefinition>>(Enumerable.Range(1, columnCount).Select(_ => new ColumnDefinition() { Width = new GridLength(columnWidth) }).ToList());
            return grid;
        }

        public static T Columns<T>(this T grid, int columnCount, GridLength columnWidth) where T : IRxGrid
        {
            grid.Columns = new PropertyValue<IList<ColumnDefinition>>(Enumerable.Range(1, columnCount).Select(_ => new ColumnDefinition() { Width = columnWidth }).ToList());
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

        public static T ColumnDefinition<T>(this T grid, ColumnDefinition definition) where T : IRxGrid
        {
            grid.Columns ??= new PropertyValue<IList<ColumnDefinition>>(new List<ColumnDefinition>());
            grid.Columns.Value!.Add(definition);
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

        public static T RowDefinition<T>(this T grid, RowDefinition definition) where T : IRxGrid
        {
            grid.Rows ??= new PropertyValue<IList<RowDefinition>>(new List<RowDefinition>());
            grid.Rows.Value!.Add(definition);
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
