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

        Action? DpiChangedAction { get; set; }
        Action<object?, DpiChangedEventArgs>? DpiChangedActionWithArgs { get; set; }
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

        Action? IRxWindow.DpiChangedAction { get; set; }
        Action<object?, DpiChangedEventArgs>? IRxWindow.DpiChangedActionWithArgs { get; set; }

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
            if (thisAsIRxWindow.DpiChangedAction != null || thisAsIRxWindow.DpiChangedActionWithArgs != null)
            {
                NativeControl.DpiChanged += NativeControl_DpiChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_DpiChanged(object? sender, DpiChangedEventArgs e)
        {
            var thisAsIRxWindow = (IRxWindow)this;
            thisAsIRxWindow.DpiChangedAction?.Invoke();
            thisAsIRxWindow.DpiChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.DpiChanged -= NativeControl_DpiChanged;
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
    }
}
