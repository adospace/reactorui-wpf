using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxRichTextBox : IRxTextBoxBase
    {
        PropertyValue<FlowDocument>? Document { get; set; }
    }

    public partial class RxRichTextBox<T>
    {
        PropertyValue<FlowDocument>? IRxRichTextBox.Document { get; set; }

        partial void OnBeginUpdate()
        {
            var thisAsIRxRichTextBox = (IRxRichTextBox)this;
            if (thisAsIRxRichTextBox.Document != null && 
                thisAsIRxRichTextBox.Document.Value != null &&
                NativeControl.Document != thisAsIRxRichTextBox.Document.Value)
            {
                //TODO: Why a new richtextbox is created?
                if (thisAsIRxRichTextBox.Document.Value.Tag != null)
                {
                    ((T)thisAsIRxRichTextBox.Document.Value.Tag).Document = new FlowDocument();
                }

                NativeControl.Document = thisAsIRxRichTextBox.Document.Value;
                thisAsIRxRichTextBox.Document.Value.Tag = NativeControl;

            }
        }
    }

    public static partial class RxRichTextBoxExtensions
    {
        public static T Document<T>(this T richtextbox, FlowDocument document) where T : IRxRichTextBox
        {
            richtextbox.Document = new PropertyValue<FlowDocument>(document);
            return richtextbox;
        }
    }
}
