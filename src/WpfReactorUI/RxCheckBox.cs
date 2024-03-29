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
    public partial interface IRxCheckBox : IRxToggleButton
    {

    }
    public partial class RxCheckBox<T> : RxToggleButton<T>, IRxCheckBox where T : CheckBox, new()
    {
        public RxCheckBox()
        {

        }

        public RxCheckBox(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }



        protected override void OnUpdate()
        {
            OnBeginUpdate();


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
    public partial class RxCheckBox : RxCheckBox<CheckBox>
    {
        public RxCheckBox()
        {

        }

        public RxCheckBox(Action<CheckBox?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxCheckBoxExtensions
    {
    }
}
