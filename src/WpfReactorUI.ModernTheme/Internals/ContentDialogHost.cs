using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfReactorUI.ModernTheme.Internals
{
    public class ContentDialogHost : DependencyObject
    {
        private ContentDialog? _window;

        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(ContentDialogHost), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnIsOpenPropertyChanged)));

        public static readonly DependencyProperty WindowProperty =
            DependencyProperty.Register("Window", typeof(ContentDialog), typeof(ContentDialogHost), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnContentPropertyChanged)));

        //public static readonly DependencyProperty OwnershipProperty =
        //    DependencyProperty.Register("Ownership", typeof(WindowHostOwnership), typeof(ContentDialogHost), new FrameworkPropertyMetadata(WindowHostOwnership.CurrentWindow));

        //public static readonly DependencyProperty ShowAsDialogProperty =
        //    DependencyProperty.Register("ShowAsDialog", typeof(bool), typeof(ContentDialogHost), new FrameworkPropertyMetadata(false));

        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        public ContentDialog? Window
        {
            get { return (ContentDialog)GetValue(WindowProperty); }
            set { SetValue(WindowProperty, value); }
        }

        //public WindowHostOwnership Ownership
        //{
        //    get { return (WindowHostOwnership)GetValue(OwnershipProperty); }
        //    set { SetValue(OwnershipProperty, value); }
        //}

        //public bool ShowAsDialog
        //{
        //    get { return (bool)GetValue(ShowAsDialogProperty); }
        //    set { SetValue(ShowAsDialogProperty, value); }
        //}

        private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var windowHost = (ContentDialogHost)d;
            windowHost.Dispatcher.BeginInvoke(new Action(() =>
            {
                windowHost.HandleIsOpen();
            }), System.Windows.Threading.DispatcherPriority.Input);
        }

        private static void OnContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var windowHost = (ContentDialogHost)d;
            windowHost.Dispatcher.BeginInvoke(new Action(() => windowHost.SetWindow((ContentDialog)e.NewValue)), System.Windows.Threading.DispatcherPriority.Input);
        }

        private void SetWindow(ContentDialog window)
        {
            if (_window == window)
            {
                return;
            }

            //_window?.Close();            

            _window = window;

            HandleIsOpen();
        }

        private async void HandleIsOpen()
        {
            if (IsVisible)
            {
                if (_window != null)
                {
                    await _window.ShowAsync();
                }
            }
            else
            {
                _window?.Hide();
            }
        }
    }

}
