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
    public partial interface IRxComboBox : IRxSelector
    {
        PropertyValue<bool>? IsDropDownOpen { get; set; }
        PropertyValue<bool>? IsEditable { get; set; }
        PropertyValue<bool>? IsReadOnly { get; set; }
        PropertyValue<double>? MaxDropDownHeight { get; set; }
        PropertyValue<bool>? ShouldPreserveUserEnteredPrefix { get; set; }
        PropertyValue<bool>? StaysOpenOnEdit { get; set; }
        PropertyValue<string>? Text { get; set; }

        Action? DropDownClosedAction { get; set; }
        Action<object?, EventArgs>? DropDownClosedActionWithArgs { get; set; }
        Action? DropDownOpenedAction { get; set; }
        Action<object?, EventArgs>? DropDownOpenedActionWithArgs { get; set; }
    }
    public partial class RxComboBox<T> : RxSelector<T>, IRxComboBox where T : ComboBox, new()
    {
        public RxComboBox()
        {

        }

        public RxComboBox(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxComboBox.IsDropDownOpen { get; set; }
        PropertyValue<bool>? IRxComboBox.IsEditable { get; set; }
        PropertyValue<bool>? IRxComboBox.IsReadOnly { get; set; }
        PropertyValue<double>? IRxComboBox.MaxDropDownHeight { get; set; }
        PropertyValue<bool>? IRxComboBox.ShouldPreserveUserEnteredPrefix { get; set; }
        PropertyValue<bool>? IRxComboBox.StaysOpenOnEdit { get; set; }
        PropertyValue<string>? IRxComboBox.Text { get; set; }

        Action? IRxComboBox.DropDownClosedAction { get; set; }
        Action<object?, EventArgs>? IRxComboBox.DropDownClosedActionWithArgs { get; set; }
        Action? IRxComboBox.DropDownOpenedAction { get; set; }
        Action<object?, EventArgs>? IRxComboBox.DropDownOpenedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxComboBox = (IRxComboBox)this;
            SetPropertyValue(NativeControl, ComboBox.IsDropDownOpenProperty, thisAsIRxComboBox.IsDropDownOpen);
            SetPropertyValue(NativeControl, ComboBox.IsEditableProperty, thisAsIRxComboBox.IsEditable);
            SetPropertyValue(NativeControl, ComboBox.IsReadOnlyProperty, thisAsIRxComboBox.IsReadOnly);
            SetPropertyValue(NativeControl, ComboBox.MaxDropDownHeightProperty, thisAsIRxComboBox.MaxDropDownHeight);
            SetPropertyValue(NativeControl, ComboBox.ShouldPreserveUserEnteredPrefixProperty, thisAsIRxComboBox.ShouldPreserveUserEnteredPrefix);
            SetPropertyValue(NativeControl, ComboBox.StaysOpenOnEditProperty, thisAsIRxComboBox.StaysOpenOnEdit);
            SetPropertyValue(NativeControl, ComboBox.TextProperty, thisAsIRxComboBox.Text);

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

            var thisAsIRxComboBox = (IRxComboBox)this;
            if (thisAsIRxComboBox.DropDownClosedAction != null || thisAsIRxComboBox.DropDownClosedActionWithArgs != null)
            {
                NativeControl.DropDownClosed += NativeControl_DropDownClosed;
            }
            if (thisAsIRxComboBox.DropDownOpenedAction != null || thisAsIRxComboBox.DropDownOpenedActionWithArgs != null)
            {
                NativeControl.DropDownOpened += NativeControl_DropDownOpened;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_DropDownClosed(object? sender, EventArgs e)
        {
            var thisAsIRxComboBox = (IRxComboBox)this;
            thisAsIRxComboBox.DropDownClosedAction?.Invoke();
            thisAsIRxComboBox.DropDownClosedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_DropDownOpened(object? sender, EventArgs e)
        {
            var thisAsIRxComboBox = (IRxComboBox)this;
            thisAsIRxComboBox.DropDownOpenedAction?.Invoke();
            thisAsIRxComboBox.DropDownOpenedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.DropDownClosed -= NativeControl_DropDownClosed;
                NativeControl.DropDownOpened -= NativeControl_DropDownOpened;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxComboBox : RxComboBox<ComboBox>
    {
        public RxComboBox()
        {

        }

        public RxComboBox(Action<ComboBox?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxComboBoxExtensions
    {
        public static T IsDropDownOpen<T>(this T combobox, bool isDropDownOpen) where T : IRxComboBox
        {
            combobox.IsDropDownOpen = new PropertyValue<bool>(isDropDownOpen);
            return combobox;
        }
        public static T IsDropDownOpen<T>(this T combobox, Func<bool> isDropDownOpenFunc) where T : IRxComboBox
        {
            combobox.IsDropDownOpen = new PropertyValue<bool>(isDropDownOpenFunc);
            return combobox;
        }
        public static T IsEditable<T>(this T combobox, bool isEditable) where T : IRxComboBox
        {
            combobox.IsEditable = new PropertyValue<bool>(isEditable);
            return combobox;
        }
        public static T IsEditable<T>(this T combobox, Func<bool> isEditableFunc) where T : IRxComboBox
        {
            combobox.IsEditable = new PropertyValue<bool>(isEditableFunc);
            return combobox;
        }
        public static T IsReadOnly<T>(this T combobox, bool isReadOnly) where T : IRxComboBox
        {
            combobox.IsReadOnly = new PropertyValue<bool>(isReadOnly);
            return combobox;
        }
        public static T IsReadOnly<T>(this T combobox, Func<bool> isReadOnlyFunc) where T : IRxComboBox
        {
            combobox.IsReadOnly = new PropertyValue<bool>(isReadOnlyFunc);
            return combobox;
        }
        public static T MaxDropDownHeight<T>(this T combobox, double maxDropDownHeight) where T : IRxComboBox
        {
            combobox.MaxDropDownHeight = new PropertyValue<double>(maxDropDownHeight);
            return combobox;
        }
        public static T MaxDropDownHeight<T>(this T combobox, Func<double> maxDropDownHeightFunc) where T : IRxComboBox
        {
            combobox.MaxDropDownHeight = new PropertyValue<double>(maxDropDownHeightFunc);
            return combobox;
        }
        public static T ShouldPreserveUserEnteredPrefix<T>(this T combobox, bool shouldPreserveUserEnteredPrefix) where T : IRxComboBox
        {
            combobox.ShouldPreserveUserEnteredPrefix = new PropertyValue<bool>(shouldPreserveUserEnteredPrefix);
            return combobox;
        }
        public static T ShouldPreserveUserEnteredPrefix<T>(this T combobox, Func<bool> shouldPreserveUserEnteredPrefixFunc) where T : IRxComboBox
        {
            combobox.ShouldPreserveUserEnteredPrefix = new PropertyValue<bool>(shouldPreserveUserEnteredPrefixFunc);
            return combobox;
        }
        public static T StaysOpenOnEdit<T>(this T combobox, bool staysOpenOnEdit) where T : IRxComboBox
        {
            combobox.StaysOpenOnEdit = new PropertyValue<bool>(staysOpenOnEdit);
            return combobox;
        }
        public static T StaysOpenOnEdit<T>(this T combobox, Func<bool> staysOpenOnEditFunc) where T : IRxComboBox
        {
            combobox.StaysOpenOnEdit = new PropertyValue<bool>(staysOpenOnEditFunc);
            return combobox;
        }
        public static T Text<T>(this T combobox, string text) where T : IRxComboBox
        {
            combobox.Text = new PropertyValue<string>(text);
            return combobox;
        }
        public static T Text<T>(this T combobox, Func<string> textFunc) where T : IRxComboBox
        {
            combobox.Text = new PropertyValue<string>(textFunc);
            return combobox;
        }
        public static T OnDropDownClosed<T>(this T combobox, Action dropdownclosedAction) where T : IRxComboBox
        {
            combobox.DropDownClosedAction = dropdownclosedAction;
            return combobox;
        }

        public static T OnDropDownClosed<T>(this T combobox, Action<object?, EventArgs> dropdownclosedActionWithArgs) where T : IRxComboBox
        {
            combobox.DropDownClosedActionWithArgs = dropdownclosedActionWithArgs;
            return combobox;
        }
        public static T OnDropDownOpened<T>(this T combobox, Action dropdownopenedAction) where T : IRxComboBox
        {
            combobox.DropDownOpenedAction = dropdownopenedAction;
            return combobox;
        }

        public static T OnDropDownOpened<T>(this T combobox, Action<object?, EventArgs> dropdownopenedActionWithArgs) where T : IRxComboBox
        {
            combobox.DropDownOpenedActionWithArgs = dropdownopenedActionWithArgs;
            return combobox;
        }
    }
}
