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
    public partial interface IRxScrollViewer : IRxContentControl
    {
        PropertyValue<bool>? CanContentScroll { get; set; }
        PropertyValue<ScrollBarVisibility>? HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool>? IsDeferredScrollingEnabled { get; set; }
        PropertyValue<double>? PanningDeceleration { get; set; }
        PropertyValue<PanningMode>? PanningMode { get; set; }
        PropertyValue<double>? PanningRatio { get; set; }
        PropertyValue<ScrollBarVisibility>? VerticalScrollBarVisibility { get; set; }

        Action? ScrollChangedAction { get; set; }
        Action<object?, ScrollChangedEventArgs>? ScrollChangedActionWithArgs { get; set; }
    }
    public partial class RxScrollViewer<T> : RxContentControl<T>, IRxScrollViewer where T : ScrollViewer, new()
    {
        public RxScrollViewer()
        {

        }

        public RxScrollViewer(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxScrollViewer.CanContentScroll { get; set; }
        PropertyValue<ScrollBarVisibility>? IRxScrollViewer.HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool>? IRxScrollViewer.IsDeferredScrollingEnabled { get; set; }
        PropertyValue<double>? IRxScrollViewer.PanningDeceleration { get; set; }
        PropertyValue<PanningMode>? IRxScrollViewer.PanningMode { get; set; }
        PropertyValue<double>? IRxScrollViewer.PanningRatio { get; set; }
        PropertyValue<ScrollBarVisibility>? IRxScrollViewer.VerticalScrollBarVisibility { get; set; }

        Action? IRxScrollViewer.ScrollChangedAction { get; set; }
        Action<object?, ScrollChangedEventArgs>? IRxScrollViewer.ScrollChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxScrollViewer = (IRxScrollViewer)this;
            SetPropertyValue(NativeControl, ScrollViewer.CanContentScrollProperty, thisAsIRxScrollViewer.CanContentScroll);
            SetPropertyValue(NativeControl, ScrollViewer.HorizontalScrollBarVisibilityProperty, thisAsIRxScrollViewer.HorizontalScrollBarVisibility);
            SetPropertyValue(NativeControl, ScrollViewer.IsDeferredScrollingEnabledProperty, thisAsIRxScrollViewer.IsDeferredScrollingEnabled);
            SetPropertyValue(NativeControl, ScrollViewer.PanningDecelerationProperty, thisAsIRxScrollViewer.PanningDeceleration);
            SetPropertyValue(NativeControl, ScrollViewer.PanningModeProperty, thisAsIRxScrollViewer.PanningMode);
            SetPropertyValue(NativeControl, ScrollViewer.PanningRatioProperty, thisAsIRxScrollViewer.PanningRatio);
            SetPropertyValue(NativeControl, ScrollViewer.VerticalScrollBarVisibilityProperty, thisAsIRxScrollViewer.VerticalScrollBarVisibility);

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

            var thisAsIRxScrollViewer = (IRxScrollViewer)this;
            if (thisAsIRxScrollViewer.ScrollChangedAction != null || thisAsIRxScrollViewer.ScrollChangedActionWithArgs != null)
            {
                NativeControl.ScrollChanged += NativeControl_ScrollChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_ScrollChanged(object? sender, ScrollChangedEventArgs e)
        {
            var thisAsIRxScrollViewer = (IRxScrollViewer)this;
            thisAsIRxScrollViewer.ScrollChangedAction?.Invoke();
            thisAsIRxScrollViewer.ScrollChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.ScrollChanged -= NativeControl_ScrollChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxScrollViewer : RxScrollViewer<ScrollViewer>
    {
        public RxScrollViewer()
        {

        }

        public RxScrollViewer(Action<ScrollViewer?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxScrollViewerExtensions
    {
        public static T CanContentScroll<T>(this T scrollviewer, bool canContentScroll) where T : IRxScrollViewer
        {
            scrollviewer.CanContentScroll = new PropertyValue<bool>(canContentScroll);
            return scrollviewer;
        }
        public static T CanContentScroll<T>(this T scrollviewer, Func<bool> canContentScrollFunc) where T : IRxScrollViewer
        {
            scrollviewer.CanContentScroll = new PropertyValue<bool>(canContentScrollFunc);
            return scrollviewer;
        }
        public static T HorizontalScrollBarVisibility<T>(this T scrollviewer, ScrollBarVisibility horizontalScrollBarVisibility) where T : IRxScrollViewer
        {
            scrollviewer.HorizontalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(horizontalScrollBarVisibility);
            return scrollviewer;
        }
        public static T HorizontalScrollBarVisibility<T>(this T scrollviewer, Func<ScrollBarVisibility> horizontalScrollBarVisibilityFunc) where T : IRxScrollViewer
        {
            scrollviewer.HorizontalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(horizontalScrollBarVisibilityFunc);
            return scrollviewer;
        }
        public static T IsDeferredScrollingEnabled<T>(this T scrollviewer, bool isDeferredScrollingEnabled) where T : IRxScrollViewer
        {
            scrollviewer.IsDeferredScrollingEnabled = new PropertyValue<bool>(isDeferredScrollingEnabled);
            return scrollviewer;
        }
        public static T IsDeferredScrollingEnabled<T>(this T scrollviewer, Func<bool> isDeferredScrollingEnabledFunc) where T : IRxScrollViewer
        {
            scrollviewer.IsDeferredScrollingEnabled = new PropertyValue<bool>(isDeferredScrollingEnabledFunc);
            return scrollviewer;
        }
        public static T PanningDeceleration<T>(this T scrollviewer, double panningDeceleration) where T : IRxScrollViewer
        {
            scrollviewer.PanningDeceleration = new PropertyValue<double>(panningDeceleration);
            return scrollviewer;
        }
        public static T PanningDeceleration<T>(this T scrollviewer, Func<double> panningDecelerationFunc) where T : IRxScrollViewer
        {
            scrollviewer.PanningDeceleration = new PropertyValue<double>(panningDecelerationFunc);
            return scrollviewer;
        }
        public static T PanningMode<T>(this T scrollviewer, PanningMode panningMode) where T : IRxScrollViewer
        {
            scrollviewer.PanningMode = new PropertyValue<PanningMode>(panningMode);
            return scrollviewer;
        }
        public static T PanningMode<T>(this T scrollviewer, Func<PanningMode> panningModeFunc) where T : IRxScrollViewer
        {
            scrollviewer.PanningMode = new PropertyValue<PanningMode>(panningModeFunc);
            return scrollviewer;
        }
        public static T PanningRatio<T>(this T scrollviewer, double panningRatio) where T : IRxScrollViewer
        {
            scrollviewer.PanningRatio = new PropertyValue<double>(panningRatio);
            return scrollviewer;
        }
        public static T PanningRatio<T>(this T scrollviewer, Func<double> panningRatioFunc) where T : IRxScrollViewer
        {
            scrollviewer.PanningRatio = new PropertyValue<double>(panningRatioFunc);
            return scrollviewer;
        }
        public static T VerticalScrollBarVisibility<T>(this T scrollviewer, ScrollBarVisibility verticalScrollBarVisibility) where T : IRxScrollViewer
        {
            scrollviewer.VerticalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(verticalScrollBarVisibility);
            return scrollviewer;
        }
        public static T VerticalScrollBarVisibility<T>(this T scrollviewer, Func<ScrollBarVisibility> verticalScrollBarVisibilityFunc) where T : IRxScrollViewer
        {
            scrollviewer.VerticalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(verticalScrollBarVisibilityFunc);
            return scrollviewer;
        }
        public static T OnScrollChanged<T>(this T scrollviewer, Action scrollchangedAction) where T : IRxScrollViewer
        {
            scrollviewer.ScrollChangedAction = scrollchangedAction;
            return scrollviewer;
        }

        public static T OnScrollChanged<T>(this T scrollviewer, Action<object?, ScrollChangedEventArgs> scrollchangedActionWithArgs) where T : IRxScrollViewer
        {
            scrollviewer.ScrollChangedActionWithArgs = scrollchangedActionWithArgs;
            return scrollviewer;
        }
    }
}
