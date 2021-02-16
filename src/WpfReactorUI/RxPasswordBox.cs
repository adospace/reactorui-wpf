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
    public partial interface IRxPasswordBox : IRxControl
    {
        PropertyValue<Brush>? CaretBrush { get; set; }
        PropertyValue<bool>? IsInactiveSelectionHighlightEnabled { get; set; }
        PropertyValue<int>? MaxLength { get; set; }
        PropertyValue<char>? PasswordChar { get; set; }
        PropertyValue<Brush>? SelectionBrush { get; set; }
        PropertyValue<double>? SelectionOpacity { get; set; }
        PropertyValue<Brush>? SelectionTextBrush { get; set; }

        Action? PasswordChangedAction { get; set; }
        Action<object?, RoutedEventArgs>? PasswordChangedActionWithArgs { get; set; }
    }
    public partial class RxPasswordBox : RxControl<PasswordBox>, IRxPasswordBox
    {
        public RxPasswordBox()
        {

        }

        public RxPasswordBox(Action<PasswordBox?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxPasswordBox.CaretBrush { get; set; }
        PropertyValue<bool>? IRxPasswordBox.IsInactiveSelectionHighlightEnabled { get; set; }
        PropertyValue<int>? IRxPasswordBox.MaxLength { get; set; }
        PropertyValue<char>? IRxPasswordBox.PasswordChar { get; set; }
        PropertyValue<Brush>? IRxPasswordBox.SelectionBrush { get; set; }
        PropertyValue<double>? IRxPasswordBox.SelectionOpacity { get; set; }
        PropertyValue<Brush>? IRxPasswordBox.SelectionTextBrush { get; set; }

        Action? IRxPasswordBox.PasswordChangedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxPasswordBox.PasswordChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxPasswordBox = (IRxPasswordBox)this;
            SetPropertyValue(NativeControl, PasswordBox.CaretBrushProperty, thisAsIRxPasswordBox.CaretBrush);
            SetPropertyValue(NativeControl, PasswordBox.IsInactiveSelectionHighlightEnabledProperty, thisAsIRxPasswordBox.IsInactiveSelectionHighlightEnabled);
            SetPropertyValue(NativeControl, PasswordBox.MaxLengthProperty, thisAsIRxPasswordBox.MaxLength);
            SetPropertyValue(NativeControl, PasswordBox.PasswordCharProperty, thisAsIRxPasswordBox.PasswordChar);
            SetPropertyValue(NativeControl, PasswordBox.SelectionBrushProperty, thisAsIRxPasswordBox.SelectionBrush);
            SetPropertyValue(NativeControl, PasswordBox.SelectionOpacityProperty, thisAsIRxPasswordBox.SelectionOpacity);
            SetPropertyValue(NativeControl, PasswordBox.SelectionTextBrushProperty, thisAsIRxPasswordBox.SelectionTextBrush);

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

            var thisAsIRxPasswordBox = (IRxPasswordBox)this;
            if (thisAsIRxPasswordBox.PasswordChangedAction != null || thisAsIRxPasswordBox.PasswordChangedActionWithArgs != null)
            {
                NativeControl.PasswordChanged += NativeControl_PasswordChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_PasswordChanged(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxPasswordBox = (IRxPasswordBox)this;
            thisAsIRxPasswordBox.PasswordChangedAction?.Invoke();
            thisAsIRxPasswordBox.PasswordChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.PasswordChanged -= NativeControl_PasswordChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxPasswordBoxExtensions
    {
        public static T CaretBrush<T>(this T passwordbox, Brush caretBrush) where T : IRxPasswordBox
        {
            passwordbox.CaretBrush = new PropertyValue<Brush>(caretBrush);
            return passwordbox;
        }
        public static T CaretBrush<T>(this T passwordbox, Func<Brush> caretBrushFunc) where T : IRxPasswordBox
        {
            passwordbox.CaretBrush = new PropertyValue<Brush>(caretBrushFunc);
            return passwordbox;
        }
        public static T CaretBrush<T>(this T passwordbox, string caretbrushResourceKey) where T : IRxPasswordBox
        {
            passwordbox.ResourceReferences[PasswordBox.CaretBrushProperty] = caretbrushResourceKey;
            return passwordbox;
        }
        public static T IsInactiveSelectionHighlightEnabled<T>(this T passwordbox, bool isInactiveSelectionHighlightEnabled) where T : IRxPasswordBox
        {
            passwordbox.IsInactiveSelectionHighlightEnabled = new PropertyValue<bool>(isInactiveSelectionHighlightEnabled);
            return passwordbox;
        }
        public static T IsInactiveSelectionHighlightEnabled<T>(this T passwordbox, Func<bool> isInactiveSelectionHighlightEnabledFunc) where T : IRxPasswordBox
        {
            passwordbox.IsInactiveSelectionHighlightEnabled = new PropertyValue<bool>(isInactiveSelectionHighlightEnabledFunc);
            return passwordbox;
        }
        public static T MaxLength<T>(this T passwordbox, int maxLength) where T : IRxPasswordBox
        {
            passwordbox.MaxLength = new PropertyValue<int>(maxLength);
            return passwordbox;
        }
        public static T MaxLength<T>(this T passwordbox, Func<int> maxLengthFunc) where T : IRxPasswordBox
        {
            passwordbox.MaxLength = new PropertyValue<int>(maxLengthFunc);
            return passwordbox;
        }
        public static T PasswordChar<T>(this T passwordbox, char passwordChar) where T : IRxPasswordBox
        {
            passwordbox.PasswordChar = new PropertyValue<char>(passwordChar);
            return passwordbox;
        }
        public static T PasswordChar<T>(this T passwordbox, Func<char> passwordCharFunc) where T : IRxPasswordBox
        {
            passwordbox.PasswordChar = new PropertyValue<char>(passwordCharFunc);
            return passwordbox;
        }
        public static T SelectionBrush<T>(this T passwordbox, Brush selectionBrush) where T : IRxPasswordBox
        {
            passwordbox.SelectionBrush = new PropertyValue<Brush>(selectionBrush);
            return passwordbox;
        }
        public static T SelectionBrush<T>(this T passwordbox, Func<Brush> selectionBrushFunc) where T : IRxPasswordBox
        {
            passwordbox.SelectionBrush = new PropertyValue<Brush>(selectionBrushFunc);
            return passwordbox;
        }
        public static T SelectionBrush<T>(this T passwordbox, string selectionbrushResourceKey) where T : IRxPasswordBox
        {
            passwordbox.ResourceReferences[PasswordBox.SelectionBrushProperty] = selectionbrushResourceKey;
            return passwordbox;
        }
        public static T SelectionOpacity<T>(this T passwordbox, double selectionOpacity) where T : IRxPasswordBox
        {
            passwordbox.SelectionOpacity = new PropertyValue<double>(selectionOpacity);
            return passwordbox;
        }
        public static T SelectionOpacity<T>(this T passwordbox, Func<double> selectionOpacityFunc) where T : IRxPasswordBox
        {
            passwordbox.SelectionOpacity = new PropertyValue<double>(selectionOpacityFunc);
            return passwordbox;
        }
        public static T SelectionTextBrush<T>(this T passwordbox, Brush selectionTextBrush) where T : IRxPasswordBox
        {
            passwordbox.SelectionTextBrush = new PropertyValue<Brush>(selectionTextBrush);
            return passwordbox;
        }
        public static T SelectionTextBrush<T>(this T passwordbox, Func<Brush> selectionTextBrushFunc) where T : IRxPasswordBox
        {
            passwordbox.SelectionTextBrush = new PropertyValue<Brush>(selectionTextBrushFunc);
            return passwordbox;
        }
        public static T SelectionTextBrush<T>(this T passwordbox, string selectiontextbrushResourceKey) where T : IRxPasswordBox
        {
            passwordbox.ResourceReferences[PasswordBox.SelectionTextBrushProperty] = selectiontextbrushResourceKey;
            return passwordbox;
        }
        public static T OnPasswordChanged<T>(this T passwordbox, Action passwordchangedAction) where T : IRxPasswordBox
        {
            passwordbox.PasswordChangedAction = passwordchangedAction;
            return passwordbox;
        }

        public static T OnPasswordChanged<T>(this T passwordbox, Action<object?, RoutedEventArgs> passwordchangedActionWithArgs) where T : IRxPasswordBox
        {
            passwordbox.PasswordChangedActionWithArgs = passwordchangedActionWithArgs;
            return passwordbox;
        }
    }
}
