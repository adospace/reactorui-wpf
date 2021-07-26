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
    public partial interface IRxDatePicker : IRxControl
    {
        PropertyValue<Style>? CalendarStyle { get; set; }
        PropertyValue<DateTime>? DisplayDate { get; set; }
        PropertyValue<DateTime>? DisplayDateEnd { get; set; }
        PropertyValue<DateTime>? DisplayDateStart { get; set; }
        PropertyValue<DayOfWeek>? FirstDayOfWeek { get; set; }
        PropertyValue<bool>? IsDropDownOpen { get; set; }
        PropertyValue<bool>? IsTodayHighlighted { get; set; }
        PropertyValue<DateTime>? SelectedDate { get; set; }
        PropertyValue<DatePickerFormat>? SelectedDateFormat { get; set; }
        PropertyValue<string>? Text { get; set; }

        Action? CalendarClosedAction { get; set; }
        Action<object?, RoutedEventArgs>? CalendarClosedActionWithArgs { get; set; }
        Action? CalendarOpenedAction { get; set; }
        Action<object?, RoutedEventArgs>? CalendarOpenedActionWithArgs { get; set; }
        Action? DateValidationErrorAction { get; set; }
        Action<object?, DatePickerDateValidationErrorEventArgs>? DateValidationErrorActionWithArgs { get; set; }
        Action? SelectedDateChangedAction { get; set; }
        Action<object?, SelectionChangedEventArgs>? SelectedDateChangedActionWithArgs { get; set; }
    }
    public partial class RxDatePicker<T> : RxControl<T>, IRxDatePicker where T : DatePicker, new()
    {
        public RxDatePicker()
        {

        }

        public RxDatePicker(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Style>? IRxDatePicker.CalendarStyle { get; set; }
        PropertyValue<DateTime>? IRxDatePicker.DisplayDate { get; set; }
        PropertyValue<DateTime>? IRxDatePicker.DisplayDateEnd { get; set; }
        PropertyValue<DateTime>? IRxDatePicker.DisplayDateStart { get; set; }
        PropertyValue<DayOfWeek>? IRxDatePicker.FirstDayOfWeek { get; set; }
        PropertyValue<bool>? IRxDatePicker.IsDropDownOpen { get; set; }
        PropertyValue<bool>? IRxDatePicker.IsTodayHighlighted { get; set; }
        PropertyValue<DateTime>? IRxDatePicker.SelectedDate { get; set; }
        PropertyValue<DatePickerFormat>? IRxDatePicker.SelectedDateFormat { get; set; }
        PropertyValue<string>? IRxDatePicker.Text { get; set; }

        Action? IRxDatePicker.CalendarClosedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxDatePicker.CalendarClosedActionWithArgs { get; set; }
        Action? IRxDatePicker.CalendarOpenedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxDatePicker.CalendarOpenedActionWithArgs { get; set; }
        Action? IRxDatePicker.DateValidationErrorAction { get; set; }
        Action<object?, DatePickerDateValidationErrorEventArgs>? IRxDatePicker.DateValidationErrorActionWithArgs { get; set; }
        Action? IRxDatePicker.SelectedDateChangedAction { get; set; }
        Action<object?, SelectionChangedEventArgs>? IRxDatePicker.SelectedDateChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxDatePicker = (IRxDatePicker)this;
            SetPropertyValue(NativeControl, DatePicker.CalendarStyleProperty, thisAsIRxDatePicker.CalendarStyle);
            SetPropertyValue(NativeControl, DatePicker.DisplayDateProperty, thisAsIRxDatePicker.DisplayDate);
            SetPropertyValue(NativeControl, DatePicker.DisplayDateEndProperty, thisAsIRxDatePicker.DisplayDateEnd);
            SetPropertyValue(NativeControl, DatePicker.DisplayDateStartProperty, thisAsIRxDatePicker.DisplayDateStart);
            SetPropertyValue(NativeControl, DatePicker.FirstDayOfWeekProperty, thisAsIRxDatePicker.FirstDayOfWeek);
            SetPropertyValue(NativeControl, DatePicker.IsDropDownOpenProperty, thisAsIRxDatePicker.IsDropDownOpen);
            SetPropertyValue(NativeControl, DatePicker.IsTodayHighlightedProperty, thisAsIRxDatePicker.IsTodayHighlighted);
            SetPropertyValue(NativeControl, DatePicker.SelectedDateProperty, thisAsIRxDatePicker.SelectedDate);
            SetPropertyValue(NativeControl, DatePicker.SelectedDateFormatProperty, thisAsIRxDatePicker.SelectedDateFormat);
            SetPropertyValue(NativeControl, DatePicker.TextProperty, thisAsIRxDatePicker.Text);

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

            var thisAsIRxDatePicker = (IRxDatePicker)this;
            if (thisAsIRxDatePicker.CalendarClosedAction != null || thisAsIRxDatePicker.CalendarClosedActionWithArgs != null)
            {
                NativeControl.CalendarClosed += NativeControl_CalendarClosed;
            }
            if (thisAsIRxDatePicker.CalendarOpenedAction != null || thisAsIRxDatePicker.CalendarOpenedActionWithArgs != null)
            {
                NativeControl.CalendarOpened += NativeControl_CalendarOpened;
            }
            if (thisAsIRxDatePicker.DateValidationErrorAction != null || thisAsIRxDatePicker.DateValidationErrorActionWithArgs != null)
            {
                NativeControl.DateValidationError += NativeControl_DateValidationError;
            }
            if (thisAsIRxDatePicker.SelectedDateChangedAction != null || thisAsIRxDatePicker.SelectedDateChangedActionWithArgs != null)
            {
                NativeControl.SelectedDateChanged += NativeControl_SelectedDateChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_CalendarClosed(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxDatePicker = (IRxDatePicker)this;
            thisAsIRxDatePicker.CalendarClosedAction?.Invoke();
            thisAsIRxDatePicker.CalendarClosedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_CalendarOpened(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxDatePicker = (IRxDatePicker)this;
            thisAsIRxDatePicker.CalendarOpenedAction?.Invoke();
            thisAsIRxDatePicker.CalendarOpenedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_DateValidationError(object? sender, DatePickerDateValidationErrorEventArgs e)
        {
            var thisAsIRxDatePicker = (IRxDatePicker)this;
            thisAsIRxDatePicker.DateValidationErrorAction?.Invoke();
            thisAsIRxDatePicker.DateValidationErrorActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_SelectedDateChanged(object? sender, SelectionChangedEventArgs e)
        {
            var thisAsIRxDatePicker = (IRxDatePicker)this;
            thisAsIRxDatePicker.SelectedDateChangedAction?.Invoke();
            thisAsIRxDatePicker.SelectedDateChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.CalendarClosed -= NativeControl_CalendarClosed;
                NativeControl.CalendarOpened -= NativeControl_CalendarOpened;
                NativeControl.DateValidationError -= NativeControl_DateValidationError;
                NativeControl.SelectedDateChanged -= NativeControl_SelectedDateChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxDatePicker : RxDatePicker<DatePicker>
    {
        public RxDatePicker()
        {

        }

        public RxDatePicker(Action<DatePicker?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxDatePickerExtensions
    {
        public static T CalendarStyle<T>(this T datepicker, Style calendarStyle) where T : IRxDatePicker
        {
            datepicker.CalendarStyle = new PropertyValue<Style>(calendarStyle);
            return datepicker;
        }
        public static T CalendarStyle<T>(this T datepicker, Func<Style> calendarStyleFunc) where T : IRxDatePicker
        {
            datepicker.CalendarStyle = new PropertyValue<Style>(calendarStyleFunc);
            return datepicker;
        }
        public static T DisplayDate<T>(this T datepicker, DateTime displayDate) where T : IRxDatePicker
        {
            datepicker.DisplayDate = new PropertyValue<DateTime>(displayDate);
            return datepicker;
        }
        public static T DisplayDate<T>(this T datepicker, Func<DateTime> displayDateFunc) where T : IRxDatePicker
        {
            datepicker.DisplayDate = new PropertyValue<DateTime>(displayDateFunc);
            return datepicker;
        }
        public static T DisplayDateEnd<T>(this T datepicker, DateTime displayDateEnd) where T : IRxDatePicker
        {
            datepicker.DisplayDateEnd = new PropertyValue<DateTime>(displayDateEnd);
            return datepicker;
        }
        public static T DisplayDateEnd<T>(this T datepicker, Func<DateTime> displayDateEndFunc) where T : IRxDatePicker
        {
            datepicker.DisplayDateEnd = new PropertyValue<DateTime>(displayDateEndFunc);
            return datepicker;
        }
        public static T DisplayDateStart<T>(this T datepicker, DateTime displayDateStart) where T : IRxDatePicker
        {
            datepicker.DisplayDateStart = new PropertyValue<DateTime>(displayDateStart);
            return datepicker;
        }
        public static T DisplayDateStart<T>(this T datepicker, Func<DateTime> displayDateStartFunc) where T : IRxDatePicker
        {
            datepicker.DisplayDateStart = new PropertyValue<DateTime>(displayDateStartFunc);
            return datepicker;
        }
        public static T FirstDayOfWeek<T>(this T datepicker, DayOfWeek firstDayOfWeek) where T : IRxDatePicker
        {
            datepicker.FirstDayOfWeek = new PropertyValue<DayOfWeek>(firstDayOfWeek);
            return datepicker;
        }
        public static T FirstDayOfWeek<T>(this T datepicker, Func<DayOfWeek> firstDayOfWeekFunc) where T : IRxDatePicker
        {
            datepicker.FirstDayOfWeek = new PropertyValue<DayOfWeek>(firstDayOfWeekFunc);
            return datepicker;
        }
        public static T IsDropDownOpen<T>(this T datepicker, bool isDropDownOpen) where T : IRxDatePicker
        {
            datepicker.IsDropDownOpen = new PropertyValue<bool>(isDropDownOpen);
            return datepicker;
        }
        public static T IsDropDownOpen<T>(this T datepicker, Func<bool> isDropDownOpenFunc) where T : IRxDatePicker
        {
            datepicker.IsDropDownOpen = new PropertyValue<bool>(isDropDownOpenFunc);
            return datepicker;
        }
        public static T IsTodayHighlighted<T>(this T datepicker, bool isTodayHighlighted) where T : IRxDatePicker
        {
            datepicker.IsTodayHighlighted = new PropertyValue<bool>(isTodayHighlighted);
            return datepicker;
        }
        public static T IsTodayHighlighted<T>(this T datepicker, Func<bool> isTodayHighlightedFunc) where T : IRxDatePicker
        {
            datepicker.IsTodayHighlighted = new PropertyValue<bool>(isTodayHighlightedFunc);
            return datepicker;
        }
        public static T SelectedDate<T>(this T datepicker, DateTime selectedDate) where T : IRxDatePicker
        {
            datepicker.SelectedDate = new PropertyValue<DateTime>(selectedDate);
            return datepicker;
        }
        public static T SelectedDate<T>(this T datepicker, Func<DateTime> selectedDateFunc) where T : IRxDatePicker
        {
            datepicker.SelectedDate = new PropertyValue<DateTime>(selectedDateFunc);
            return datepicker;
        }
        public static T SelectedDateFormat<T>(this T datepicker, DatePickerFormat selectedDateFormat) where T : IRxDatePicker
        {
            datepicker.SelectedDateFormat = new PropertyValue<DatePickerFormat>(selectedDateFormat);
            return datepicker;
        }
        public static T SelectedDateFormat<T>(this T datepicker, Func<DatePickerFormat> selectedDateFormatFunc) where T : IRxDatePicker
        {
            datepicker.SelectedDateFormat = new PropertyValue<DatePickerFormat>(selectedDateFormatFunc);
            return datepicker;
        }
        public static T Text<T>(this T datepicker, string text) where T : IRxDatePicker
        {
            datepicker.Text = new PropertyValue<string>(text);
            return datepicker;
        }
        public static T Text<T>(this T datepicker, Func<string> textFunc) where T : IRxDatePicker
        {
            datepicker.Text = new PropertyValue<string>(textFunc);
            return datepicker;
        }
        public static T OnCalendarClosed<T>(this T datepicker, Action calendarclosedAction) where T : IRxDatePicker
        {
            datepicker.CalendarClosedAction = calendarclosedAction;
            return datepicker;
        }

        public static T OnCalendarClosed<T>(this T datepicker, Action<object?, RoutedEventArgs> calendarclosedActionWithArgs) where T : IRxDatePicker
        {
            datepicker.CalendarClosedActionWithArgs = calendarclosedActionWithArgs;
            return datepicker;
        }
        public static T OnCalendarOpened<T>(this T datepicker, Action calendaropenedAction) where T : IRxDatePicker
        {
            datepicker.CalendarOpenedAction = calendaropenedAction;
            return datepicker;
        }

        public static T OnCalendarOpened<T>(this T datepicker, Action<object?, RoutedEventArgs> calendaropenedActionWithArgs) where T : IRxDatePicker
        {
            datepicker.CalendarOpenedActionWithArgs = calendaropenedActionWithArgs;
            return datepicker;
        }
        public static T OnDateValidationError<T>(this T datepicker, Action datevalidationerrorAction) where T : IRxDatePicker
        {
            datepicker.DateValidationErrorAction = datevalidationerrorAction;
            return datepicker;
        }

        public static T OnDateValidationError<T>(this T datepicker, Action<object?, DatePickerDateValidationErrorEventArgs> datevalidationerrorActionWithArgs) where T : IRxDatePicker
        {
            datepicker.DateValidationErrorActionWithArgs = datevalidationerrorActionWithArgs;
            return datepicker;
        }
        public static T OnSelectedDateChanged<T>(this T datepicker, Action selecteddatechangedAction) where T : IRxDatePicker
        {
            datepicker.SelectedDateChangedAction = selecteddatechangedAction;
            return datepicker;
        }

        public static T OnSelectedDateChanged<T>(this T datepicker, Action<object?, SelectionChangedEventArgs> selecteddatechangedActionWithArgs) where T : IRxDatePicker
        {
            datepicker.SelectedDateChangedActionWithArgs = selecteddatechangedActionWithArgs;
            return datepicker;
        }
    }
}
