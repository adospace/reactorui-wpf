using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WpfReactorUI
{
    public static partial class RxTextBoxExtensions
    {
        public static T OnTextChanged<T>(this T textbox, Action<string> textchangedAction) where T : IRxTextBox
        {
            textbox.TextChangedActionWithArgs = (sender, e) => textchangedAction(((TextBox)sender).Text);
            return textbox;
        }
    }
}
