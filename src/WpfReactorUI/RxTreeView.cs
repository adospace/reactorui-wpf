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
    public partial interface IRxTreeView : IRxItemsControl
    {
        PropertyValue<string>? SelectedValuePath { get; set; }

    }
    public partial class RxTreeView<T> : RxItemsControl<T>, IRxTreeView where T : TreeView, new()
    {
        public RxTreeView()
        {

        }

        public RxTreeView(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<string>? IRxTreeView.SelectedValuePath { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTreeView = (IRxTreeView)this;
            SetPropertyValue(NativeControl, TreeView.SelectedValuePathProperty, thisAsIRxTreeView.SelectedValuePath);

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
    public partial class RxTreeView : RxTreeView<TreeView>
    {
        public RxTreeView()
        {

        }

        public RxTreeView(Action<TreeView?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxTreeViewExtensions
    {
        public static T SelectedValuePath<T>(this T treeview, string selectedValuePath) where T : IRxTreeView
        {
            treeview.SelectedValuePath = new PropertyValue<string>(selectedValuePath);
            return treeview;
        }
        public static T SelectedValuePath<T>(this T treeview, Func<string> selectedValuePathFunc) where T : IRxTreeView
        {
            treeview.SelectedValuePath = new PropertyValue<string>(selectedValuePathFunc);
            return treeview;
        }
    }
}
