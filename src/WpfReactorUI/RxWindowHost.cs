using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public interface IRxWindowHost
    {
        PropertyValue<bool>? IsVisible { get; set; }
        PropertyValue<WindowHostOwnership>? Ownership { get; set; }
        PropertyValue<bool>? ShowAsDialog { get; set; }
    }

    public sealed class RxWindowHost : VisualNode<WindowHost>, IRxWindowHost, IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _contents = new List<VisualNode>();

        public RxWindowHost()
        {

        }

        public RxWindowHost(Action<WindowHost?> componentRefAction)
            : base(componentRefAction)
        {

        }

        public void Add(VisualNode child)
        {
            if (_contents.Any())
                throw new InvalidOperationException("Content already set");

            _contents.Add(child);
        }

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _contents.GetEnumerator();
        }

        protected sealed override void OnAddChild(VisualNode widget, object childControl)
        {
            if (childControl is Window window)
            {
                NativeControl.Window = window;
            }
            else
            {
                throw new NotSupportedException();
            }

            base.OnAddChild(widget, childControl);
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object childControl)
        {
            NativeControl.Window = null;

            base.OnRemoveChild(widget, childControl);
        }

        PropertyValue<bool>? IRxWindowHost.IsVisible { get; set; }
        PropertyValue<WindowHostOwnership>? IRxWindowHost.Ownership { get; set; }
        PropertyValue<bool>? IRxWindowHost.ShowAsDialog { get; set; }

        protected override void OnMount()
        {
            if (_nativeControl == null)
            {
                _nativeControl = new WindowHost();
                //do not add it to parent control
            }

            base.OnMount();
        }

        protected override void OnUpdate()
        {
            var thisAsIRxWindow = (IRxWindowHost)this;
            SetPropertyValue(NativeControl, WindowHost.IsVisibleProperty, thisAsIRxWindow.IsVisible);
            SetPropertyValue(NativeControl, WindowHost.OwnershipProperty, thisAsIRxWindow.Ownership);
            SetPropertyValue(NativeControl, WindowHost.ShowAsDialogProperty, thisAsIRxWindow.ShowAsDialog);

            base.OnUpdate();
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _contents;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }

    public static partial class RxWindowHostExtensions
    {
        public static T IsVisible<T>(this T windowHost, bool isVisible) where T : IRxWindowHost
        {
            windowHost.IsVisible = new PropertyValue<bool>(isVisible);
            return windowHost;
        }

        public static T Ownership<T>(this T windowHost, WindowHostOwnership ownership) where T : IRxWindowHost
        {
            windowHost.Ownership = new PropertyValue<WindowHostOwnership>(ownership);
            return windowHost;
        }

        public static T ShowAsDialog<T>(this T windowHost, bool showAsDialog) where T : IRxWindowHost
        {
            windowHost.ShowAsDialog = new PropertyValue<bool>(showAsDialog);
            return windowHost;
        }


    }

}
