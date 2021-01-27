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
    public partial interface IRxNavigationWindow : IRxWindow
    {
        PropertyValue<bool>? SandboxExternalContent { get; set; }
        PropertyValue<bool>? ShowsNavigationUI { get; set; }
        PropertyValue<Uri>? Source { get; set; }

    }

    public partial class RxNavigationWindow<T> : RxWindow<T>, IRxNavigationWindow where T : NavigationWindow, new()
    {
        public RxNavigationWindow()
        {

        }

        public RxNavigationWindow(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxNavigationWindow.SandboxExternalContent { get; set; }
        PropertyValue<bool>? IRxNavigationWindow.ShowsNavigationUI { get; set; }
        PropertyValue<Uri>? IRxNavigationWindow.Source { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            SetPropertyValue(NativeControl, NavigationWindow.SandboxExternalContentProperty, thisAsIRxNavigationWindow.SandboxExternalContent);
            SetPropertyValue(NativeControl, NavigationWindow.ShowsNavigationUIProperty, thisAsIRxNavigationWindow.ShowsNavigationUI);
            SetPropertyValue(NativeControl, NavigationWindow.SourceProperty, thisAsIRxNavigationWindow.Source);

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
    public partial class RxNavigationWindow : RxNavigationWindow<NavigationWindow>
    {
        public RxNavigationWindow()
        {

        }

        public RxNavigationWindow(Action<NavigationWindow?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxNavigationWindowExtensions
    {
        public static T SandboxExternalContent<T>(this T navigationwindow, bool sandboxExternalContent) where T : IRxNavigationWindow
        {
            navigationwindow.SandboxExternalContent = new PropertyValue<bool>(sandboxExternalContent);
            return navigationwindow;
        }
        public static T SandboxExternalContent<T>(this T navigationwindow, Func<bool> sandboxExternalContentFunc) where T : IRxNavigationWindow
        {
            navigationwindow.SandboxExternalContent = new PropertyValue<bool>(sandboxExternalContentFunc);
            return navigationwindow;
        }
        public static T ShowsNavigationUI<T>(this T navigationwindow, bool showsNavigationUI) where T : IRxNavigationWindow
        {
            navigationwindow.ShowsNavigationUI = new PropertyValue<bool>(showsNavigationUI);
            return navigationwindow;
        }
        public static T ShowsNavigationUI<T>(this T navigationwindow, Func<bool> showsNavigationUIFunc) where T : IRxNavigationWindow
        {
            navigationwindow.ShowsNavigationUI = new PropertyValue<bool>(showsNavigationUIFunc);
            return navigationwindow;
        }
        public static T Source<T>(this T navigationwindow, Uri source) where T : IRxNavigationWindow
        {
            navigationwindow.Source = new PropertyValue<Uri>(source);
            return navigationwindow;
        }
        public static T Source<T>(this T navigationwindow, Func<Uri> sourceFunc) where T : IRxNavigationWindow
        {
            navigationwindow.Source = new PropertyValue<Uri>(sourceFunc);
            return navigationwindow;
        }
    }
}
