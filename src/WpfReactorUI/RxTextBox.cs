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
    public partial interface IRxTextBox : IRxTextBoxBase
    {
        PropertyValue<CharacterCasing> CharacterCasing { get; set; }
        PropertyValue<int> MaxLength { get; set; }
        PropertyValue<int> MaxLines { get; set; }
        PropertyValue<int> MinLines { get; set; }
        PropertyValue<string> Text { get; set; }
        PropertyValue<TextAlignment> TextAlignment { get; set; }
        PropertyValue<TextDecorationCollection> TextDecorations { get; set; }
        PropertyValue<TextWrapping> TextWrapping { get; set; }

    }

    public partial class RxTextBox<T> : RxTextBoxBase<T>, IRxTextBox where T : TextBox, new()
    {
        public RxTextBox()
        {

        }

        public RxTextBox(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<CharacterCasing> IRxTextBox.CharacterCasing { get; set; }
        PropertyValue<int> IRxTextBox.MaxLength { get; set; }
        PropertyValue<int> IRxTextBox.MaxLines { get; set; }
        PropertyValue<int> IRxTextBox.MinLines { get; set; }
        PropertyValue<string> IRxTextBox.Text { get; set; }
        PropertyValue<TextAlignment> IRxTextBox.TextAlignment { get; set; }
        PropertyValue<TextDecorationCollection> IRxTextBox.TextDecorations { get; set; }
        PropertyValue<TextWrapping> IRxTextBox.TextWrapping { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxTextBox = (IRxTextBox)this;
            NativeControl.Set(this, TextBox.CharacterCasingProperty, thisAsIRxTextBox.CharacterCasing);
            NativeControl.Set(this, TextBox.MaxLengthProperty, thisAsIRxTextBox.MaxLength);
            NativeControl.Set(this, TextBox.MaxLinesProperty, thisAsIRxTextBox.MaxLines);
            NativeControl.Set(this, TextBox.MinLinesProperty, thisAsIRxTextBox.MinLines);
            NativeControl.Set(this, TextBox.TextProperty, thisAsIRxTextBox.Text);
            NativeControl.Set(this, TextBox.TextAlignmentProperty, thisAsIRxTextBox.TextAlignment);
            NativeControl.Set(this, TextBox.TextDecorationsProperty, thisAsIRxTextBox.TextDecorations);
            NativeControl.Set(this, TextBox.TextWrappingProperty, thisAsIRxTextBox.TextWrapping);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxTextBox = (IRxTextBox)this;

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
    public partial class RxTextBox : RxTextBox<TextBox>
    {
        public RxTextBox()
        {

        }

        public RxTextBox(Action<TextBox> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxTextBoxExtensions
    {
        public static T CharacterCasing<T>(this T textbox, CharacterCasing characterCasing) where T : IRxTextBox
        {
            textbox.CharacterCasing = new PropertyValue<CharacterCasing>(characterCasing);
            return textbox;
        }
        public static T MaxLength<T>(this T textbox, int maxLength) where T : IRxTextBox
        {
            textbox.MaxLength = new PropertyValue<int>(maxLength);
            return textbox;
        }
        public static T MaxLines<T>(this T textbox, int maxLines) where T : IRxTextBox
        {
            textbox.MaxLines = new PropertyValue<int>(maxLines);
            return textbox;
        }
        public static T MinLines<T>(this T textbox, int minLines) where T : IRxTextBox
        {
            textbox.MinLines = new PropertyValue<int>(minLines);
            return textbox;
        }
        public static T Text<T>(this T textbox, string text) where T : IRxTextBox
        {
            textbox.Text = new PropertyValue<string>(text);
            return textbox;
        }
        public static T TextAlignment<T>(this T textbox, TextAlignment textAlignment) where T : IRxTextBox
        {
            textbox.TextAlignment = new PropertyValue<TextAlignment>(textAlignment);
            return textbox;
        }
        public static T TextDecorations<T>(this T textbox, TextDecorationCollection textDecorations) where T : IRxTextBox
        {
            textbox.TextDecorations = new PropertyValue<TextDecorationCollection>(textDecorations);
            return textbox;
        }
        public static T TextWrapping<T>(this T textbox, TextWrapping textWrapping) where T : IRxTextBox
        {
            textbox.TextWrapping = new PropertyValue<TextWrapping>(textWrapping);
            return textbox;
        }
    }
}
