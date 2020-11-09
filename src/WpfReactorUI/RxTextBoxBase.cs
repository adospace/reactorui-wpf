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
    public partial interface IRxTextBoxBase : IRxControl
    {
        PropertyValue<bool> AcceptsReturn { get; set; }
        PropertyValue<bool> AcceptsTab { get; set; }
        PropertyValue<bool> AutoWordSelection { get; set; }
        PropertyValue<Brush> CaretBrush { get; set; }
        PropertyValue<ScrollBarVisibility> HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool> IsInactiveSelectionHighlightEnabled { get; set; }
        PropertyValue<bool> IsReadOnly { get; set; }
        PropertyValue<bool> IsReadOnlyCaretVisible { get; set; }
        PropertyValue<bool> IsUndoEnabled { get; set; }
        PropertyValue<Brush> SelectionBrush { get; set; }
        PropertyValue<double> SelectionOpacity { get; set; }
        PropertyValue<Brush> SelectionTextBrush { get; set; }
        PropertyValue<int> UndoLimit { get; set; }
        PropertyValue<ScrollBarVisibility> VerticalScrollBarVisibility { get; set; }

        Action SelectionChangedAction { get; set; }
        Action<object, RoutedEventArgs> SelectionChangedActionWithArgs { get; set; }
        Action TextChangedAction { get; set; }
        Action<object, TextChangedEventArgs> TextChangedActionWithArgs { get; set; }
    }

    public partial class RxTextBoxBase<T> : RxControl<T>, IRxTextBoxBase where T : TextBoxBase, new()
    {
        public RxTextBoxBase()
        {

        }

        public RxTextBoxBase(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool> IRxTextBoxBase.AcceptsReturn { get; set; }
        PropertyValue<bool> IRxTextBoxBase.AcceptsTab { get; set; }
        PropertyValue<bool> IRxTextBoxBase.AutoWordSelection { get; set; }
        PropertyValue<Brush> IRxTextBoxBase.CaretBrush { get; set; }
        PropertyValue<ScrollBarVisibility> IRxTextBoxBase.HorizontalScrollBarVisibility { get; set; }
        PropertyValue<bool> IRxTextBoxBase.IsInactiveSelectionHighlightEnabled { get; set; }
        PropertyValue<bool> IRxTextBoxBase.IsReadOnly { get; set; }
        PropertyValue<bool> IRxTextBoxBase.IsReadOnlyCaretVisible { get; set; }
        PropertyValue<bool> IRxTextBoxBase.IsUndoEnabled { get; set; }
        PropertyValue<Brush> IRxTextBoxBase.SelectionBrush { get; set; }
        PropertyValue<double> IRxTextBoxBase.SelectionOpacity { get; set; }
        PropertyValue<Brush> IRxTextBoxBase.SelectionTextBrush { get; set; }
        PropertyValue<int> IRxTextBoxBase.UndoLimit { get; set; }
        PropertyValue<ScrollBarVisibility> IRxTextBoxBase.VerticalScrollBarVisibility { get; set; }

        Action IRxTextBoxBase.SelectionChangedAction { get; set; }
        Action<object, RoutedEventArgs> IRxTextBoxBase.SelectionChangedActionWithArgs { get; set; }
        Action IRxTextBoxBase.TextChangedAction { get; set; }
        Action<object, TextChangedEventArgs> IRxTextBoxBase.TextChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTextBoxBase = (IRxTextBoxBase)this;
            NativeControl.Set(this, TextBoxBase.AcceptsReturnProperty, thisAsIRxTextBoxBase.AcceptsReturn);
            NativeControl.Set(this, TextBoxBase.AcceptsTabProperty, thisAsIRxTextBoxBase.AcceptsTab);
            NativeControl.Set(this, TextBoxBase.AutoWordSelectionProperty, thisAsIRxTextBoxBase.AutoWordSelection);
            NativeControl.Set(this, TextBoxBase.CaretBrushProperty, thisAsIRxTextBoxBase.CaretBrush);
            NativeControl.Set(this, TextBoxBase.HorizontalScrollBarVisibilityProperty, thisAsIRxTextBoxBase.HorizontalScrollBarVisibility);
            NativeControl.Set(this, TextBoxBase.IsInactiveSelectionHighlightEnabledProperty, thisAsIRxTextBoxBase.IsInactiveSelectionHighlightEnabled);
            NativeControl.Set(this, TextBoxBase.IsReadOnlyProperty, thisAsIRxTextBoxBase.IsReadOnly);
            NativeControl.Set(this, TextBoxBase.IsReadOnlyCaretVisibleProperty, thisAsIRxTextBoxBase.IsReadOnlyCaretVisible);
            NativeControl.Set(this, TextBoxBase.IsUndoEnabledProperty, thisAsIRxTextBoxBase.IsUndoEnabled);
            NativeControl.Set(this, TextBoxBase.SelectionBrushProperty, thisAsIRxTextBoxBase.SelectionBrush);
            NativeControl.Set(this, TextBoxBase.SelectionOpacityProperty, thisAsIRxTextBoxBase.SelectionOpacity);
            NativeControl.Set(this, TextBoxBase.SelectionTextBrushProperty, thisAsIRxTextBoxBase.SelectionTextBrush);
            NativeControl.Set(this, TextBoxBase.UndoLimitProperty, thisAsIRxTextBoxBase.UndoLimit);
            NativeControl.Set(this, TextBoxBase.VerticalScrollBarVisibilityProperty, thisAsIRxTextBoxBase.VerticalScrollBarVisibility);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
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

        private void NativeControl_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var thisAsIRxTextBoxBase = (IRxTextBoxBase)this;
            thisAsIRxTextBoxBase.SelectionChangedAction?.Invoke();
            thisAsIRxTextBoxBase.SelectionChangedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_TextChanged(object sender, TextChangedEventArgs e)
        {
            var thisAsIRxTextBoxBase = (IRxTextBoxBase)this;
            thisAsIRxTextBoxBase.TextChangedAction?.Invoke();
            thisAsIRxTextBoxBase.TextChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
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
        public static T AcceptsTab<T>(this T textboxbase, bool acceptsTab) where T : IRxTextBoxBase
        {
            textboxbase.AcceptsTab = new PropertyValue<bool>(acceptsTab);
            return textboxbase;
        }
        public static T AutoWordSelection<T>(this T textboxbase, bool autoWordSelection) where T : IRxTextBoxBase
        {
            textboxbase.AutoWordSelection = new PropertyValue<bool>(autoWordSelection);
            return textboxbase;
        }
        public static T CaretBrush<T>(this T textboxbase, Brush caretBrush) where T : IRxTextBoxBase
        {
            textboxbase.CaretBrush = new PropertyValue<Brush>(caretBrush);
            return textboxbase;
        }
        public static T HorizontalScrollBarVisibility<T>(this T textboxbase, ScrollBarVisibility horizontalScrollBarVisibility) where T : IRxTextBoxBase
        {
            textboxbase.HorizontalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(horizontalScrollBarVisibility);
            return textboxbase;
        }
        public static T IsInactiveSelectionHighlightEnabled<T>(this T textboxbase, bool isInactiveSelectionHighlightEnabled) where T : IRxTextBoxBase
        {
            textboxbase.IsInactiveSelectionHighlightEnabled = new PropertyValue<bool>(isInactiveSelectionHighlightEnabled);
            return textboxbase;
        }
        public static T IsReadOnly<T>(this T textboxbase, bool isReadOnly) where T : IRxTextBoxBase
        {
            textboxbase.IsReadOnly = new PropertyValue<bool>(isReadOnly);
            return textboxbase;
        }
        public static T IsReadOnlyCaretVisible<T>(this T textboxbase, bool isReadOnlyCaretVisible) where T : IRxTextBoxBase
        {
            textboxbase.IsReadOnlyCaretVisible = new PropertyValue<bool>(isReadOnlyCaretVisible);
            return textboxbase;
        }
        public static T IsUndoEnabled<T>(this T textboxbase, bool isUndoEnabled) where T : IRxTextBoxBase
        {
            textboxbase.IsUndoEnabled = new PropertyValue<bool>(isUndoEnabled);
            return textboxbase;
        }
        public static T SelectionBrush<T>(this T textboxbase, Brush selectionBrush) where T : IRxTextBoxBase
        {
            textboxbase.SelectionBrush = new PropertyValue<Brush>(selectionBrush);
            return textboxbase;
        }
        public static T SelectionOpacity<T>(this T textboxbase, double selectionOpacity) where T : IRxTextBoxBase
        {
            textboxbase.SelectionOpacity = new PropertyValue<double>(selectionOpacity);
            return textboxbase;
        }
        public static T SelectionTextBrush<T>(this T textboxbase, Brush selectionTextBrush) where T : IRxTextBoxBase
        {
            textboxbase.SelectionTextBrush = new PropertyValue<Brush>(selectionTextBrush);
            return textboxbase;
        }
        public static T UndoLimit<T>(this T textboxbase, int undoLimit) where T : IRxTextBoxBase
        {
            textboxbase.UndoLimit = new PropertyValue<int>(undoLimit);
            return textboxbase;
        }
        public static T VerticalScrollBarVisibility<T>(this T textboxbase, ScrollBarVisibility verticalScrollBarVisibility) where T : IRxTextBoxBase
        {
            textboxbase.VerticalScrollBarVisibility = new PropertyValue<ScrollBarVisibility>(verticalScrollBarVisibility);
            return textboxbase;
        }
        public static T OnSelectionChanged<T>(this T textboxbase, Action selectionchangedAction) where T : IRxTextBoxBase
        {
            textboxbase.SelectionChangedAction = selectionchangedAction;
            return textboxbase;
        }

        public static T OnSelectionChanged<T>(this T textboxbase, Action<object, RoutedEventArgs> selectionchangedActionWithArgs) where T : IRxTextBoxBase
        {
            textboxbase.SelectionChangedActionWithArgs = selectionchangedActionWithArgs;
            return textboxbase;
        }
        public static T OnTextChanged<T>(this T textboxbase, Action textchangedAction) where T : IRxTextBoxBase
        {
            textboxbase.TextChangedAction = textchangedAction;
            return textboxbase;
        }

        public static T OnTextChanged<T>(this T textboxbase, Action<object, TextChangedEventArgs> textchangedActionWithArgs) where T : IRxTextBoxBase
        {
            textboxbase.TextChangedActionWithArgs = textchangedActionWithArgs;
            return textboxbase;
        }
    }
}
