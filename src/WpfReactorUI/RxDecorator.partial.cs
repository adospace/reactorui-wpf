using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfReactorUI
{
    public partial class RxDecorator<T> : IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _contents = new List<VisualNode>();
        public RxDecorator(VisualNode? content)
        {
            if (content != null)
            {
                _contents.Add(content);
            }
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
            OnAddChildCore(widget, childControl);

            base.OnAddChild(widget, childControl);
        }

        protected virtual void OnAddChildCore(VisualNode widget, object childControl)
        {
            if (childControl is UIElement element)
            {
                NativeControl.Child = element;
            }
            else
            {
                throw new InvalidOperationException($"Type '{childControl.GetType()}' not supported under '{GetType()}': expected UIElement derived object");
            }
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object childControl)
        {
            OnRemoveChildCore(widget, childControl);

            base.OnRemoveChild(widget, childControl);
        }

        protected virtual void OnRemoveChildCore(VisualNode widget, object childControl)
        {
            NativeControl.Child = null;
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
}
