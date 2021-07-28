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
using System.Linq;

namespace WpfReactorUI
{
    public partial interface IRxComboBox
    {
        Action<object?>? SelectedItemChangedActionWithSingleArg { get; set; }
    }

    public partial class RxComboBox<T>
    {
        Action<object?>? IRxComboBox.SelectedItemChangedActionWithSingleArg { get; set; }


        partial void OnAttachingNewEvents()
        {
            var thisAsIRxComboBox = (IRxComboBox)this;
            if (thisAsIRxComboBox.SelectedItemChangedActionWithSingleArg != null)
            {
                NativeControl.SelectionChanged += NativeControl_SelectedItemChangedForSingleArg;
            }
        }

        private void NativeControl_SelectedItemChangedForSingleArg(object? sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            if (combobox == null) return;
            var thisAsIRxComboBox = (IRxComboBox)this;
            thisAsIRxComboBox.SelectedItemChangedActionWithSingleArg?.Invoke(combobox.SelectedItem);
        }

        partial void OnDetachingNewEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.SelectionChanged -= NativeControl_SelectedItemChangedForSingleArg;
            }
        }
    }

    public static partial class RxComboBoxExtensions
    {
        public static T OnSelectedItemChanged<T>(this T passwordbox, Action<object?> action) where T : IRxComboBox
        {
            passwordbox.SelectedItemChangedActionWithSingleArg = action;
            return passwordbox;
        }
    }
}
