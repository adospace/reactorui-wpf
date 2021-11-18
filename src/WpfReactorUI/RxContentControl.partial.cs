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
        PropertyValue<string>? ContentString { get; set; }
    }

    public partial class RxContentControl<T> : IEnumerable<VisualNode>
    {
        protected readonly List<VisualNode> _contents = new();
        public RxContentControl(VisualNode? content)
        {
            if (content != null)
            {
                _contents.Add(content);
            }
        }

        PropertyValue<string>? IRxContentControl.ContentString { get; set; }

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

        //protected void Remove(VisualNode node)
        //{
        //    _contents.Remove(node);
        //}

        protected VisualNode? ContentNode
        {
            get => _contents.FirstOrDefault() as VisualNode;
            set
            {
                if (value != ContentNode)
                {
                    _contents.Clear();
                    if (value != null)
                    {
                        _contents.Add(value);
                    }

                    InvalidateChildren();
                    Invalidate();
                }
            }
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
            OnRemoveChildCore(widget, childControl);

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
            var thisAsIRxContentControl = (IRxContentControl)this;
            SetPropertyValue(NativeControl, ContentControl.ContentProperty, thisAsIRxContentControl.ContentString);
        }
    }

    public static partial class RxContentControlExtensions
    {
        public static T ContentString<T>(this T contentcontrol, string contentString) where T : IRxContentControl
        {
            contentcontrol.ContentString = new PropertyValue<string>(contentString);
            return contentcontrol;
        }

    }
}
