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
    public partial interface IRxImage : IRxFrameworkElement
    {
        PropertyValue<ImageSource>? Source { get; set; }
        PropertyValue<Stretch>? Stretch { get; set; }
        PropertyValue<StretchDirection>? StretchDirection { get; set; }

        Action? DpiChangedAction { get; set; }
        Action<object?, DpiChangedEventArgs>? DpiChangedActionWithArgs { get; set; }
        Action? ImageFailedAction { get; set; }
        Action<object?, ExceptionRoutedEventArgs>? ImageFailedActionWithArgs { get; set; }
    }

    public partial class RxImage<T> : RxFrameworkElement<T>, IRxImage where T : Image, new()
    {
        public RxImage()
        {

        }

        public RxImage(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<ImageSource>? IRxImage.Source { get; set; }
        PropertyValue<Stretch>? IRxImage.Stretch { get; set; }
        PropertyValue<StretchDirection>? IRxImage.StretchDirection { get; set; }

        Action? IRxImage.DpiChangedAction { get; set; }
        Action<object?, DpiChangedEventArgs>? IRxImage.DpiChangedActionWithArgs { get; set; }
        Action? IRxImage.ImageFailedAction { get; set; }
        Action<object?, ExceptionRoutedEventArgs>? IRxImage.ImageFailedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxImage = (IRxImage)this;
            SetPropertyValue(NativeControl, Image.SourceProperty, thisAsIRxImage.Source);
            SetPropertyValue(NativeControl, Image.StretchProperty, thisAsIRxImage.Stretch);
            SetPropertyValue(NativeControl, Image.StretchDirectionProperty, thisAsIRxImage.StretchDirection);

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

            var thisAsIRxImage = (IRxImage)this;
            if (thisAsIRxImage.DpiChangedAction != null || thisAsIRxImage.DpiChangedActionWithArgs != null)
            {
                NativeControl.DpiChanged += NativeControl_DpiChanged;
            }
            if (thisAsIRxImage.ImageFailedAction != null || thisAsIRxImage.ImageFailedActionWithArgs != null)
            {
                NativeControl.ImageFailed += NativeControl_ImageFailed;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_DpiChanged(object? sender, DpiChangedEventArgs e)
        {
            var thisAsIRxImage = (IRxImage)this;
            thisAsIRxImage.DpiChangedAction?.Invoke();
            thisAsIRxImage.DpiChangedActionWithArgs?.Invoke(sender, e);
        }
        private void NativeControl_ImageFailed(object? sender, ExceptionRoutedEventArgs e)
        {
            var thisAsIRxImage = (IRxImage)this;
            thisAsIRxImage.ImageFailedAction?.Invoke();
            thisAsIRxImage.ImageFailedActionWithArgs?.Invoke(sender, e);
        }

        protected override void OnDetachNativeEvents()
        {
            OnDetachingNewEvents();

            if (NativeControl != null)
            {
                NativeControl.DpiChanged -= NativeControl_DpiChanged;
                NativeControl.ImageFailed -= NativeControl_ImageFailed;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxImage : RxImage<Image>
    {
        public RxImage()
        {

        }

        public RxImage(Action<Image?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxImageExtensions
    {
        public static T Source<T>(this T image, ImageSource source) where T : IRxImage
        {
            image.Source = new PropertyValue<ImageSource>(source);
            return image;
        }
        public static T Source<T>(this T image, Func<ImageSource> sourceFunc) where T : IRxImage
        {
            image.Source = new PropertyValue<ImageSource>(sourceFunc);
            return image;
        }

        public static T Source<T>(this T image, string file) where T : IRxImage
        {
            image.Source = new PropertyValue<ImageSource>(new BitmapImage(new Uri(file)));
            return image;
        }
        /*
        public static T Source<T>(this T image, string resourceName, Assembly sourceAssembly) where T : IRxImage
        {
            image.Source = new PropertyValue<ImageSource>(ImageSource.FromResource(resourceName, sourceAssembly));
            return image;
        }
        */
        public static T Source<T>(this T image, Uri imageUri) where T : IRxImage
        {
            image.Source = new PropertyValue<ImageSource>(new BitmapImage(imageUri));
            return image;
        }
        /*
        public static T Source<T>(this T image, Uri imageUri, bool cachingEnabled, TimeSpan cacheValidity) where T : IRxImage
        {
            image.Source = new PropertyValue<ImageSource>(new UriImageSource
            {
                Uri = imageUri,
                CachingEnabled = cachingEnabled,
                CacheValidity = cacheValidity
            });
            return image;
        }
        public static T Source<T>(this T image, Func<Stream> imageStream) where T : IRxImage
        {
            image.Source = new PropertyValue<ImageSource>(ImageSource.FromStream(imageStream));
            return image;
        }
        */
        public static T Stretch<T>(this T image, Stretch stretch) where T : IRxImage
        {
            image.Stretch = new PropertyValue<Stretch>(stretch);
            return image;
        }
        public static T Stretch<T>(this T image, Func<Stretch> stretchFunc) where T : IRxImage
        {
            image.Stretch = new PropertyValue<Stretch>(stretchFunc);
            return image;
        }
        public static T StretchDirection<T>(this T image, StretchDirection stretchDirection) where T : IRxImage
        {
            image.StretchDirection = new PropertyValue<StretchDirection>(stretchDirection);
            return image;
        }
        public static T StretchDirection<T>(this T image, Func<StretchDirection> stretchDirectionFunc) where T : IRxImage
        {
            image.StretchDirection = new PropertyValue<StretchDirection>(stretchDirectionFunc);
            return image;
        }
        public static T OnDpiChanged<T>(this T image, Action dpichangedAction) where T : IRxImage
        {
            image.DpiChangedAction = dpichangedAction;
            return image;
        }

        public static T OnDpiChanged<T>(this T image, Action<object?, DpiChangedEventArgs> dpichangedActionWithArgs) where T : IRxImage
        {
            image.DpiChangedActionWithArgs = dpichangedActionWithArgs;
            return image;
        }
        public static T OnImageFailed<T>(this T image, Action imagefailedAction) where T : IRxImage
        {
            image.ImageFailedAction = imagefailedAction;
            return image;
        }

        public static T OnImageFailed<T>(this T image, Action<object?, ExceptionRoutedEventArgs> imagefailedActionWithArgs) where T : IRxImage
        {
            image.ImageFailedActionWithArgs = imagefailedActionWithArgs;
            return image;
        }
    }
}
