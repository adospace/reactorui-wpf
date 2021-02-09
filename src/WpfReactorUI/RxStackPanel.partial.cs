using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public static partial class RxStackPanelExtensions
    {
        public static T WithHorizontalOrientation<T>(this T stackpanel) where T : IRxStackPanel
        {
            stackpanel.Orientation = new PropertyValue<Orientation>(System.Windows.Controls.Orientation.Horizontal);
            return stackpanel;
        }

        public static T WithVerticalOrientation<T>(this T stackpanel) where T : IRxStackPanel
        {
            stackpanel.Orientation = new PropertyValue<Orientation>(System.Windows.Controls.Orientation.Vertical);
            return stackpanel;
        }
    }
}
