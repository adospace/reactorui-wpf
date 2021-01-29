using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfReactorUI
{
    public partial interface IRxFrame : INavigation
    { }

    public partial class RxFrame<T>
    {
        private class CachedPageEntry
        {
            private readonly WeakReference<Page> _pageRef;
            private readonly WeakReference<VisualNode> _nodeRef;

            public CachedPageEntry(Page page, VisualNode node)
            {
                _pageRef = new WeakReference<Page>(page);
                _nodeRef = new WeakReference<VisualNode>(node);
            }

            public bool IsAlive => _pageRef.TryGetTarget(out var _) && _nodeRef.TryGetTarget(out var _);

            public Page? Page
            {
                get
                {
                    _pageRef.TryGetTarget(out var page);
                    return page;
                }
            }

            public VisualNode? Node
            {
                get
                {
                    _nodeRef.TryGetTarget(out var node);
                    return node;
                }
            }
        }
        
        private readonly List<CachedPageEntry> _cachedPageReferences = new List<CachedPageEntry>();

        protected override void OnAddChildCore(VisualNode widget, object childControl)
        {
            if (childControl is Page page)
            {
                NativeControl.Navigate(page);

                _cachedPageReferences.Add(new CachedPageEntry(page, widget));
            }
            else
            {
                throw new NotSupportedException($"The type {childControl} is not supported under a frame: use an RxPage instead");
            }

            base.OnAddChildCore(widget, childControl);
        }

        protected override void OnRemoveChildCore(VisualNode widget, object childControl)
        {
        }


        partial void OnAttachingNewEvents()
        {
            NativeControl.Navigated += NativeControl_Navigated;
        }

        private void NativeControl_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var cacheItem = _cachedPageReferences.FirstOrDefault(_ => _.Page == e.Content);
            if (cacheItem != null)
            {
                ContentNode = cacheItem.Node;
            }

            _cachedPageReferences.RemoveAll((item) => 
            {
                //keep the node in memory if the page is still referenced by the wpf frame
                return !item.IsAlive;
            });
        }

        partial void OnDetachingNewEvents()
        {
            NativeControl.Navigated -= NativeControl_Navigated;
        }

        public override INavigation Navigation => this;

        public void Navigate<TPAGE>() where TPAGE : VisualNode, new()
        {
            ContentNode = new TPAGE();
        }

        public void GoBack()
        {
            NativeControl.NavigationService.GoBack();
        }
    }
}
