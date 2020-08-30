using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace WpfReactorUI
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Effects;

    namespace WpfReactorUI
    {
        public interface IRxUIElement
        {
            bool AllowDrop { get; set; }
            Transform RenderTransform { get; set; }
            Point RenderTransformOrigin { get; set; }
            double Opacity { get; set; }
            Brush OpacityMask { get; set; }
            Effect Effect { get; set; }
            CacheMode CacheMode { get; set; }
            string Uid { get; set; }
            Visibility Visibility { get; set; }
            bool ClipToBounds { get; set; }
            Geometry Clip { get; set; }
            bool SnapsToDevicePixels { get; set; }
            bool IsEnabled { get; set; }
            bool IsHitTestVisible { get; set; }
            bool Focusable { get; set; }
            bool IsManipulationEnabled { get; set; }
        }

        public class RxUIElement<T> : VisualNode<T>, IRxUIElement where T : UIElement, new()
        {
            public RxUIElement()
            {

            }

            public RxUIElement(Action<T> componentRefAction)
                : base(componentRefAction)
            {

            }

            public bool AllowDrop { get; set; } = (bool)UIElement.AllowDropProperty.DefaultMetadata.DefaultValue;
            public Transform RenderTransform { get; set; } = (Transform)UIElement.RenderTransformProperty.DefaultValue;
            public Point RenderTransformOrigin { get; set; } = (Point)UIElement.RenderTransformOriginProperty.DefaultValue;
            public double Opacity { get; set; } = (double)UIElement.OpacityProperty.DefaultValue;
            public Brush OpacityMask { get; set; } = (Brush)UIElement.OpacityMaskProperty.DefaultValue;
            public Effect Effect { get; set; } = (Effect)UIElement.EffectProperty.DefaultValue;
            public CacheMode CacheMode { get; set; } = (CacheMode)UIElement.CacheModeProperty.DefaultValue;
            public string Uid { get; set; } = (string)UIElement.UidProperty.DefaultValue;
            public Visibility Visibility { get; set; } = (Visibility)UIElement.VisibilityProperty.DefaultValue;
            public bool ClipToBounds { get; set; } = (bool)UIElement.ClipToBoundsProperty.DefaultValue;
            public Geometry Clip { get; set; } = (Geometry)UIElement.ClipProperty.DefaultValue;
            public bool SnapsToDevicePixels { get; set; } = (bool)UIElement.SnapsToDevicePixelsProperty.DefaultValue;
            public bool IsEnabled { get; set; } = (bool)UIElement.IsEnabledProperty.DefaultValue;
            public bool IsHitTestVisible { get; set; } = (bool)UIElement.IsHitTestVisibleProperty.DefaultValue;
            public bool Focusable { get; set; } = (bool)UIElement.FocusableProperty.DefaultValue;
            public bool IsManipulationEnabled { get; set; } = (bool)UIElement.IsManipulationEnabledProperty.DefaultValue;

            protected override void OnUpdate()
            {
                NativeControl.AllowDrop = AllowDrop;
                NativeControl.RenderTransform = RenderTransform;
                NativeControl.RenderTransformOrigin = RenderTransformOrigin;
                NativeControl.Opacity = Opacity;
                NativeControl.OpacityMask = OpacityMask;
                NativeControl.Effect = Effect;
                NativeControl.CacheMode = CacheMode;
                NativeControl.Uid = Uid;
                NativeControl.Visibility = Visibility;
                NativeControl.ClipToBounds = ClipToBounds;
                NativeControl.Clip = Clip;
                NativeControl.SnapsToDevicePixels = SnapsToDevicePixels;
                NativeControl.IsEnabled = IsEnabled;
                NativeControl.IsHitTestVisible = IsHitTestVisible;
                NativeControl.Focusable = Focusable;
                NativeControl.IsManipulationEnabled = IsManipulationEnabled;

                base.OnUpdate();
            }

            protected override IEnumerable<VisualNode> RenderChildren()
            {
                yield break;
            }
        }

        public class RxUIElement : RxUIElement<UIElement>
        {
            public RxUIElement()
            {

            }

            public RxUIElement(Action<UIElement> componentRefAction)
                : base(componentRefAction)
            {

            }
        }

        public static class RxUIElementExtensions
        {
            public static T AllowDrop<T>(this T uielement, bool allowDrop) where T : IRxUIElement
            {
                uielement.AllowDrop = allowDrop;
                return uielement;
            }



            public static T RenderTransform<T>(this T uielement, Transform renderTransform) where T : IRxUIElement
            {
                uielement.RenderTransform = renderTransform;
                return uielement;
            }



            public static T RenderTransformOrigin<T>(this T uielement, Point renderTransformOrigin) where T : IRxUIElement
            {
                uielement.RenderTransformOrigin = renderTransformOrigin;
                return uielement;
            }



            public static T Opacity<T>(this T uielement, double opacity) where T : IRxUIElement
            {
                uielement.Opacity = opacity;
                return uielement;
            }



            public static T OpacityMask<T>(this T uielement, Brush opacityMask) where T : IRxUIElement
            {
                uielement.OpacityMask = opacityMask;
                return uielement;
            }



            public static T Effect<T>(this T uielement, Effect effect) where T : IRxUIElement
            {
                uielement.Effect = effect;
                return uielement;
            }



            public static T CacheMode<T>(this T uielement, CacheMode cacheMode) where T : IRxUIElement
            {
                uielement.CacheMode = cacheMode;
                return uielement;
            }



            public static T Uid<T>(this T uielement, string uid) where T : IRxUIElement
            {
                uielement.Uid = uid;
                return uielement;
            }



            public static T Visibility<T>(this T uielement, Visibility visibility) where T : IRxUIElement
            {
                uielement.Visibility = visibility;
                return uielement;
            }



            public static T ClipToBounds<T>(this T uielement, bool clipToBounds) where T : IRxUIElement
            {
                uielement.ClipToBounds = clipToBounds;
                return uielement;
            }



            public static T Clip<T>(this T uielement, Geometry clip) where T : IRxUIElement
            {
                uielement.Clip = clip;
                return uielement;
            }



            public static T SnapsToDevicePixels<T>(this T uielement, bool snapsToDevicePixels) where T : IRxUIElement
            {
                uielement.SnapsToDevicePixels = snapsToDevicePixels;
                return uielement;
            }



            public static T IsEnabled<T>(this T uielement, bool isEnabled) where T : IRxUIElement
            {
                uielement.IsEnabled = isEnabled;
                return uielement;
            }



            public static T IsHitTestVisible<T>(this T uielement, bool isHitTestVisible) where T : IRxUIElement
            {
                uielement.IsHitTestVisible = isHitTestVisible;
                return uielement;
            }



            public static T Focusable<T>(this T uielement, bool focusable) where T : IRxUIElement
            {
                uielement.Focusable = focusable;
                return uielement;
            }



            public static T IsManipulationEnabled<T>(this T uielement, bool isManipulationEnabled) where T : IRxUIElement
            {
                uielement.IsManipulationEnabled = isManipulationEnabled;
                return uielement;
            }



        }
    }
}