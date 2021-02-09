using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxWindow
    {
        PropertyValue<WindowStartupLocation>? WindowStartupLocation { get; set; }
    }


    public partial class RxWindow<T>
    {
        PropertyValue<WindowStartupLocation>? IRxWindow.WindowStartupLocation { get; set; }

        partial void OnBeginUpdate()
        {
            var thisAsIRxWindow = (IRxWindow)this;
            if (thisAsIRxWindow.WindowStartupLocation != null)
                NativeControl.WindowStartupLocation = thisAsIRxWindow.WindowStartupLocation.Value;
            else
                NativeControl.WindowStartupLocation = WindowStartupLocation.Manual;
        }
    }

    public static partial class RxWindowExtensions
    {
        public static T WindowStartupLocation<T>(this T window, WindowStartupLocation windowStartupLocation) where T : IRxWindow
        {
            window.WindowStartupLocation = new PropertyValue<WindowStartupLocation>(windowStartupLocation);
            return window;
        }
    }
}
