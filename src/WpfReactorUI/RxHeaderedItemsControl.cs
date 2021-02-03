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
    public partial interface IRxHeaderedItemsControl : IRxItemsControl
    {
        PropertyValue<object>? Header { get; set; }
        PropertyValue<string>? HeaderStringFormat { get; set; }

    }
    public partial class RxHeaderedItemsControl<T> : RxItemsControl<T>, IRxHeaderedItemsControl where T : HeaderedItemsControl, new()
    {
        public RxHeaderedItemsControl()
        {

        }

        public RxHeaderedItemsControl(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<object>? IRxHeaderedItemsControl.Header { get; set; }
        PropertyValue<string>? IRxHeaderedItemsControl.HeaderStringFormat { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxHeaderedItemsControl = (IRxHeaderedItemsControl)this;
            SetPropertyValue(NativeControl, HeaderedItemsControl.HeaderProperty, thisAsIRxHeaderedItemsControl.Header);
            SetPropertyValue(NativeControl, HeaderedItemsControl.HeaderStringFormatProperty, thisAsIRxHeaderedItemsControl.HeaderStringFormat);

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
    public partial class RxHeaderedItemsControl : RxHeaderedItemsControl<HeaderedItemsControl>
    {
        public RxHeaderedItemsControl()
        {

        }

        public RxHeaderedItemsControl(Action<HeaderedItemsControl?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxHeaderedItemsControlExtensions
    {
        public static T Header<T>(this T headereditemscontrol, object header) where T : IRxHeaderedItemsControl
        {
            headereditemscontrol.Header = new PropertyValue<object>(header);
            return headereditemscontrol;
        }
        public static T Header<T>(this T headereditemscontrol, Func<object> headerFunc) where T : IRxHeaderedItemsControl
        {
            headereditemscontrol.Header = new PropertyValue<object>(headerFunc);
            return headereditemscontrol;
        }
        public static T HeaderStringFormat<T>(this T headereditemscontrol, string headerStringFormat) where T : IRxHeaderedItemsControl
        {
            headereditemscontrol.HeaderStringFormat = new PropertyValue<string>(headerStringFormat);
            return headereditemscontrol;
        }
        public static T HeaderStringFormat<T>(this T headereditemscontrol, Func<string> headerStringFormatFunc) where T : IRxHeaderedItemsControl
        {
            headereditemscontrol.HeaderStringFormat = new PropertyValue<string>(headerStringFormatFunc);
            return headereditemscontrol;
        }
    }
}
