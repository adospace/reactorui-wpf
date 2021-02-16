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
    public partial interface IRxFrame : IRxContentControl
    {
        PropertyValue<JournalOwnership>? JournalOwnership { get; set; }
        PropertyValue<NavigationUIVisibility>? NavigationUIVisibility { get; set; }
        PropertyValue<bool>? SandboxExternalContent { get; set; }
        PropertyValue<Uri>? Source { get; set; }

        Action? ContentRenderedAction { get; set; }
        Action<object?, EventArgs>? ContentRenderedActionWithArgs { get; set; }
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
    public partial class RxFrame<T> : RxContentControl<T>, IRxFrame where T : Frame, new()
    {
        public RxFrame()
        {

        }

        public RxFrame(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<JournalOwnership>? IRxFrame.JournalOwnership { get; set; }
        PropertyValue<NavigationUIVisibility>? IRxFrame.NavigationUIVisibility { get; set; }
        PropertyValue<bool>? IRxFrame.SandboxExternalContent { get; set; }
        PropertyValue<Uri>? IRxFrame.Source { get; set; }

        Action? IRxFrame.ContentRenderedAction { get; set; }
        Action<object?, EventArgs>? IRxFrame.ContentRenderedActionWithArgs { get; set; }
        Action? IRxFrame.FragmentNavigationAction { get; set; }
        Action<object?, FragmentNavigationEventArgs>? IRxFrame.FragmentNavigationActionWithArgs { get; set; }
        Action? IRxFrame.LoadCompletedAction { get; set; }
        Action<object?, NavigationEventArgs>? IRxFrame.LoadCompletedActionWithArgs { get; set; }
        Action? IRxFrame.NavigatedAction { get; set; }
        Action<object?, NavigationEventArgs>? IRxFrame.NavigatedActionWithArgs { get; set; }
        Action? IRxFrame.NavigatingAction { get; set; }
        Action<object?, NavigatingCancelEventArgs>? IRxFrame.NavigatingActionWithArgs { get; set; }
        Action? IRxFrame.NavigationFailedAction { get; set; }
        Action<object?, NavigationFailedEventArgs>? IRxFrame.NavigationFailedActionWithArgs { get; set; }
        Action? IRxFrame.NavigationProgressAction { get; set; }
        Action<object?, NavigationProgressEventArgs>? IRxFrame.NavigationProgressActionWithArgs { get; set; }
        Action? IRxFrame.NavigationStoppedAction { get; set; }
        Action<object?, NavigationEventArgs>? IRxFrame.NavigationStoppedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxFrame = (IRxFrame)this;
            SetPropertyValue(NativeControl, Frame.JournalOwnershipProperty, thisAsIRxFrame.JournalOwnership);
            SetPropertyValue(NativeControl, Frame.NavigationUIVisibilityProperty, thisAsIRxFrame.NavigationUIVisibility);
            SetPropertyValue(NativeControl, Frame.SandboxExternalContentProperty, thisAsIRxFrame.SandboxExternalContent);
            SetPropertyValue(NativeControl, Frame.SourceProperty, thisAsIRxFrame.Source);

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

            var thisAsIRxFrame = (IRxFrame)this;
            if (thisAsIRxFrame.ContentRenderedAction != null || thisAsIRxFrame.ContentRenderedActionWithArgs != null)
            {
                NativeControl.ContentRendered += NativeControl_ContentRendered;
            }
            if (thisAsIRxFrame.FragmentNavigationAction != null || thisAsIRxFrame.FragmentNavigationActionWithArgs != null)
            {
                NativeControl.FragmentNavigation += NativeControl_FragmentNavigation;
            }
            if (thisAsIRxFrame.LoadCompletedAction != null || thisAsIRxFrame.LoadCompletedActionWithArgs != null)
            {
                NativeControl.LoadCompleted += NativeControl_LoadCompleted;
            }
            if (thisAsIRxFrame.NavigatedAction != null || thisAsIRxFrame.NavigatedActionWithArgs != null)
            {
                NativeControl.Navigated += NativeControl_Navigated;
            }
            if (thisAsIRxFrame.NavigatingAction != null || thisAsIRxFrame.NavigatingActionWithArgs != null)
            {
                NativeControl.Navigating += NativeControl_Navigating;
            }
            if (thisAsIRxFrame.NavigationFailedAction != null || thisAsIRxFrame.NavigationFailedActionWithArgs != null)
            {
                NativeControl.NavigationFailed += NativeControl_NavigationFailed;
            }
            if (thisAsIRxFrame.NavigationProgressAction != null || thisAsIRxFrame.NavigationProgressActionWithArgs != null)
            {
                NativeControl.NavigationProgress += NativeControl_NavigationProgress;
            }
            if (thisAsIRxFrame.NavigationStoppedAction != null || thisAsIRxFrame.NavigationStoppedActionWithArgs != null)
            {
                NativeControl.NavigationStopped += NativeControl_NavigationStopped;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_ContentRendered(object? sender, EventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.ContentRenderedAction?.Invoke();
            thisAsIRxFrame.ContentRenderedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_FragmentNavigation(object? sender, FragmentNavigationEventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.FragmentNavigationAction?.Invoke();
            thisAsIRxFrame.FragmentNavigationActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_LoadCompleted(object? sender, NavigationEventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.LoadCompletedAction?.Invoke();
            thisAsIRxFrame.LoadCompletedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Navigated(object? sender, NavigationEventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.NavigatedAction?.Invoke();
            thisAsIRxFrame.NavigatedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Navigating(object? sender, NavigatingCancelEventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.NavigatingAction?.Invoke();
            thisAsIRxFrame.NavigatingActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_NavigationFailed(object? sender, NavigationFailedEventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.NavigationFailedAction?.Invoke();
            thisAsIRxFrame.NavigationFailedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_NavigationProgress(object? sender, NavigationProgressEventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.NavigationProgressAction?.Invoke();
            thisAsIRxFrame.NavigationProgressActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_NavigationStopped(object? sender, NavigationEventArgs e)
        {
            var thisAsIRxFrame = (IRxFrame)this;
            thisAsIRxFrame.NavigationStoppedAction?.Invoke();
            thisAsIRxFrame.NavigationStoppedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.ContentRendered -= NativeControl_ContentRendered;
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
    public partial class RxFrame : RxFrame<Frame>
    {
        public RxFrame()
        {

        }

        public RxFrame(Action<Frame?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxFrameExtensions
    {
        public static T JournalOwnership<T>(this T frame, JournalOwnership journalOwnership) where T : IRxFrame
        {
            frame.JournalOwnership = new PropertyValue<JournalOwnership>(journalOwnership);
            return frame;
        }
        public static T JournalOwnership<T>(this T frame, Func<JournalOwnership> journalOwnershipFunc) where T : IRxFrame
        {
            frame.JournalOwnership = new PropertyValue<JournalOwnership>(journalOwnershipFunc);
            return frame;
        }
        public static T NavigationUIVisibility<T>(this T frame, NavigationUIVisibility navigationUIVisibility) where T : IRxFrame
        {
            frame.NavigationUIVisibility = new PropertyValue<NavigationUIVisibility>(navigationUIVisibility);
            return frame;
        }
        public static T NavigationUIVisibility<T>(this T frame, Func<NavigationUIVisibility> navigationUIVisibilityFunc) where T : IRxFrame
        {
            frame.NavigationUIVisibility = new PropertyValue<NavigationUIVisibility>(navigationUIVisibilityFunc);
            return frame;
        }
        public static T SandboxExternalContent<T>(this T frame, bool sandboxExternalContent) where T : IRxFrame
        {
            frame.SandboxExternalContent = new PropertyValue<bool>(sandboxExternalContent);
            return frame;
        }
        public static T SandboxExternalContent<T>(this T frame, Func<bool> sandboxExternalContentFunc) where T : IRxFrame
        {
            frame.SandboxExternalContent = new PropertyValue<bool>(sandboxExternalContentFunc);
            return frame;
        }
        public static T Source<T>(this T frame, Uri source) where T : IRxFrame
        {
            frame.Source = new PropertyValue<Uri>(source);
            return frame;
        }
        public static T Source<T>(this T frame, Func<Uri> sourceFunc) where T : IRxFrame
        {
            frame.Source = new PropertyValue<Uri>(sourceFunc);
            return frame;
        }
        public static T OnContentRendered<T>(this T frame, Action contentrenderedAction) where T : IRxFrame
        {
            frame.ContentRenderedAction = contentrenderedAction;
            return frame;
        }

        public static T OnContentRendered<T>(this T frame, Action<object?, EventArgs> contentrenderedActionWithArgs) where T : IRxFrame
        {
            frame.ContentRenderedActionWithArgs = contentrenderedActionWithArgs;
            return frame;
        }
        public static T OnFragmentNavigation<T>(this T frame, Action fragmentnavigationAction) where T : IRxFrame
        {
            frame.FragmentNavigationAction = fragmentnavigationAction;
            return frame;
        }

        public static T OnFragmentNavigation<T>(this T frame, Action<object?, FragmentNavigationEventArgs> fragmentnavigationActionWithArgs) where T : IRxFrame
        {
            frame.FragmentNavigationActionWithArgs = fragmentnavigationActionWithArgs;
            return frame;
        }
        public static T OnLoadCompleted<T>(this T frame, Action loadcompletedAction) where T : IRxFrame
        {
            frame.LoadCompletedAction = loadcompletedAction;
            return frame;
        }

        public static T OnLoadCompleted<T>(this T frame, Action<object?, NavigationEventArgs> loadcompletedActionWithArgs) where T : IRxFrame
        {
            frame.LoadCompletedActionWithArgs = loadcompletedActionWithArgs;
            return frame;
        }
        public static T OnNavigated<T>(this T frame, Action navigatedAction) where T : IRxFrame
        {
            frame.NavigatedAction = navigatedAction;
            return frame;
        }

        public static T OnNavigated<T>(this T frame, Action<object?, NavigationEventArgs> navigatedActionWithArgs) where T : IRxFrame
        {
            frame.NavigatedActionWithArgs = navigatedActionWithArgs;
            return frame;
        }
        public static T OnNavigating<T>(this T frame, Action navigatingAction) where T : IRxFrame
        {
            frame.NavigatingAction = navigatingAction;
            return frame;
        }

        public static T OnNavigating<T>(this T frame, Action<object?, NavigatingCancelEventArgs> navigatingActionWithArgs) where T : IRxFrame
        {
            frame.NavigatingActionWithArgs = navigatingActionWithArgs;
            return frame;
        }
        public static T OnNavigationFailed<T>(this T frame, Action navigationfailedAction) where T : IRxFrame
        {
            frame.NavigationFailedAction = navigationfailedAction;
            return frame;
        }

        public static T OnNavigationFailed<T>(this T frame, Action<object?, NavigationFailedEventArgs> navigationfailedActionWithArgs) where T : IRxFrame
        {
            frame.NavigationFailedActionWithArgs = navigationfailedActionWithArgs;
            return frame;
        }
        public static T OnNavigationProgress<T>(this T frame, Action navigationprogressAction) where T : IRxFrame
        {
            frame.NavigationProgressAction = navigationprogressAction;
            return frame;
        }

        public static T OnNavigationProgress<T>(this T frame, Action<object?, NavigationProgressEventArgs> navigationprogressActionWithArgs) where T : IRxFrame
        {
            frame.NavigationProgressActionWithArgs = navigationprogressActionWithArgs;
            return frame;
        }
        public static T OnNavigationStopped<T>(this T frame, Action navigationstoppedAction) where T : IRxFrame
        {
            frame.NavigationStoppedAction = navigationstoppedAction;
            return frame;
        }

        public static T OnNavigationStopped<T>(this T frame, Action<object?, NavigationEventArgs> navigationstoppedActionWithArgs) where T : IRxFrame
        {
            frame.NavigationStoppedActionWithArgs = navigationstoppedActionWithArgs;
            return frame;
        }
    }
}
