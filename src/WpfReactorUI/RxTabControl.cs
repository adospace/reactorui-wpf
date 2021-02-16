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
    public partial interface IRxTabControl : IRxSelector
    {
        PropertyValue<string>? ContentStringFormat { get; set; }
        PropertyValue<Dock>? TabStripPlacement { get; set; }

    }
    public partial class RxTabControl<T> : RxSelector<T>, IRxTabControl where T : TabControl, new()
    {
        public RxTabControl()
        {

        }

        public RxTabControl(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<string>? IRxTabControl.ContentStringFormat { get; set; }
        PropertyValue<Dock>? IRxTabControl.TabStripPlacement { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTabControl = (IRxTabControl)this;
            SetPropertyValue(NativeControl, TabControl.ContentStringFormatProperty, thisAsIRxTabControl.ContentStringFormat);
            SetPropertyValue(NativeControl, TabControl.TabStripPlacementProperty, thisAsIRxTabControl.TabStripPlacement);

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
    public partial class RxTabControl : RxTabControl<TabControl>
    {
        public RxTabControl()
        {

        }

        public RxTabControl(Action<TabControl?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxTabControlExtensions
    {
        public static T ContentStringFormat<T>(this T tabcontrol, string contentStringFormat) where T : IRxTabControl
        {
            tabcontrol.ContentStringFormat = new PropertyValue<string>(contentStringFormat);
            return tabcontrol;
        }
        public static T ContentStringFormat<T>(this T tabcontrol, Func<string> contentStringFormatFunc) where T : IRxTabControl
        {
            tabcontrol.ContentStringFormat = new PropertyValue<string>(contentStringFormatFunc);
            return tabcontrol;
        }
        public static T TabStripPlacement<T>(this T tabcontrol, Dock tabStripPlacement) where T : IRxTabControl
        {
            tabcontrol.TabStripPlacement = new PropertyValue<Dock>(tabStripPlacement);
            return tabcontrol;
        }
        public static T TabStripPlacement<T>(this T tabcontrol, Func<Dock> tabStripPlacementFunc) where T : IRxTabControl
        {
            tabcontrol.TabStripPlacement = new PropertyValue<Dock>(tabStripPlacementFunc);
            return tabcontrol;
        }
    }
}
