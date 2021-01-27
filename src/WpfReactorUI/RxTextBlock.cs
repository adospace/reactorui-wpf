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
    public partial interface IRxTextBlock : IRxFrameworkElement
    {
        PropertyValue<Brush>? Background { get; set; }
        PropertyValue<double>? BaselineOffset { get; set; }
        PropertyValue<FontFamily>? FontFamily { get; set; }
        PropertyValue<double>? FontSize { get; set; }
        PropertyValue<FontStretch>? FontStretch { get; set; }
        PropertyValue<FontStyle>? FontStyle { get; set; }
        PropertyValue<FontWeight>? FontWeight { get; set; }
        PropertyValue<Brush>? Foreground { get; set; }
        PropertyValue<bool>? IsHyphenationEnabled { get; set; }
        PropertyValue<double>? LineHeight { get; set; }
        PropertyValue<LineStackingStrategy>? LineStackingStrategy { get; set; }
        PropertyValue<Thickness>? Padding { get; set; }
        PropertyValue<string>? Text { get; set; }
        PropertyValue<TextAlignment>? TextAlignment { get; set; }
        PropertyValue<TextDecorationCollection>? TextDecorations { get; set; }
        PropertyValue<TextEffectCollection>? TextEffects { get; set; }
        PropertyValue<TextTrimming>? TextTrimming { get; set; }
        PropertyValue<TextWrapping>? TextWrapping { get; set; }

    }

    public partial class RxTextBlock<T> : RxFrameworkElement<T>, IRxTextBlock where T : TextBlock, new()
    {
        public RxTextBlock()
        {

        }

        public RxTextBlock(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxTextBlock.Background { get; set; }
        PropertyValue<double>? IRxTextBlock.BaselineOffset { get; set; }
        PropertyValue<FontFamily>? IRxTextBlock.FontFamily { get; set; }
        PropertyValue<double>? IRxTextBlock.FontSize { get; set; }
        PropertyValue<FontStretch>? IRxTextBlock.FontStretch { get; set; }
        PropertyValue<FontStyle>? IRxTextBlock.FontStyle { get; set; }
        PropertyValue<FontWeight>? IRxTextBlock.FontWeight { get; set; }
        PropertyValue<Brush>? IRxTextBlock.Foreground { get; set; }
        PropertyValue<bool>? IRxTextBlock.IsHyphenationEnabled { get; set; }
        PropertyValue<double>? IRxTextBlock.LineHeight { get; set; }
        PropertyValue<LineStackingStrategy>? IRxTextBlock.LineStackingStrategy { get; set; }
        PropertyValue<Thickness>? IRxTextBlock.Padding { get; set; }
        PropertyValue<string>? IRxTextBlock.Text { get; set; }
        PropertyValue<TextAlignment>? IRxTextBlock.TextAlignment { get; set; }
        PropertyValue<TextDecorationCollection>? IRxTextBlock.TextDecorations { get; set; }
        PropertyValue<TextEffectCollection>? IRxTextBlock.TextEffects { get; set; }
        PropertyValue<TextTrimming>? IRxTextBlock.TextTrimming { get; set; }
        PropertyValue<TextWrapping>? IRxTextBlock.TextWrapping { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTextBlock = (IRxTextBlock)this;
            SetPropertyValue(NativeControl, TextBlock.BackgroundProperty, thisAsIRxTextBlock.Background);
            SetPropertyValue(NativeControl, TextBlock.BaselineOffsetProperty, thisAsIRxTextBlock.BaselineOffset);
            SetPropertyValue(NativeControl, TextBlock.FontFamilyProperty, thisAsIRxTextBlock.FontFamily);
            SetPropertyValue(NativeControl, TextBlock.FontSizeProperty, thisAsIRxTextBlock.FontSize);
            SetPropertyValue(NativeControl, TextBlock.FontStretchProperty, thisAsIRxTextBlock.FontStretch);
            SetPropertyValue(NativeControl, TextBlock.FontStyleProperty, thisAsIRxTextBlock.FontStyle);
            SetPropertyValue(NativeControl, TextBlock.FontWeightProperty, thisAsIRxTextBlock.FontWeight);
            SetPropertyValue(NativeControl, TextBlock.ForegroundProperty, thisAsIRxTextBlock.Foreground);
            SetPropertyValue(NativeControl, TextBlock.IsHyphenationEnabledProperty, thisAsIRxTextBlock.IsHyphenationEnabled);
            SetPropertyValue(NativeControl, TextBlock.LineHeightProperty, thisAsIRxTextBlock.LineHeight);
            SetPropertyValue(NativeControl, TextBlock.LineStackingStrategyProperty, thisAsIRxTextBlock.LineStackingStrategy);
            SetPropertyValue(NativeControl, TextBlock.PaddingProperty, thisAsIRxTextBlock.Padding);
            SetPropertyValue(NativeControl, TextBlock.TextProperty, thisAsIRxTextBlock.Text);
            SetPropertyValue(NativeControl, TextBlock.TextAlignmentProperty, thisAsIRxTextBlock.TextAlignment);
            SetPropertyValue(NativeControl, TextBlock.TextDecorationsProperty, thisAsIRxTextBlock.TextDecorations);
            SetPropertyValue(NativeControl, TextBlock.TextEffectsProperty, thisAsIRxTextBlock.TextEffects);
            SetPropertyValue(NativeControl, TextBlock.TextTrimmingProperty, thisAsIRxTextBlock.TextTrimming);
            SetPropertyValue(NativeControl, TextBlock.TextWrappingProperty, thisAsIRxTextBlock.TextWrapping);

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
    public partial class RxTextBlock : RxTextBlock<TextBlock>
    {
        public RxTextBlock()
        {

        }

        public RxTextBlock(Action<TextBlock?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxTextBlockExtensions
    {
        public static T Background<T>(this T textblock, Brush background) where T : IRxTextBlock
        {
            textblock.Background = new PropertyValue<Brush>(background);
            return textblock;
        }
        public static T Background<T>(this T textblock, Func<Brush> backgroundFunc) where T : IRxTextBlock
        {
            textblock.Background = new PropertyValue<Brush>(backgroundFunc);
            return textblock;
        }
        public static T BaselineOffset<T>(this T textblock, double baselineOffset) where T : IRxTextBlock
        {
            textblock.BaselineOffset = new PropertyValue<double>(baselineOffset);
            return textblock;
        }
        public static T BaselineOffset<T>(this T textblock, Func<double> baselineOffsetFunc) where T : IRxTextBlock
        {
            textblock.BaselineOffset = new PropertyValue<double>(baselineOffsetFunc);
            return textblock;
        }
        public static T FontFamily<T>(this T textblock, FontFamily fontFamily) where T : IRxTextBlock
        {
            textblock.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return textblock;
        }
        public static T FontFamily<T>(this T textblock, Func<FontFamily> fontFamilyFunc) where T : IRxTextBlock
        {
            textblock.FontFamily = new PropertyValue<FontFamily>(fontFamilyFunc);
            return textblock;
        }
        public static T FontSize<T>(this T textblock, double fontSize) where T : IRxTextBlock
        {
            textblock.FontSize = new PropertyValue<double>(fontSize);
            return textblock;
        }
        public static T FontSize<T>(this T textblock, Func<double> fontSizeFunc) where T : IRxTextBlock
        {
            textblock.FontSize = new PropertyValue<double>(fontSizeFunc);
            return textblock;
        }
        public static T FontStretch<T>(this T textblock, FontStretch fontStretch) where T : IRxTextBlock
        {
            textblock.FontStretch = new PropertyValue<FontStretch>(fontStretch);
            return textblock;
        }
        public static T FontStretch<T>(this T textblock, Func<FontStretch> fontStretchFunc) where T : IRxTextBlock
        {
            textblock.FontStretch = new PropertyValue<FontStretch>(fontStretchFunc);
            return textblock;
        }
        public static T FontStyle<T>(this T textblock, FontStyle fontStyle) where T : IRxTextBlock
        {
            textblock.FontStyle = new PropertyValue<FontStyle>(fontStyle);
            return textblock;
        }
        public static T FontStyle<T>(this T textblock, Func<FontStyle> fontStyleFunc) where T : IRxTextBlock
        {
            textblock.FontStyle = new PropertyValue<FontStyle>(fontStyleFunc);
            return textblock;
        }
        public static T FontWeight<T>(this T textblock, FontWeight fontWeight) where T : IRxTextBlock
        {
            textblock.FontWeight = new PropertyValue<FontWeight>(fontWeight);
            return textblock;
        }
        public static T FontWeight<T>(this T textblock, Func<FontWeight> fontWeightFunc) where T : IRxTextBlock
        {
            textblock.FontWeight = new PropertyValue<FontWeight>(fontWeightFunc);
            return textblock;
        }
        public static T Foreground<T>(this T textblock, Brush foreground) where T : IRxTextBlock
        {
            textblock.Foreground = new PropertyValue<Brush>(foreground);
            return textblock;
        }
        public static T Foreground<T>(this T textblock, Func<Brush> foregroundFunc) where T : IRxTextBlock
        {
            textblock.Foreground = new PropertyValue<Brush>(foregroundFunc);
            return textblock;
        }
        public static T IsHyphenationEnabled<T>(this T textblock, bool isHyphenationEnabled) where T : IRxTextBlock
        {
            textblock.IsHyphenationEnabled = new PropertyValue<bool>(isHyphenationEnabled);
            return textblock;
        }
        public static T IsHyphenationEnabled<T>(this T textblock, Func<bool> isHyphenationEnabledFunc) where T : IRxTextBlock
        {
            textblock.IsHyphenationEnabled = new PropertyValue<bool>(isHyphenationEnabledFunc);
            return textblock;
        }
        public static T LineHeight<T>(this T textblock, double lineHeight) where T : IRxTextBlock
        {
            textblock.LineHeight = new PropertyValue<double>(lineHeight);
            return textblock;
        }
        public static T LineHeight<T>(this T textblock, Func<double> lineHeightFunc) where T : IRxTextBlock
        {
            textblock.LineHeight = new PropertyValue<double>(lineHeightFunc);
            return textblock;
        }
        public static T LineStackingStrategy<T>(this T textblock, LineStackingStrategy lineStackingStrategy) where T : IRxTextBlock
        {
            textblock.LineStackingStrategy = new PropertyValue<LineStackingStrategy>(lineStackingStrategy);
            return textblock;
        }
        public static T LineStackingStrategy<T>(this T textblock, Func<LineStackingStrategy> lineStackingStrategyFunc) where T : IRxTextBlock
        {
            textblock.LineStackingStrategy = new PropertyValue<LineStackingStrategy>(lineStackingStrategyFunc);
            return textblock;
        }
        public static T Padding<T>(this T textblock, Thickness padding) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(padding);
            return textblock;
        }
        public static T Padding<T>(this T textblock, Func<Thickness> paddingFunc) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(paddingFunc);
            return textblock;
        }
        public static T Padding<T>(this T textblock, double leftRight, double topBottom) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return textblock;
        }
        public static T Padding<T>(this T textblock, double uniformSize) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return textblock;
        }
        public static T Text<T>(this T textblock, string text) where T : IRxTextBlock
        {
            textblock.Text = new PropertyValue<string>(text);
            return textblock;
        }
        public static T Text<T>(this T textblock, Func<string> textFunc) where T : IRxTextBlock
        {
            textblock.Text = new PropertyValue<string>(textFunc);
            return textblock;
        }
        public static T TextAlignment<T>(this T textblock, TextAlignment textAlignment) where T : IRxTextBlock
        {
            textblock.TextAlignment = new PropertyValue<TextAlignment>(textAlignment);
            return textblock;
        }
        public static T TextAlignment<T>(this T textblock, Func<TextAlignment> textAlignmentFunc) where T : IRxTextBlock
        {
            textblock.TextAlignment = new PropertyValue<TextAlignment>(textAlignmentFunc);
            return textblock;
        }
        public static T TextDecorations<T>(this T textblock, TextDecorationCollection textDecorations) where T : IRxTextBlock
        {
            textblock.TextDecorations = new PropertyValue<TextDecorationCollection>(textDecorations);
            return textblock;
        }
        public static T TextDecorations<T>(this T textblock, Func<TextDecorationCollection> textDecorationsFunc) where T : IRxTextBlock
        {
            textblock.TextDecorations = new PropertyValue<TextDecorationCollection>(textDecorationsFunc);
            return textblock;
        }
        public static T TextEffects<T>(this T textblock, TextEffectCollection textEffects) where T : IRxTextBlock
        {
            textblock.TextEffects = new PropertyValue<TextEffectCollection>(textEffects);
            return textblock;
        }
        public static T TextEffects<T>(this T textblock, Func<TextEffectCollection> textEffectsFunc) where T : IRxTextBlock
        {
            textblock.TextEffects = new PropertyValue<TextEffectCollection>(textEffectsFunc);
            return textblock;
        }
        public static T TextTrimming<T>(this T textblock, TextTrimming textTrimming) where T : IRxTextBlock
        {
            textblock.TextTrimming = new PropertyValue<TextTrimming>(textTrimming);
            return textblock;
        }
        public static T TextTrimming<T>(this T textblock, Func<TextTrimming> textTrimmingFunc) where T : IRxTextBlock
        {
            textblock.TextTrimming = new PropertyValue<TextTrimming>(textTrimmingFunc);
            return textblock;
        }
        public static T TextWrapping<T>(this T textblock, TextWrapping textWrapping) where T : IRxTextBlock
        {
            textblock.TextWrapping = new PropertyValue<TextWrapping>(textWrapping);
            return textblock;
        }
        public static T TextWrapping<T>(this T textblock, Func<TextWrapping> textWrappingFunc) where T : IRxTextBlock
        {
            textblock.TextWrapping = new PropertyValue<TextWrapping>(textWrappingFunc);
            return textblock;
        }
    }
}
