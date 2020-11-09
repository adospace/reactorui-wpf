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
    public partial interface IRxListBox : IRxSelector
    {
        PropertyValue<SelectionMode> SelectionMode { get; set; }

    }

    public partial class RxListBox<T> : RxSelector<T>, IRxListBox where T : ListBox, new()
    {
        public RxListBox()
        {

        }

        public RxListBox(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<SelectionMode> IRxListBox.SelectionMode { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxListBox = (IRxListBox)this;
            NativeControl.Set(this, ListBox.SelectionModeProperty, thisAsIRxListBox.SelectionMode);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxListBox = (IRxListBox)this;

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
    public partial class RxListBox : RxListBox<ListBox>
    {
        public RxListBox()
        {

        }

        public RxListBox(Action<ListBox> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxListBoxExtensions
    {
        public static T SelectionMode<T>(this T listbox, SelectionMode selectionMode) where T : IRxListBox
        {
            listbox.SelectionMode = new PropertyValue<SelectionMode>(selectionMode);
            return listbox;
        }
    }
}