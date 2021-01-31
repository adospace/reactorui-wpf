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
        public CachedPageEntry(Page page, VisualNode node)
        {
            Page = page;
            Node = node;
        }

        public Page Page { get; }

        public VisualNode Node { get; }
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
            NativeControl.Navigated += NativeControl_InternalNavigated;
        }

        private void NativeControl_InternalNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var cacheItem = _cachedPageReferences.FirstOrDefault(_ => _.Page == e.Content);
            if (cacheItem != null)
            {
                ContentNode = cacheItem.Node;
            }

            var currentPages = new HashSet<Page>(NativeControl.GetPages());

            _cachedPageReferences.RemoveAll((item) => 
            {
                //keep the node in memory if the page is still referenced by the wpf frame
                if (!currentPages.Contains(item.Page) && ContentNode != item.Node)
                {
                    item.Node.Unmount();
                    return true;
                }

                return false;
            });
        }

        partial void OnDetachingNewEvents()
        {
            NativeControl.Navigated -= NativeControl_InternalNavigated;
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode.GetType() == GetType())
            {
                ((VisualNode<T>)newNode).OnMergedWith(this);

                OnMigrated(newNode);

                //do not call base method to avoid unmounting children of this (old) rx frame
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
        }

        public void GoBack()
        {
            NativeControl.NavigationService.GoBack();
        }
    }

    internal static class NavigationServiceExtensions
    {
        public static IEnumerable<Page> GetPages(this Frame frame)
        {
            if (frame.BackStack != null)
            {
                foreach (var entry in frame.BackStack)
                {
                    if (entry.GetType().GetProperty("KeepAliveRoot", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.GetValue(entry) is Page page)
                        yield return page;
                }
            }
            if (frame.ForwardStack != null)
            {
                foreach (var entry in frame.ForwardStack)
                {
                    if (entry.GetType().GetProperty("KeepAliveRoot", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)?.GetValue(entry) is Page page)
                        yield return page;
                }
            }
        }
    }
}
