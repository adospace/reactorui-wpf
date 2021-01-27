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
using System.Windows.Navigation;

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxTextBoxBase : IRxControl
    {
        PropertyValue<bool>? AcceptsReturn { get; set; }
        PropertyValue<bool>? AcceptsTab { get; set; }
        PropertyValue<bool>? AutoWordSelection { get; set; }
        PropertyValue<Brush>? CaretBrush { get; set; }
        PropertyValue<ScrollBarVisibility>? HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool>? IsInactiveSelectionHighlightEnabled { get; set; }
        PropertyValue<bool>? IsReadOnly { get; set; }
        PropertyValue<bool>? IsReadOnlyCaretVisible { get; set; }
        PropertyValue<bool>? IsUndoEnabled { get; set; }
        PropertyValue<Brush>? SelectionBrush { get; set; }
        PropertyValue<double>? SelectionOpacity { get; set; }
        PropertyValue<Brush>? SelectionTextBrush { get; set; }
        PropertyValue<int>? UndoLimit { get; set; }
        PropertyValue<ScrollBarVisibility>? VerticalScrollBarVisibility { get; set; }

        Action? SelectionChangedAction { get; set; }
        Action<object?, RoutedEventArgs>? SelectionChangedActionWithArgs { get; set; }
        Action? TextChangedAction { get; set; }
        Action<object?, TextChangedEventArgs>? TextChangedActionWithArgs { get; set; }
    }

    public partial class RxTextBoxBase<T> : RxControl<T>, IRxTextBoxBase where T : TextBoxBase, new()
    {
        public RxTextBoxBase()
        {

        }

        public RxTextBoxBase(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxTextBoxBase.AcceptsReturn { get; set; }
        PropertyValue<bool>? IRxTextBoxBase.AcceptsTab { get; set; }
        PropertyValue<bool>? IRxTextBoxBase.AutoWordSelection { get; set; }
        PropertyValue<Brush>? IRxTextBoxBase.CaretBrush { get; set; }
        PropertyValue<ScrollBarVisibility>? IRxTextBoxBase.HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool>? IRxTextBoxBase.IsInactiveSelectionHighlightEnabled { get; set; }
        PropertyValue<bool>? IRxTextBoxBase.IsReadOnly { get; set; }
        PropertyValue<bool>? IRxTextBoxBase.IsReadOnlyCaretVisible { get; set; }
        PropertyValue<bool>? IRxTextBoxBase.IsUndoEnabled { get; set; }
        PropertyValue<Brush>? IRxTextBoxBase.SelectionBrush { get; set; }
        PropertyValue<double>? IRxTextBoxBase.SelectionOpacity { get; set; }
        PropertyValue<Brush>? IRxTextBoxBase.SelectionTextBrush { get; set; }
        PropertyValue<int>? IRxTextBoxBase.UndoLimit { get; set; }
        PropertyValue<ScrollBarVisibility>? IRxTextBoxBase.VerticalScrollBarVisibility { get; set; }

        Action? IRxTextBoxBase.SelectionChangedAction { get; set; }
        Action<object?, RoutedEventArgs>? IRxTextBoxBase.SelectionChangedActionWithArgs { get; set; }
        Action? IRxTextBoxBase.TextChangedAction { get; set; }
        Action<object?, TextChangedEventArgs>? IRxTextBoxBase.TextChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTextBoxBase = (IRxTextBoxBase)this;
            SetPropertyValue(NativeControl, TextBoxBase.AcceptsReturnProperty, thisAsIRxTextBoxBase.AcceptsReturn);
            SetPropertyValue(NativeControl, TextBoxBase.AcceptsTabProperty, thisAsIRxTextBoxBase.AcceptsTab);
            SetPropertyValue(NativeControl, TextBoxBase.AutoWordSelectionProperty, thisAsIRxTextBoxBase.AutoWordSelection);
            SetPropertyValue(NativeControl, TextBoxBase.CaretBrushProperty, thisAsIRxTextBoxBase.CaretBrush);
            SetPropertyValue(NativeControl, TextBoxBase.HorizontalScrollBarVisibilityProperty, thisAsIRxTextBoxBase.HorizontalScrollBarVisibility);
            SetPropertyValue(NativeControl, TextBoxBase.IsInactiveSelectionHighlightEnabledProperty, thisAsIRxTextBoxBase.IsInactiveSelectionHighlightEnabled);
            SetPropertyValue(NativeControl, TextBoxBase.IsReadOnlyProperty, thisAsIRxTextBoxBase.IsReadOnly);
            SetPropertyValue(NativeControl, TextBoxBase.IsReadOnlyCaretVisibleProperty, thisAsIRxTextBoxBase.IsReadOnlyCaretVisible);
            SetPropertyValue(NativeControl, TextBoxBase.IsUndoEnabledProperty, thisAsIRxTextBoxBase.IsUndoEnabled);
            SetPropertyValue(NativeControl, TextBoxBase.SelectionBrushProperty, thisAsIRxTextBoxBase.SelectionBrush);
            SetPropertyValue(NativeControl, TextBoxBase.SelectionOpacityProperty, thisAsIRxTextBoxBase.SelectionOpacity);
            SetPropertyValue(NativeControl, TextBoxBase.SelectionTextBrushProperty, thisAsIRxTextBoxBase.SelectionTextBrush);
            SetPropertyValue(NativeControl, TextBoxBase.UndoLimitProperty, thisAsIRxTextBoxBase.UndoLimit);
            SetPropertyValue(NativeControl, TextBoxBase.VerticalScrollBarVisibilityProperty, thisAsIRxTextBoxBase.VerticalScrollBarVisibility);

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

            var thisAsIRxTextBoxBase = (IRxTextBoxBase)this;
            if (thisAsIRxTextBoxBase.SelectionChangedAction != null || thisAsIRxTextBoxBase.SelectionChangedActionWithArgs != null)
            {
                NativeControl.SelectionChanged += NativeControl_SelectionChanged;
            }
            if (thisAsIRxTextBoxBase.TextChangedAction != null || thisAsIRxTextBoxBase.TextChangedActionWithArgs != null)
            {
                NativeControl.TextChanged += NativeControl_TextChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_SelectionChanged(object? sender, RoutedEventArgs e)
        {
            var thisAsIRxTextBoxBase = (IRxTextBoxBase)this;
            thisAsIRxTextBoxBase.SelectionChangedAction?.Invoke();
            thisAsIRxTextBoxBase.SelectionChangedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_TextChanged(object? sender, TextChangedEventArgs e)
        {
            var thisAsIRxTextBoxBase = (IRxTextBoxBase)this;
            thisAsIRxTextBoxBase.TextChangedAction?.Invoke();
            thisAsIRxTextBoxBase.TextChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.SelectionChanged -= NativeControl_SelectionChanged;
                NativeControl.TextChanged -= NativeControl_TextChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public static partial class RxTextBoxBaseExtensions
    {
        public static T AcceptsReturn<T>(this T textboxbase, bool acceptsReturn) where T : IRxTextBoxBase
        {
            textboxbase.AcceptsReturn = new PropertyValue<bool>(acceptsReturn);
            return textboxbase;
        }
        public static T AcceptsReturn<T>(this T textboxbase, Func<bool> acceptsReturnFunc) where T : IRxTextBoxBase
        {
            textboxbase.AcceptsReturn = new PropertyValue<bool>(acceptsReturnFunc);
            return textboxbase;
        }
        public static T AcceptsTab<T>(this T textboxbase, bool acceptsTab) where T : IRxTextBoxBase
        {
            textboxbase.AcceptsTab = new PropertyValue<bool>(acceptsTab);
            return textboxbase;
        }
        public static T AcceptsTab<T>(this T textboxbase, Func<bool> acceptsTabFunc) where T : IRxTextBoxBase
        {
            textboxbase.AcceptsTab = new PropertyValue<bool>(acceptsTabFunc);
            return textboxbase;
        }
        public static T AutoWordSelection<T>(this T textboxbase, bool autoWordSelection) where T : IRxTextBoxBase
        {
            textboxbase.AutoWordSelection = new PropertyValue<bool>(autoWordSelection);
            return textboxbase;
        }
        public static T AutoWordSelection<T>(this T textboxbase, Func<bool> autoWordSelectionFunc) where T : IRxTextBoxBase
        {
            textboxbase.AutoWordSelection = new PropertyValue<bool>(autoWordSelectionFunc);
            return textboxbase;
        }
        public static T CaretBrush<T>(this T textboxbase, Brush caretBrush) where T : IRxTextBoxBase
        {
            textboxbase.CaretBrush = new PropertyValue<Brush>(caretBrush);
            return textboxbase;
        }
        public static T CaretBrush<T>(this T textboxbase, Func<Brush> caretBrushFunc) where T : IRxTextBoxBase
        {
            textboxbase.CaretBrush = new PropertyValue<Brush>(caretBrushFunc);
            return textboxbase;
        }
        public static T HorizontalScrollBarVisibility<T>(this T textboxbase, ScrollBarVisibility horizontalScrollBarVisibility) where T : IRxTextBoxBase
        {
            textboxbase.HorizontalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(horizontalScrollBarVisibility);
            return textboxbase;
        }
        public static T HorizontalScrollBarVisibility<T>(this T textboxbase, Func<ScrollBarVisibility> horizontalScrollBarVisibilityFunc) where T : IRxTextBoxBase
        {
            textboxbase.HorizontalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(horizontalScrollBarVisibilityFunc);
            return textboxbase;
        }
        public static T IsInactiveSelectionHighlightEnabled<T>(this T textboxbase, bool isInactiveSelectionHighlightEnabled) where T : IRxTextBoxBase
        {
            textboxbase.IsInactiveSelectionHighlightEnabled = new PropertyValue<bool>(isInactiveSelectionHighlightEnabled);
            return textboxbase;
        }
        public static T IsInactiveSelectionHighlightEnabled<T>(this T textboxbase, Func<bool> isInactiveSelectionHighlightEnabledFunc) where T : IRxTextBoxBase
        {
            textboxbase.IsInactiveSelectionHighlightEnabled = new PropertyValue<bool>(isInactiveSelectionHighlightEnabledFunc);
            return textboxbase;
        }
        public static T IsReadOnly<T>(this T textboxbase, bool isReadOnly) where T : IRxTextBoxBase
        {
            textboxbase.IsReadOnly = new PropertyValue<bool>(isReadOnly);
            return textboxbase;
        }
        public static T IsReadOnly<T>(this T textboxbase, Func<bool> isReadOnlyFunc) where T : IRxTextBoxBase
        {
            textboxbase.IsReadOnly = new PropertyValue<bool>(isReadOnlyFunc);
            return textboxbase;
        }
        public static T IsReadOnlyCaretVisible<T>(this T textboxbase, bool isReadOnlyCaretVisible) where T : IRxTextBoxBase
        {
            textboxbase.IsReadOnlyCaretVisible = new PropertyValue<bool>(isReadOnlyCaretVisible);
            return textboxbase;
        }
        public static T IsReadOnlyCaretVisible<T>(this T textboxbase, Func<bool> isReadOnlyCaretVisibleFunc) where T : IRxTextBoxBase
        {
            textboxbase.IsReadOnlyCaretVisible = new PropertyValue<bool>(isReadOnlyCaretVisibleFunc);
            return textboxbase;
        }
        public static T IsUndoEnabled<T>(this T textboxbase, bool isUndoEnabled) where T : IRxTextBoxBase
        {
            textboxbase.IsUndoEnabled = new PropertyValue<bool>(isUndoEnabled);
            return textboxbase;
        }
        public static T IsUndoEnabled<T>(this T textboxbase, Func<bool> isUndoEnabledFunc) where T : IRxTextBoxBase
        {
            textboxbase.IsUndoEnabled = new PropertyValue<bool>(isUndoEnabledFunc);
            return textboxbase;
        }
        public static T SelectionBrush<T>(this T textboxbase, Brush selectionBrush) where T : IRxTextBoxBase
        {
            textboxbase.SelectionBrush = new PropertyValue<Brush>(selectionBrush);
            return textboxbase;
        }
        public static T SelectionBrush<T>(this T textboxbase, Func<Brush> selectionBrushFunc) where T : IRxTextBoxBase
        {
            textboxbase.SelectionBrush = new PropertyValue<Brush>(selectionBrushFunc);
            return textboxbase;
        }
        public static T SelectionOpacity<T>(this T textboxbase, double selectionOpacity) where T : IRxTextBoxBase
        {
            textboxbase.SelectionOpacity = new PropertyValue<double>(selectionOpacity);
            return textboxbase;
        }
        public static T SelectionOpacity<T>(this T textboxbase, Func<double> selectionOpacityFunc) where T : IRxTextBoxBase
        {
            textboxbase.SelectionOpacity = new PropertyValue<double>(selectionOpacityFunc);
            return textboxbase;
        }
        public static T SelectionTextBrush<T>(this T textboxbase, Brush selectionTextBrush) where T : IRxTextBoxBase
        {
            textboxbase.SelectionTextBrush = new PropertyValue<Brush>(selectionTextBrush);
            return textboxbase;
        }
        public static T SelectionTextBrush<T>(this T textboxbase, Func<Brush> selectionTextBrushFunc) where T : IRxTextBoxBase
        {
            textboxbase.SelectionTextBrush = new PropertyValue<Brush>(selectionTextBrushFunc);
            return textboxbase;
        }
        public static T UndoLimit<T>(this T textboxbase, int undoLimit) where T : IRxTextBoxBase
        {
            textboxbase.UndoLimit = new PropertyValue<int>(undoLimit);
            return textboxbase;
        }
        public static T UndoLimit<T>(this T textboxbase, Func<int> undoLimitFunc) where T : IRxTextBoxBase
        {
            textboxbase.UndoLimit = new PropertyValue<int>(undoLimitFunc);
            return textboxbase;
        }
        public static T VerticalScrollBarVisibility<T>(this T textboxbase, ScrollBarVisibility verticalScrollBarVisibility) where T : IRxTextBoxBase
        {
            textboxbase.VerticalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(verticalScrollBarVisibility);
            return textboxbase;
        }
        public static T VerticalScrollBarVisibility<T>(this T textboxbase, Func<ScrollBarVisibility> verticalScrollBarVisibilityFunc) where T : IRxTextBoxBase
        {
            textboxbase.VerticalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(verticalScrollBarVisibilityFunc);
            return textboxbase;
        }
        public static T OnSelectionChanged<T>(this T textboxbase, Action selectionchangedAction) where T : IRxTextBoxBase
        {
            textboxbase.SelectionChangedAction = selectionchangedAction;
            return textboxbase;
        }

        public static T OnSelectionChanged<T>(this T textboxbase, Action<object?, RoutedEventArgs> selectionchangedActionWithArgs) where T : IRxTextBoxBase
        {
            textboxbase.SelectionChangedActionWithArgs = selectionchangedActionWithArgs;
            return textboxbase;
        }
        public static T OnTextChanged<T>(this T textboxbase, Action textchangedAction) where T : IRxTextBoxBase
        {
            textboxbase.TextChangedAction = textchangedAction;
            return textboxbase;
        }

        public static T OnTextChanged<T>(this T textboxbase, Action<object?, TextChangedEventArgs> textchangedActionWithArgs) where T : IRxTextBoxBase
        {
            textboxbase.TextChangedActionWithArgs = textchangedActionWithArgs;
            return textboxbase;
        }
    }
}
