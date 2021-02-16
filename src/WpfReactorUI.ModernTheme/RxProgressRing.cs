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
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;

namespace WpfReactorUI.ModernTheme
{
    public partial interface IRxProgressRing : IRxControl
    {
        PropertyValue<bool>? IsActive { get; set; }

    }
    public partial class RxProgressRing<T> : RxControl<T>, IRxProgressRing where T : ProgressRing, new()
    {
        public RxProgressRing()
        {

        }

        public RxProgressRing(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxProgressRing.IsActive { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxProgressRing = (IRxProgressRing)this;
            SetPropertyValue(NativeControl, ProgressRing.IsActiveProperty, thisAsIRxProgressRing.IsActive);

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
    public partial class RxProgressRing : RxProgressRing<ProgressRing>
    {
        public RxProgressRing()
        {

        }

        public RxProgressRing(Action<ProgressRing?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxProgressRingExtensions
    {
        public static T IsActive<T>(this T progressring, bool isActive) where T : IRxProgressRing
        {
            progressring.IsActive = new PropertyValue<bool>(isActive);
            return progressring;
        }
        public static T IsActive<T>(this T progressring, Func<bool> isActiveFunc) where T : IRxProgressRing
        {
            progressring.IsActive = new PropertyValue<bool>(isActiveFunc);
            return progressring;
        }
    }
}
