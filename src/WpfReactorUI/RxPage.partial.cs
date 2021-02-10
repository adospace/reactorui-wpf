using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Reflection;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shell;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Windows.Markup;


using WpfReactorUI.Internals;
using System.Linq;

namespace WpfReactorUI
{
    public partial interface IRxPage
    {
        PropertyValue<string>? ContentString { get; set; }
    }

    public partial class RxPage<T> : IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _contents = new List<VisualNode>();
        public RxPage(VisualNode content)
        {
            _contents.Add(content);
        }

        PropertyValue<string>? IRxPage.ContentString { get; set; }

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
            NativeControl.Content = childControl;
        }

        protected sealed override void OnRemoveChild(VisualNode widget, object childControl)
        {
            NativeControl.Content = null;

            base.OnRemoveChild(widget, childControl);
        }

        protected virtual void OnRemoveChildCore(VisualNode widget, object childControl)
        {
            NativeControl.Content = null;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            return _contents;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        partial void OnBeginUpdate()
        {
            var thisAsIRxPage = (IRxPage)this;
            SetPropertyValue(NativeControl, ContentControl.ContentProperty, thisAsIRxPage.ContentString);
        }

        //protected override void OnMount()
        //{
        //    //if the page is reloaded by the native frame the page is already mounted
        //    if (!IsMounted)
        //    {
        //        base.OnMount();
        //    }
        //}

        //protected override void OnUnmount()
        //{
        //    //NOTE: It's important to not unmount the page because the native wpf Page is directly managed by the parent native Frame
        //    //base.OnUnmount();
        //}
    }

    public static partial class RxPageExtensions
    {
        public static T ContentString<T>(this T contentcontrol, string contentString) where T : IRxPage
        {
            contentcontrol.ContentString = new PropertyValue<string>(contentString);
            return contentcontrol;
        }

    }
}
