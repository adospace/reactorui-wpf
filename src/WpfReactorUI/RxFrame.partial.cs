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

    internal class CachedPageEntry
    {
        private readonly WeakReference<Page> _pageRef;
        private readonly VisualNode _node;

        public CachedPageEntry(Page page, VisualNode node)
        {
            _pageRef = new WeakReference<Page>(page);
            _node = node;
        }

        public bool IsAlive => _pageRef.TryGetTarget(out var _);

        public Page? Page
        {
            get
            {
                _pageRef.TryGetTarget(out var page);
                return page;
            }
        }

        public VisualNode Node
        {
            get
            {
                return _node;
            }
        }
    }

    public partial class RxFrame<T>
    {
        
        private List<CachedPageEntry> _cachedPageReferences = new List<CachedPageEntry>();

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
                if (!item.IsAlive)
                {
                    item.Node.Unmount();
                    //Remove(item.Node);
                    //Invalidate();
                    return true;
                }

                return false;
            });
        }

        partial void OnDetachingNewEvents()
        {
            NativeControl.Navigated -= NativeControl_Navigated;
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode.GetType() == GetType())
            {
                ((VisualNode<T>)newNode).OnMergedWith(this);

                OnMigrated(newNode);

                //do not call base merge with
                //base.MergeWith(newNode);
            }
            else
            {
                Unmount();
            }
        }

        internal override void OnMergedWith(VisualNode oldNode)
        {
            _cachedPageReferences = ((RxFrame)oldNode)._cachedPageReferences;

            base.OnMergedWith(oldNode);
        }

        public override INavigation Navigation => this;

        public void Navigate<TPAGE>() where TPAGE : VisualNode, new()
        {
            ContentNode = new TPAGE();
            //Add(new TPAGE());
            //Invalidate();
        }

        public void GoBack()
        {
            NativeControl.NavigationService.GoBack();
        }
    }
}
