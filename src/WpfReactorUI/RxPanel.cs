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
    public partial interface IRxPanel : IRxFrameworkElement
    {
        PropertyValue<Brush>? Background { get; set; }
        PropertyValue<bool>? IsItemsHost { get; set; }

    }
    public partial class RxPanel<T> : RxFrameworkElement<T>, IRxPanel where T : Panel, new()
    {
        public RxPanel()
        {

        }

        public RxPanel(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxPanel.Background { get; set; }
        PropertyValue<bool>? IRxPanel.IsItemsHost { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxPanel = (IRxPanel)this;
            SetPropertyValue(NativeControl, Panel.BackgroundProperty, thisAsIRxPanel.Background);
            SetPropertyValue(NativeControl, Panel.IsItemsHostProperty, thisAsIRxPanel.IsItemsHost);

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
    public static partial class RxPanelExtensions
    {
        public static T Background<T>(this T panel, Brush background) where T : IRxPanel
        {
            panel.Background = new PropertyValue<Brush>(background);
            return panel;
        }
        public static T Background<T>(this T panel, Func<Brush> backgroundFunc) where T : IRxPanel
        {
            panel.Background = new PropertyValue<Brush>(backgroundFunc);
            return panel;
        }
        public static T Background<T>(this T panel, string backgroundResourceKey) where T : IRxPanel
        {
            panel.ResourceReferences[Panel.BackgroundProperty] = backgroundResourceKey;
            return panel;
        }
        public static T IsItemsHost<T>(this T panel, bool isItemsHost) where T : IRxPanel
        {
            panel.IsItemsHost = new PropertyValue<bool>(isItemsHost);
            return panel;
        }
        public static T IsItemsHost<T>(this T panel, Func<bool> isItemsHostFunc) where T : IRxPanel
        {
            panel.IsItemsHost = new PropertyValue<bool>(isItemsHostFunc);
            return panel;
        }
    }
}
