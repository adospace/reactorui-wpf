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
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;

namespace WpfReactorUI
{
    public partial interface IRxCommandBar : IRxControl
    {
        PropertyValue<Style>? CommandBarOverflowPresenterStyle { get; set; }
        PropertyValue<object>? Content { get; set; }
        PropertyValue<CornerRadius>? CornerRadius { get; set; }
        PropertyValue<CommandBarDefaultLabelPosition>? DefaultLabelPosition { get; set; }
        PropertyValue<bool>? IsDynamicOverflowEnabled { get; set; }
        PropertyValue<bool>? IsOpen { get; set; }
        PropertyValue<CommandBarOverflowButtonVisibility>? OverflowButtonVisibility { get; set; }

    }

    public partial class RxCommandBar<T> : RxControl<T>, IRxCommandBar where T : CommandBar, new()
    {
        public RxCommandBar()
        {

        }

        public RxCommandBar(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Style>? IRxCommandBar.CommandBarOverflowPresenterStyle { get; set; }
        PropertyValue<object>? IRxCommandBar.Content { get; set; }
        PropertyValue<CornerRadius>? IRxCommandBar.CornerRadius { get; set; }
        PropertyValue<CommandBarDefaultLabelPosition>? IRxCommandBar.DefaultLabelPosition { get; set; }
        PropertyValue<bool>? IRxCommandBar.IsDynamicOverflowEnabled { get; set; }
        PropertyValue<bool>? IRxCommandBar.IsOpen { get; set; }
        PropertyValue<CommandBarOverflowButtonVisibility>? IRxCommandBar.OverflowButtonVisibility { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxCommandBar = (IRxCommandBar)this;
            SetPropertyValue(NativeControl, CommandBar.CommandBarOverflowPresenterStyleProperty, thisAsIRxCommandBar.CommandBarOverflowPresenterStyle);
            SetPropertyValue(NativeControl, CommandBar.ContentProperty, thisAsIRxCommandBar.Content);
            SetPropertyValue(NativeControl, CommandBar.CornerRadiusProperty, thisAsIRxCommandBar.CornerRadius);
            SetPropertyValue(NativeControl, CommandBar.DefaultLabelPositionProperty, thisAsIRxCommandBar.DefaultLabelPosition);
            SetPropertyValue(NativeControl, CommandBar.IsDynamicOverflowEnabledProperty, thisAsIRxCommandBar.IsDynamicOverflowEnabled);
            SetPropertyValue(NativeControl, CommandBar.IsOpenProperty, thisAsIRxCommandBar.IsOpen);
            SetPropertyValue(NativeControl, CommandBar.OverflowButtonVisibilityProperty, thisAsIRxCommandBar.OverflowButtonVisibility);

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
    public partial class RxCommandBar : RxCommandBar<CommandBar>
    {
        public RxCommandBar()
        {

        }

        public RxCommandBar(Action<CommandBar?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxCommandBarExtensions
    {
        public static T CommandBarOverflowPresenterStyle<T>(this T commandbar, Style commandBarOverflowPresenterStyle) where T : IRxCommandBar
        {
            commandbar.CommandBarOverflowPresenterStyle = new PropertyValue<Style>(commandBarOverflowPresenterStyle);
            return commandbar;
        }
        public static T CommandBarOverflowPresenterStyle<T>(this T commandbar, Func<Style> commandBarOverflowPresenterStyleFunc) where T : IRxCommandBar
        {
            commandbar.CommandBarOverflowPresenterStyle = new PropertyValue<Style>(commandBarOverflowPresenterStyleFunc);
            return commandbar;
        }
        public static T Content<T>(this T commandbar, object content) where T : IRxCommandBar
        {
            commandbar.Content = new PropertyValue<object>(content);
            return commandbar;
        }
        public static T Content<T>(this T commandbar, Func<object> contentFunc) where T : IRxCommandBar
        {
            commandbar.Content = new PropertyValue<object>(contentFunc);
            return commandbar;
        }
        public static T CornerRadius<T>(this T commandbar, CornerRadius cornerRadius) where T : IRxCommandBar
        {
            commandbar.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return commandbar;
        }
        public static T CornerRadius<T>(this T commandbar, Func<CornerRadius> cornerRadiusFunc) where T : IRxCommandBar
        {
            commandbar.CornerRadius = new PropertyValue<CornerRadius>(cornerRadiusFunc);
            return commandbar;
        }
        public static T DefaultLabelPosition<T>(this T commandbar, CommandBarDefaultLabelPosition defaultLabelPosition) where T : IRxCommandBar
        {
            commandbar.DefaultLabelPosition = new PropertyValue<CommandBarDefaultLabelPosition>(defaultLabelPosition);
            return commandbar;
        }
        public static T DefaultLabelPosition<T>(this T commandbar, Func<CommandBarDefaultLabelPosition> defaultLabelPositionFunc) where T : IRxCommandBar
        {
            commandbar.DefaultLabelPosition = new PropertyValue<CommandBarDefaultLabelPosition>(defaultLabelPositionFunc);
            return commandbar;
        }
        public static T IsDynamicOverflowEnabled<T>(this T commandbar, bool isDynamicOverflowEnabled) where T : IRxCommandBar
        {
            commandbar.IsDynamicOverflowEnabled = new PropertyValue<bool>(isDynamicOverflowEnabled);
            return commandbar;
        }
        public static T IsDynamicOverflowEnabled<T>(this T commandbar, Func<bool> isDynamicOverflowEnabledFunc) where T : IRxCommandBar
        {
            commandbar.IsDynamicOverflowEnabled = new PropertyValue<bool>(isDynamicOverflowEnabledFunc);
            return commandbar;
        }
        public static T IsOpen<T>(this T commandbar, bool isOpen) where T : IRxCommandBar
        {
            commandbar.IsOpen = new PropertyValue<bool>(isOpen);
            return commandbar;
        }
        public static T IsOpen<T>(this T commandbar, Func<bool> isOpenFunc) where T : IRxCommandBar
        {
            commandbar.IsOpen = new PropertyValue<bool>(isOpenFunc);
            return commandbar;
        }
        public static T OverflowButtonVisibility<T>(this T commandbar, CommandBarOverflowButtonVisibility overflowButtonVisibility) where T : IRxCommandBar
        {
            commandbar.OverflowButtonVisibility = new PropertyValue<CommandBarOverflowButtonVisibility>(overflowButtonVisibility);
            return commandbar;
        }
        public static T OverflowButtonVisibility<T>(this T commandbar, Func<CommandBarOverflowButtonVisibility> overflowButtonVisibilityFunc) where T : IRxCommandBar
        {
            commandbar.OverflowButtonVisibility = new PropertyValue<CommandBarOverflowButtonVisibility>(overflowButtonVisibilityFunc);
            return commandbar;
        }
    }
}
