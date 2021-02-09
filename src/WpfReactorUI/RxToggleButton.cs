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
    public partial interface IRxToggleButton : IRxButtonBase
    {
        PropertyValue<bool?>? IsChecked { get; set; }
        PropertyValue<bool>? IsThreeState { get; set; }

        Action? CheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? CheckedActionWithArgs { get; set; }
        Action? IndeterminateAction { get; set; }
        Action<object?, RoutedEventArgs>? IndeterminateActionWithArgs { get; set; }
        Action? UncheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? UncheckedActionWithArgs { get; set; }
    }
    public partial class RxToggleButton<T> : RxButtonBase<T>, IRxToggleButton where T : ToggleButton, new()
    {
        public RxToggleButton()
        {

        }

        public RxToggleButton(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool?>? IRxToggleButton.IsChecked { get; set; }
        PropertyValue<bool>? IRxToggleButton.IsThreeState { get; set; }

        Action? IRxToggleButton.CheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxToggleButton.CheckedActionWithArgs { get; set; }
        Action? IRxToggleButton.IndeterminateAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxToggleButton.IndeterminateActionWithArgs { get; set; }
        Action? IRxToggleButton.UncheckedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxToggleButton.UncheckedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxToggleButton = (IRxToggleButton)this;
            SetPropertyValue(NativeControl, ToggleButton.IsCheckedProperty, thisAsIRxToggleButton.IsChecked);
            SetPropertyValue(NativeControl, ToggleButton.IsThreeStateProperty, thisAsIRxToggleButton.IsThreeState);

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

            var thisAsIRxToggleButton = (IRxToggleButton)this;
            if (thisAsIRxToggleButton.CheckedAction != null || thisAsIRxToggleButton.CheckedActionWithArgs != null)
            {
                NativeControl.Checked += NativeControl_Checked;
            }
            if (thisAsIRxToggleButton.IndeterminateAction != null || thisAsIRxToggleButton.IndeterminateActionWithArgs != null)
            {
                NativeControl.Indeterminate += NativeControl_Indeterminate;
            }
            if (thisAsIRxToggleButton.UncheckedAction != null || thisAsIRxToggleButton.UncheckedActionWithArgs != null)
            {
                NativeControl.Unchecked += NativeControl_Unchecked;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Checked(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxToggleButton = (IRxToggleButton)this;
            thisAsIRxToggleButton.CheckedAction?.Invoke();
            thisAsIRxToggleButton.CheckedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Indeterminate(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxToggleButton = (IRxToggleButton)this;
            thisAsIRxToggleButton.IndeterminateAction?.Invoke();
            thisAsIRxToggleButton.IndeterminateActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Unchecked(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxToggleButton = (IRxToggleButton)this;
            thisAsIRxToggleButton.UncheckedAction?.Invoke();
            thisAsIRxToggleButton.UncheckedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.Checked -= NativeControl_Checked;
                NativeControl.Indeterminate -= NativeControl_Indeterminate;
                NativeControl.Unchecked -= NativeControl_Unchecked;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxToggleButton : RxToggleButton<ToggleButton>
    {
        public RxToggleButton()
        {

        }

        public RxToggleButton(Action<ToggleButton?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxToggleButtonExtensions
    {
        public static T IsChecked<T>(this T togglebutton, bool? isChecked) where T : IRxToggleButton
        {
            togglebutton.IsChecked = new PropertyValue<bool?>(isChecked);
            return togglebutton;
        }
        public static T IsChecked<T>(this T togglebutton, Func<bool?> isCheckedFunc) where T : IRxToggleButton
        {
            togglebutton.IsChecked = new PropertyValue<bool?>(isCheckedFunc);
            return togglebutton;
        }
        public static T IsThreeState<T>(this T togglebutton, bool isThreeState) where T : IRxToggleButton
        {
            togglebutton.IsThreeState = new PropertyValue<bool>(isThreeState);
            return togglebutton;
        }
        public static T IsThreeState<T>(this T togglebutton, Func<bool> isThreeStateFunc) where T : IRxToggleButton
        {
            togglebutton.IsThreeState = new PropertyValue<bool>(isThreeStateFunc);
            return togglebutton;
        }
        public static T OnChecked<T>(this T togglebutton, Action checkedAction) where T : IRxToggleButton
        {
            togglebutton.CheckedAction = checkedAction;
            return togglebutton;
        }

        public static T OnChecked<T>(this T togglebutton, Action<object?, RoutedEventArgs> checkedActionWithArgs) where T : IRxToggleButton
        {
            togglebutton.CheckedActionWithArgs = checkedActionWithArgs;
            return togglebutton;
        }
        public static T OnIndeterminate<T>(this T togglebutton, Action indeterminateAction) where T : IRxToggleButton
        {
            togglebutton.IndeterminateAction = indeterminateAction;
            return togglebutton;
        }

        public static T OnIndeterminate<T>(this T togglebutton, Action<object?, RoutedEventArgs> indeterminateActionWithArgs) where T : IRxToggleButton
        {
            togglebutton.IndeterminateActionWithArgs = indeterminateActionWithArgs;
            return togglebutton;
        }
        public static T OnUnchecked<T>(this T togglebutton, Action uncheckedAction) where T : IRxToggleButton
        {
            togglebutton.UncheckedAction = uncheckedAction;
            return togglebutton;
        }

        public static T OnUnchecked<T>(this T togglebutton, Action<object?, RoutedEventArgs> uncheckedActionWithArgs) where T : IRxToggleButton
        {
            togglebutton.UncheckedActionWithArgs = uncheckedActionWithArgs;
            return togglebutton;
        }
    }
}
