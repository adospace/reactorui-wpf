using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxPasswordBox
    {
        PropertyValue<string>? Password { get; set; }
        Action<string>? PasswordChangedActionWithSingleArgument { get; set; }
    }


    public partial class RxPasswordBox
    {
        PropertyValue<string>? IRxPasswordBox.Password { get; set; }
        Action<string>? IRxPasswordBox.PasswordChangedActionWithSingleArgument { get; set; }

        partial void OnBeginUpdate()
        {
            var thisAsIRxPasswordBox = (IRxPasswordBox)this;
            NativeControl.Password = thisAsIRxPasswordBox.Password?.Value;
        }

        partial void OnAttachingNewEvents()
        {
            var thisAsIRxPasswordBox = (IRxPasswordBox)this;
            if (thisAsIRxPasswordBox.PasswordChangedActionWithSingleArgument != null)
            {
                NativeControl.PasswordChanged += NativeControl_PasswordChangedWithSingleArgument;
            }
        }

        private void NativeControl_PasswordChangedWithSingleArgument(object? sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            if (passwordBox == null) return;
            var thisAsIRxPasswordBox = (IRxPasswordBox)this;
            thisAsIRxPasswordBox.PasswordChangedActionWithSingleArgument?.Invoke(passwordBox.Password);
        }

        partial void OnDetachingNewEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.PasswordChanged -= NativeControl_PasswordChangedWithSingleArgument;
            }
        }
    }

    public static partial class RxPasswordBoxExtensions
    {
        public static T Password<T>(this T passwordbox, string password) where T : IRxPasswordBox
        {
            passwordbox.Password = new PropertyValue<string>(password);
            return passwordbox;
        }

        public static T OnPasswordChanged<T>(this T passwordbox, Action<string> action) where T : IRxPasswordBox
        {
            passwordbox.PasswordChangedActionWithSingleArgument = action;
            return passwordbox;
        }
    }
}
