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

        Action? FragmentNavigationAction { get; set; }
        Action<object?, FragmentNavigationEventArgs>? FragmentNavigationActionWithArgs { get; set; }
        Action? LoadCompletedAction { get; set; }
        Action<object?, NavigationEventArgs>? LoadCompletedActionWithArgs { get; set; }
        Action? NavigatedAction { get; set; }
        Action<object?, NavigationEventArgs>? NavigatedActionWithArgs { get; set; }
        Action? NavigatingAction { get; set; }
        Action<object?, NavigatingCancelEventArgs>? NavigatingActionWithArgs { get; set; }
        Action? NavigationFailedAction { get; set; }
        Action<object?, NavigationFailedEventArgs>? NavigationFailedActionWithArgs { get; set; }
        Action? NavigationProgressAction { get; set; }
        Action<object?, NavigationProgressEventArgs>? NavigationProgressActionWithArgs { get; set; }
        Action? NavigationStoppedAction { get; set; }
        Action<object?, NavigationEventArgs>? NavigationStoppedActionWithArgs { get; set; }
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

        Action? IRxNavigationWindow.FragmentNavigationAction { get; set; }
        Action<object?, FragmentNavigationEventArgs>? IRxNavigationWindow.FragmentNavigationActionWithArgs { get; set; }
        Action? IRxNavigationWindow.LoadCompletedAction { get; set; }
        Action<object?, NavigationEventArgs>? IRxNavigationWindow.LoadCompletedActionWithArgs { get; set; }
        Action? IRxNavigationWindow.NavigatedAction { get; set; }
        Action<object?, NavigationEventArgs>? IRxNavigationWindow.NavigatedActionWithArgs { get; set; }
        Action? IRxNavigationWindow.NavigatingAction { get; set; }
        Action<object?, NavigatingCancelEventArgs>? IRxNavigationWindow.NavigatingActionWithArgs { get; set; }
        Action? IRxNavigationWindow.NavigationFailedAction { get; set; }
        Action<object?, NavigationFailedEventArgs>? IRxNavigationWindow.NavigationFailedActionWithArgs { get; set; }
        Action? IRxNavigationWindow.NavigationProgressAction { get; set; }
        Action<object?, NavigationProgressEventArgs>? IRxNavigationWindow.NavigationProgressActionWithArgs { get; set; }
        Action? IRxNavigationWindow.NavigationStoppedAction { get; set; }
        Action<object?, NavigationEventArgs>? IRxNavigationWindow.NavigationStoppedActionWithArgs { get; set; }

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

            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            if (thisAsIRxNavigationWindow.FragmentNavigationAction != null || thisAsIRxNavigationWindow.FragmentNavigationActionWithArgs != null)
            {
                NativeControl.FragmentNavigation += NativeControl_FragmentNavigation;
            }
            if (thisAsIRxNavigationWindow.LoadCompletedAction != null || thisAsIRxNavigationWindow.LoadCompletedActionWithArgs != null)
            {
                NativeControl.LoadCompleted += NativeControl_LoadCompleted;
            }
            if (thisAsIRxNavigationWindow.NavigatedAction != null || thisAsIRxNavigationWindow.NavigatedActionWithArgs != null)
            {
                NativeControl.Navigated += NativeControl_Navigated;
            }
            if (thisAsIRxNavigationWindow.NavigatingAction != null || thisAsIRxNavigationWindow.NavigatingActionWithArgs != null)
            {
                NativeControl.Navigating += NativeControl_Navigating;
            }
            if (thisAsIRxNavigationWindow.NavigationFailedAction != null || thisAsIRxNavigationWindow.NavigationFailedActionWithArgs != null)
            {
                NativeControl.NavigationFailed += NativeControl_NavigationFailed;
            }
            if (thisAsIRxNavigationWindow.NavigationProgressAction != null || thisAsIRxNavigationWindow.NavigationProgressActionWithArgs != null)
            {
                NativeControl.NavigationProgress += NativeControl_NavigationProgress;
            }
            if (thisAsIRxNavigationWindow.NavigationStoppedAction != null || thisAsIRxNavigationWindow.NavigationStoppedActionWithArgs != null)
            {
                NativeControl.NavigationStopped += NativeControl_NavigationStopped;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_FragmentNavigation(object? sender, FragmentNavigationEventArgs e)
        {
            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            thisAsIRxNavigationWindow.FragmentNavigationAction?.Invoke();
            thisAsIRxNavigationWindow.FragmentNavigationActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_LoadCompleted(object? sender, NavigationEventArgs e)
        {
            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            thisAsIRxNavigationWindow.LoadCompletedAction?.Invoke();
            thisAsIRxNavigationWindow.LoadCompletedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Navigated(object? sender, NavigationEventArgs e)
        {
            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            thisAsIRxNavigationWindow.NavigatedAction?.Invoke();
            thisAsIRxNavigationWindow.NavigatedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Navigating(object? sender, NavigatingCancelEventArgs e)
        {
            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            thisAsIRxNavigationWindow.NavigatingAction?.Invoke();
            thisAsIRxNavigationWindow.NavigatingActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_NavigationFailed(object? sender, NavigationFailedEventArgs e)
        {
            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            thisAsIRxNavigationWindow.NavigationFailedAction?.Invoke();
            thisAsIRxNavigationWindow.NavigationFailedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_NavigationProgress(object? sender, NavigationProgressEventArgs e)
        {
            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            thisAsIRxNavigationWindow.NavigationProgressAction?.Invoke();
            thisAsIRxNavigationWindow.NavigationProgressActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_NavigationStopped(object? sender, NavigationEventArgs e)
        {
            var thisAsIRxNavigationWindow = (IRxNavigationWindow)this;
            thisAsIRxNavigationWindow.NavigationStoppedAction?.Invoke();
            thisAsIRxNavigationWindow.NavigationStoppedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.FragmentNavigation -= NativeControl_FragmentNavigation;
                NativeControl.LoadCompleted -= NativeControl_LoadCompleted;
                NativeControl.Navigated -= NativeControl_Navigated;
                NativeControl.Navigating -= NativeControl_Navigating;
                NativeControl.NavigationFailed -= NativeControl_NavigationFailed;
                NativeControl.NavigationProgress -= NativeControl_NavigationProgress;
                NativeControl.NavigationStopped -= NativeControl_NavigationStopped;
            }

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
        public static T OnFragmentNavigation<T>(this T navigationwindow, Action fragmentnavigationAction) where T : IRxNavigationWindow
        {
            navigationwindow.FragmentNavigationAction = fragmentnavigationAction;
            return navigationwindow;
        }

        public static T OnFragmentNavigation<T>(this T navigationwindow, Action<object?, FragmentNavigationEventArgs> fragmentnavigationActionWithArgs) where T : IRxNavigationWindow
        {
            navigationwindow.FragmentNavigationActionWithArgs = fragmentnavigationActionWithArgs;
            return navigationwindow;
        }
        public static T OnLoadCompleted<T>(this T navigationwindow, Action loadcompletedAction) where T : IRxNavigationWindow
        {
            navigationwindow.LoadCompletedAction = loadcompletedAction;
            return navigationwindow;
        }

        public static T OnLoadCompleted<T>(this T navigationwindow, Action<object?, NavigationEventArgs> loadcompletedActionWithArgs) where T : IRxNavigationWindow
        {
            navigationwindow.LoadCompletedActionWithArgs = loadcompletedActionWithArgs;
            return navigationwindow;
        }
        public static T OnNavigated<T>(this T navigationwindow, Action navigatedAction) where T : IRxNavigationWindow
        {
            navigationwindow.NavigatedAction = navigatedAction;
            return navigationwindow;
        }

        public static T OnNavigated<T>(this T navigationwindow, Action<object?, NavigationEventArgs> navigatedActionWithArgs) where T : IRxNavigationWindow
        {
            navigationwindow.NavigatedActionWithArgs = navigatedActionWithArgs;
            return navigationwindow;
        }
        public static T OnNavigating<T>(this T navigationwindow, Action navigatingAction) where T : IRxNavigationWindow
        {
            navigationwindow.NavigatingAction = navigatingAction;
            return navigationwindow;
        }

        public static T OnNavigating<T>(this T navigationwindow, Action<object?, NavigatingCancelEventArgs> navigatingActionWithArgs) where T : IRxNavigationWindow
        {
            navigationwindow.NavigatingActionWithArgs = navigatingActionWithArgs;
            return navigationwindow;
        }
        public static T OnNavigationFailed<T>(this T navigationwindow, Action navigationfailedAction) where T : IRxNavigationWindow
        {
            navigationwindow.NavigationFailedAction = navigationfailedAction;
            return navigationwindow;
        }

        public static T OnNavigationFailed<T>(this T navigationwindow, Action<object?, NavigationFailedEventArgs> navigationfailedActionWithArgs) where T : IRxNavigationWindow
        {
            navigationwindow.NavigationFailedActionWithArgs = navigationfailedActionWithArgs;
            return navigationwindow;
        }
        public static T OnNavigationProgress<T>(this T navigationwindow, Action navigationprogressAction) where T : IRxNavigationWindow
        {
            navigationwindow.NavigationProgressAction = navigationprogressAction;
            return navigationwindow;
        }

        public static T OnNavigationProgress<T>(this T navigationwindow, Action<object?, NavigationProgressEventArgs> navigationprogressActionWithArgs) where T : IRxNavigationWindow
        {
            navigationwindow.NavigationProgressActionWithArgs = navigationprogressActionWithArgs;
            return navigationwindow;
        }
        public static T OnNavigationStopped<T>(this T navigationwindow, Action navigationstoppedAction) where T : IRxNavigationWindow
        {
            navigationwindow.NavigationStoppedAction = navigationstoppedAction;
            return navigationwindow;
        }

        public static T OnNavigationStopped<T>(this T navigationwindow, Action<object?, NavigationEventArgs> navigationstoppedActionWithArgs) where T : IRxNavigationWindow
        {
            navigationwindow.NavigationStoppedActionWithArgs = navigationstoppedActionWithArgs;
            return navigationwindow;
        }
    }
}
