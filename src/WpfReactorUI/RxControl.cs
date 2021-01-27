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
    public partial interface IRxControl : IRxFrameworkElement
    {
        PropertyValue<Brush>? Background { get; set; }
        PropertyValue<Brush>? BorderBrush { get; set; }
        PropertyValue<Thickness>? BorderThickness { get; set; }
        PropertyValue<FontFamily>? FontFamily { get; set; }
        PropertyValue<double>? FontSize { get; set; }
        PropertyValue<FontStretch>? FontStretch { get; set; }
        PropertyValue<FontStyle>? FontStyle { get; set; }
        PropertyValue<FontWeight>? FontWeight { get; set; }
        PropertyValue<Brush>? Foreground { get; set; }
        PropertyValue<HorizontalAlignment>? HorizontalContentAlignment { get; set; }
        PropertyValue<bool>? IsTabStop { get; set; }
        PropertyValue<Thickness>? Padding { get; set; }
        PropertyValue<int>? TabIndex { get; set; }
        PropertyValue<VerticalAlignment>? VerticalContentAlignment { get; set; }

        Action? MouseDoubleClickAction { get; set; }
        Action<object?, MouseButtonEventArgs>? MouseDoubleClickActionWithArgs { get; set; }
        Action? PreviewMouseDoubleClickAction { get; set; }
        Action<object?, MouseButtonEventArgs>? PreviewMouseDoubleClickActionWithArgs { get; set; }
    }

    public partial class RxControl<T> : RxFrameworkElement<T>, IRxControl where T : Control, new()
    {
        public RxControl()
        {

        }

        public RxControl(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxControl.Background { get; set; }
        PropertyValue<Brush>? IRxControl.BorderBrush { get; set; }
        PropertyValue<Thickness>? IRxControl.BorderThickness { get; set; }
        PropertyValue<FontFamily>? IRxControl.FontFamily { get; set; }
        PropertyValue<double>? IRxControl.FontSize { get; set; }
        PropertyValue<FontStretch>? IRxControl.FontStretch { get; set; }
        PropertyValue<FontStyle>? IRxControl.FontStyle { get; set; }
        PropertyValue<FontWeight>? IRxControl.FontWeight { get; set; }
        PropertyValue<Brush>? IRxControl.Foreground { get; set; }
        PropertyValue<HorizontalAlignment>? IRxControl.HorizontalContentAlignment { get; set; }
        PropertyValue<bool>? IRxControl.IsTabStop { get; set; }
        PropertyValue<Thickness>? IRxControl.Padding { get; set; }
        PropertyValue<int>? IRxControl.TabIndex { get; set; }
        PropertyValue<VerticalAlignment>? IRxControl.VerticalContentAlignment { get; set; }

        Action? IRxControl.MouseDoubleClickAction { get; set; }
        Action<object?, MouseButtonEventArgs>? IRxControl.MouseDoubleClickActionWithArgs { get; set; }
        Action? IRxControl.PreviewMouseDoubleClickAction { get; set; }
        Action<object?, MouseButtonEventArgs>? IRxControl.PreviewMouseDoubleClickActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxControl = (IRxControl)this;
            SetPropertyValue(NativeControl, Control.BackgroundProperty, thisAsIRxControl.Background);
            SetPropertyValue(NativeControl, Control.BorderBrushProperty, thisAsIRxControl.BorderBrush);
            SetPropertyValue(NativeControl, Control.BorderThicknessProperty, thisAsIRxControl.BorderThickness);
            SetPropertyValue(NativeControl, Control.FontFamilyProperty, thisAsIRxControl.FontFamily);
            SetPropertyValue(NativeControl, Control.FontSizeProperty, thisAsIRxControl.FontSize);
            SetPropertyValue(NativeControl, Control.FontStretchProperty, thisAsIRxControl.FontStretch);
            SetPropertyValue(NativeControl, Control.FontStyleProperty, thisAsIRxControl.FontStyle);
            SetPropertyValue(NativeControl, Control.FontWeightProperty, thisAsIRxControl.FontWeight);
            SetPropertyValue(NativeControl, Control.ForegroundProperty, thisAsIRxControl.Foreground);
            SetPropertyValue(NativeControl, Control.HorizontalContentAlignmentProperty, thisAsIRxControl.HorizontalContentAlignment);
            SetPropertyValue(NativeControl, Control.IsTabStopProperty, thisAsIRxControl.IsTabStop);
            SetPropertyValue(NativeControl, Control.PaddingProperty, thisAsIRxControl.Padding);
            SetPropertyValue(NativeControl, Control.TabIndexProperty, thisAsIRxControl.TabIndex);
            SetPropertyValue(NativeControl, Control.VerticalContentAlignmentProperty, thisAsIRxControl.VerticalContentAlignment);

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

            var thisAsIRxControl = (IRxControl)this;
            if (thisAsIRxControl.MouseDoubleClickAction != null || thisAsIRxControl.MouseDoubleClickActionWithArgs != null)
            {
                NativeControl.MouseDoubleClick += NativeControl_MouseDoubleClick;
            }
            if (thisAsIRxControl.PreviewMouseDoubleClickAction != null || thisAsIRxControl.PreviewMouseDoubleClickActionWithArgs != null)
            {
                NativeControl.PreviewMouseDoubleClick += NativeControl_PreviewMouseDoubleClick;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_MouseDoubleClick(object? sender, MouseButtonEventArgs e)
        {
            var thisAsIRxControl = (IRxControl)this;
            thisAsIRxControl.MouseDoubleClickAction?.Invoke();
            thisAsIRxControl.MouseDoubleClickActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_PreviewMouseDoubleClick(object? sender, MouseButtonEventArgs e)
        {
            var thisAsIRxControl = (IRxControl)this;
            thisAsIRxControl.PreviewMouseDoubleClickAction?.Invoke();
            thisAsIRxControl.PreviewMouseDoubleClickActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.MouseDoubleClick -= NativeControl_MouseDoubleClick;
                NativeControl.PreviewMouseDoubleClick -= NativeControl_PreviewMouseDoubleClick;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxControl : RxControl<Control>
    {
        public RxControl()
        {

        }

        public RxControl(Action<Control?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxControlExtensions
    {
        public static T Background<T>(this T control, Brush background) where T : IRxControl
        {
            control.Background = new PropertyValue<Brush>(background);
            return control;
        }
        public static T Background<T>(this T control, Func<Brush> backgroundFunc) where T : IRxControl
        {
            control.Background = new PropertyValue<Brush>(backgroundFunc);
            return control;
        }
        public static T BorderBrush<T>(this T control, Brush borderBrush) where T : IRxControl
        {
            control.BorderBrush = new PropertyValue<Brush>(borderBrush);
            return control;
        }
        public static T BorderBrush<T>(this T control, Func<Brush> borderBrushFunc) where T : IRxControl
        {
            control.BorderBrush = new PropertyValue<Brush>(borderBrushFunc);
            return control;
        }
        public static T BorderThickness<T>(this T control, Thickness borderThickness) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(borderThickness);
            return control;
        }
        public static T BorderThickness<T>(this T control, Func<Thickness> borderThicknessFunc) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(borderThicknessFunc);
            return control;
        }
        public static T BorderThickness<T>(this T control, double leftRight, double topBottom) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return control;
        }
        public static T BorderThickness<T>(this T control, double uniformSize) where T : IRxControl
        {
            control.BorderThickness = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return control;
        }
        public static T FontFamily<T>(this T control, FontFamily fontFamily) where T : IRxControl
        {
            control.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return control;
        }
        public static T FontFamily<T>(this T control, Func<FontFamily> fontFamilyFunc) where T : IRxControl
        {
            control.FontFamily = new PropertyValue<FontFamily>(fontFamilyFunc);
            return control;
        }
        public static T FontSize<T>(this T control, double fontSize) where T : IRxControl
        {
            control.FontSize = new PropertyValue<double>(fontSize);
            return control;
        }
        public static T FontSize<T>(this T control, Func<double> fontSizeFunc) where T : IRxControl
        {
            control.FontSize = new PropertyValue<double>(fontSizeFunc);
            return control;
        }
        public static T FontStretch<T>(this T control, FontStretch fontStretch) where T : IRxControl
        {
            control.FontStretch = new PropertyValue<FontStretch>(fontStretch);
            return control;
        }
        public static T FontStretch<T>(this T control, Func<FontStretch> fontStretchFunc) where T : IRxControl
        {
            control.FontStretch = new PropertyValue<FontStretch>(fontStretchFunc);
            return control;
        }
        public static T FontStyle<T>(this T control, FontStyle fontStyle) where T : IRxControl
        {
            control.FontStyle = new PropertyValue<FontStyle>(fontStyle);
            return control;
        }
        public static T FontStyle<T>(this T control, Func<FontStyle> fontStyleFunc) where T : IRxControl
        {
            control.FontStyle = new PropertyValue<FontStyle>(fontStyleFunc);
            return control;
        }
        public static T FontWeight<T>(this T control, FontWeight fontWeight) where T : IRxControl
        {
            control.FontWeight = new PropertyValue<FontWeight>(fontWeight);
            return control;
        }
        public static T FontWeight<T>(this T control, Func<FontWeight> fontWeightFunc) where T : IRxControl
        {
            control.FontWeight = new PropertyValue<FontWeight>(fontWeightFunc);
            return control;
        }
        public static T Foreground<T>(this T control, Brush foreground) where T : IRxControl
        {
            control.Foreground = new PropertyValue<Brush>(foreground);
            return control;
        }
        public static T Foreground<T>(this T control, Func<Brush> foregroundFunc) where T : IRxControl
        {
            control.Foreground = new PropertyValue<Brush>(foregroundFunc);
            return control;
        }
        public static T HorizontalContentAlignment<T>(this T control, HorizontalAlignment horizontalContentAlignment) where T : IRxControl
        {
            control.HorizontalContentAlignment = new PropertyValue<HorizontalAlignment>(horizontalContentAlignment);
            return control;
        }
        public static T HorizontalContentAlignment<T>(this T control, Func<HorizontalAlignment> horizontalContentAlignmentFunc) where T : IRxControl
        {
            control.HorizontalContentAlignment = new PropertyValue<HorizontalAlignment>(horizontalContentAlignmentFunc);
            return control;
        }
        public static T IsTabStop<T>(this T control, bool isTabStop) where T : IRxControl
        {
            control.IsTabStop = new PropertyValue<bool>(isTabStop);
            return control;
        }
        public static T IsTabStop<T>(this T control, Func<bool> isTabStopFunc) where T : IRxControl
        {
            control.IsTabStop = new PropertyValue<bool>(isTabStopFunc);
            return control;
        }
        public static T Padding<T>(this T control, Thickness padding) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(padding);
            return control;
        }
        public static T Padding<T>(this T control, Func<Thickness> paddingFunc) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(paddingFunc);
            return control;
        }
        public static T Padding<T>(this T control, double leftRight, double topBottom) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return control;
        }
        public static T Padding<T>(this T control, double uniformSize) where T : IRxControl
        {
            control.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return control;
        }
        public static T TabIndex<T>(this T control, int tabIndex) where T : IRxControl
        {
            control.TabIndex = new PropertyValue<int>(tabIndex);
            return control;
        }
        public static T TabIndex<T>(this T control, Func<int> tabIndexFunc) where T : IRxControl
        {
            control.TabIndex = new PropertyValue<int>(tabIndexFunc);
            return control;
        }
        public static T VerticalContentAlignment<T>(this T control, VerticalAlignment verticalContentAlignment) where T : IRxControl
        {
            control.VerticalContentAlignment = new PropertyValue<VerticalAlignment>(verticalContentAlignment);
            return control;
        }
        public static T VerticalContentAlignment<T>(this T control, Func<VerticalAlignment> verticalContentAlignmentFunc) where T : IRxControl
        {
            control.VerticalContentAlignment = new PropertyValue<VerticalAlignment>(verticalContentAlignmentFunc);
            return control;
        }
        public static T OnMouseDoubleClick<T>(this T control, Action mousedoubleclickAction) where T : IRxControl
        {
            control.MouseDoubleClickAction = mousedoubleclickAction;
            return control;
        }

        public static T OnMouseDoubleClick<T>(this T control, Action<object?, MouseButtonEventArgs> mousedoubleclickActionWithArgs) where T : IRxControl
        {
            control.MouseDoubleClickActionWithArgs = mousedoubleclickActionWithArgs;
            return control;
        }
        public static T OnPreviewMouseDoubleClick<T>(this T control, Action previewmousedoubleclickAction) where T : IRxControl
        {
            control.PreviewMouseDoubleClickAction = previewmousedoubleclickAction;
            return control;
        }

        public static T OnPreviewMouseDoubleClick<T>(this T control, Action<object?, MouseButtonEventArgs> previewmousedoubleclickActionWithArgs) where T : IRxControl
        {
            control.PreviewMouseDoubleClickActionWithArgs = previewmousedoubleclickActionWithArgs;
            return control;
        }
    }
}
