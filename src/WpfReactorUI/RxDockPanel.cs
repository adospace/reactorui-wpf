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
    public partial interface IRxDockPanel : IRxPanel
    {
        PropertyValue<bool>? LastChildFill { get; set; }

    }

    public partial class RxDockPanel<T> : RxPanel<T>, IRxDockPanel where T : DockPanel, new()
    {
        public RxDockPanel()
        {

        }

        public RxDockPanel(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxDockPanel.LastChildFill { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxDockPanel = (IRxDockPanel)this;
            SetPropertyValue(NativeControl, DockPanel.LastChildFillProperty, thisAsIRxDockPanel.LastChildFill);

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
    public partial class RxDockPanel : RxDockPanel<DockPanel>
    {
        public RxDockPanel()
        {

        }

        public RxDockPanel(Action<DockPanel?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxDockPanelExtensions
    {
        public static T LastChildFill<T>(this T dockpanel, bool lastChildFill) where T : IRxDockPanel
        {
            dockpanel.LastChildFill = new PropertyValue<bool>(lastChildFill);
            return dockpanel;
        }
        public static T LastChildFill<T>(this T dockpanel, Func<bool> lastChildFillFunc) where T : IRxDockPanel
        {
            dockpanel.LastChildFill = new PropertyValue<bool>(lastChildFillFunc);
            return dockpanel;
        }
    }
}
