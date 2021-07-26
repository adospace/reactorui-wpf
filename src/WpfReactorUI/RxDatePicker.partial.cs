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
    public partial interface IRxDatePicker
    {
        Action<DateTime?>? SelectedDateChangedActionWithSingleArg { get; set; }
    }

    public partial class RxDatePicker<T>
    {
        Action<DateTime?>? IRxDatePicker.SelectedDateChangedActionWithSingleArg { get; set; }


        partial void OnAttachingNewEvents()
        {
            var thisAsIRxDatePicker = (IRxDatePicker)this;
            if (thisAsIRxDatePicker.SelectedDateChangedActionWithSingleArg != null)
            {
                NativeControl.SelectedDateChanged += NativeControl_SelectedDateChangedForSingleArg;
            }
        }

        private void NativeControl_SelectedDateChangedForSingleArg(object? sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            if (datePicker == null) return;
            var thisAsIRxDatePicker = (IRxDatePicker)this;
            thisAsIRxDatePicker.SelectedDateChangedActionWithSingleArg?.Invoke(datePicker.SelectedDate);
        }

        partial void OnDetachingNewEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.SelectedDateChanged -= NativeControl_SelectedDateChangedForSingleArg;
            }
        }
    }

    public static partial class RxPasswordBoxExtensions
    {
        public static T OnSelectedDateChanged<T>(this T passwordbox, Action<DateTime?> action) where T : IRxDatePicker
        {
            passwordbox.SelectedDateChangedActionWithSingleArg = action;
            return passwordbox;
        }
    }
}
