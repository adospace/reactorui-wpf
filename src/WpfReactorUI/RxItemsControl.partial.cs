using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxItemsControl : IRxControl
    {
        PropertyValue<DataTemplate>? ItemTemplate { get; set; }
    }

    public partial class RxItemsControl<T> : IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _internalChildren = new List<VisualNode>();

        protected override void OnAddChild(VisualNode widget, object childControl)
        {
            if (childControl is UIElement control)
            {
                NativeControl.Items.Insert(widget.ChildIndex, control);
            }
            else
            {
                throw new InvalidOperationException($"Type '{childControl.GetType()}' not supported under '{GetType()}'");
            }

            base.OnAddChild(widget, childControl);
        }

        protected override void OnRemoveChild(VisualNode widget, object childControl)
        {
            NativeControl.Items.Remove((UIElement)childControl);

            base.OnRemoveChild(widget, childControl);
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

        PropertyValue<DataTemplate>? IRxItemsControl.ItemTemplate { get; set; }

        partial void OnBeginUpdate()
        {
            var thisAsIRxLayoutable = (IRxItemsControl)this;
            var previousItemTemplate = NativeControl.ItemTemplate as IItemTemplate;
            
            NativeControl.ItemTemplate = thisAsIRxLayoutable.ItemTemplate?.Value;

            if (NativeControl.ItemTemplate is IItemTemplate currentItemTemplate)
            {
                currentItemTemplate.PreviousTemplate = previousItemTemplate;
            }
        }
    }

    internal class ItemTemplateNode : VisualNode
    {
        public ItemTemplateNode(VisualNode root)
        {
            Root = root;
        }

        private VisualNode? _root;

        public VisualNode? Root
        {
            get => _root;
            set
            {
                if (_root != value)
                {
                    _root = value;
                    Invalidate();
                }
            }
        }

        public UIElement? RootControl { get; private set; }

        protected sealed override void OnAddChild(VisualNode widget, object nativeControl)
        {
            if (nativeControl is UIElement view)
                RootControl = view;
            else
            {
                throw new InvalidOperationException($"Type '{nativeControl.GetType()}' not supported under '{GetType()}'");
            }
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object nativeControl)
        {
            RootControl = null;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (Root == null)
            {
                throw new InvalidOperationException();
            }

            yield return Root;
        }

        protected internal override void OnLayoutCycleRequested()
        {
            Layout();
            base.OnLayoutCycleRequested();
        }
    }

    internal class ItemTemplatePresenter<I> : ContentControl
    {
        public ItemTemplatePresenter()
        {
            DataContextChanged += ItemTemplatePresenter_DataContextChanged;
        }

        private void ItemTemplatePresenter_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var itemTemplate = (ItemTemplate<I>)((ContentPresenter)TemplatedParent).ContentTemplate;
            var newRoot = itemTemplate.RenderFunc((I)e.NewValue);

            var previousTemplateNode = itemTemplate.PreviousTemplate?.GetAvailableTemplateNode();

            if (previousTemplateNode != null)
            {
                previousTemplateNode.Root = newRoot;
                previousTemplateNode.Layout();
                itemTemplate.RegisterTemplate(previousTemplateNode);
                Content = previousTemplateNode.RootControl;
            }
            else
            {
                var itemTemplateNode = new ItemTemplateNode(newRoot);
                itemTemplateNode.Layout();
                itemTemplate.RegisterTemplate(itemTemplateNode);
                Content = itemTemplateNode.RootControl;
            }
        }
    }

    internal interface IItemTemplate
    {
        IItemTemplate? PreviousTemplate { get; set; }

        ItemTemplateNode? GetAvailableTemplateNode();

        void RegisterTemplate(ItemTemplateNode itemTemplateNode);
    }

    internal class ItemTemplate<I> : DataTemplate, IItemTemplate
    {
        private readonly Queue<ItemTemplateNode> _availableItemTemplates = new Queue<ItemTemplateNode>();
        public ItemTemplate(Func<I, VisualNode> renderFunc)
        {
            VisualTree = new FrameworkElementFactory(typeof(ItemTemplatePresenter<I>));
            RenderFunc = renderFunc;
        }

        public Func<I, VisualNode> RenderFunc { get; }

        //public Type ItemType => typeof(I);

        public IItemTemplate? PreviousTemplate { get; set; }

        public ItemTemplateNode? GetAvailableTemplateNode()
        {
            if (_availableItemTemplates.TryDequeue(out var itemTemplateNode))
                return itemTemplateNode;

            return null;
        }

        public void RegisterTemplate(ItemTemplateNode itemTemplateNode)
        {
            _availableItemTemplates.Enqueue(itemTemplateNode);
        }
    }

    public static partial class RxItemsControlExtensions
    {
        public static T OnRenderItem<T, I>(this T itemscontrol, Func<I, VisualNode> renderFunc) where T : IRxItemsControl
        {
            itemscontrol.ItemTemplate = new PropertyValue<DataTemplate>(new ItemTemplate<I>(renderFunc));

            return itemscontrol;
        }
    }
}
