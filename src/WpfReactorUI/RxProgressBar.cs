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
    public partial interface IRxProgressBar : IRxRangeBase
    {
        PropertyValue<bool>? IsIndeterminate { get; set; }
        PropertyValue<Orientation>? Orientation { get; set; }

    }
    public partial class RxProgressBar<T> : RxRangeBase<T>, IRxProgressBar where T : ProgressBar, new()
    {
        public RxProgressBar()
        {

        }

        public RxProgressBar(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxProgressBar.IsIndeterminate { get; set; }
        PropertyValue<Orientation>? IRxProgressBar.Orientation { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxProgressBar = (IRxProgressBar)this;
            SetPropertyValue(NativeControl, ProgressBar.IsIndeterminateProperty, thisAsIRxProgressBar.IsIndeterminate);
            SetPropertyValue(NativeControl, ProgressBar.OrientationProperty, thisAsIRxProgressBar.Orientation);

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
    public partial class RxProgressBar : RxProgressBar<ProgressBar>
    {
        public RxProgressBar()
        {

        }

        public RxProgressBar(Action<ProgressBar?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxProgressBarExtensions
    {
        public static T IsIndeterminate<T>(this T progressbar, bool isIndeterminate) where T : IRxProgressBar
        {
            progressbar.IsIndeterminate = new PropertyValue<bool>(isIndeterminate);
            return progressbar;
        }
        public static T IsIndeterminate<T>(this T progressbar, Func<bool> isIndeterminateFunc) where T : IRxProgressBar
        {
            progressbar.IsIndeterminate = new PropertyValue<bool>(isIndeterminateFunc);
            return progressbar;
        }
        public static T Orientation<T>(this T progressbar, Orientation orientation) where T : IRxProgressBar
        {
            progressbar.Orientation = new PropertyValue<Orientation>(orientation);
            return progressbar;
        }
        public static T Orientation<T>(this T progressbar, Func<Orientation> orientationFunc) where T : IRxProgressBar
        {
            progressbar.Orientation = new PropertyValue<Orientation>(orientationFunc);
            return progressbar;
        }
    }
}
