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
    public partial interface IRxTextBlock : IRxFrameworkElement
    {
        PropertyValue<Brush> Background { get; set; }
        PropertyValue<double> BaselineOffset { get; set; }
        PropertyValue<FontFamily> FontFamily { get; set; }
        PropertyValue<double> FontSize { get; set; }
        PropertyValue<FontStretch> FontStretch { get; set; }
        PropertyValue<FontStyle> FontStyle { get; set; }
        PropertyValue<FontWeight> FontWeight { get; set; }
        PropertyValue<Brush> Foreground { get; set; }
        PropertyValue<bool> IsHyphenationEnabled { get; set; }
        PropertyValue<double> LineHeight { get; set; }
        PropertyValue<LineStackingStrategy> LineStackingStrategy { get; set; }
        PropertyValue<Thickness> Padding { get; set; }
        PropertyValue<string> Text { get; set; }
        PropertyValue<TextAlignment> TextAlignment { get; set; }
        PropertyValue<TextDecorationCollection> TextDecorations { get; set; }
        PropertyValue<TextEffectCollection> TextEffects { get; set; }
        PropertyValue<TextTrimming> TextTrimming { get; set; }
        PropertyValue<TextWrapping> TextWrapping { get; set; }

    }

    public partial class RxTextBlock<T> : RxFrameworkElement<T>, IRxTextBlock where T : TextBlock, new()
    {
        public RxTextBlock()
        {

        }

        public RxTextBlock(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush> IRxTextBlock.Background { get; set; }
        PropertyValue<double> IRxTextBlock.BaselineOffset { get; set; }
        PropertyValue<FontFamily> IRxTextBlock.FontFamily { get; set; }
        PropertyValue<double> IRxTextBlock.FontSize { get; set; }
        PropertyValue<FontStretch> IRxTextBlock.FontStretch { get; set; }
        PropertyValue<FontStyle> IRxTextBlock.FontStyle { get; set; }
        PropertyValue<FontWeight> IRxTextBlock.FontWeight { get; set; }
        PropertyValue<Brush> IRxTextBlock.Foreground { get; set; }
        PropertyValue<bool> IRxTextBlock.IsHyphenationEnabled { get; set; }
        PropertyValue<double> IRxTextBlock.LineHeight { get; set; }
        PropertyValue<LineStackingStrategy> IRxTextBlock.LineStackingStrategy { get; set; }
        PropertyValue<Thickness> IRxTextBlock.Padding { get; set; }
        PropertyValue<string> IRxTextBlock.Text { get; set; }
        PropertyValue<TextAlignment> IRxTextBlock.TextAlignment { get; set; }
        PropertyValue<TextDecorationCollection> IRxTextBlock.TextDecorations { get; set; }
        PropertyValue<TextEffectCollection> IRxTextBlock.TextEffects { get; set; }
        PropertyValue<TextTrimming> IRxTextBlock.TextTrimming { get; set; }
        PropertyValue<TextWrapping> IRxTextBlock.TextWrapping { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTextBlock = (IRxTextBlock)this;
            NativeControl.Set(this, TextBlock.BackgroundProperty, thisAsIRxTextBlock.Background);
            NativeControl.Set(this, TextBlock.BaselineOffsetProperty, thisAsIRxTextBlock.BaselineOffset);
            NativeControl.Set(this, TextBlock.FontFamilyProperty, thisAsIRxTextBlock.FontFamily);
            NativeControl.Set(this, TextBlock.FontSizeProperty, thisAsIRxTextBlock.FontSize);
            NativeControl.Set(this, TextBlock.FontStretchProperty, thisAsIRxTextBlock.FontStretch);
            NativeControl.Set(this, TextBlock.FontStyleProperty, thisAsIRxTextBlock.FontStyle);
            NativeControl.Set(this, TextBlock.FontWeightProperty, thisAsIRxTextBlock.FontWeight);
            NativeControl.Set(this, TextBlock.ForegroundProperty, thisAsIRxTextBlock.Foreground);
            NativeControl.Set(this, TextBlock.IsHyphenationEnabledProperty, thisAsIRxTextBlock.IsHyphenationEnabled);
            NativeControl.Set(this, TextBlock.LineHeightProperty, thisAsIRxTextBlock.LineHeight);
            NativeControl.Set(this, TextBlock.LineStackingStrategyProperty, thisAsIRxTextBlock.LineStackingStrategy);
            NativeControl.Set(this, TextBlock.PaddingProperty, thisAsIRxTextBlock.Padding);
            NativeControl.Set(this, TextBlock.TextProperty, thisAsIRxTextBlock.Text);
            NativeControl.Set(this, TextBlock.TextAlignmentProperty, thisAsIRxTextBlock.TextAlignment);
            NativeControl.Set(this, TextBlock.TextDecorationsProperty, thisAsIRxTextBlock.TextDecorations);
            NativeControl.Set(this, TextBlock.TextEffectsProperty, thisAsIRxTextBlock.TextEffects);
            NativeControl.Set(this, TextBlock.TextTrimmingProperty, thisAsIRxTextBlock.TextTrimming);
            NativeControl.Set(this, TextBlock.TextWrappingProperty, thisAsIRxTextBlock.TextWrapping);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxTextBlock = (IRxTextBlock)this;

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
    public partial class RxTextBlock : RxTextBlock<TextBlock>
    {
        public RxTextBlock()
        {

        }

        public RxTextBlock(Action<TextBlock> componentRefAction)
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
        public static T BaselineOffset<T>(this T textblock, double baselineOffset) where T : IRxTextBlock
        {
            textblock.BaselineOffset = new PropertyValue<double>(baselineOffset);
            return textblock;
        }
        public static T FontFamily<T>(this T textblock, FontFamily fontFamily) where T : IRxTextBlock
        {
            textblock.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return textblock;
        }
        public static T FontSize<T>(this T textblock, double fontSize) where T : IRxTextBlock
        {
            textblock.FontSize = new PropertyValue<double>(fontSize);
            return textblock;
        }
        public static T FontStretch<T>(this T textblock, FontStretch fontStretch) where T : IRxTextBlock
        {
            textblock.FontStretch = new PropertyValue<FontStretch>(fontStretch);
            return textblock;
        }
        public static T FontStyle<T>(this T textblock, FontStyle fontStyle) where T : IRxTextBlock
        {
            textblock.FontStyle = new PropertyValue<FontStyle>(fontStyle);
            return textblock;
        }
        public static T FontWeight<T>(this T textblock, FontWeight fontWeight) where T : IRxTextBlock
        {
            textblock.FontWeight = new PropertyValue<FontWeight>(fontWeight);
            return textblock;
        }
        public static T Foreground<T>(this T textblock, Brush foreground) where T : IRxTextBlock
        {
            textblock.Foreground = new PropertyValue<Brush>(foreground);
            return textblock;
        }
        public static T IsHyphenationEnabled<T>(this T textblock, bool isHyphenationEnabled) where T : IRxTextBlock
        {
            textblock.IsHyphenationEnabled = new PropertyValue<bool>(isHyphenationEnabled);
            return textblock;
        }
        public static T LineHeight<T>(this T textblock, double lineHeight) where T : IRxTextBlock
        {
            textblock.LineHeight = new PropertyValue<double>(lineHeight);
            return textblock;
        }
        public static T LineStackingStrategy<T>(this T textblock, LineStackingStrategy lineStackingStrategy) where T : IRxTextBlock
        {
            textblock.LineStackingStrategy = new PropertyValue<LineStackingStrategy>(lineStackingStrategy);
            return textblock;
        }
        public static T Padding<T>(this T textblock, Thickness padding) where T : IRxTextBlock
        {
            textblock.Padding = new PropertyValue<Thickness>(padding);
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
        public static T TextAlignment<T>(this T textblock, TextAlignment textAlignment) where T : IRxTextBlock
        {
            textblock.TextAlignment = new PropertyValue<TextAlignment>(textAlignment);
            return textblock;
        }
        public static T TextDecorations<T>(this T textblock, TextDecorationCollection textDecorations) where T : IRxTextBlock
        {
            textblock.TextDecorations = new PropertyValue<TextDecorationCollection>(textDecorations);
            return textblock;
        }
        public static T TextEffects<T>(this T textblock, TextEffectCollection textEffects) where T : IRxTextBlock
        {
            textblock.TextEffects = new PropertyValue<TextEffectCollection>(textEffects);
            return textblock;
        }
        public static T TextTrimming<T>(this T textblock, TextTrimming textTrimming) where T : IRxTextBlock
        {
            textblock.TextTrimming = new PropertyValue<TextTrimming>(textTrimming);
            return textblock;
        }
        public static T TextWrapping<T>(this T textblock, TextWrapping textWrapping) where T : IRxTextBlock
        {
            textblock.TextWrapping = new PropertyValue<TextWrapping>(textWrapping);
            return textblock;
        }
    }
}
