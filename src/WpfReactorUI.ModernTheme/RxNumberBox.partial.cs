using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI.ModernTheme
{
    public static partial class RxNumberBoxExtensions
    {
        public static T OnValueChanged<T>(this T numberbox, Action<double> valuechangedAction) where T : IRxNumberBox
        {
            numberbox.ValueChangedActionWithArgs = new Action<object?, ModernWpf.Controls.NumberBoxValueChangedEventArgs>((s, e) => valuechangedAction(e.NewValue));
            return numberbox;
        }
    }
}
