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
    public partial interface IRxButton : IRxButtonBase
    {
        PropertyValue<bool>? IsCancel { get; set; }
        PropertyValue<bool>? IsDefault { get; set; }

    }

    public partial class RxButton<T> : RxButtonBase<T>, IRxButton where T : Button, new()
    {
        public RxButton()
        {

        }

        public RxButton(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxButton.IsCancel { get; set; }
        PropertyValue<bool>? IRxButton.IsDefault { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxButton = (IRxButton)this;
            SetPropertyValue(NativeControl, Button.IsCancelProperty, thisAsIRxButton.IsCancel);
            SetPropertyValue(NativeControl, Button.IsDefaultProperty, thisAsIRxButton.IsDefault);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {

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
    public partial class RxButton : RxButton<Button>
    {
        public RxButton()
        {

        }

        public RxButton(Action<Button?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxButtonExtensions
    {
        public static T IsCancel<T>(this T button, bool isCancel) where T : IRxButton
        {
            button.IsCancel = new PropertyValue<bool>(isCancel);
            return button;
        }
        public static T IsCancel<T>(this T button, Func<bool> isCancelFunc) where T : IRxButton
        {
            button.IsCancel = new PropertyValue<bool>(isCancelFunc);
            return button;
        }
        public static T IsDefault<T>(this T button, bool isDefault) where T : IRxButton
        {
            button.IsDefault = new PropertyValue<bool>(isDefault);
            return button;
        }
        public static T IsDefault<T>(this T button, Func<bool> isDefaultFunc) where T : IRxButton
        {
            button.IsDefault = new PropertyValue<bool>(isDefaultFunc);
            return button;
        }
    }
}
