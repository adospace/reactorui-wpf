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
    public partial interface IRxMenuItem : IRxHeaderedItemsControl
    {
        PropertyValue<ICommand>? Command { get; set; }
        PropertyValue<object>? CommandParameter { get; set; }
        PropertyValue<IInputElement>? CommandTarget { get; set; }
        PropertyValue<object>? Icon { get; set; }
        PropertyValue<string>? InputGestureText { get; set; }
        PropertyValue<bool>? IsCheckable { get; set; }
        PropertyValue<bool>? IsChecked { get; set; }
        PropertyValue<bool>? IsSubmenuOpen { get; set; }
        PropertyValue<ItemContainerTemplateSelector>? ItemContainerTemplateSelector { get; set; }
        PropertyValue<bool>? StaysOpenOnClick { get; set; }
        PropertyValue<bool>? UsesItemContainerTemplate { get; set; }

        Action? CheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? CheckedActionWithArgs { get; set; }
        Action? ClickAction { get; set; }
        Action<object?, RoutedEventArgs>? ClickActionWithArgs { get; set; }
        Action? SubmenuClosedAction { get; set; }
        Action<object?, RoutedEventArgs>? SubmenuClosedActionWithArgs { get; set; }
        Action? SubmenuOpenedAction { get; set; }
        Action<object?, RoutedEventArgs>? SubmenuOpenedActionWithArgs { get; set; }
        Action? UncheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? UncheckedActionWithArgs { get; set; }
    }
    public partial class RxMenuItem<T> : RxHeaderedItemsControl<T>, IRxMenuItem where T : MenuItem, new()
    {
        public RxMenuItem()
        {

        }

        public RxMenuItem(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<ICommand>? IRxMenuItem.Command { get; set; }
        PropertyValue<object>? IRxMenuItem.CommandParameter { get; set; }
        PropertyValue<IInputElement>? IRxMenuItem.CommandTarget { get; set; }
        PropertyValue<object>? IRxMenuItem.Icon { get; set; }
        PropertyValue<string>? IRxMenuItem.InputGestureText { get; set; }
        PropertyValue<bool>? IRxMenuItem.IsCheckable { get; set; }
        PropertyValue<bool>? IRxMenuItem.IsChecked { get; set; }
        PropertyValue<bool>? IRxMenuItem.IsSubmenuOpen { get; set; }
        PropertyValue<ItemContainerTemplateSelector>? IRxMenuItem.ItemContainerTemplateSelector { get; set; }
        PropertyValue<bool>? IRxMenuItem.StaysOpenOnClick { get; set; }
        PropertyValue<bool>? IRxMenuItem.UsesItemContainerTemplate { get; set; }

        Action? IRxMenuItem.CheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxMenuItem.CheckedActionWithArgs { get; set; }
        Action? IRxMenuItem.ClickAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxMenuItem.ClickActionWithArgs { get; set; }
        Action? IRxMenuItem.SubmenuClosedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxMenuItem.SubmenuClosedActionWithArgs { get; set; }
        Action? IRxMenuItem.SubmenuOpenedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxMenuItem.SubmenuOpenedActionWithArgs { get; set; }
        Action? IRxMenuItem.UncheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxMenuItem.UncheckedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxMenuItem = (IRxMenuItem)this;
            SetPropertyValue(NativeControl, MenuItem.CommandProperty, thisAsIRxMenuItem.Command);
            SetPropertyValue(NativeControl, MenuItem.CommandParameterProperty, thisAsIRxMenuItem.CommandParameter);
            SetPropertyValue(NativeControl, MenuItem.CommandTargetProperty, thisAsIRxMenuItem.CommandTarget);
            SetPropertyValue(NativeControl, MenuItem.IconProperty, thisAsIRxMenuItem.Icon);
            SetPropertyValue(NativeControl, MenuItem.InputGestureTextProperty, thisAsIRxMenuItem.InputGestureText);
            SetPropertyValue(NativeControl, MenuItem.IsCheckableProperty, thisAsIRxMenuItem.IsCheckable);
            SetPropertyValue(NativeControl, MenuItem.IsCheckedProperty, thisAsIRxMenuItem.IsChecked);
            SetPropertyValue(NativeControl, MenuItem.IsSubmenuOpenProperty, thisAsIRxMenuItem.IsSubmenuOpen);
            SetPropertyValue(NativeControl, MenuItem.ItemContainerTemplateSelectorProperty, thisAsIRxMenuItem.ItemContainerTemplateSelector);
            SetPropertyValue(NativeControl, MenuItem.StaysOpenOnClickProperty, thisAsIRxMenuItem.StaysOpenOnClick);
            SetPropertyValue(NativeControl, MenuItem.UsesItemContainerTemplateProperty, thisAsIRxMenuItem.UsesItemContainerTemplate);

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

            var thisAsIRxMenuItem = (IRxMenuItem)this;
            if (thisAsIRxMenuItem.CheckedAction != null || thisAsIRxMenuItem.CheckedActionWithArgs != null)
            {
                NativeControl.Checked += NativeControl_Checked;
            }
            if (thisAsIRxMenuItem.ClickAction != null || thisAsIRxMenuItem.ClickActionWithArgs != null)
            {
                NativeControl.Click += NativeControl_Click;
            }
            if (thisAsIRxMenuItem.SubmenuClosedAction != null || thisAsIRxMenuItem.SubmenuClosedActionWithArgs != null)
            {
                NativeControl.SubmenuClosed += NativeControl_SubmenuClosed;
            }
            if (thisAsIRxMenuItem.SubmenuOpenedAction != null || thisAsIRxMenuItem.SubmenuOpenedActionWithArgs != null)
            {
                NativeControl.SubmenuOpened += NativeControl_SubmenuOpened;
            }
            if (thisAsIRxMenuItem.UncheckedAction != null || thisAsIRxMenuItem.UncheckedActionWithArgs != null)
            {
                NativeControl.Unchecked += NativeControl_Unchecked;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Checked(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxMenuItem = (IRxMenuItem)this;
            thisAsIRxMenuItem.CheckedAction?.Invoke();
            thisAsIRxMenuItem.CheckedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Click(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxMenuItem = (IRxMenuItem)this;
            thisAsIRxMenuItem.ClickAction?.Invoke();
            thisAsIRxMenuItem.ClickActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_SubmenuClosed(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxMenuItem = (IRxMenuItem)this;
            thisAsIRxMenuItem.SubmenuClosedAction?.Invoke();
            thisAsIRxMenuItem.SubmenuClosedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_SubmenuOpened(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxMenuItem = (IRxMenuItem)this;
            thisAsIRxMenuItem.SubmenuOpenedAction?.Invoke();
            thisAsIRxMenuItem.SubmenuOpenedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Unchecked(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxMenuItem = (IRxMenuItem)this;
            thisAsIRxMenuItem.UncheckedAction?.Invoke();
            thisAsIRxMenuItem.UncheckedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.Checked -= NativeControl_Checked;
                NativeControl.Click -= NativeControl_Click;
                NativeControl.SubmenuClosed -= NativeControl_SubmenuClosed;
                NativeControl.SubmenuOpened -= NativeControl_SubmenuOpened;
                NativeControl.Unchecked -= NativeControl_Unchecked;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxMenuItem : RxMenuItem<MenuItem>
    {
        public RxMenuItem()
        {

        }

        public RxMenuItem(Action<MenuItem?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxMenuItemExtensions
    {
        public static T Command<T>(this T menuitem, ICommand command) where T : IRxMenuItem
        {
            menuitem.Command = new PropertyValue<ICommand>(command);
            return menuitem;
        }
        public static T Command<T>(this T menuitem, Func<ICommand> commandFunc) where T : IRxMenuItem
        {
            menuitem.Command = new PropertyValue<ICommand>(commandFunc);
            return menuitem;
        }
        public static T Command<T>(this T menuitem, Action action) where T : IRxMenuItem
        {
            menuitem.Command = new PropertyValue<ICommand>(new ActionCommand(action));
            return menuitem;
        }
        public static T CommandParameter<T>(this T menuitem, object commandParameter) where T : IRxMenuItem
        {
            menuitem.CommandParameter = new PropertyValue<object>(commandParameter);
            return menuitem;
        }
        public static T CommandParameter<T>(this T menuitem, Func<object> commandParameterFunc) where T : IRxMenuItem
        {
            menuitem.CommandParameter = new PropertyValue<object>(commandParameterFunc);
            return menuitem;
        }
        public static T CommandTarget<T>(this T menuitem, IInputElement commandTarget) where T : IRxMenuItem
        {
            menuitem.CommandTarget = new PropertyValue<IInputElement>(commandTarget);
            return menuitem;
        }
        public static T CommandTarget<T>(this T menuitem, Func<IInputElement> commandTargetFunc) where T : IRxMenuItem
        {
            menuitem.CommandTarget = new PropertyValue<IInputElement>(commandTargetFunc);
            return menuitem;
        }
        public static T Icon<T>(this T menuitem, object icon) where T : IRxMenuItem
        {
            menuitem.Icon = new PropertyValue<object>(icon);
            return menuitem;
        }
        public static T Icon<T>(this T menuitem, Func<object> iconFunc) where T : IRxMenuItem
        {
            menuitem.Icon = new PropertyValue<object>(iconFunc);
            return menuitem;
        }
        public static T InputGestureText<T>(this T menuitem, string inputGestureText) where T : IRxMenuItem
        {
            menuitem.InputGestureText = new PropertyValue<string>(inputGestureText);
            return menuitem;
        }
        public static T InputGestureText<T>(this T menuitem, Func<string> inputGestureTextFunc) where T : IRxMenuItem
        {
            menuitem.InputGestureText = new PropertyValue<string>(inputGestureTextFunc);
            return menuitem;
        }
        public static T IsCheckable<T>(this T menuitem, bool isCheckable) where T : IRxMenuItem
        {
            menuitem.IsCheckable = new PropertyValue<bool>(isCheckable);
            return menuitem;
        }
        public static T IsCheckable<T>(this T menuitem, Func<bool> isCheckableFunc) where T : IRxMenuItem
        {
            menuitem.IsCheckable = new PropertyValue<bool>(isCheckableFunc);
            return menuitem;
        }
        public static T IsChecked<T>(this T menuitem, bool isChecked) where T : IRxMenuItem
        {
            menuitem.IsChecked = new PropertyValue<bool>(isChecked);
            return menuitem;
        }
        public static T IsChecked<T>(this T menuitem, Func<bool> isCheckedFunc) where T : IRxMenuItem
        {
            menuitem.IsChecked = new PropertyValue<bool>(isCheckedFunc);
            return menuitem;
        }
        public static T IsSubmenuOpen<T>(this T menuitem, bool isSubmenuOpen) where T : IRxMenuItem
        {
            menuitem.IsSubmenuOpen = new PropertyValue<bool>(isSubmenuOpen);
            return menuitem;
        }
        public static T IsSubmenuOpen<T>(this T menuitem, Func<bool> isSubmenuOpenFunc) where T : IRxMenuItem
        {
            menuitem.IsSubmenuOpen = new PropertyValue<bool>(isSubmenuOpenFunc);
            return menuitem;
        }
        public static T ItemContainerTemplateSelector<T>(this T menuitem, ItemContainerTemplateSelector itemContainerTemplateSelector) where T : IRxMenuItem
        {
            menuitem.ItemContainerTemplateSelector = new PropertyValue<ItemContainerTemplateSelector>(itemContainerTemplateSelector);
            return menuitem;
        }
        public static T ItemContainerTemplateSelector<T>(this T menuitem, Func<ItemContainerTemplateSelector> itemContainerTemplateSelectorFunc) where T : IRxMenuItem
        {
            menuitem.ItemContainerTemplateSelector = new PropertyValue<ItemContainerTemplateSelector>(itemContainerTemplateSelectorFunc);
            return menuitem;
        }
        public static T StaysOpenOnClick<T>(this T menuitem, bool staysOpenOnClick) where T : IRxMenuItem
        {
            menuitem.StaysOpenOnClick = new PropertyValue<bool>(staysOpenOnClick);
            return menuitem;
        }
        public static T StaysOpenOnClick<T>(this T menuitem, Func<bool> staysOpenOnClickFunc) where T : IRxMenuItem
        {
            menuitem.StaysOpenOnClick = new PropertyValue<bool>(staysOpenOnClickFunc);
            return menuitem;
        }
        public static T UsesItemContainerTemplate<T>(this T menuitem, bool usesItemContainerTemplate) where T : IRxMenuItem
        {
            menuitem.UsesItemContainerTemplate = new PropertyValue<bool>(usesItemContainerTemplate);
            return menuitem;
        }
        public static T UsesItemContainerTemplate<T>(this T menuitem, Func<bool> usesItemContainerTemplateFunc) where T : IRxMenuItem
        {
            menuitem.UsesItemContainerTemplate = new PropertyValue<bool>(usesItemContainerTemplateFunc);
            return menuitem;
        }
        public static T OnChecked<T>(this T menuitem, Action checkedAction) where T : IRxMenuItem
        {
            menuitem.CheckedAction = checkedAction;
            return menuitem;
        }

        public static T OnChecked<T>(this T menuitem, Action<object?, RoutedEventArgs> checkedActionWithArgs) where T : IRxMenuItem
        {
            menuitem.CheckedActionWithArgs = checkedActionWithArgs;
            return menuitem;
        }
        public static T OnClick<T>(this T menuitem, Action clickAction) where T : IRxMenuItem
        {
            menuitem.ClickAction = clickAction;
            return menuitem;
        }

        public static T OnClick<T>(this T menuitem, Action<object?, RoutedEventArgs> clickActionWithArgs) where T : IRxMenuItem
        {
            menuitem.ClickActionWithArgs = clickActionWithArgs;
            return menuitem;
        }
        public static T OnSubmenuClosed<T>(this T menuitem, Action submenuclosedAction) where T : IRxMenuItem
        {
            menuitem.SubmenuClosedAction = submenuclosedAction;
            return menuitem;
        }

        public static T OnSubmenuClosed<T>(this T menuitem, Action<object?, RoutedEventArgs> submenuclosedActionWithArgs) where T : IRxMenuItem
        {
            menuitem.SubmenuClosedActionWithArgs = submenuclosedActionWithArgs;
            return menuitem;
        }
        public static T OnSubmenuOpened<T>(this T menuitem, Action submenuopenedAction) where T : IRxMenuItem
        {
            menuitem.SubmenuOpenedAction = submenuopenedAction;
            return menuitem;
        }

        public static T OnSubmenuOpened<T>(this T menuitem, Action<object?, RoutedEventArgs> submenuopenedActionWithArgs) where T : IRxMenuItem
        {
            menuitem.SubmenuOpenedActionWithArgs = submenuopenedActionWithArgs;
            return menuitem;
        }
        public static T OnUnchecked<T>(this T menuitem, Action uncheckedAction) where T : IRxMenuItem
        {
            menuitem.UncheckedAction = uncheckedAction;
            return menuitem;
        }

        public static T OnUnchecked<T>(this T menuitem, Action<object?, RoutedEventArgs> uncheckedActionWithArgs) where T : IRxMenuItem
        {
            menuitem.UncheckedActionWithArgs = uncheckedActionWithArgs;
            return menuitem;
        }
    }
}
