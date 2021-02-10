using ModernWpf.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfReactorUI.Internals;
using WpfReactorUI.ModernTheme.Internals;

namespace WpfReactorUI.ModernTheme
{
    public interface IRxContentDialogHost
    {
        PropertyValue<bool>? IsVisible { get; set; }
        //PropertyValue<WindowHostOwnership>? Ownership { get; set; }
        //PropertyValue<bool>? ShowAsDialog { get; set; }
    }

    public sealed class RxContentDialogHost : VisualNode<ContentDialogHost>, IRxContentDialogHost, IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _contents = new List<VisualNode>();

        public RxContentDialogHost()
        {

        }

        public RxContentDialogHost(Action<ContentDialogHost?> componentRefAction)
            : base(componentRefAction)
        {

        }

        public void Add(VisualNode? child)
        {
            if (child == null)
            {
                return;
            }

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
            if (childControl is ContentDialog window)
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
            //NativeControl.Window = null;

            base.OnRemoveChild(widget, childControl);
        }

        PropertyValue<bool>? IRxContentDialogHost.IsVisible { get; set; }
        //PropertyValue<WindowHostOwnership>? IRxContentDialogHost.Ownership { get; set; }
        //PropertyValue<bool>? IRxContentDialogHost.ShowAsDialog { get; set; }

        protected override void OnMount()
        {
            if (_nativeControl == null)
            {
                _nativeControl = new ContentDialogHost();
                //do not add it to parent control
            }

            base.OnMount();
        }

        protected override void OnUnmount()
        {
            if (_nativeControl != null)
            {
                OnDetachNativeEvents();

                //do not remove from parent

                _nativeControl = null;
            }

            base.OnUnmount();
        }

        protected override void OnUpdate()
        {
            var thisAsIRxWindow = (IRxContentDialogHost)this;
            SetPropertyValue(NativeControl, ContentDialogHost.IsVisibleProperty, thisAsIRxWindow.IsVisible);
            //SetPropertyValue(NativeControl, WindowHost.OwnershipProperty, thisAsIRxWindow.Ownership);
            //SetPropertyValue(NativeControl, WindowHost.ShowAsDialogProperty, thisAsIRxWindow.ShowAsDialog);

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

    public static partial class RxContentDialogHostExtensions
    {
        public static T IsVisible<T>(this T windowHost, bool isVisible) where T : IRxContentDialogHost
        {
            windowHost.IsVisible = new PropertyValue<bool>(isVisible);
            return windowHost;
        }

        //public static T Ownership<T>(this T windowHost, WindowHostOwnership ownership) where T : IRxContentDialogHost
        //{
        //    windowHost.Ownership = new PropertyValue<WindowHostOwnership>(ownership);
        //    return windowHost;
        //}

        //public static T ShowAsDialog<T>(this T windowHost, bool showAsDialog) where T : IRxContentDialogHost
        //{
        //    windowHost.ShowAsDialog = new PropertyValue<bool>(showAsDialog);
        //    return windowHost;
        //}


    }

}
