using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfReactorUI
{
    public partial class RxDataGrid<T> : IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _internalChildren = new List<VisualNode>();

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _internalChildren;
        }

        protected override void OnAddChild(VisualNode widget, object childNativeControl)
        {
            if (childNativeControl is DataGridColumn dataGridColumn)
            {
                NativeControl.Columns.Add(dataGridColumn);
            }

            base.OnAddChild(widget, childNativeControl);
        }

        protected override void OnRemoveChild(VisualNode widget, object childNativeControl)
        {
            if (childNativeControl is DataGridColumn dataGridColumn)
            {
                NativeControl.Columns.Remove(dataGridColumn);
            }

            base.OnRemoveChild(widget, childNativeControl);
        }

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _internalChildren.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _internalChildren.GetEnumerator();
        }

        public void Add(params VisualNode[] nodes)
        {
            if (nodes is null)
            {
                throw new ArgumentNullException(nameof(nodes));
            }

            foreach (var node in nodes)
                _internalChildren.Add(node);
        }

        public void Add(object genericNode)
        {
            if (genericNode == null)
            {
                return;
            }

            if (genericNode is VisualNode visualNode)
            {
                _internalChildren.Add(visualNode);
            }
            else if (genericNode is IEnumerable nodes)
            {
                foreach (var node in nodes.Cast<VisualNode>())
                    _internalChildren.Add(node);
            }
            else
            {
                throw new NotSupportedException($"Unable to add value of type '{genericNode.GetType()}' under {typeof(T)}");
            }
        }


    }
}
