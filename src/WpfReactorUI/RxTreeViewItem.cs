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
    public partial interface IRxTreeViewItem : IRxHeaderedItemsControl
    {
        PropertyValue<bool>? IsExpanded { get; set; }
        PropertyValue<bool>? IsSelected { get; set; }

        Action? CollapsedAction { get; set; }
        Action<object?, RoutedEventArgs>? CollapsedActionWithArgs { get; set; }
        Action? ExpandedAction { get; set; }
        Action<object?, RoutedEventArgs>? ExpandedActionWithArgs { get; set; }
        Action? SelectedAction { get; set; }
        Action<object?, RoutedEventArgs>? SelectedActionWithArgs { get; set; }
        Action? UnselectedAction { get; set; }
        Action<object?, RoutedEventArgs>? UnselectedActionWithArgs { get; set; }
    }
    public partial class RxTreeViewItem<T> : RxHeaderedItemsControl<T>, IRxTreeViewItem where T : TreeViewItem, new()
    {
        public RxTreeViewItem()
        {

        }

        public RxTreeViewItem(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxTreeViewItem.IsExpanded { get; set; }
        PropertyValue<bool>? IRxTreeViewItem.IsSelected { get; set; }

        Action? IRxTreeViewItem.CollapsedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxTreeViewItem.CollapsedActionWithArgs { get; set; }
        Action? IRxTreeViewItem.ExpandedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxTreeViewItem.ExpandedActionWithArgs { get; set; }
        Action? IRxTreeViewItem.SelectedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxTreeViewItem.SelectedActionWithArgs { get; set; }
        Action? IRxTreeViewItem.UnselectedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxTreeViewItem.UnselectedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTreeViewItem = (IRxTreeViewItem)this;
            SetPropertyValue(NativeControl, TreeViewItem.IsExpandedProperty, thisAsIRxTreeViewItem.IsExpanded);
            SetPropertyValue(NativeControl, TreeViewItem.IsSelectedProperty, thisAsIRxTreeViewItem.IsSelected);

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

            var thisAsIRxTreeViewItem = (IRxTreeViewItem)this;
            if (thisAsIRxTreeViewItem.CollapsedAction != null || thisAsIRxTreeViewItem.CollapsedActionWithArgs != null)
            {
                NativeControl.Collapsed += NativeControl_Collapsed;
            }
            if (thisAsIRxTreeViewItem.ExpandedAction != null || thisAsIRxTreeViewItem.ExpandedActionWithArgs != null)
            {
                NativeControl.Expanded += NativeControl_Expanded;
            }
            if (thisAsIRxTreeViewItem.SelectedAction != null || thisAsIRxTreeViewItem.SelectedActionWithArgs != null)
            {
                NativeControl.Selected += NativeControl_Selected;
            }
            if (thisAsIRxTreeViewItem.UnselectedAction != null || thisAsIRxTreeViewItem.UnselectedActionWithArgs != null)
            {
                NativeControl.Unselected += NativeControl_Unselected;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_Collapsed(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxTreeViewItem = (IRxTreeViewItem)this;
            thisAsIRxTreeViewItem.CollapsedAction?.Invoke();
            thisAsIRxTreeViewItem.CollapsedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Expanded(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxTreeViewItem = (IRxTreeViewItem)this;
            thisAsIRxTreeViewItem.ExpandedAction?.Invoke();
            thisAsIRxTreeViewItem.ExpandedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Selected(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxTreeViewItem = (IRxTreeViewItem)this;
            thisAsIRxTreeViewItem.SelectedAction?.Invoke();
            thisAsIRxTreeViewItem.SelectedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_Unselected(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxTreeViewItem = (IRxTreeViewItem)this;
            thisAsIRxTreeViewItem.UnselectedAction?.Invoke();
            thisAsIRxTreeViewItem.UnselectedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.Collapsed -= NativeControl_Collapsed;
                NativeControl.Expanded -= NativeControl_Expanded;
                NativeControl.Selected -= NativeControl_Selected;
                NativeControl.Unselected -= NativeControl_Unselected;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxTreeViewItem : RxTreeViewItem<TreeViewItem>
    {
        public RxTreeViewItem()
        {

        }

        public RxTreeViewItem(Action<TreeViewItem?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxTreeViewItemExtensions
    {
        public static T IsExpanded<T>(this T treeviewitem, bool isExpanded) where T : IRxTreeViewItem
        {
            treeviewitem.IsExpanded = new PropertyValue<bool>(isExpanded);
            return treeviewitem;
        }
        public static T IsExpanded<T>(this T treeviewitem, Func<bool> isExpandedFunc) where T : IRxTreeViewItem
        {
            treeviewitem.IsExpanded = new PropertyValue<bool>(isExpandedFunc);
            return treeviewitem;
        }
        public static T IsSelected<T>(this T treeviewitem, bool isSelected) where T : IRxTreeViewItem
        {
            treeviewitem.IsSelected = new PropertyValue<bool>(isSelected);
            return treeviewitem;
        }
        public static T IsSelected<T>(this T treeviewitem, Func<bool> isSelectedFunc) where T : IRxTreeViewItem
        {
            treeviewitem.IsSelected = new PropertyValue<bool>(isSelectedFunc);
            return treeviewitem;
        }
        public static T OnCollapsed<T>(this T treeviewitem, Action collapsedAction) where T : IRxTreeViewItem
        {
            treeviewitem.CollapsedAction = collapsedAction;
            return treeviewitem;
        }

        public static T OnCollapsed<T>(this T treeviewitem, Action<object?, RoutedEventArgs> collapsedActionWithArgs) where T : IRxTreeViewItem
        {
            treeviewitem.CollapsedActionWithArgs = collapsedActionWithArgs;
            return treeviewitem;
        }
        public static T OnExpanded<T>(this T treeviewitem, Action expandedAction) where T : IRxTreeViewItem
        {
            treeviewitem.ExpandedAction = expandedAction;
            return treeviewitem;
        }

        public static T OnExpanded<T>(this T treeviewitem, Action<object?, RoutedEventArgs> expandedActionWithArgs) where T : IRxTreeViewItem
        {
            treeviewitem.ExpandedActionWithArgs = expandedActionWithArgs;
            return treeviewitem;
        }
        public static T OnSelected<T>(this T treeviewitem, Action selectedAction) where T : IRxTreeViewItem
        {
            treeviewitem.SelectedAction = selectedAction;
            return treeviewitem;
        }

        public static T OnSelected<T>(this T treeviewitem, Action<object?, RoutedEventArgs> selectedActionWithArgs) where T : IRxTreeViewItem
        {
            treeviewitem.SelectedActionWithArgs = selectedActionWithArgs;
            return treeviewitem;
        }
        public static T OnUnselected<T>(this T treeviewitem, Action unselectedAction) where T : IRxTreeViewItem
        {
            treeviewitem.UnselectedAction = unselectedAction;
            return treeviewitem;
        }

        public static T OnUnselected<T>(this T treeviewitem, Action<object?, RoutedEventArgs> unselectedActionWithArgs) where T : IRxTreeViewItem
        {
            treeviewitem.UnselectedActionWithArgs = unselectedActionWithArgs;
            return treeviewitem;
        }
    }
}
