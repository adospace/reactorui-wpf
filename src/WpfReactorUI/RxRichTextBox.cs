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
    public partial interface IRxRichTextBox : IRxTextBoxBase
    {
        PropertyValue<bool>? IsDocumentEnabled { get; set; }

    }
    public partial class RxRichTextBox<T> : RxTextBoxBase<T>, IRxRichTextBox where T : RichTextBox, new()
    {
        public RxRichTextBox()
        {

        }

        public RxRichTextBox(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxRichTextBox.IsDocumentEnabled { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxRichTextBox = (IRxRichTextBox)this;
            SetPropertyValue(NativeControl, RichTextBox.IsDocumentEnabledProperty, thisAsIRxRichTextBox.IsDocumentEnabled);

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
    public partial class RxRichTextBox : RxRichTextBox<RichTextBox>
    {
        public RxRichTextBox()
        {

        }

        public RxRichTextBox(Action<RichTextBox?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxRichTextBoxExtensions
    {
        public static T IsDocumentEnabled<T>(this T richtextbox, bool isDocumentEnabled) where T : IRxRichTextBox
        {
            richtextbox.IsDocumentEnabled = new PropertyValue<bool>(isDocumentEnabled);
            return richtextbox;
        }
        public static T IsDocumentEnabled<T>(this T richtextbox, Func<bool> isDocumentEnabledFunc) where T : IRxRichTextBox
        {
            richtextbox.IsDocumentEnabled = new PropertyValue<bool>(isDocumentEnabledFunc);
            return richtextbox;
        }
    }
}
