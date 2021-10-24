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
    public partial interface IRxTabItem : IRxHeaderedContentControl
    {
        PropertyValue<bool>? IsSelected { get; set; }

    }
    public partial class RxTabItem<T> : RxHeaderedContentControl<T>, IRxTabItem where T : TabItem, new()
    {
        public RxTabItem()
        {

        }

        public RxTabItem(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxTabItem.IsSelected { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTabItem = (IRxTabItem)this;
            SetPropertyValue(NativeControl, TabItem.IsSelectedProperty, thisAsIRxTabItem.IsSelected);

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
    public partial class RxTabItem : RxTabItem<TabItem>
    {
        public RxTabItem()
        {

        }

        public RxTabItem(Action<TabItem?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxTabItemExtensions
    {
        public static T IsSelected<T>(this T tabitem, bool isSelected) where T : IRxTabItem
        {
            tabitem.IsSelected = new PropertyValue<bool>(isSelected);
            return tabitem;
        }
        public static T IsSelected<T>(this T tabitem, Func<bool> isSelectedFunc) where T : IRxTabItem
        {
            tabitem.IsSelected = new PropertyValue<bool>(isSelectedFunc);
            return tabitem;
        }
    }
}
