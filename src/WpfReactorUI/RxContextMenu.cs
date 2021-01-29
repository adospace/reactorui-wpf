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
    public partial interface IRxContextMenu : IRxMenuBase
    {
        PropertyValue<CustomPopupPlacementCallback>? CustomPopupPlacementCallback { get; set; }
        PropertyValue<bool>? HasDropShadow { get; set; }
        PropertyValue<double>? HorizontalOffset { get; set; }
        PropertyValue<bool>? IsOpen { get; set; }
        PropertyValue<PlacementMode>? Placement { get; set; }
        PropertyValue<Rect>? PlacementRectangle { get; set; }
        PropertyValue<UIElement>? PlacementTarget { get; set; }
        PropertyValue<bool>? StaysOpen { get; set; }
        PropertyValue<double>? VerticalOffset { get; set; }

        Action? ClosedAction { get; set; }
        Action<object?, RoutedEventArgs>? ClosedActionWithArgs { get; set; }
        Action? OpenedAction { get; set; }
        Action<object?, RoutedEventArgs>? OpenedActionWithArgs { get; set; }
    }

    public partial class RxContextMenu<T> : RxMenuBase<T>, IRxContextMenu where T : ContextMenu, new()
    {
        public RxContextMenu()
        {

        }

        public RxContextMenu(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<CustomPopupPlacementCallback>? IRxContextMenu.CustomPopupPlacementCallback { get; set; }
        PropertyValue<bool>? IRxContextMenu.HasDropShadow { get; set; }
        PropertyValue<double>? IRxContextMenu.HorizontalOffset { get; set; }
        PropertyValue<bool>? IRxContextMenu.IsOpen { get; set; }
        PropertyValue<PlacementMode>? IRxContextMenu.Placement { get; set; }
        PropertyValue<Rect>? IRxContextMenu.PlacementRectangle { get; set; }
        PropertyValue<UIElement>? IRxContextMenu.PlacementTarget { get; set; }
        PropertyValue<bool>? IRxContextMenu.StaysOpen { get; set; }
        PropertyValue<double>? IRxContextMenu.VerticalOffset { get; set; }

        Action? IRxContextMenu.ClosedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxContextMenu.ClosedActionWithArgs { get; set; }
        Action? IRxContextMenu.OpenedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxContextMenu.OpenedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxContextMenu = (IRxContextMenu)this;
            SetPropertyValue(NativeControl, ContextMenu.CustomPopupPlacementCallbackProperty, thisAsIRxContextMenu.CustomPopupPlacementCallback);
            SetPropertyValue(NativeControl, ContextMenu.HasDropShadowProperty, thisAsIRxContextMenu.HasDropShadow);
            SetPropertyValue(NativeControl, ContextMenu.HorizontalOffsetProperty, thisAsIRxContextMenu.HorizontalOffset);
            SetPropertyValue(NativeControl, ContextMenu.IsOpenProperty, thisAsIRxContextMenu.IsOpen);
            SetPropertyValue(NativeControl, ContextMenu.PlacementProperty, thisAsIRxContextMenu.Placement);
            SetPropertyValue(NativeControl, ContextMenu.PlacementRectangleProperty, thisAsIRxContextMenu.PlacementRectangle);
            SetPropertyValue(NativeControl, ContextMenu.PlacementTargetProperty, thisAsIRxContextMenu.PlacementTarget);
            SetPropertyValue(NativeControl, ContextMenu.StaysOpenProperty, thisAsIRxContextMenu.StaysOpen);
            SetPropertyValue(NativeControl, ContextMenu.VerticalOffsetProperty, thisAsIRxContextMenu.VerticalOffset);

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

            var thisAsIRxContextMenu = (IRxContextMenu)this;
            if (thisAsIRxContextMenu.ClosedAction != null || thisAsIRxContextMenu.ClosedActionWithArgs != null)
            {
                NativeControl.Closed += NativeControl_Closed;
            }
            if (thisAsIRxContextMenu.OpenedAction != null || thisAsIRxContextMenu.OpenedActionWithArgs != null)
            {
                NativeControl.Opened += NativeControl_Opened;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Closed(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxContextMenu = (IRxContextMenu)this;
            thisAsIRxContextMenu.ClosedAction?.Invoke();
            thisAsIRxContextMenu.ClosedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Opened(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxContextMenu = (IRxContextMenu)this;
            thisAsIRxContextMenu.OpenedAction?.Invoke();
            thisAsIRxContextMenu.OpenedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.Closed -= NativeControl_Closed;
                NativeControl.Opened -= NativeControl_Opened;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxContextMenu : RxContextMenu<ContextMenu>
    {
        public RxContextMenu()
        {

        }

        public RxContextMenu(Action<ContextMenu?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxContextMenuExtensions
    {
        public static T CustomPopupPlacementCallback<T>(this T contextmenu, CustomPopupPlacementCallback customPopupPlacementCallback) where T : IRxContextMenu
        {
            contextmenu.CustomPopupPlacementCallback = new PropertyValue<CustomPopupPlacementCallback>(customPopupPlacementCallback);
            return contextmenu;
        }
        public static T CustomPopupPlacementCallback<T>(this T contextmenu, Func<CustomPopupPlacementCallback> customPopupPlacementCallbackFunc) where T : IRxContextMenu
        {
            contextmenu.CustomPopupPlacementCallback = new PropertyValue<CustomPopupPlacementCallback>(customPopupPlacementCallbackFunc);
            return contextmenu;
        }
        public static T HasDropShadow<T>(this T contextmenu, bool hasDropShadow) where T : IRxContextMenu
        {
            contextmenu.HasDropShadow = new PropertyValue<bool>(hasDropShadow);
            return contextmenu;
        }
        public static T HasDropShadow<T>(this T contextmenu, Func<bool> hasDropShadowFunc) where T : IRxContextMenu
        {
            contextmenu.HasDropShadow = new PropertyValue<bool>(hasDropShadowFunc);
            return contextmenu;
        }
        public static T HorizontalOffset<T>(this T contextmenu, double horizontalOffset) where T : IRxContextMenu
        {
            contextmenu.HorizontalOffset = new PropertyValue<double>(horizontalOffset);
            return contextmenu;
        }
        public static T HorizontalOffset<T>(this T contextmenu, Func<double> horizontalOffsetFunc) where T : IRxContextMenu
        {
            contextmenu.HorizontalOffset = new PropertyValue<double>(horizontalOffsetFunc);
            return contextmenu;
        }
        public static T IsOpen<T>(this T contextmenu, bool isOpen) where T : IRxContextMenu
        {
            contextmenu.IsOpen = new PropertyValue<bool>(isOpen);
            return contextmenu;
        }
        public static T IsOpen<T>(this T contextmenu, Func<bool> isOpenFunc) where T : IRxContextMenu
        {
            contextmenu.IsOpen = new PropertyValue<bool>(isOpenFunc);
            return contextmenu;
        }
        public static T Placement<T>(this T contextmenu, PlacementMode placement) where T : IRxContextMenu
        {
            contextmenu.Placement = new PropertyValue<PlacementMode>(placement);
            return contextmenu;
        }
        public static T Placement<T>(this T contextmenu, Func<PlacementMode> placementFunc) where T : IRxContextMenu
        {
            contextmenu.Placement = new PropertyValue<PlacementMode>(placementFunc);
            return contextmenu;
        }
        public static T PlacementRectangle<T>(this T contextmenu, Rect placementRectangle) where T : IRxContextMenu
        {
            contextmenu.PlacementRectangle = new PropertyValue<Rect>(placementRectangle);
            return contextmenu;
        }
        public static T PlacementRectangle<T>(this T contextmenu, Func<Rect> placementRectangleFunc) where T : IRxContextMenu
        {
            contextmenu.PlacementRectangle = new PropertyValue<Rect>(placementRectangleFunc);
            return contextmenu;
        }
        public static T PlacementTarget<T>(this T contextmenu, UIElement placementTarget) where T : IRxContextMenu
        {
            contextmenu.PlacementTarget = new PropertyValue<UIElement>(placementTarget);
            return contextmenu;
        }
        public static T PlacementTarget<T>(this T contextmenu, Func<UIElement> placementTargetFunc) where T : IRxContextMenu
        {
            contextmenu.PlacementTarget = new PropertyValue<UIElement>(placementTargetFunc);
            return contextmenu;
        }
        public static T StaysOpen<T>(this T contextmenu, bool staysOpen) where T : IRxContextMenu
        {
            contextmenu.StaysOpen = new PropertyValue<bool>(staysOpen);
            return contextmenu;
        }
        public static T StaysOpen<T>(this T contextmenu, Func<bool> staysOpenFunc) where T : IRxContextMenu
        {
            contextmenu.StaysOpen = new PropertyValue<bool>(staysOpenFunc);
            return contextmenu;
        }
        public static T VerticalOffset<T>(this T contextmenu, double verticalOffset) where T : IRxContextMenu
        {
            contextmenu.VerticalOffset = new PropertyValue<double>(verticalOffset);
            return contextmenu;
        }
        public static T VerticalOffset<T>(this T contextmenu, Func<double> verticalOffsetFunc) where T : IRxContextMenu
        {
            contextmenu.VerticalOffset = new PropertyValue<double>(verticalOffsetFunc);
            return contextmenu;
        }
        public static T OnClosed<T>(this T contextmenu, Action closedAction) where T : IRxContextMenu
        {
            contextmenu.ClosedAction = closedAction;
            return contextmenu;
        }

        public static T OnClosed<T>(this T contextmenu, Action<object?, RoutedEventArgs> closedActionWithArgs) where T : IRxContextMenu
        {
            contextmenu.ClosedActionWithArgs = closedActionWithArgs;
            return contextmenu;
        }
        public static T OnOpened<T>(this T contextmenu, Action openedAction) where T : IRxContextMenu
        {
            contextmenu.OpenedAction = openedAction;
            return contextmenu;
        }

        public static T OnOpened<T>(this T contextmenu, Action<object?, RoutedEventArgs> openedActionWithArgs) where T : IRxContextMenu
        {
            contextmenu.OpenedActionWithArgs = openedActionWithArgs;
            return contextmenu;
        }
    }
}
