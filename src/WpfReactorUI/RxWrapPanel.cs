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
    public partial interface IRxWrapPanel : IRxPanel
    {
        PropertyValue<double>? ItemHeight { get; set; }
        PropertyValue<double>? ItemWidth { get; set; }
        PropertyValue<Orientation>? Orientation { get; set; }

    }
    public partial class RxWrapPanel<T> : RxPanel<T>, IRxWrapPanel where T : WrapPanel, new()
    {
        public RxWrapPanel()
        {

        }

        public RxWrapPanel(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<double>? IRxWrapPanel.ItemHeight { get; set; }
        PropertyValue<double>? IRxWrapPanel.ItemWidth { get; set; }
        PropertyValue<Orientation>? IRxWrapPanel.Orientation { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxWrapPanel = (IRxWrapPanel)this;
            SetPropertyValue(NativeControl, WrapPanel.ItemHeightProperty, thisAsIRxWrapPanel.ItemHeight);
            SetPropertyValue(NativeControl, WrapPanel.ItemWidthProperty, thisAsIRxWrapPanel.ItemWidth);
            SetPropertyValue(NativeControl, WrapPanel.OrientationProperty, thisAsIRxWrapPanel.Orientation);

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
    public partial class RxWrapPanel : RxWrapPanel<WrapPanel>
    {
        public RxWrapPanel()
        {

        }

        public RxWrapPanel(Action<WrapPanel?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxWrapPanelExtensions
    {
        public static T ItemHeight<T>(this T wrappanel, double itemHeight) where T : IRxWrapPanel
        {
            wrappanel.ItemHeight = new PropertyValue<double>(itemHeight);
            return wrappanel;
        }
        public static T ItemHeight<T>(this T wrappanel, Func<double> itemHeightFunc) where T : IRxWrapPanel
        {
            wrappanel.ItemHeight = new PropertyValue<double>(itemHeightFunc);
            return wrappanel;
        }
        public static T ItemWidth<T>(this T wrappanel, double itemWidth) where T : IRxWrapPanel
        {
            wrappanel.ItemWidth = new PropertyValue<double>(itemWidth);
            return wrappanel;
        }
        public static T ItemWidth<T>(this T wrappanel, Func<double> itemWidthFunc) where T : IRxWrapPanel
        {
            wrappanel.ItemWidth = new PropertyValue<double>(itemWidthFunc);
            return wrappanel;
        }
        public static T Orientation<T>(this T wrappanel, Orientation orientation) where T : IRxWrapPanel
        {
            wrappanel.Orientation = new PropertyValue<Orientation>(orientation);
            return wrappanel;
        }
        public static T Orientation<T>(this T wrappanel, Func<Orientation> orientationFunc) where T : IRxWrapPanel
        {
            wrappanel.Orientation = new PropertyValue<Orientation>(orientationFunc);
            return wrappanel;
        }
    }
}
