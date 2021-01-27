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
using ModernWpf.Controls;
using ModernWpf.Controls.Primitives;

namespace WpfReactorUI
{
    public partial interface IRxAppBarButton : IRxButton
    {
        PropertyValue<CornerRadius>? CornerRadius { get; set; }
        PropertyValue<FlyoutBase>? Flyout { get; set; }
        PropertyValue<Thickness>? FocusVisualMargin { get; set; }
        PropertyValue<IconElement>? Icon { get; set; }
        PropertyValue<string>? InputGestureText { get; set; }
        PropertyValue<bool>? IsCompact { get; set; }
        PropertyValue<string>? Label { get; set; }
        PropertyValue<CommandBarLabelPosition>? LabelPosition { get; set; }
        PropertyValue<bool>? UseSystemFocusVisuals { get; set; }

    }

    public partial class RxAppBarButton<T> : RxButton<T>, IRxAppBarButton where T : AppBarButton, new()
    {
        public RxAppBarButton()
        {

        }

        public RxAppBarButton(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<CornerRadius>? IRxAppBarButton.CornerRadius { get; set; }
        PropertyValue<FlyoutBase>? IRxAppBarButton.Flyout { get; set; }
        PropertyValue<Thickness>? IRxAppBarButton.FocusVisualMargin { get; set; }
        PropertyValue<IconElement>? IRxAppBarButton.Icon { get; set; }
        PropertyValue<string>? IRxAppBarButton.InputGestureText { get; set; }
        PropertyValue<bool>? IRxAppBarButton.IsCompact { get; set; }
        PropertyValue<string>? IRxAppBarButton.Label { get; set; }
        PropertyValue<CommandBarLabelPosition>? IRxAppBarButton.LabelPosition { get; set; }
        PropertyValue<bool>? IRxAppBarButton.UseSystemFocusVisuals { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxAppBarButton = (IRxAppBarButton)this;
            SetPropertyValue(NativeControl, AppBarButton.CornerRadiusProperty, thisAsIRxAppBarButton.CornerRadius);
            SetPropertyValue(NativeControl, AppBarButton.FlyoutProperty, thisAsIRxAppBarButton.Flyout);
            SetPropertyValue(NativeControl, AppBarButton.FocusVisualMarginProperty, thisAsIRxAppBarButton.FocusVisualMargin);
            SetPropertyValue(NativeControl, AppBarButton.IconProperty, thisAsIRxAppBarButton.Icon);
            SetPropertyValue(NativeControl, AppBarButton.InputGestureTextProperty, thisAsIRxAppBarButton.InputGestureText);
            SetPropertyValue(NativeControl, AppBarButton.IsCompactProperty, thisAsIRxAppBarButton.IsCompact);
            SetPropertyValue(NativeControl, AppBarButton.LabelProperty, thisAsIRxAppBarButton.Label);
            SetPropertyValue(NativeControl, AppBarButton.LabelPositionProperty, thisAsIRxAppBarButton.LabelPosition);
            SetPropertyValue(NativeControl, AppBarButton.UseSystemFocusVisualsProperty, thisAsIRxAppBarButton.UseSystemFocusVisuals);

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
    public partial class RxAppBarButton : RxAppBarButton<AppBarButton>
    {
        public RxAppBarButton()
        {

        }

        public RxAppBarButton(Action<AppBarButton?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxAppBarButtonExtensions
    {
        public static T CornerRadius<T>(this T appbarbutton, CornerRadius cornerRadius) where T : IRxAppBarButton
        {
            appbarbutton.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return appbarbutton;
        }
        public static T CornerRadius<T>(this T appbarbutton, Func<CornerRadius> cornerRadiusFunc) where T : IRxAppBarButton
        {
            appbarbutton.CornerRadius = new PropertyValue<CornerRadius>(cornerRadiusFunc);
            return appbarbutton;
        }
        public static T Flyout<T>(this T appbarbutton, FlyoutBase flyout) where T : IRxAppBarButton
        {
            appbarbutton.Flyout = new PropertyValue<FlyoutBase>(flyout);
            return appbarbutton;
        }
        public static T Flyout<T>(this T appbarbutton, Func<FlyoutBase> flyoutFunc) where T : IRxAppBarButton
        {
            appbarbutton.Flyout = new PropertyValue<FlyoutBase>(flyoutFunc);
            return appbarbutton;
        }
        public static T FocusVisualMargin<T>(this T appbarbutton, Thickness focusVisualMargin) where T : IRxAppBarButton
        {
            appbarbutton.FocusVisualMargin = new PropertyValue<Thickness>(focusVisualMargin);
            return appbarbutton;
        }
        public static T FocusVisualMargin<T>(this T appbarbutton, Func<Thickness> focusVisualMarginFunc) where T : IRxAppBarButton
        {
            appbarbutton.FocusVisualMargin = new PropertyValue<Thickness>(focusVisualMarginFunc);
            return appbarbutton;
        }
        public static T FocusVisualMargin<T>(this T appbarbutton, double leftRight, double topBottom) where T : IRxAppBarButton
        {
            appbarbutton.FocusVisualMargin = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return appbarbutton;
        }
        public static T FocusVisualMargin<T>(this T appbarbutton, double uniformSize) where T : IRxAppBarButton
        {
            appbarbutton.FocusVisualMargin = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return appbarbutton;
        }
        public static T Icon<T>(this T appbarbutton, IconElement icon) where T : IRxAppBarButton
        {
            appbarbutton.Icon = new PropertyValue<IconElement>(icon);
            return appbarbutton;
        }
        public static T Icon<T>(this T appbarbutton, Func<IconElement> iconFunc) where T : IRxAppBarButton
        {
            appbarbutton.Icon = new PropertyValue<IconElement>(iconFunc);
            return appbarbutton;
        }
        public static T InputGestureText<T>(this T appbarbutton, string inputGestureText) where T : IRxAppBarButton
        {
            appbarbutton.InputGestureText = new PropertyValue<string>(inputGestureText);
            return appbarbutton;
        }
        public static T InputGestureText<T>(this T appbarbutton, Func<string> inputGestureTextFunc) where T : IRxAppBarButton
        {
            appbarbutton.InputGestureText = new PropertyValue<string>(inputGestureTextFunc);
            return appbarbutton;
        }
        public static T IsCompact<T>(this T appbarbutton, bool isCompact) where T : IRxAppBarButton
        {
            appbarbutton.IsCompact = new PropertyValue<bool>(isCompact);
            return appbarbutton;
        }
        public static T IsCompact<T>(this T appbarbutton, Func<bool> isCompactFunc) where T : IRxAppBarButton
        {
            appbarbutton.IsCompact = new PropertyValue<bool>(isCompactFunc);
            return appbarbutton;
        }
        public static T Label<T>(this T appbarbutton, string label) where T : IRxAppBarButton
        {
            appbarbutton.Label = new PropertyValue<string>(label);
            return appbarbutton;
        }
        public static T Label<T>(this T appbarbutton, Func<string> labelFunc) where T : IRxAppBarButton
        {
            appbarbutton.Label = new PropertyValue<string>(labelFunc);
            return appbarbutton;
        }
        public static T LabelPosition<T>(this T appbarbutton, CommandBarLabelPosition labelPosition) where T : IRxAppBarButton
        {
            appbarbutton.LabelPosition = new PropertyValue<CommandBarLabelPosition>(labelPosition);
            return appbarbutton;
        }
        public static T LabelPosition<T>(this T appbarbutton, Func<CommandBarLabelPosition> labelPositionFunc) where T : IRxAppBarButton
        {
            appbarbutton.LabelPosition = new PropertyValue<CommandBarLabelPosition>(labelPositionFunc);
            return appbarbutton;
        }
        public static T UseSystemFocusVisuals<T>(this T appbarbutton, bool useSystemFocusVisuals) where T : IRxAppBarButton
        {
            appbarbutton.UseSystemFocusVisuals = new PropertyValue<bool>(useSystemFocusVisuals);
            return appbarbutton;
        }
        public static T UseSystemFocusVisuals<T>(this T appbarbutton, Func<bool> useSystemFocusVisualsFunc) where T : IRxAppBarButton
        {
            appbarbutton.UseSystemFocusVisuals = new PropertyValue<bool>(useSystemFocusVisualsFunc);
            return appbarbutton;
        }
    }
}
