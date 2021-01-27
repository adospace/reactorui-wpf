using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfReactorUI
{
    public partial interface IRxFrame : INavigation
    { }

    public partial class RxFrame<T>
    {
        private readonly List<(WeakReference, VisualNode)> _cachedPageReferences = new List<(WeakReference, VisualNode)>();

        protected override void OnAddChildCore(VisualNode widget, object childControl)
        {
            NativeControl.Navigate(childControl);

            _cachedPageReferences.Add((new WeakReference(childControl), widget));

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
            var cacheItem = _cachedPageReferences.FirstOrDefault(_ => _.Item1.Target == e.Content);
            if (cacheItem.Item2 != null)
            {
                ContentNode = cacheItem.Item2;
            }

            GC.Collect();
        }

        partial void OnDetachingNewEvents()
        {
            NativeControl.Navigated -= NativeControl_Navigated;
        }

        public override INavigation Navigation => this;

        public void Navigate<TPAGE>() where TPAGE : VisualNode, new()
        {
            throw new NotSupportedException();
            ContentNode = new TPAGE();
        }

        public void GoBack()
        {
            throw new NotSupportedException();
            NativeControl.NavigationService.GoBack();
        }
    }
}
