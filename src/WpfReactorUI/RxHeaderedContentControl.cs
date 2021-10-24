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
    public partial interface IRxHeaderedContentControl : IRxContentControl
    {
        PropertyValue<object>? Header { get; set; }
        PropertyValue<string>? HeaderStringFormat { get; set; }

    }
    public partial class RxHeaderedContentControl<T> : RxContentControl<T>, IRxHeaderedContentControl where T : HeaderedContentControl, new()
    {
        public RxHeaderedContentControl()
        {

        }

        public RxHeaderedContentControl(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<object>? IRxHeaderedContentControl.Header { get; set; }
        PropertyValue<string>? IRxHeaderedContentControl.HeaderStringFormat { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxHeaderedContentControl = (IRxHeaderedContentControl)this;
            SetPropertyValue(NativeControl, HeaderedContentControl.HeaderProperty, thisAsIRxHeaderedContentControl.Header);
            SetPropertyValue(NativeControl, HeaderedContentControl.HeaderStringFormatProperty, thisAsIRxHeaderedContentControl.HeaderStringFormat);

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
    public partial class RxHeaderedContentControl : RxHeaderedContentControl<HeaderedContentControl>
    {
        public RxHeaderedContentControl()
        {

        }

        public RxHeaderedContentControl(Action<HeaderedContentControl?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxHeaderedContentControlExtensions
    {
        public static T Header<T>(this T headeredcontentcontrol, object header) where T : IRxHeaderedContentControl
        {
            headeredcontentcontrol.Header = new PropertyValue<object>(header);
            return headeredcontentcontrol;
        }
        public static T Header<T>(this T headeredcontentcontrol, Func<object> headerFunc) where T : IRxHeaderedContentControl
        {
            headeredcontentcontrol.Header = new PropertyValue<object>(headerFunc);
            return headeredcontentcontrol;
        }
        public static T HeaderStringFormat<T>(this T headeredcontentcontrol, string headerStringFormat) where T : IRxHeaderedContentControl
        {
            headeredcontentcontrol.HeaderStringFormat = new PropertyValue<string>(headerStringFormat);
            return headeredcontentcontrol;
        }
        public static T HeaderStringFormat<T>(this T headeredcontentcontrol, Func<string> headerStringFormatFunc) where T : IRxHeaderedContentControl
        {
            headeredcontentcontrol.HeaderStringFormat = new PropertyValue<string>(headerStringFormatFunc);
            return headeredcontentcontrol;
        }
    }
}
