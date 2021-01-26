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
    public partial interface IRxDataGridTextColumn : IRxDataGridBoundColumn
    {
        PropertyValue<FontFamily>? FontFamily { get; set; }
        PropertyValue<double>? FontSize { get; set; }
        PropertyValue<FontStyle>? FontStyle { get; set; }
        PropertyValue<FontWeight>? FontWeight { get; set; }
        PropertyValue<Brush>? Foreground { get; set; }

    }

    public partial class RxDataGridTextColumn<T> : RxDataGridBoundColumn<T>, IRxDataGridTextColumn where T : DataGridTextColumn, new()
    {
        public RxDataGridTextColumn()
        {

        }

        public RxDataGridTextColumn(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<FontFamily>? IRxDataGridTextColumn.FontFamily { get; set; }
        PropertyValue<double>? IRxDataGridTextColumn.FontSize { get; set; }
        PropertyValue<FontStyle>? IRxDataGridTextColumn.FontStyle { get; set; }
        PropertyValue<FontWeight>? IRxDataGridTextColumn.FontWeight { get; set; }
        PropertyValue<Brush>? IRxDataGridTextColumn.Foreground { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxDataGridTextColumn = (IRxDataGridTextColumn)this;
            SetPropertyValue(NativeControl, DataGridTextColumn.FontFamilyProperty, thisAsIRxDataGridTextColumn.FontFamily);
            SetPropertyValue(NativeControl, DataGridTextColumn.FontSizeProperty, thisAsIRxDataGridTextColumn.FontSize);
            SetPropertyValue(NativeControl, DataGridTextColumn.FontStyleProperty, thisAsIRxDataGridTextColumn.FontStyle);
            SetPropertyValue(NativeControl, DataGridTextColumn.FontWeightProperty, thisAsIRxDataGridTextColumn.FontWeight);
            SetPropertyValue(NativeControl, DataGridTextColumn.ForegroundProperty, thisAsIRxDataGridTextColumn.Foreground);

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
    public partial class RxDataGridTextColumn : RxDataGridTextColumn<DataGridTextColumn>
    {
        public RxDataGridTextColumn()
        {

        }

        public RxDataGridTextColumn(Action<DataGridTextColumn?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxDataGridTextColumnExtensions
    {
        public static T FontFamily<T>(this T datagridtextcolumn, FontFamily fontFamily) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return datagridtextcolumn;
        }
        public static T FontFamily<T>(this T datagridtextcolumn, Func<FontFamily> fontFamilyFunc) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontFamily = new PropertyValue<FontFamily>(fontFamilyFunc);
            return datagridtextcolumn;
        }
        public static T FontSize<T>(this T datagridtextcolumn, double fontSize) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontSize = new PropertyValue<double>(fontSize);
            return datagridtextcolumn;
        }
        public static T FontSize<T>(this T datagridtextcolumn, Func<double> fontSizeFunc) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontSize = new PropertyValue<double>(fontSizeFunc);
            return datagridtextcolumn;
        }
        public static T FontStyle<T>(this T datagridtextcolumn, FontStyle fontStyle) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontStyle = new PropertyValue<FontStyle>(fontStyle);
            return datagridtextcolumn;
        }
        public static T FontStyle<T>(this T datagridtextcolumn, Func<FontStyle> fontStyleFunc) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontStyle = new PropertyValue<FontStyle>(fontStyleFunc);
            return datagridtextcolumn;
        }
        public static T FontWeight<T>(this T datagridtextcolumn, FontWeight fontWeight) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontWeight = new PropertyValue<FontWeight>(fontWeight);
            return datagridtextcolumn;
        }
        public static T FontWeight<T>(this T datagridtextcolumn, Func<FontWeight> fontWeightFunc) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.FontWeight = new PropertyValue<FontWeight>(fontWeightFunc);
            return datagridtextcolumn;
        }
        public static T Foreground<T>(this T datagridtextcolumn, Brush foreground) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.Foreground = new PropertyValue<Brush>(foreground);
            return datagridtextcolumn;
        }
        public static T Foreground<T>(this T datagridtextcolumn, Func<Brush> foregroundFunc) where T : IRxDataGridTextColumn
        {
            datagridtextcolumn.Foreground = new PropertyValue<Brush>(foregroundFunc);
            return datagridtextcolumn;
        }
    }
}
