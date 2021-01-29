using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public static partial class RxDockPanelExtensions
    {
        public static T Dock<T>(this T dockPanel, Dock dock) where T : VisualNodeWithAttachedProperties
        {
            dockPanel.SetAttachedProperty(DockPanel.DockProperty, dock);
            return dockPanel;
        }

        public static T DockLeft<T>(this T dockPanel) where T : VisualNodeWithAttachedProperties
        {
            dockPanel.SetAttachedProperty(DockPanel.DockProperty, System.Windows.Controls.Dock.Left);
            return dockPanel;
        }

        public static T DockTop<T>(this T dockPanel) where T : VisualNodeWithAttachedProperties
        {
            dockPanel.SetAttachedProperty(DockPanel.DockProperty, System.Windows.Controls.Dock.Top);
            return dockPanel;
        }

        public static T DockRight<T>(this T dockPanel) where T : VisualNodeWithAttachedProperties
        {
            dockPanel.SetAttachedProperty(DockPanel.DockProperty, System.Windows.Controls.Dock.Right);
            return dockPanel;
        }

        public static T DockBottom<T>(this T dockPanel) where T : VisualNodeWithAttachedProperties
        {
            dockPanel.SetAttachedProperty(DockPanel.DockProperty, System.Windows.Controls.Dock.Bottom);
            return dockPanel;
        }
    }
}
