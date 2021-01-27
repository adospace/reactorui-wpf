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
    public partial interface IRxStackPanel : IRxPanel
    {
        PropertyValue<Orientation>? Orientation { get; set; }

    }

    public partial class RxStackPanel<T> : RxPanel<T>, IRxStackPanel where T : StackPanel, new()
    {
        public RxStackPanel()
        {

        }

        public RxStackPanel(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Orientation>? IRxStackPanel.Orientation { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxStackPanel = (IRxStackPanel)this;
            SetPropertyValue(NativeControl, StackPanel.OrientationProperty, thisAsIRxStackPanel.Orientation);

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
    public partial class RxStackPanel : RxStackPanel<StackPanel>
    {
        public RxStackPanel()
        {

        }

        public RxStackPanel(Action<StackPanel?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxStackPanelExtensions
    {
        public static T Orientation<T>(this T stackpanel, Orientation orientation) where T : IRxStackPanel
        {
            stackpanel.Orientation = new PropertyValue<Orientation>(orientation);
            return stackpanel;
        }
        public static T Orientation<T>(this T stackpanel, Func<Orientation> orientationFunc) where T : IRxStackPanel
        {
            stackpanel.Orientation = new PropertyValue<Orientation>(orientationFunc);
            return stackpanel;
        }
    }
}
