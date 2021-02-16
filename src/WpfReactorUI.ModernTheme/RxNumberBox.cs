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
    public partial interface IRxNumberBox : IRxControl
    {
        PropertyValue<bool>? AcceptsExpression { get; set; }
        PropertyValue<CornerRadius>? CornerRadius { get; set; }
        PropertyValue<object>? Description { get; set; }
        PropertyValue<object>? Header { get; set; }
        PropertyValue<bool>? IsWrapEnabled { get; set; }
        PropertyValue<double>? LargeChange { get; set; }
        PropertyValue<double>? Maximum { get; set; }
        PropertyValue<double>? Minimum { get; set; }
        PropertyValue<INumberBoxNumberFormatter>? NumberFormatter { get; set; }
        PropertyValue<string>? PlaceholderText { get; set; }
        PropertyValue<Brush>? SelectionBrush { get; set; }
        PropertyValue<double>? SmallChange { get; set; }
        PropertyValue<NumberBoxSpinButtonPlacementMode>? SpinButtonPlacementMode { get; set; }
        PropertyValue<string>? Text { get; set; }
        PropertyValue<TextAlignment>? TextAlignment { get; set; }
        PropertyValue<NumberBoxValidationMode>? ValidationMode { get; set; }
        PropertyValue<double>? Value { get; set; }

        Action? ValueChangedAction { get; set; }
        Action<object?, NumberBoxValueChangedEventArgs>? ValueChangedActionWithArgs { get; set; }
    }
    public partial class RxNumberBox<T> : RxControl<T>, IRxNumberBox where T : NumberBox, new()
    {
        public RxNumberBox()
        {

        }

        public RxNumberBox(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxNumberBox.AcceptsExpression { get; set; }
        PropertyValue<CornerRadius>? IRxNumberBox.CornerRadius { get; set; }
        PropertyValue<object>? IRxNumberBox.Description { get; set; }
        PropertyValue<object>? IRxNumberBox.Header { get; set; }
        PropertyValue<bool>? IRxNumberBox.IsWrapEnabled { get; set; }
        PropertyValue<double>? IRxNumberBox.LargeChange { get; set; }
        PropertyValue<double>? IRxNumberBox.Maximum { get; set; }
        PropertyValue<double>? IRxNumberBox.Minimum { get; set; }
        PropertyValue<INumberBoxNumberFormatter>? IRxNumberBox.NumberFormatter { get; set; }
        PropertyValue<string>? IRxNumberBox.PlaceholderText { get; set; }
        PropertyValue<Brush>? IRxNumberBox.SelectionBrush { get; set; }
        PropertyValue<double>? IRxNumberBox.SmallChange { get; set; }
        PropertyValue<NumberBoxSpinButtonPlacementMode>? IRxNumberBox.SpinButtonPlacementMode { get; set; }
        PropertyValue<string>? IRxNumberBox.Text { get; set; }
        PropertyValue<TextAlignment>? IRxNumberBox.TextAlignment { get; set; }
        PropertyValue<NumberBoxValidationMode>? IRxNumberBox.ValidationMode { get; set; }
        PropertyValue<double>? IRxNumberBox.Value { get; set; }

        Action? IRxNumberBox.ValueChangedAction { get; set; }
        Action<object?, NumberBoxValueChangedEventArgs>? IRxNumberBox.ValueChangedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxNumberBox = (IRxNumberBox)this;
            SetPropertyValue(NativeControl, NumberBox.AcceptsExpressionProperty, thisAsIRxNumberBox.AcceptsExpression);
            SetPropertyValue(NativeControl, NumberBox.CornerRadiusProperty, thisAsIRxNumberBox.CornerRadius);
            SetPropertyValue(NativeControl, NumberBox.DescriptionProperty, thisAsIRxNumberBox.Description);
            SetPropertyValue(NativeControl, NumberBox.HeaderProperty, thisAsIRxNumberBox.Header);
            SetPropertyValue(NativeControl, NumberBox.IsWrapEnabledProperty, thisAsIRxNumberBox.IsWrapEnabled);
            SetPropertyValue(NativeControl, NumberBox.LargeChangeProperty, thisAsIRxNumberBox.LargeChange);
            SetPropertyValue(NativeControl, NumberBox.MaximumProperty, thisAsIRxNumberBox.Maximum);
            SetPropertyValue(NativeControl, NumberBox.MinimumProperty, thisAsIRxNumberBox.Minimum);
            SetPropertyValue(NativeControl, NumberBox.NumberFormatterProperty, thisAsIRxNumberBox.NumberFormatter);
            SetPropertyValue(NativeControl, NumberBox.PlaceholderTextProperty, thisAsIRxNumberBox.PlaceholderText);
            SetPropertyValue(NativeControl, NumberBox.SelectionBrushProperty, thisAsIRxNumberBox.SelectionBrush);
            SetPropertyValue(NativeControl, NumberBox.SmallChangeProperty, thisAsIRxNumberBox.SmallChange);
            SetPropertyValue(NativeControl, NumberBox.SpinButtonPlacementModeProperty, thisAsIRxNumberBox.SpinButtonPlacementMode);
            SetPropertyValue(NativeControl, NumberBox.TextProperty, thisAsIRxNumberBox.Text);
            SetPropertyValue(NativeControl, NumberBox.TextAlignmentProperty, thisAsIRxNumberBox.TextAlignment);
            SetPropertyValue(NativeControl, NumberBox.ValidationModeProperty, thisAsIRxNumberBox.ValidationMode);
            SetPropertyValue(NativeControl, NumberBox.ValueProperty, thisAsIRxNumberBox.Value);

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

            var thisAsIRxNumberBox = (IRxNumberBox)this;
            if (thisAsIRxNumberBox.ValueChangedAction != null || thisAsIRxNumberBox.ValueChangedActionWithArgs != null)
            {
                NativeControl.ValueChanged += NativeControl_ValueChanged;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_ValueChanged(object? sender, NumberBoxValueChangedEventArgs e)
        {
            var thisAsIRxNumberBox = (IRxNumberBox)this;
            thisAsIRxNumberBox.ValueChangedAction?.Invoke();
            thisAsIRxNumberBox.ValueChangedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.ValueChanged -= NativeControl_ValueChanged;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxNumberBox : RxNumberBox<NumberBox>
    {
        public RxNumberBox()
        {

        }

        public RxNumberBox(Action<NumberBox?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxNumberBoxExtensions
    {
        public static T AcceptsExpression<T>(this T numberbox, bool acceptsExpression) where T : IRxNumberBox
        {
            numberbox.AcceptsExpression = new PropertyValue<bool>(acceptsExpression);
            return numberbox;
        }
        public static T AcceptsExpression<T>(this T numberbox, Func<bool> acceptsExpressionFunc) where T : IRxNumberBox
        {
            numberbox.AcceptsExpression = new PropertyValue<bool>(acceptsExpressionFunc);
            return numberbox;
        }
        public static T CornerRadius<T>(this T numberbox, CornerRadius cornerRadius) where T : IRxNumberBox
        {
            numberbox.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return numberbox;
        }
        public static T CornerRadius<T>(this T numberbox, Func<CornerRadius> cornerRadiusFunc) where T : IRxNumberBox
        {
            numberbox.CornerRadius = new PropertyValue<CornerRadius>(cornerRadiusFunc);
            return numberbox;
        }
        public static T Description<T>(this T numberbox, object description) where T : IRxNumberBox
        {
            numberbox.Description = new PropertyValue<object>(description);
            return numberbox;
        }
        public static T Description<T>(this T numberbox, Func<object> descriptionFunc) where T : IRxNumberBox
        {
            numberbox.Description = new PropertyValue<object>(descriptionFunc);
            return numberbox;
        }
        public static T Header<T>(this T numberbox, object header) where T : IRxNumberBox
        {
            numberbox.Header = new PropertyValue<object>(header);
            return numberbox;
        }
        public static T Header<T>(this T numberbox, Func<object> headerFunc) where T : IRxNumberBox
        {
            numberbox.Header = new PropertyValue<object>(headerFunc);
            return numberbox;
        }
        public static T IsWrapEnabled<T>(this T numberbox, bool isWrapEnabled) where T : IRxNumberBox
        {
            numberbox.IsWrapEnabled = new PropertyValue<bool>(isWrapEnabled);
            return numberbox;
        }
        public static T IsWrapEnabled<T>(this T numberbox, Func<bool> isWrapEnabledFunc) where T : IRxNumberBox
        {
            numberbox.IsWrapEnabled = new PropertyValue<bool>(isWrapEnabledFunc);
            return numberbox;
        }
        public static T LargeChange<T>(this T numberbox, double largeChange) where T : IRxNumberBox
        {
            numberbox.LargeChange = new PropertyValue<double>(largeChange);
            return numberbox;
        }
        public static T LargeChange<T>(this T numberbox, Func<double> largeChangeFunc) where T : IRxNumberBox
        {
            numberbox.LargeChange = new PropertyValue<double>(largeChangeFunc);
            return numberbox;
        }
        public static T Maximum<T>(this T numberbox, double maximum) where T : IRxNumberBox
        {
            numberbox.Maximum = new PropertyValue<double>(maximum);
            return numberbox;
        }
        public static T Maximum<T>(this T numberbox, Func<double> maximumFunc) where T : IRxNumberBox
        {
            numberbox.Maximum = new PropertyValue<double>(maximumFunc);
            return numberbox;
        }
        public static T Minimum<T>(this T numberbox, double minimum) where T : IRxNumberBox
        {
            numberbox.Minimum = new PropertyValue<double>(minimum);
            return numberbox;
        }
        public static T Minimum<T>(this T numberbox, Func<double> minimumFunc) where T : IRxNumberBox
        {
            numberbox.Minimum = new PropertyValue<double>(minimumFunc);
            return numberbox;
        }
        public static T NumberFormatter<T>(this T numberbox, INumberBoxNumberFormatter numberFormatter) where T : IRxNumberBox
        {
            numberbox.NumberFormatter = new PropertyValue<INumberBoxNumberFormatter>(numberFormatter);
            return numberbox;
        }
        public static T NumberFormatter<T>(this T numberbox, Func<INumberBoxNumberFormatter> numberFormatterFunc) where T : IRxNumberBox
        {
            numberbox.NumberFormatter = new PropertyValue<INumberBoxNumberFormatter>(numberFormatterFunc);
            return numberbox;
        }
        public static T PlaceholderText<T>(this T numberbox, string placeholderText) where T : IRxNumberBox
        {
            numberbox.PlaceholderText = new PropertyValue<string>(placeholderText);
            return numberbox;
        }
        public static T PlaceholderText<T>(this T numberbox, Func<string> placeholderTextFunc) where T : IRxNumberBox
        {
            numberbox.PlaceholderText = new PropertyValue<string>(placeholderTextFunc);
            return numberbox;
        }
        public static T SelectionBrush<T>(this T numberbox, Brush selectionBrush) where T : IRxNumberBox
        {
            numberbox.SelectionBrush = new PropertyValue<Brush>(selectionBrush);
            return numberbox;
        }
        public static T SelectionBrush<T>(this T numberbox, Func<Brush> selectionBrushFunc) where T : IRxNumberBox
        {
            numberbox.SelectionBrush = new PropertyValue<Brush>(selectionBrushFunc);
            return numberbox;
        }
        public static T SelectionBrush<T>(this T numberbox, string selectionbrushResourceKey) where T : IRxNumberBox
        {
            numberbox.ResourceReferences[NumberBox.SelectionBrushProperty] = selectionbrushResourceKey;
            return numberbox;
        }
        public static T SmallChange<T>(this T numberbox, double smallChange) where T : IRxNumberBox
        {
            numberbox.SmallChange = new PropertyValue<double>(smallChange);
            return numberbox;
        }
        public static T SmallChange<T>(this T numberbox, Func<double> smallChangeFunc) where T : IRxNumberBox
        {
            numberbox.SmallChange = new PropertyValue<double>(smallChangeFunc);
            return numberbox;
        }
        public static T SpinButtonPlacementMode<T>(this T numberbox, NumberBoxSpinButtonPlacementMode spinButtonPlacementMode) where T : IRxNumberBox
        {
            numberbox.SpinButtonPlacementMode = new PropertyValue<NumberBoxSpinButtonPlacementMode>(spinButtonPlacementMode);
            return numberbox;
        }
        public static T SpinButtonPlacementMode<T>(this T numberbox, Func<NumberBoxSpinButtonPlacementMode> spinButtonPlacementModeFunc) where T : IRxNumberBox
        {
            numberbox.SpinButtonPlacementMode = new PropertyValue<NumberBoxSpinButtonPlacementMode>(spinButtonPlacementModeFunc);
            return numberbox;
        }
        public static T Text<T>(this T numberbox, string text) where T : IRxNumberBox
        {
            numberbox.Text = new PropertyValue<string>(text);
            return numberbox;
        }
        public static T Text<T>(this T numberbox, Func<string> textFunc) where T : IRxNumberBox
        {
            numberbox.Text = new PropertyValue<string>(textFunc);
            return numberbox;
        }
        public static T TextAlignment<T>(this T numberbox, TextAlignment textAlignment) where T : IRxNumberBox
        {
            numberbox.TextAlignment = new PropertyValue<TextAlignment>(textAlignment);
            return numberbox;
        }
        public static T TextAlignment<T>(this T numberbox, Func<TextAlignment> textAlignmentFunc) where T : IRxNumberBox
        {
            numberbox.TextAlignment = new PropertyValue<TextAlignment>(textAlignmentFunc);
            return numberbox;
        }
        public static T ValidationMode<T>(this T numberbox, NumberBoxValidationMode validationMode) where T : IRxNumberBox
        {
            numberbox.ValidationMode = new PropertyValue<NumberBoxValidationMode>(validationMode);
            return numberbox;
        }
        public static T ValidationMode<T>(this T numberbox, Func<NumberBoxValidationMode> validationModeFunc) where T : IRxNumberBox
        {
            numberbox.ValidationMode = new PropertyValue<NumberBoxValidationMode>(validationModeFunc);
            return numberbox;
        }
        public static T Value<T>(this T numberbox, double value) where T : IRxNumberBox
        {
            numberbox.Value = new PropertyValue<double>(value);
            return numberbox;
        }
        public static T Value<T>(this T numberbox, Func<double> valueFunc) where T : IRxNumberBox
        {
            numberbox.Value = new PropertyValue<double>(valueFunc);
            return numberbox;
        }
        public static T OnValueChanged<T>(this T numberbox, Action valuechangedAction) where T : IRxNumberBox
        {
            numberbox.ValueChangedAction = valuechangedAction;
            return numberbox;
        }

        public static T OnValueChanged<T>(this T numberbox, Action<object?, NumberBoxValueChangedEventArgs> valuechangedActionWithArgs) where T : IRxNumberBox
        {
            numberbox.ValueChangedActionWithArgs = valuechangedActionWithArgs;
            return numberbox;
        }
    }
}
