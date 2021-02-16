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
    public partial interface IRxRangeBase : IRxControl
    {
        PropertyValue<double>? LargeChange { get; set; }
        PropertyValue<double>? Maximum { get; set; }
        PropertyValue<double>? Minimum { get; set; }
        PropertyValue<double>? SmallChange { get; set; }
        PropertyValue<double>? Value { get; set; }

    }
    public partial class RxRangeBase<T> : RxControl<T>, IRxRangeBase where T : RangeBase, new()
    {
        public RxRangeBase()
        {

        }

        public RxRangeBase(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<double>? IRxRangeBase.LargeChange { get; set; }
        PropertyValue<double>? IRxRangeBase.Maximum { get; set; }
        PropertyValue<double>? IRxRangeBase.Minimum { get; set; }
        PropertyValue<double>? IRxRangeBase.SmallChange { get; set; }
        PropertyValue<double>? IRxRangeBase.Value { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxRangeBase = (IRxRangeBase)this;
            SetPropertyValue(NativeControl, RangeBase.LargeChangeProperty, thisAsIRxRangeBase.LargeChange);
            SetPropertyValue(NativeControl, RangeBase.MaximumProperty, thisAsIRxRangeBase.Maximum);
            SetPropertyValue(NativeControl, RangeBase.MinimumProperty, thisAsIRxRangeBase.Minimum);
            SetPropertyValue(NativeControl, RangeBase.SmallChangeProperty, thisAsIRxRangeBase.SmallChange);
            SetPropertyValue(NativeControl, RangeBase.ValueProperty, thisAsIRxRangeBase.Value);

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
    public static partial class RxRangeBaseExtensions
    {
        public static T LargeChange<T>(this T rangebase, double largeChange) where T : IRxRangeBase
        {
            rangebase.LargeChange = new PropertyValue<double>(largeChange);
            return rangebase;
        }
        public static T LargeChange<T>(this T rangebase, Func<double> largeChangeFunc) where T : IRxRangeBase
        {
            rangebase.LargeChange = new PropertyValue<double>(largeChangeFunc);
            return rangebase;
        }
        public static T Maximum<T>(this T rangebase, double maximum) where T : IRxRangeBase
        {
            rangebase.Maximum = new PropertyValue<double>(maximum);
            return rangebase;
        }
        public static T Maximum<T>(this T rangebase, Func<double> maximumFunc) where T : IRxRangeBase
        {
            rangebase.Maximum = new PropertyValue<double>(maximumFunc);
            return rangebase;
        }
        public static T Minimum<T>(this T rangebase, double minimum) where T : IRxRangeBase
        {
            rangebase.Minimum = new PropertyValue<double>(minimum);
            return rangebase;
        }
        public static T Minimum<T>(this T rangebase, Func<double> minimumFunc) where T : IRxRangeBase
        {
            rangebase.Minimum = new PropertyValue<double>(minimumFunc);
            return rangebase;
        }
        public static T SmallChange<T>(this T rangebase, double smallChange) where T : IRxRangeBase
        {
            rangebase.SmallChange = new PropertyValue<double>(smallChange);
            return rangebase;
        }
        public static T SmallChange<T>(this T rangebase, Func<double> smallChangeFunc) where T : IRxRangeBase
        {
            rangebase.SmallChange = new PropertyValue<double>(smallChangeFunc);
            return rangebase;
        }
        public static T Value<T>(this T rangebase, double value) where T : IRxRangeBase
        {
            rangebase.Value = new PropertyValue<double>(value);
            return rangebase;
        }
        public static T Value<T>(this T rangebase, Func<double> valueFunc) where T : IRxRangeBase
        {
            rangebase.Value = new PropertyValue<double>(valueFunc);
            return rangebase;
        }
    }
}
