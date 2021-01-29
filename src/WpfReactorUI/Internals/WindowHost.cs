using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfReactorUI
{
    public enum WindowHostOwnership
    { 
        CurrentWindow,

        MainWindow,

        NotOwned
    }

    public class WindowHost : DependencyObject
    {
        private Window? _window;

        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register("IsVisible", typeof(bool), typeof(WindowHost), new FrameworkPropertyMetadata(true, new PropertyChangedCallback(OnIsOpenPropertyChanged)));

        public static readonly DependencyProperty WindowProperty =
            DependencyProperty.Register("Window", typeof(Window), typeof(WindowHost), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnContentPropertyChanged)));

        public static readonly DependencyProperty OwnershipProperty =
            DependencyProperty.Register("Ownership", typeof(WindowHostOwnership), typeof(WindowHost), new FrameworkPropertyMetadata(WindowHostOwnership.CurrentWindow));

        public static readonly DependencyProperty ShowAsDialogProperty =
            DependencyProperty.Register("ShowAsDialog", typeof(bool), typeof(WindowHost), new FrameworkPropertyMetadata(false));

        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }

        public Window? Window
        {
            get { return (Window)GetValue(WindowProperty); }
            set { SetValue(WindowProperty, value); }
        }

        public WindowHostOwnership Ownership
        {
            get { return (WindowHostOwnership)GetValue(OwnershipProperty); }
            set { SetValue(OwnershipProperty, value); }
        }

        public bool ShowAsDialog
        {
            get { return (bool)GetValue(ShowAsDialogProperty); }
            set { SetValue(ShowAsDialogProperty, value); }
        }

        private static void OnIsOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var windowHost = (WindowHost)d;
            windowHost.Dispatcher.BeginInvoke(new Action(() =>
            {
                windowHost.HandleIsOpen();
            }), System.Windows.Threading.DispatcherPriority.Input);
        }

        private static void OnContentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var windowHost = (WindowHost)d;
            windowHost.Dispatcher.BeginInvoke(new Action(() => windowHost.SetWindow((Window)e.NewValue)), System.Windows.Threading.DispatcherPriority.Input);
        }

        private void SetWindow(Window window)
        {
            _window?.Close();

            _window = window;

            HandleIsOpen();
        }

        private void HandleIsOpen()
        {
            if (IsVisible)
            {
                if (_window != null)
                {
                    switch (Ownership)
                    {
                        case WindowHostOwnership.CurrentWindow:
                            _window.Owner = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive) ?? Application.Current.MainWindow;
                            break;
                        case WindowHostOwnership.MainWindow:
                            _window.Owner = Application.Current.MainWindow;
                            break;
                        case WindowHostOwnership.NotOwned:
                            _window.Owner = null;
                            break;
                    }

                    if (ShowAsDialog)
                    {
                        _window.ShowDialog();
                    }
                    else
                    {
                        _window.Show();
                    }
                }
            }
            else
            {
                _window?.Hide();
            }
        }
    }
}
