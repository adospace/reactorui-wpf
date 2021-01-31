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
    public partial interface IRxWindow : IRxContentControl
    {
        PropertyValue<bool>? AllowsTransparency { get; set; }
        PropertyValue<ImageSource>? Icon { get; set; }
        PropertyValue<double>? Left { get; set; }
        PropertyValue<ResizeMode>? ResizeMode { get; set; }
        PropertyValue<bool>? ShowActivated { get; set; }
        PropertyValue<bool>? ShowInTaskbar { get; set; }
        PropertyValue<SizeToContent>? SizeToContent { get; set; }
        PropertyValue<TaskbarItemInfo>? TaskbarItemInfo { get; set; }
        PropertyValue<string>? Title { get; set; }
        PropertyValue<double>? Top { get; set; }
        PropertyValue<bool>? Topmost { get; set; }
        PropertyValue<WindowState>? WindowState { get; set; }
        PropertyValue<WindowStyle>? WindowStyle { get; set; }

        Action? ActivatedAction { get; set; }
        Action<object?, EventArgs>? ActivatedActionWithArgs { get; set; }
        Action? ClosedAction { get; set; }
        Action<object?, EventArgs>? ClosedActionWithArgs { get; set; }
        Action? ClosingAction { get; set; }
        Action<object?, CancelEventArgs>? ClosingActionWithArgs { get; set; }
        Action? ContentRenderedAction { get; set; }
        Action<object?, EventArgs>? ContentRenderedActionWithArgs { get; set; }
        Action? DeactivatedAction { get; set; }
        Action<object?, EventArgs>? DeactivatedActionWithArgs { get; set; }
        Action? DpiChangedAction { get; set; }
        Action<object?, DpiChangedEventArgs>? DpiChangedActionWithArgs { get; set; }
        Action? LocationChangedAction { get; set; }
        Action<object?, EventArgs>? LocationChangedActionWithArgs { get; set; }
        Action? SourceInitializedAction { get; set; }
        Action<object?, EventArgs>? SourceInitializedActionWithArgs { get; set; }
        Action? StateChangedAction { get; set; }
        Action<object?, EventArgs>? StateChangedActionWithArgs { get; set; }
    }

    public partial class RxWindow<T> : RxContentControl<T>, IRxWindow where T : Window, new()
    {
        public RxWindow()
        {

        }

        public RxWindow(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxWindow.AllowsTransparency { get; set; }
        PropertyValue<ImageSource>? IRxWindow.Icon { get; set; }
        PropertyValue<double>? IRxWindow.Left { get; set; }
        PropertyValue<ResizeMode>? IRxWindow.ResizeMode { get; set; }
        PropertyValue<bool>? IRxWindow.ShowActivated { get; set; }
        PropertyValue<bool>? IRxWindow.ShowInTaskbar { get; set; }
        PropertyValue<SizeToContent>? IRxWindow.SizeToContent { get; set; }
        PropertyValue<TaskbarItemInfo>? IRxWindow.TaskbarItemInfo { get; set; }
        PropertyValue<string>? IRxWindow.Title { get; set; }
        PropertyValue<double>? IRxWindow.Top { get; set; }
        PropertyValue<bool>? IRxWindow.Topmost { get; set; }
        PropertyValue<WindowState>? IRxWindow.WindowState { get; set; }
        PropertyValue<WindowStyle>? IRxWindow.WindowStyle { get; set; }

        Action? IRxWindow.ActivatedAction { get; set; }
        Action<object?, EventArgs>? IRxWindow.ActivatedActionWithArgs { get; set; }
        Action? IRxWindow.ClosedAction { get; set; }
        Action<object?, EventArgs>? IRxWindow.ClosedActionWithArgs { get; set; }
        Action? IRxWindow.ClosingAction { get; set; }
        Action<object?, CancelEventArgs>? IRxWindow.ClosingActionWithArgs { get; set; }
        Action? IRxWindow.ContentRenderedAction { get; set; }
        Action<object?, EventArgs>? IRxWindow.ContentRenderedActionWithArgs { get; set; }
        Action? IRxWindow.DeactivatedAction { get; set; }
        Action<object?, EventArgs>? IRxWindow.DeactivatedActionWithArgs { get; set; }
        Action? IRxWindow.DpiChangedAction { get; set; }
        Action<object?, DpiChangedEventArgs>? IRxWindow.DpiChangedActionWithArgs { get; set; }
        Action? IRxWindow.LocationChangedAction { get; set; }
        Action<object?, EventArgs>? IRxWindow.LocationChangedActionWithArgs { get; set; }
        Action? IRxWindow.SourceInitializedAction { get; set; }
        Action<object?, EventArgs>? IRxWindow.SourceInitializedActionWithArgs { get; set; }
        Action? IRxWindow.StateChangedAction { get; set; }
        Action<object?, EventArgs>? IRxWindow.StateChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxWindow = (IRxWindow)this;
            SetPropertyValue(NativeControl, Window.AllowsTransparencyProperty, thisAsIRxWindow.AllowsTransparency);
            SetPropertyValue(NativeControl, Window.IconProperty, thisAsIRxWindow.Icon);
            SetPropertyValue(NativeControl, Window.LeftProperty, thisAsIRxWindow.Left);
            SetPropertyValue(NativeControl, Window.ResizeModeProperty, thisAsIRxWindow.ResizeMode);
            SetPropertyValue(NativeControl, Window.ShowActivatedProperty, thisAsIRxWindow.ShowActivated);
            SetPropertyValue(NativeControl, Window.ShowInTaskbarProperty, thisAsIRxWindow.ShowInTaskbar);
            SetPropertyValue(NativeControl, Window.SizeToContentProperty, thisAsIRxWindow.SizeToContent);
            SetPropertyValue(NativeControl, Window.TaskbarItemInfoProperty, thisAsIRxWindow.TaskbarItemInfo);
            SetPropertyValue(NativeControl, Window.TitleProperty, thisAsIRxWindow.Title);
            SetPropertyValue(NativeControl, Window.TopProperty, thisAsIRxWindow.Top);
            SetPropertyValue(NativeControl, Window.TopmostProperty, thisAsIRxWindow.Topmost);
            SetPropertyValue(NativeControl, Window.WindowStateProperty, thisAsIRxWindow.WindowState);
            SetPropertyValue(NativeControl, Window.WindowStyleProperty, thisAsIRxWindow.WindowStyle);

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

            var thisAsIRxWindow = (IRxWindow)this;
            if (thisAsIRxWindow.ActivatedAction != null || thisAsIRxWindow.ActivatedActionWithArgs != null)
            {
                NativeControl.Activated += NativeControl_Activated;
            }
            if (thisAsIRxWindow.ClosedAction != null || thisAsIRxWindow.ClosedActionWithArgs != null)
            {
                NativeControl.Closed += NativeControl_Closed;
            }
            if (thisAsIRxWindow.ClosingAction != null || thisAsIRxWindow.ClosingActionWithArgs != null)
            {
                NativeControl.Closing += NativeControl_Closing;
            }
            if (thisAsIRxWindow.ContentRenderedAction != null || thisAsIRxWindow.ContentRenderedActionWithArgs != null)
            {
                NativeControl.ContentRendered += NativeControl_ContentRendered;
            }
            if (thisAsIRxWindow.DeactivatedAction != null || thisAsIRxWindow.DeactivatedActionWithArgs != null)
            {
                NativeControl.Deactivated += NativeControl_Deactivated;
            }
            if (thisAsIRxWindow.DpiChangedAction != null || thisAsIRxWindow.DpiChangedActionWithArgs != null)
            {
                NativeControl.DpiChanged += NativeControl_DpiChanged;
            }
            if (thisAsIRxWindow.LocationChangedAction != null || thisAsIRxWindow.LocationChangedActionWithArgs != null)
            {
                NativeControl.LocationChanged += NativeControl_LocationChanged;
            }
            if (thisAsIRxWindow.SourceInitializedAction != null || thisAsIRxWindow.SourceInitializedActionWithArgs != null)
            {
                NativeControl.SourceInitialized += NativeControl_SourceInitialized;
            }
            if (thisAsIRxWindow.StateChangedAction != null || thisAsIRxWindow.StateChangedActionWithArgs != null)
            {
                NativeControl.StateChanged += NativeControl_StateChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Activated(object? sender, EventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.ActivatedAction?.Invoke();
            thisAsIRxWindow.ActivatedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Closed(object? sender, EventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.ClosedAction?.Invoke();
            thisAsIRxWindow.ClosedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Closing(object? sender, CancelEventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.ClosingAction?.Invoke();
            thisAsIRxWindow.ClosingActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_ContentRendered(object? sender, EventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.ContentRenderedAction?.Invoke();
            thisAsIRxWindow.ContentRenderedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Deactivated(object? sender, EventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.DeactivatedAction?.Invoke();
            thisAsIRxWindow.DeactivatedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_DpiChanged(object? sender, DpiChangedEventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.DpiChangedAction?.Invoke();
            thisAsIRxWindow.DpiChangedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_LocationChanged(object? sender, EventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.LocationChangedAction?.Invoke();
            thisAsIRxWindow.LocationChangedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_SourceInitialized(object? sender, EventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.SourceInitializedAction?.Invoke();
            thisAsIRxWindow.SourceInitializedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_StateChanged(object? sender, EventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.StateChangedAction?.Invoke();
            thisAsIRxWindow.StateChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.Activated -= NativeControl_Activated;
                NativeControl.Closed -= NativeControl_Closed;
                NativeControl.Closing -= NativeControl_Closing;
                NativeControl.ContentRendered -= NativeControl_ContentRendered;
                NativeControl.Deactivated -= NativeControl_Deactivated;
                NativeControl.DpiChanged -= NativeControl_DpiChanged;
                NativeControl.LocationChanged -= NativeControl_LocationChanged;
                NativeControl.SourceInitialized -= NativeControl_SourceInitialized;
                NativeControl.StateChanged -= NativeControl_StateChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxWindow : RxWindow<Window>
    {
        public RxWindow()
        {

        }

        public RxWindow(Action<Window?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxWindowExtensions
    {
        public static T AllowsTransparency<T>(this T window, bool allowsTransparency) where T : IRxWindow
        {
            window.AllowsTransparency = new PropertyValue<bool>(allowsTransparency);
            return window;
        }
        public static T AllowsTransparency<T>(this T window, Func<bool> allowsTransparencyFunc) where T : IRxWindow
        {
            window.AllowsTransparency = new PropertyValue<bool>(allowsTransparencyFunc);
            return window;
        }
        public static T Icon<T>(this T window, ImageSource icon) where T : IRxWindow
        {
            window.Icon = new PropertyValue<ImageSource>(icon);
            return window;
        }
        public static T Icon<T>(this T window, Func<ImageSource> iconFunc) where T : IRxWindow
        {
            window.Icon = new PropertyValue<ImageSource>(iconFunc);
            return window;
        }

        public static T Icon<T>(this T window, string file) where T : IRxWindow
        {
            window.Icon = new PropertyValue<ImageSource>(new BitmapImage(new Uri(file)));
            return window;
        }
        /*
        public static T Icon<T>(this T window, string resourceName, Assembly sourceAssembly) where T : IRxWindow
        {
            window.Icon = new PropertyValue<ImageSource>(ImageSource.FromResource(resourceName, sourceAssembly));
            return window;
        }
        */
        public static T Icon<T>(this T window, Uri imageUri) where T : IRxWindow
        {
            window.Icon = new PropertyValue<ImageSource>(new BitmapImage(imageUri));
            return window;
        }
        /*
        public static T Icon<T>(this T window, Uri imageUri, bool cachingEnabled, TimeSpan cacheValidity) where T : IRxWindow
        {
            window.Icon = new PropertyValue<ImageSource>(new UriImageSource
            {
                Uri = imageUri,
                CachingEnabled = cachingEnabled,
                CacheValidity = cacheValidity
            });
            return window;
        }
        public static T Icon<T>(this T window, Func<Stream> imageStream) where T : IRxWindow
        {
            window.Icon = new PropertyValue<ImageSource>(ImageSource.FromStream(imageStream));
            return window;
        }
        */
        public static T Left<T>(this T window, double left) where T : IRxWindow
        {
            window.Left = new PropertyValue<double>(left);
            return window;
        }
        public static T Left<T>(this T window, Func<double> leftFunc) where T : IRxWindow
        {
            window.Left = new PropertyValue<double>(leftFunc);
            return window;
        }
        public static T ResizeMode<T>(this T window, ResizeMode resizeMode) where T : IRxWindow
        {
            window.ResizeMode = new PropertyValue<ResizeMode>(resizeMode);
            return window;
        }
        public static T ResizeMode<T>(this T window, Func<ResizeMode> resizeModeFunc) where T : IRxWindow
        {
            window.ResizeMode = new PropertyValue<ResizeMode>(resizeModeFunc);
            return window;
        }
        public static T ShowActivated<T>(this T window, bool showActivated) where T : IRxWindow
        {
            window.ShowActivated = new PropertyValue<bool>(showActivated);
            return window;
        }
        public static T ShowActivated<T>(this T window, Func<bool> showActivatedFunc) where T : IRxWindow
        {
            window.ShowActivated = new PropertyValue<bool>(showActivatedFunc);
            return window;
        }
        public static T ShowInTaskbar<T>(this T window, bool showInTaskbar) where T : IRxWindow
        {
            window.ShowInTaskbar = new PropertyValue<bool>(showInTaskbar);
            return window;
        }
        public static T ShowInTaskbar<T>(this T window, Func<bool> showInTaskbarFunc) where T : IRxWindow
        {
            window.ShowInTaskbar = new PropertyValue<bool>(showInTaskbarFunc);
            return window;
        }
        public static T SizeToContent<T>(this T window, SizeToContent sizeToContent) where T : IRxWindow
        {
            window.SizeToContent = new PropertyValue<SizeToContent>(sizeToContent);
            return window;
        }
        public static T SizeToContent<T>(this T window, Func<SizeToContent> sizeToContentFunc) where T : IRxWindow
        {
            window.SizeToContent = new PropertyValue<SizeToContent>(sizeToContentFunc);
            return window;
        }
        public static T TaskbarItemInfo<T>(this T window, TaskbarItemInfo taskbarItemInfo) where T : IRxWindow
        {
            window.TaskbarItemInfo = new PropertyValue<TaskbarItemInfo>(taskbarItemInfo);
            return window;
        }
        public static T TaskbarItemInfo<T>(this T window, Func<TaskbarItemInfo> taskbarItemInfoFunc) where T : IRxWindow
        {
            window.TaskbarItemInfo = new PropertyValue<TaskbarItemInfo>(taskbarItemInfoFunc);
            return window;
        }
        public static T Title<T>(this T window, string title) where T : IRxWindow
        {
            window.Title = new PropertyValue<string>(title);
            return window;
        }
        public static T Title<T>(this T window, Func<string> titleFunc) where T : IRxWindow
        {
            window.Title = new PropertyValue<string>(titleFunc);
            return window;
        }
        public static T Top<T>(this T window, double top) where T : IRxWindow
        {
            window.Top = new PropertyValue<double>(top);
            return window;
        }
        public static T Top<T>(this T window, Func<double> topFunc) where T : IRxWindow
        {
            window.Top = new PropertyValue<double>(topFunc);
            return window;
        }
        public static T Topmost<T>(this T window, bool topmost) where T : IRxWindow
        {
            window.Topmost = new PropertyValue<bool>(topmost);
            return window;
        }
        public static T Topmost<T>(this T window, Func<bool> topmostFunc) where T : IRxWindow
        {
            window.Topmost = new PropertyValue<bool>(topmostFunc);
            return window;
        }
        public static T WindowState<T>(this T window, WindowState windowState) where T : IRxWindow
        {
            window.WindowState = new PropertyValue<WindowState>(windowState);
            return window;
        }
        public static T WindowState<T>(this T window, Func<WindowState> windowStateFunc) where T : IRxWindow
        {
            window.WindowState = new PropertyValue<WindowState>(windowStateFunc);
            return window;
        }
        public static T WindowStyle<T>(this T window, WindowStyle windowStyle) where T : IRxWindow
        {
            window.WindowStyle = new PropertyValue<WindowStyle>(windowStyle);
            return window;
        }
        public static T WindowStyle<T>(this T window, Func<WindowStyle> windowStyleFunc) where T : IRxWindow
        {
            window.WindowStyle = new PropertyValue<WindowStyle>(windowStyleFunc);
            return window;
        }
        public static T OnActivated<T>(this T window, Action activatedAction) where T : IRxWindow
        {
            window.ActivatedAction = activatedAction;
            return window;
        }

        public static T OnActivated<T>(this T window, Action<object?, EventArgs> activatedActionWithArgs) where T : IRxWindow
        {
            window.ActivatedActionWithArgs = activatedActionWithArgs;
            return window;
        }
        public static T OnClosed<T>(this T window, Action closedAction) where T : IRxWindow
        {
            window.ClosedAction = closedAction;
            return window;
        }

        public static T OnClosed<T>(this T window, Action<object?, EventArgs> closedActionWithArgs) where T : IRxWindow
        {
            window.ClosedActionWithArgs = closedActionWithArgs;
            return window;
        }
        public static T OnClosing<T>(this T window, Action closingAction) where T : IRxWindow
        {
            window.ClosingAction = closingAction;
            return window;
        }

        public static T OnClosing<T>(this T window, Action<object?, CancelEventArgs> closingActionWithArgs) where T : IRxWindow
        {
            window.ClosingActionWithArgs = closingActionWithArgs;
            return window;
        }
        public static T OnContentRendered<T>(this T window, Action contentrenderedAction) where T : IRxWindow
        {
            window.ContentRenderedAction = contentrenderedAction;
            return window;
        }

        public static T OnContentRendered<T>(this T window, Action<object?, EventArgs> contentrenderedActionWithArgs) where T : IRxWindow
        {
            window.ContentRenderedActionWithArgs = contentrenderedActionWithArgs;
            return window;
        }
        public static T OnDeactivated<T>(this T window, Action deactivatedAction) where T : IRxWindow
        {
            window.DeactivatedAction = deactivatedAction;
            return window;
        }

        public static T OnDeactivated<T>(this T window, Action<object?, EventArgs> deactivatedActionWithArgs) where T : IRxWindow
        {
            window.DeactivatedActionWithArgs = deactivatedActionWithArgs;
            return window;
        }
        public static T OnDpiChanged<T>(this T window, Action dpichangedAction) where T : IRxWindow
        {
            window.DpiChangedAction = dpichangedAction;
            return window;
        }

        public static T OnDpiChanged<T>(this T window, Action<object?, DpiChangedEventArgs> dpichangedActionWithArgs) where T : IRxWindow
        {
            window.DpiChangedActionWithArgs = dpichangedActionWithArgs;
            return window;
        }
        public static T OnLocationChanged<T>(this T window, Action locationchangedAction) where T : IRxWindow
        {
            window.LocationChangedAction = locationchangedAction;
            return window;
        }

        public static T OnLocationChanged<T>(this T window, Action<object?, EventArgs> locationchangedActionWithArgs) where T : IRxWindow
        {
            window.LocationChangedActionWithArgs = locationchangedActionWithArgs;
            return window;
        }
        public static T OnSourceInitialized<T>(this T window, Action sourceinitializedAction) where T : IRxWindow
        {
            window.SourceInitializedAction = sourceinitializedAction;
            return window;
        }

        public static T OnSourceInitialized<T>(this T window, Action<object?, EventArgs> sourceinitializedActionWithArgs) where T : IRxWindow
        {
            window.SourceInitializedActionWithArgs = sourceinitializedActionWithArgs;
            return window;
        }
        public static T OnStateChanged<T>(this T window, Action statechangedAction) where T : IRxWindow
        {
            window.StateChangedAction = statechangedAction;
            return window;
        }

        public static T OnStateChanged<T>(this T window, Action<object?, EventArgs> statechangedActionWithArgs) where T : IRxWindow
        {
            window.StateChangedActionWithArgs = statechangedActionWithArgs;
            return window;
        }
    }
}
