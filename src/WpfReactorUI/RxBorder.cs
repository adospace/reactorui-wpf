using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
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
using System.Windows.Shapes;

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxBorder : IRxDecorator
    {
        PropertyValue<Brush>? Background { get; set; }
        PropertyValue<Brush>? BorderBrush { get; set; }
        PropertyValue<Thickness>? BorderThickness { get; set; }
        PropertyValue<CornerRadius>? CornerRadius { get; set; }
        PropertyValue<Thickness>? Padding { get; set; }

    }
    public partial class RxBorder<T> : RxDecorator<T>, IRxBorder where T : Border, new()
    {
        public RxBorder()
        {

        }

        public RxBorder(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxBorder.Background { get; set; }
        PropertyValue<Brush>? IRxBorder.BorderBrush { get; set; }
        PropertyValue<Thickness>? IRxBorder.BorderThickness { get; set; }
        PropertyValue<CornerRadius>? IRxBorder.CornerRadius { get; set; }
        PropertyValue<Thickness>? IRxBorder.Padding { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxBorder = (IRxBorder)this;
            SetPropertyValue(NativeControl, Border.BackgroundProperty, thisAsIRxBorder.Background);
            SetPropertyValue(NativeControl, Border.BorderBrushProperty, thisAsIRxBorder.BorderBrush);
            SetPropertyValue(NativeControl, Border.BorderThicknessProperty, thisAsIRxBorder.BorderThickness);
            SetPropertyValue(NativeControl, Border.CornerRadiusProperty, thisAsIRxBorder.CornerRadius);
            SetPropertyValue(NativeControl, Border.PaddingProperty, thisAsIRxBorder.Padding);

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
    public partial class RxBorder : RxBorder<Border>
    {
        public RxBorder()
        {

        }

        public RxBorder(Action<Border?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxBorderExtensions
    {
        public static T Background<T>(this T border, Brush background) where T : IRxBorder
        {
            border.Background = new PropertyValue<Brush>(background);
            return border;
        }
        public static T Background<T>(this T border, Func<Brush> backgroundFunc) where T : IRxBorder
        {
            border.Background = new PropertyValue<Brush>(backgroundFunc);
            return border;
        }
        public static T Background<T>(this T border, string backgroundResourceKey) where T : IRxBorder
        {
            border.ResourceReferences[Border.BackgroundProperty] = backgroundResourceKey;
            return border;
        }
        public static T BorderBrush<T>(this T border, Brush borderBrush) where T : IRxBorder
        {
            border.BorderBrush = new PropertyValue<Brush>(borderBrush);
            return border;
        }
        public static T BorderBrush<T>(this T border, Func<Brush> borderBrushFunc) where T : IRxBorder
        {
            border.BorderBrush = new PropertyValue<Brush>(borderBrushFunc);
            return border;
        }
        public static T BorderBrush<T>(this T border, string borderbrushResourceKey) where T : IRxBorder
        {
            border.ResourceReferences[Border.BorderBrushProperty] = borderbrushResourceKey;
            return border;
        }
        public static T BorderThickness<T>(this T border, Thickness borderThickness) where T : IRxBorder
        {
            border.BorderThickness = new PropertyValue<Thickness>(borderThickness);
            return border;
        }
        public static T BorderThickness<T>(this T border, Func<Thickness> borderThicknessFunc) where T : IRxBorder
        {
            border.BorderThickness = new PropertyValue<Thickness>(borderThicknessFunc);
            return border;
        }
        public static T BorderThickness<T>(this T border, double leftRight, double topBottom) where T : IRxBorder
        {
            border.BorderThickness = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return border;
        }
        public static T BorderThickness<T>(this T border, double uniformSize) where T : IRxBorder
        {
            border.BorderThickness = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return border;
        }
        public static T BorderThickness<T>(this T border, double left, double top, double right, double bottom) where T : IRxBorder
        {
            border.BorderThickness = new PropertyValue<Thickness>(new Thickness(left, top, right, bottom));
            return border;
        }
        public static T CornerRadius<T>(this T border, CornerRadius cornerRadius) where T : IRxBorder
        {
            border.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return border;
        }
        public static T CornerRadius<T>(this T border, Func<CornerRadius> cornerRadiusFunc) where T : IRxBorder
        {
            border.CornerRadius = new PropertyValue<CornerRadius>(cornerRadiusFunc);
            return border;
        }
        public static T Padding<T>(this T border, Thickness padding) where T : IRxBorder
        {
            border.Padding = new PropertyValue<Thickness>(padding);
            return border;
        }
        public static T Padding<T>(this T border, Func<Thickness> paddingFunc) where T : IRxBorder
        {
            border.Padding = new PropertyValue<Thickness>(paddingFunc);
            return border;
        }
        public static T Padding<T>(this T border, double leftRight, double topBottom) where T : IRxBorder
        {
            border.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return border;
        }
        public static T Padding<T>(this T border, double uniformSize) where T : IRxBorder
        {
            border.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return border;
        }
        public static T Padding<T>(this T border, double left, double top, double right, double bottom) where T : IRxBorder
        {
            border.Padding = new PropertyValue<Thickness>(new Thickness(left, top, right, bottom));
            return border;
        }
    }
}
