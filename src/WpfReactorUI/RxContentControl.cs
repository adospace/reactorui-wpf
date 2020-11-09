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
    public partial interface IRxContentControl : IRxControl
    {
        PropertyValue<object> Content { get; set; }
        PropertyValue<string> ContentStringFormat { get; set; }

    }

    public partial class RxContentControl<T> : RxControl<T>, IRxContentControl where T : ContentControl, new()
    {
        public RxContentControl()
        {

        }

        public RxContentControl(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<object> IRxContentControl.Content { get; set; }
        PropertyValue<string> IRxContentControl.ContentStringFormat { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxContentControl = (IRxContentControl)this;
            NativeControl.Set(ContentControl.ContentProperty, thisAsIRxContentControl.Content);
            NativeControl.Set(ContentControl.ContentStringFormatProperty, thisAsIRxContentControl.ContentStringFormat);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxContentControl = (IRxContentControl)this;

            base.OnAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxContentControl : RxContentControl<ContentControl>
    {
        public RxContentControl()
        {

        }

        public RxContentControl(Action<ContentControl> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxContentControlExtensions
    {
        public static T Content<T>(this T contentcontrol, object content) where T : IRxContentControl
        {
            contentcontrol.Content = new PropertyValue<object>(content);
            return contentcontrol;
        }
        public static T ContentStringFormat<T>(this T contentcontrol, string contentStringFormat) where T : IRxContentControl
        {
            contentcontrol.ContentStringFormat = new PropertyValue<string>(contentStringFormat);
            return contentcontrol;
        }
    }
}
