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
    public partial interface IRxButtonBase : IRxContentControl
    {
        PropertyValue<ClickMode>? ClickMode { get; set; }
        PropertyValue<ICommand>? Command { get; set; }
        PropertyValue<object>? CommandParameter { get; set; }
        PropertyValue<IInputElement>? CommandTarget { get; set; }

        Action? ClickAction { get; set; }
        Action<object?, RoutedEventArgs>? ClickActionWithArgs { get; set; }
    }

    public partial class RxButtonBase<T> : RxContentControl<T>, IRxButtonBase where T : ButtonBase, new()
    {
        public RxButtonBase()
        {

        }

        public RxButtonBase(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<ClickMode>? IRxButtonBase.ClickMode { get; set; }
        PropertyValue<ICommand>? IRxButtonBase.Command { get; set; }
        PropertyValue<object>? IRxButtonBase.CommandParameter { get; set; }
        PropertyValue<IInputElement>? IRxButtonBase.CommandTarget { get; set; }

        Action? IRxButtonBase.ClickAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxButtonBase.ClickActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxButtonBase = (IRxButtonBase)this;
            SetPropertyValue(NativeControl, ButtonBase.ClickModeProperty, thisAsIRxButtonBase.ClickMode);
            SetPropertyValue(NativeControl, ButtonBase.CommandProperty, thisAsIRxButtonBase.Command);
            SetPropertyValue(NativeControl, ButtonBase.CommandParameterProperty, thisAsIRxButtonBase.CommandParameter);
            SetPropertyValue(NativeControl, ButtonBase.CommandTargetProperty, thisAsIRxButtonBase.CommandTarget);

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

            var thisAsIRxButtonBase = (IRxButtonBase)this;
            if (thisAsIRxButtonBase.ClickAction != null || thisAsIRxButtonBase.ClickActionWithArgs != null)
            {
                NativeControl.Click += NativeControl_Click;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Click(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxButtonBase = (IRxButtonBase)this;
            thisAsIRxButtonBase.ClickAction?.Invoke();
            thisAsIRxButtonBase.ClickActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.Click -= NativeControl_Click;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxButtonBaseExtensions
    {
        public static T ClickMode<T>(this T buttonbase, ClickMode clickMode) where T : IRxButtonBase
        {
            buttonbase.ClickMode = new PropertyValue<ClickMode>(clickMode);
            return buttonbase;
        }
        public static T ClickMode<T>(this T buttonbase, Func<ClickMode> clickModeFunc) where T : IRxButtonBase
        {
            buttonbase.ClickMode = new PropertyValue<ClickMode>(clickModeFunc);
            return buttonbase;
        }
        public static T Command<T>(this T buttonbase, ICommand command) where T : IRxButtonBase
        {
            buttonbase.Command = new PropertyValue<ICommand>(command);
            return buttonbase;
        }
        public static T Command<T>(this T buttonbase, Func<ICommand> commandFunc) where T : IRxButtonBase
        {
            buttonbase.Command = new PropertyValue<ICommand>(commandFunc);
            return buttonbase;
        }
        public static T CommandParameter<T>(this T buttonbase, object commandParameter) where T : IRxButtonBase
        {
            buttonbase.CommandParameter = new PropertyValue<object>(commandParameter);
            return buttonbase;
        }
        public static T CommandParameter<T>(this T buttonbase, Func<object> commandParameterFunc) where T : IRxButtonBase
        {
            buttonbase.CommandParameter = new PropertyValue<object>(commandParameterFunc);
            return buttonbase;
        }
        public static T CommandTarget<T>(this T buttonbase, IInputElement commandTarget) where T : IRxButtonBase
        {
            buttonbase.CommandTarget = new PropertyValue<IInputElement>(commandTarget);
            return buttonbase;
        }
        public static T CommandTarget<T>(this T buttonbase, Func<IInputElement> commandTargetFunc) where T : IRxButtonBase
        {
            buttonbase.CommandTarget = new PropertyValue<IInputElement>(commandTargetFunc);
            return buttonbase;
        }
        public static T OnClick<T>(this T buttonbase, Action clickAction) where T : IRxButtonBase
        {
            buttonbase.ClickAction = clickAction;
            return buttonbase;
        }

        public static T OnClick<T>(this T buttonbase, Action<object?, RoutedEventArgs> clickActionWithArgs) where T : IRxButtonBase
        {
            buttonbase.ClickActionWithArgs = clickActionWithArgs;
            return buttonbase;
        }
    }
}
