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


using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxVisual : IVisualNode
    {

    }

    public partial class RxVisual<T> : VisualNode<T>, IRxVisual where T : Visual, new()
    {
        public RxVisual()
        {

        }

        public RxVisual(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }



        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxVisual = (IRxVisual)this;

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxVisual = (IRxVisual)this;

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
    public static partial class RxVisualExtensions
    {
    }
}
