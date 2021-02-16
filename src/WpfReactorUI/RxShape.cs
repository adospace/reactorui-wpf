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
    public partial interface IRxShape : IRxFrameworkElement
    {
        PropertyValue<Brush>? Fill { get; set; }
        PropertyValue<Stretch>? Stretch { get; set; }
        PropertyValue<Brush>? Stroke { get; set; }
        PropertyValue<DoubleCollection>? StrokeDashArray { get; set; }
        PropertyValue<PenLineCap>? StrokeDashCap { get; set; }
        PropertyValue<double>? StrokeDashOffset { get; set; }
        PropertyValue<PenLineCap>? StrokeEndLineCap { get; set; }
        PropertyValue<PenLineJoin>? StrokeLineJoin { get; set; }
        PropertyValue<double>? StrokeMiterLimit { get; set; }
        PropertyValue<PenLineCap>? StrokeStartLineCap { get; set; }
        PropertyValue<double>? StrokeThickness { get; set; }

    }
    public partial class RxShape<T> : RxFrameworkElement<T>, IRxShape where T : Shape, new()
    {
        public RxShape()
        {

        }

        public RxShape(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxShape.Fill { get; set; }
        PropertyValue<Stretch>? IRxShape.Stretch { get; set; }
        PropertyValue<Brush>? IRxShape.Stroke { get; set; }
        PropertyValue<DoubleCollection>? IRxShape.StrokeDashArray { get; set; }
        PropertyValue<PenLineCap>? IRxShape.StrokeDashCap { get; set; }
        PropertyValue<double>? IRxShape.StrokeDashOffset { get; set; }
        PropertyValue<PenLineCap>? IRxShape.StrokeEndLineCap { get; set; }
        PropertyValue<PenLineJoin>? IRxShape.StrokeLineJoin { get; set; }
        PropertyValue<double>? IRxShape.StrokeMiterLimit { get; set; }
        PropertyValue<PenLineCap>? IRxShape.StrokeStartLineCap { get; set; }
        PropertyValue<double>? IRxShape.StrokeThickness { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxShape = (IRxShape)this;
            SetPropertyValue(NativeControl, Shape.FillProperty, thisAsIRxShape.Fill);
            SetPropertyValue(NativeControl, Shape.StretchProperty, thisAsIRxShape.Stretch);
            SetPropertyValue(NativeControl, Shape.StrokeProperty, thisAsIRxShape.Stroke);
            SetPropertyValue(NativeControl, Shape.StrokeDashArrayProperty, thisAsIRxShape.StrokeDashArray);
            SetPropertyValue(NativeControl, Shape.StrokeDashCapProperty, thisAsIRxShape.StrokeDashCap);
            SetPropertyValue(NativeControl, Shape.StrokeDashOffsetProperty, thisAsIRxShape.StrokeDashOffset);
            SetPropertyValue(NativeControl, Shape.StrokeEndLineCapProperty, thisAsIRxShape.StrokeEndLineCap);
            SetPropertyValue(NativeControl, Shape.StrokeLineJoinProperty, thisAsIRxShape.StrokeLineJoin);
            SetPropertyValue(NativeControl, Shape.StrokeMiterLimitProperty, thisAsIRxShape.StrokeMiterLimit);
            SetPropertyValue(NativeControl, Shape.StrokeStartLineCapProperty, thisAsIRxShape.StrokeStartLineCap);
            SetPropertyValue(NativeControl, Shape.StrokeThicknessProperty, thisAsIRxShape.StrokeThickness);

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
    public static partial class RxShapeExtensions
    {
        public static T Fill<T>(this T shape, Brush fill) where T : IRxShape
        {
            shape.Fill = new PropertyValue<Brush>(fill);
            return shape;
        }
        public static T Fill<T>(this T shape, Func<Brush> fillFunc) where T : IRxShape
        {
            shape.Fill = new PropertyValue<Brush>(fillFunc);
            return shape;
        }
        public static T Fill<T>(this T shape, string fillResourceKey) where T : IRxShape
        {
            shape.ResourceReferences[Shape.FillProperty] = fillResourceKey;
            return shape;
        }
        public static T Stretch<T>(this T shape, Stretch stretch) where T : IRxShape
        {
            shape.Stretch = new PropertyValue<Stretch>(stretch);
            return shape;
        }
        public static T Stretch<T>(this T shape, Func<Stretch> stretchFunc) where T : IRxShape
        {
            shape.Stretch = new PropertyValue<Stretch>(stretchFunc);
            return shape;
        }
        public static T Stroke<T>(this T shape, Brush stroke) where T : IRxShape
        {
            shape.Stroke = new PropertyValue<Brush>(stroke);
            return shape;
        }
        public static T Stroke<T>(this T shape, Func<Brush> strokeFunc) where T : IRxShape
        {
            shape.Stroke = new PropertyValue<Brush>(strokeFunc);
            return shape;
        }
        public static T Stroke<T>(this T shape, string strokeResourceKey) where T : IRxShape
        {
            shape.ResourceReferences[Shape.StrokeProperty] = strokeResourceKey;
            return shape;
        }
        public static T StrokeDashArray<T>(this T shape, DoubleCollection strokeDashArray) where T : IRxShape
        {
            shape.StrokeDashArray = new PropertyValue<DoubleCollection>(strokeDashArray);
            return shape;
        }
        public static T StrokeDashArray<T>(this T shape, Func<DoubleCollection> strokeDashArrayFunc) where T : IRxShape
        {
            shape.StrokeDashArray = new PropertyValue<DoubleCollection>(strokeDashArrayFunc);
            return shape;
        }
        public static T StrokeDashCap<T>(this T shape, PenLineCap strokeDashCap) where T : IRxShape
        {
            shape.StrokeDashCap = new PropertyValue<PenLineCap>(strokeDashCap);
            return shape;
        }
        public static T StrokeDashCap<T>(this T shape, Func<PenLineCap> strokeDashCapFunc) where T : IRxShape
        {
            shape.StrokeDashCap = new PropertyValue<PenLineCap>(strokeDashCapFunc);
            return shape;
        }
        public static T StrokeDashOffset<T>(this T shape, double strokeDashOffset) where T : IRxShape
        {
            shape.StrokeDashOffset = new PropertyValue<double>(strokeDashOffset);
            return shape;
        }
        public static T StrokeDashOffset<T>(this T shape, Func<double> strokeDashOffsetFunc) where T : IRxShape
        {
            shape.StrokeDashOffset = new PropertyValue<double>(strokeDashOffsetFunc);
            return shape;
        }
        public static T StrokeEndLineCap<T>(this T shape, PenLineCap strokeEndLineCap) where T : IRxShape
        {
            shape.StrokeEndLineCap = new PropertyValue<PenLineCap>(strokeEndLineCap);
            return shape;
        }
        public static T StrokeEndLineCap<T>(this T shape, Func<PenLineCap> strokeEndLineCapFunc) where T : IRxShape
        {
            shape.StrokeEndLineCap = new PropertyValue<PenLineCap>(strokeEndLineCapFunc);
            return shape;
        }
        public static T StrokeLineJoin<T>(this T shape, PenLineJoin strokeLineJoin) where T : IRxShape
        {
            shape.StrokeLineJoin = new PropertyValue<PenLineJoin>(strokeLineJoin);
            return shape;
        }
        public static T StrokeLineJoin<T>(this T shape, Func<PenLineJoin> strokeLineJoinFunc) where T : IRxShape
        {
            shape.StrokeLineJoin = new PropertyValue<PenLineJoin>(strokeLineJoinFunc);
            return shape;
        }
        public static T StrokeMiterLimit<T>(this T shape, double strokeMiterLimit) where T : IRxShape
        {
            shape.StrokeMiterLimit = new PropertyValue<double>(strokeMiterLimit);
            return shape;
        }
        public static T StrokeMiterLimit<T>(this T shape, Func<double> strokeMiterLimitFunc) where T : IRxShape
        {
            shape.StrokeMiterLimit = new PropertyValue<double>(strokeMiterLimitFunc);
            return shape;
        }
        public static T StrokeStartLineCap<T>(this T shape, PenLineCap strokeStartLineCap) where T : IRxShape
        {
            shape.StrokeStartLineCap = new PropertyValue<PenLineCap>(strokeStartLineCap);
            return shape;
        }
        public static T StrokeStartLineCap<T>(this T shape, Func<PenLineCap> strokeStartLineCapFunc) where T : IRxShape
        {
            shape.StrokeStartLineCap = new PropertyValue<PenLineCap>(strokeStartLineCapFunc);
            return shape;
        }
        public static T StrokeThickness<T>(this T shape, double strokeThickness) where T : IRxShape
        {
            shape.StrokeThickness = new PropertyValue<double>(strokeThickness);
            return shape;
        }
        public static T StrokeThickness<T>(this T shape, Func<double> strokeThicknessFunc) where T : IRxShape
        {
            shape.StrokeThickness = new PropertyValue<double>(strokeThicknessFunc);
            return shape;
        }
    }
}
