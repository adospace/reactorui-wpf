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
    public partial interface IRxThumb : IRxControl
    {

        Action? DragCompletedAction { get; set; }
        Action<object?, DragCompletedEventArgs>? DragCompletedActionWithArgs { get; set; }
        Action? DragDeltaAction { get; set; }
        Action<object?, DragDeltaEventArgs>? DragDeltaActionWithArgs { get; set; }
        Action? DragStartedAction { get; set; }
        Action<object?, DragStartedEventArgs>? DragStartedActionWithArgs { get; set; }
    }
    public partial class RxThumb<T> : RxControl<T>, IRxThumb where T : Thumb, new()
    {
        public RxThumb()
        {

        }

        public RxThumb(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }


        Action? IRxThumb.DragCompletedAction { get; set; }
        Action<object?, DragCompletedEventArgs>? IRxThumb.DragCompletedActionWithArgs { get; set; }
        Action? IRxThumb.DragDeltaAction { get; set; }
        Action<object?, DragDeltaEventArgs>? IRxThumb.DragDeltaActionWithArgs { get; set; }
        Action? IRxThumb.DragStartedAction { get; set; }
        Action<object?, DragStartedEventArgs>? IRxThumb.DragStartedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();


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

            var thisAsIRxThumb = (IRxThumb)this;
            if (thisAsIRxThumb.DragCompletedAction != null || thisAsIRxThumb.DragCompletedActionWithArgs != null)
            {
                NativeControl.DragCompleted += NativeControl_DragCompleted;
            }
            if (thisAsIRxThumb.DragDeltaAction != null || thisAsIRxThumb.DragDeltaActionWithArgs != null)
            {
                NativeControl.DragDelta += NativeControl_DragDelta;
            }
            if (thisAsIRxThumb.DragStartedAction != null || thisAsIRxThumb.DragStartedActionWithArgs != null)
            {
                NativeControl.DragStarted += NativeControl_DragStarted;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_DragCompleted(object? sender, DragCompletedEventArgs e)
        {
            var thisAsIRxThumb = (IRxThumb)this;
            thisAsIRxThumb.DragCompletedAction?.Invoke();
            thisAsIRxThumb.DragCompletedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_DragDelta(object? sender, DragDeltaEventArgs e)
        {
            var thisAsIRxThumb = (IRxThumb)this;
            thisAsIRxThumb.DragDeltaAction?.Invoke();
            thisAsIRxThumb.DragDeltaActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_DragStarted(object? sender, DragStartedEventArgs e)
        {
            var thisAsIRxThumb = (IRxThumb)this;
            thisAsIRxThumb.DragStartedAction?.Invoke();
            thisAsIRxThumb.DragStartedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.DragCompleted -= NativeControl_DragCompleted;
                NativeControl.DragDelta -= NativeControl_DragDelta;
                NativeControl.DragStarted -= NativeControl_DragStarted;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxThumb : RxThumb<Thumb>
    {
        public RxThumb()
        {

        }

        public RxThumb(Action<Thumb?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxThumbExtensions
    {
        public static T OnDragCompleted<T>(this T thumb, Action dragcompletedAction) where T : IRxThumb
        {
            thumb.DragCompletedAction = dragcompletedAction;
            return thumb;
        }

        public static T OnDragCompleted<T>(this T thumb, Action<object?, DragCompletedEventArgs> dragcompletedActionWithArgs) where T : IRxThumb
        {
            thumb.DragCompletedActionWithArgs = dragcompletedActionWithArgs;
            return thumb;
        }
        public static T OnDragDelta<T>(this T thumb, Action dragdeltaAction) where T : IRxThumb
        {
            thumb.DragDeltaAction = dragdeltaAction;
            return thumb;
        }

        public static T OnDragDelta<T>(this T thumb, Action<object?, DragDeltaEventArgs> dragdeltaActionWithArgs) where T : IRxThumb
        {
            thumb.DragDeltaActionWithArgs = dragdeltaActionWithArgs;
            return thumb;
        }
        public static T OnDragStarted<T>(this T thumb, Action dragstartedAction) where T : IRxThumb
        {
            thumb.DragStartedAction = dragstartedAction;
            return thumb;
        }

        public static T OnDragStarted<T>(this T thumb, Action<object?, DragStartedEventArgs> dragstartedActionWithArgs) where T : IRxThumb
        {
            thumb.DragStartedActionWithArgs = dragstartedActionWithArgs;
            return thumb;
        }
    }
}
