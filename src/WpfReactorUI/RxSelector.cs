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

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxSelector : IRxItemsControl
    {
        PropertyValue<int> SelectedIndex { get; set; }
        PropertyValue<object> SelectedItem { get; set; }
        PropertyValue<object> SelectedValue { get; set; }
        PropertyValue<string> SelectedValuePath { get; set; }

        Action SelectionChangedAction { get; set; }
        Action<SelectionChangedEventArgs> SelectionChangedActionWithArgs { get; set; }
    }

    public partial class RxSelector<T> : RxItemsControl<T>, IRxSelector where T : Selector, new()
    {
        public RxSelector()
        {

        }

        public RxSelector(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<int> IRxSelector.SelectedIndex { get; set; }
        PropertyValue<object> IRxSelector.SelectedItem { get; set; }
        PropertyValue<object> IRxSelector.SelectedValue { get; set; }
        PropertyValue<string> IRxSelector.SelectedValuePath { get; set; }

        Action IRxSelector.SelectionChangedAction { get; set; }
        Action<SelectionChangedEventArgs> IRxSelector.SelectionChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxSelector = (IRxSelector)this;
            NativeControl.Set(Selector.SelectedIndexProperty, thisAsIRxSelector.SelectedIndex);
            NativeControl.Set(Selector.SelectedItemProperty, thisAsIRxSelector.SelectedItem);
            NativeControl.Set(Selector.SelectedValueProperty, thisAsIRxSelector.SelectedValue);
            NativeControl.Set(Selector.SelectedValuePathProperty, thisAsIRxSelector.SelectedValuePath);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxSelector = (IRxSelector)this;
            if (thisAsIRxSelector.SelectionChangedAction != null || thisAsIRxSelector.SelectionChangedActionWithArgs != null)
            {
                NativeControl.SelectionChanged += NativeControl_SelectionChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var thisAsIRxSelector = (IRxSelector)this;
            thisAsIRxSelector.SelectionChangedAction?.Invoke();
            thisAsIRxSelector.SelectionChangedActionWithArgs?.Invoke(e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.SelectionChanged -= NativeControl_SelectionChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxSelectorExtensions
    {
        public static T SelectedIndex<T>(this T selector, int selectedIndex) where T : IRxSelector
        {
            selector.SelectedIndex = new PropertyValue<int>(selectedIndex);
            return selector;
        }
        public static T SelectedItem<T>(this T selector, object selectedItem) where T : IRxSelector
        {
            selector.SelectedItem = new PropertyValue<object>(selectedItem);
            return selector;
        }
        public static T SelectedValue<T>(this T selector, object selectedValue) where T : IRxSelector
        {
            selector.SelectedValue = new PropertyValue<object>(selectedValue);
            return selector;
        }
        public static T SelectedValuePath<T>(this T selector, string selectedValuePath) where T : IRxSelector
        {
            selector.SelectedValuePath = new PropertyValue<string>(selectedValuePath);
            return selector;
        }
        public static T OnSelectionChanged<T>(this T selector, Action selectionchangedAction) where T : IRxSelector
        {
            selector.SelectionChangedAction = selectionchangedAction;
            return selector;
        }

        public static T OnSelectionChanged<T>(this T selector, Action<SelectionChangedEventArgs> selectionchangedActionWithArgs) where T : IRxSelector
        {
            selector.SelectionChangedActionWithArgs = selectionchangedActionWithArgs;
            return selector;
        }
    }
}
