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

using WpfReactorUI.Internals;
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;

namespace WpfReactorUI
{
    public partial interface IRxSimpleStackPanel : IRxPanel
    {
        PropertyValue<Orientation>? Orientation { get; set; }
        PropertyValue<double>? Spacing { get; set; }

    }

    public partial class RxSimpleStackPanel<T> : RxPanel<T>, IRxSimpleStackPanel where T : SimpleStackPanel, new()
    {
        public RxSimpleStackPanel()
        {

        }

        public RxSimpleStackPanel(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Orientation>? IRxSimpleStackPanel.Orientation { get; set; }
        PropertyValue<double>? IRxSimpleStackPanel.Spacing { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxSimpleStackPanel = (IRxSimpleStackPanel)this;
            SetPropertyValue(NativeControl, SimpleStackPanel.OrientationProperty, thisAsIRxSimpleStackPanel.Orientation);
            SetPropertyValue(NativeControl, SimpleStackPanel.SpacingProperty, thisAsIRxSimpleStackPanel.Spacing);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {

            base.OnAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxSimpleStackPanel : RxSimpleStackPanel<SimpleStackPanel>
    {
        public RxSimpleStackPanel()
        {

        }

        public RxSimpleStackPanel(Action<SimpleStackPanel?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxSimpleStackPanelExtensions
    {
        public static T Orientation<T>(this T simplestackpanel, Orientation orientation) where T : IRxSimpleStackPanel
        {
            simplestackpanel.Orientation = new PropertyValue<Orientation>(orientation);
            return simplestackpanel;
        }
        public static T Orientation<T>(this T simplestackpanel, Func<Orientation> orientationFunc) where T : IRxSimpleStackPanel
        {
            simplestackpanel.Orientation = new PropertyValue<Orientation>(orientationFunc);
            return simplestackpanel;
        }
        public static T Spacing<T>(this T simplestackpanel, double spacing) where T : IRxSimpleStackPanel
        {
            simplestackpanel.Spacing = new PropertyValue<double>(spacing);
            return simplestackpanel;
        }
        public static T Spacing<T>(this T simplestackpanel, Func<double> spacingFunc) where T : IRxSimpleStackPanel
        {
            simplestackpanel.Spacing = new PropertyValue<double>(spacingFunc);
            return simplestackpanel;
        }
    }
}
