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
    public partial interface IRxContentControl
    {

    }

    public partial class RxContentControl<T> : IEnumerable<VisualNode>
    {
        private readonly List<VisualNode> _contents = new List<VisualNode>();
        public RxContentControl(VisualNode content)
        {
            _contents.Add(content);
        }

        public void Add(VisualNode child)
        {
            if (child is VisualNode && _contents.Any())
                throw new InvalidOperationException("Content already set");

            _contents.Add(child);
        }

        public IEnumerator<VisualNode> GetEnumerator()
        {
            return _contents.GetEnumerator();
        }
        
        protected override void OnAddChild(VisualNode widget, DependencyObject childControl)
        {
            NativeControl.Content = childControl;

            base.OnAddChild(widget, childControl);
        }

        protected override void OnRemoveChild(VisualNode widget, DependencyObject childControl)
        {
            NativeControl.Content = null;

            base.OnRemoveChild(widget, childControl);
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

        }
    }

    public static partial class RxContentControlExtensions
    {


    }
}
