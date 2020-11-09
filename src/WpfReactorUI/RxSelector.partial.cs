using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls.Primitives;

namespace WpfReactorUI
{
    public partial class RxSelectorExtensions
    {
        public static T OnSelectionChanged<T, I>(this T itemscontrol, Action<I> selectedItemAction) where T : IRxSelector
        {
            itemscontrol.SelectionChangedActionWithArgs = (sender, e) => selectedItemAction((I)((Selector)sender).SelectedItem);

            return itemscontrol;
        }
    }
}
