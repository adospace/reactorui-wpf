using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
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
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxGridSplitter : IRxThumb
    {
        PropertyValue<double>? DragIncrement { get; set; }
        PropertyValue<double>? KeyboardIncrement { get; set; }
        PropertyValue<Style>? PreviewStyle { get; set; }
        PropertyValue<GridResizeBehavior>? ResizeBehavior { get; set; }
        PropertyValue<GridResizeDirection>? ResizeDirection { get; set; }
        PropertyValue<bool>? ShowsPreview { get; set; }

    }
    public partial class RxGridSplitter<T> : RxThumb<T>, IRxGridSplitter where T : GridSplitter, new()
    {
        public RxGridSplitter()
        {

        }

        public RxGridSplitter(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<double>? IRxGridSplitter.DragIncrement { get; set; }
        PropertyValue<double>? IRxGridSplitter.KeyboardIncrement { get; set; }
        PropertyValue<Style>? IRxGridSplitter.PreviewStyle { get; set; }
        PropertyValue<GridResizeBehavior>? IRxGridSplitter.ResizeBehavior { get; set; }
        PropertyValue<GridResizeDirection>? IRxGridSplitter.ResizeDirection { get; set; }
        PropertyValue<bool>? IRxGridSplitter.ShowsPreview { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxGridSplitter = (IRxGridSplitter)this;
            SetPropertyValue(NativeControl, GridSplitter.DragIncrementProperty, thisAsIRxGridSplitter.DragIncrement);
            SetPropertyValue(NativeControl, GridSplitter.KeyboardIncrementProperty, thisAsIRxGridSplitter.KeyboardIncrement);
            SetPropertyValue(NativeControl, GridSplitter.PreviewStyleProperty, thisAsIRxGridSplitter.PreviewStyle);
            SetPropertyValue(NativeControl, GridSplitter.ResizeBehaviorProperty, thisAsIRxGridSplitter.ResizeBehavior);
            SetPropertyValue(NativeControl, GridSplitter.ResizeDirectionProperty, thisAsIRxGridSplitter.ResizeDirection);
            SetPropertyValue(NativeControl, GridSplitter.ShowsPreviewProperty, thisAsIRxGridSplitter.ShowsPreview);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();
        partial void OnAttachingNewEvents();
        partial void OnDetachingNewEvents();

        protected override void OnAttachNativeEvents()
        {
            OnAttachingNewEvents();


            base.OnAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();


            base.OnDetachNativeEvents();
        }

    }
    public partial class RxGridSplitter : RxGridSplitter<GridSplitter>
    {
        public RxGridSplitter()
        {

        }

        public RxGridSplitter(Action<GridSplitter?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxGridSplitterExtensions
    {
        public static T DragIncrement<T>(this T gridsplitter, double dragIncrement) where T : IRxGridSplitter
        {
            gridsplitter.DragIncrement = new PropertyValue<double>(dragIncrement);
            return gridsplitter;
        }
        public static T DragIncrement<T>(this T gridsplitter, Func<double> dragIncrementFunc) where T : IRxGridSplitter
        {
            gridsplitter.DragIncrement = new PropertyValue<double>(dragIncrementFunc);
            return gridsplitter;
        }
        public static T KeyboardIncrement<T>(this T gridsplitter, double keyboardIncrement) where T : IRxGridSplitter
        {
            gridsplitter.KeyboardIncrement = new PropertyValue<double>(keyboardIncrement);
            return gridsplitter;
        }
        public static T KeyboardIncrement<T>(this T gridsplitter, Func<double> keyboardIncrementFunc) where T : IRxGridSplitter
        {
            gridsplitter.KeyboardIncrement = new PropertyValue<double>(keyboardIncrementFunc);
            return gridsplitter;
        }
        public static T PreviewStyle<T>(this T gridsplitter, Style previewStyle) where T : IRxGridSplitter
        {
            gridsplitter.PreviewStyle = new PropertyValue<Style>(previewStyle);
            return gridsplitter;
        }
        public static T PreviewStyle<T>(this T gridsplitter, Func<Style> previewStyleFunc) where T : IRxGridSplitter
        {
            gridsplitter.PreviewStyle = new PropertyValue<Style>(previewStyleFunc);
            return gridsplitter;
        }
        public static T ResizeBehavior<T>(this T gridsplitter, GridResizeBehavior resizeBehavior) where T : IRxGridSplitter
        {
            gridsplitter.ResizeBehavior = new PropertyValue<GridResizeBehavior>(resizeBehavior);
            return gridsplitter;
        }
        public static T ResizeBehavior<T>(this T gridsplitter, Func<GridResizeBehavior> resizeBehaviorFunc) where T : IRxGridSplitter
        {
            gridsplitter.ResizeBehavior = new PropertyValue<GridResizeBehavior>(resizeBehaviorFunc);
            return gridsplitter;
        }
        public static T ResizeDirection<T>(this T gridsplitter, GridResizeDirection resizeDirection) where T : IRxGridSplitter
        {
            gridsplitter.ResizeDirection = new PropertyValue<GridResizeDirection>(resizeDirection);
            return gridsplitter;
        }
        public static T ResizeDirection<T>(this T gridsplitter, Func<GridResizeDirection> resizeDirectionFunc) where T : IRxGridSplitter
        {
            gridsplitter.ResizeDirection = new PropertyValue<GridResizeDirection>(resizeDirectionFunc);
            return gridsplitter;
        }
        public static T ShowsPreview<T>(this T gridsplitter, bool showsPreview) where T : IRxGridSplitter
        {
            gridsplitter.ShowsPreview = new PropertyValue<bool>(showsPreview);
            return gridsplitter;
        }
        public static T ShowsPreview<T>(this T gridsplitter, Func<bool> showsPreviewFunc) where T : IRxGridSplitter
        {
            gridsplitter.ShowsPreview = new PropertyValue<bool>(showsPreviewFunc);
            return gridsplitter;
        }
    }
}
