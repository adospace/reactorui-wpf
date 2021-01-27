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
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxFrame : IRxContentControl
    {
        PropertyValue<JournalOwnership>? JournalOwnership { get; set; }
        PropertyValue<NavigationUIVisibility>? NavigationUIVisibility { get; set; }
        PropertyValue<bool>? SandboxExternalContent { get; set; }
        PropertyValue<Uri>? Source { get; set; }

    }

    public partial class RxFrame<T> : RxContentControl<T>, IRxFrame where T : Frame, new()
    {
        public RxFrame()
        {

        }

        public RxFrame(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<JournalOwnership>? IRxFrame.JournalOwnership { get; set; }
        PropertyValue<NavigationUIVisibility>? IRxFrame.NavigationUIVisibility { get; set; }
        PropertyValue<bool>? IRxFrame.SandboxExternalContent { get; set; }
        PropertyValue<Uri>? IRxFrame.Source { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxFrame = (IRxFrame)this;
            SetPropertyValue(NativeControl, Frame.JournalOwnershipProperty, thisAsIRxFrame.JournalOwnership);
            SetPropertyValue(NativeControl, Frame.NavigationUIVisibilityProperty, thisAsIRxFrame.NavigationUIVisibility);
            SetPropertyValue(NativeControl, Frame.SandboxExternalContentProperty, thisAsIRxFrame.SandboxExternalContent);
            SetPropertyValue(NativeControl, Frame.SourceProperty, thisAsIRxFrame.Source);

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
    public partial class RxFrame : RxFrame<Frame>
    {
        public RxFrame()
        {

        }

        public RxFrame(Action<Frame?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxFrameExtensions
    {
        public static T JournalOwnership<T>(this T frame, JournalOwnership journalOwnership) where T : IRxFrame
        {
            frame.JournalOwnership = new PropertyValue<JournalOwnership>(journalOwnership);
            return frame;
        }
        public static T JournalOwnership<T>(this T frame, Func<JournalOwnership> journalOwnershipFunc) where T : IRxFrame
        {
            frame.JournalOwnership = new PropertyValue<JournalOwnership>(journalOwnershipFunc);
            return frame;
        }
        public static T NavigationUIVisibility<T>(this T frame, NavigationUIVisibility navigationUIVisibility) where T : IRxFrame
        {
            frame.NavigationUIVisibility = new PropertyValue<NavigationUIVisibility>(navigationUIVisibility);
            return frame;
        }
        public static T NavigationUIVisibility<T>(this T frame, Func<NavigationUIVisibility> navigationUIVisibilityFunc) where T : IRxFrame
        {
            frame.NavigationUIVisibility = new PropertyValue<NavigationUIVisibility>(navigationUIVisibilityFunc);
            return frame;
        }
        public static T SandboxExternalContent<T>(this T frame, bool sandboxExternalContent) where T : IRxFrame
        {
            frame.SandboxExternalContent = new PropertyValue<bool>(sandboxExternalContent);
            return frame;
        }
        public static T SandboxExternalContent<T>(this T frame, Func<bool> sandboxExternalContentFunc) where T : IRxFrame
        {
            frame.SandboxExternalContent = new PropertyValue<bool>(sandboxExternalContentFunc);
            return frame;
        }
        public static T Source<T>(this T frame, Uri source) where T : IRxFrame
        {
            frame.Source = new PropertyValue<Uri>(source);
            return frame;
        }
        public static T Source<T>(this T frame, Func<Uri> sourceFunc) where T : IRxFrame
        {
            frame.Source = new PropertyValue<Uri>(sourceFunc);
            return frame;
        }
    }
}
