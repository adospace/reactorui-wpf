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
    public partial interface IRxContentDialog : IRxContentControl
    {
        PropertyValue<ICommand>? CloseButtonCommand { get; set; }
        PropertyValue<object>? CloseButtonCommandParameter { get; set; }
        PropertyValue<Style>? CloseButtonStyle { get; set; }
        PropertyValue<string>? CloseButtonText { get; set; }
        PropertyValue<CornerRadius>? CornerRadius { get; set; }
        PropertyValue<ContentDialogButton>? DefaultButton { get; set; }
        PropertyValue<bool>? FullSizeDesired { get; set; }
        PropertyValue<bool>? IsPrimaryButtonEnabled { get; set; }
        PropertyValue<bool>? IsSecondaryButtonEnabled { get; set; }
        PropertyValue<bool>? IsShadowEnabled { get; set; }
        PropertyValue<ICommand>? PrimaryButtonCommand { get; set; }
        PropertyValue<object>? PrimaryButtonCommandParameter { get; set; }
        PropertyValue<Style>? PrimaryButtonStyle { get; set; }
        PropertyValue<string>? PrimaryButtonText { get; set; }
        PropertyValue<ICommand>? SecondaryButtonCommand { get; set; }
        PropertyValue<object>? SecondaryButtonCommandParameter { get; set; }
        PropertyValue<Style>? SecondaryButtonStyle { get; set; }
        PropertyValue<string>? SecondaryButtonText { get; set; }
        PropertyValue<object>? Title { get; set; }

    }

    public partial class RxContentDialog<T> : RxContentControl<T>, IRxContentDialog where T : ContentDialog, new()
    {
        public RxContentDialog()
        {

        }

        public RxContentDialog(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<ICommand>? IRxContentDialog.CloseButtonCommand { get; set; }
        PropertyValue<object>? IRxContentDialog.CloseButtonCommandParameter { get; set; }
        PropertyValue<Style>? IRxContentDialog.CloseButtonStyle { get; set; }
        PropertyValue<string>? IRxContentDialog.CloseButtonText { get; set; }
        PropertyValue<CornerRadius>? IRxContentDialog.CornerRadius { get; set; }
        PropertyValue<ContentDialogButton>? IRxContentDialog.DefaultButton { get; set; }
        PropertyValue<bool>? IRxContentDialog.FullSizeDesired { get; set; }
        PropertyValue<bool>? IRxContentDialog.IsPrimaryButtonEnabled { get; set; }
        PropertyValue<bool>? IRxContentDialog.IsSecondaryButtonEnabled { get; set; }
        PropertyValue<bool>? IRxContentDialog.IsShadowEnabled { get; set; }
        PropertyValue<ICommand>? IRxContentDialog.PrimaryButtonCommand { get; set; }
        PropertyValue<object>? IRxContentDialog.PrimaryButtonCommandParameter { get; set; }
        PropertyValue<Style>? IRxContentDialog.PrimaryButtonStyle { get; set; }
        PropertyValue<string>? IRxContentDialog.PrimaryButtonText { get; set; }
        PropertyValue<ICommand>? IRxContentDialog.SecondaryButtonCommand { get; set; }
        PropertyValue<object>? IRxContentDialog.SecondaryButtonCommandParameter { get; set; }
        PropertyValue<Style>? IRxContentDialog.SecondaryButtonStyle { get; set; }
        PropertyValue<string>? IRxContentDialog.SecondaryButtonText { get; set; }
        PropertyValue<object>? IRxContentDialog.Title { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxContentDialog = (IRxContentDialog)this;
            SetPropertyValue(NativeControl, ContentDialog.CloseButtonCommandProperty, thisAsIRxContentDialog.CloseButtonCommand);
            SetPropertyValue(NativeControl, ContentDialog.CloseButtonCommandParameterProperty, thisAsIRxContentDialog.CloseButtonCommandParameter);
            SetPropertyValue(NativeControl, ContentDialog.CloseButtonStyleProperty, thisAsIRxContentDialog.CloseButtonStyle);
            SetPropertyValue(NativeControl, ContentDialog.CloseButtonTextProperty, thisAsIRxContentDialog.CloseButtonText);
            SetPropertyValue(NativeControl, ContentDialog.CornerRadiusProperty, thisAsIRxContentDialog.CornerRadius);
            SetPropertyValue(NativeControl, ContentDialog.DefaultButtonProperty, thisAsIRxContentDialog.DefaultButton);
            SetPropertyValue(NativeControl, ContentDialog.FullSizeDesiredProperty, thisAsIRxContentDialog.FullSizeDesired);
            SetPropertyValue(NativeControl, ContentDialog.IsPrimaryButtonEnabledProperty, thisAsIRxContentDialog.IsPrimaryButtonEnabled);
            SetPropertyValue(NativeControl, ContentDialog.IsSecondaryButtonEnabledProperty, thisAsIRxContentDialog.IsSecondaryButtonEnabled);
            SetPropertyValue(NativeControl, ContentDialog.IsShadowEnabledProperty, thisAsIRxContentDialog.IsShadowEnabled);
            SetPropertyValue(NativeControl, ContentDialog.PrimaryButtonCommandProperty, thisAsIRxContentDialog.PrimaryButtonCommand);
            SetPropertyValue(NativeControl, ContentDialog.PrimaryButtonCommandParameterProperty, thisAsIRxContentDialog.PrimaryButtonCommandParameter);
            SetPropertyValue(NativeControl, ContentDialog.PrimaryButtonStyleProperty, thisAsIRxContentDialog.PrimaryButtonStyle);
            SetPropertyValue(NativeControl, ContentDialog.PrimaryButtonTextProperty, thisAsIRxContentDialog.PrimaryButtonText);
            SetPropertyValue(NativeControl, ContentDialog.SecondaryButtonCommandProperty, thisAsIRxContentDialog.SecondaryButtonCommand);
            SetPropertyValue(NativeControl, ContentDialog.SecondaryButtonCommandParameterProperty, thisAsIRxContentDialog.SecondaryButtonCommandParameter);
            SetPropertyValue(NativeControl, ContentDialog.SecondaryButtonStyleProperty, thisAsIRxContentDialog.SecondaryButtonStyle);
            SetPropertyValue(NativeControl, ContentDialog.SecondaryButtonTextProperty, thisAsIRxContentDialog.SecondaryButtonText);
            SetPropertyValue(NativeControl, ContentDialog.TitleProperty, thisAsIRxContentDialog.Title);

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
    public partial class RxContentDialog : RxContentDialog<ContentDialog>
    {
        public RxContentDialog()
        {

        }

        public RxContentDialog(Action<ContentDialog?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxContentDialogExtensions
    {
        public static T CloseButtonCommand<T>(this T contentdialog, ICommand closeButtonCommand) where T : IRxContentDialog
        {
            contentdialog.CloseButtonCommand = new PropertyValue<ICommand>(closeButtonCommand);
            return contentdialog;
        }
        public static T CloseButtonCommand<T>(this T contentdialog, Func<ICommand> closeButtonCommandFunc) where T : IRxContentDialog
        {
            contentdialog.CloseButtonCommand = new PropertyValue<ICommand>(closeButtonCommandFunc);
            return contentdialog;
        }
        public static T CloseButtonCommand<T>(this T contentdialog, Action action) where T : IRxContentDialog
        {
            contentdialog.CloseButtonCommand = new PropertyValue<ICommand>(new ActionCommand(action));
            return contentdialog;
        }
        public static T CloseButtonCommandParameter<T>(this T contentdialog, object closeButtonCommandParameter) where T : IRxContentDialog
        {
            contentdialog.CloseButtonCommandParameter = new PropertyValue<object>(closeButtonCommandParameter);
            return contentdialog;
        }
        public static T CloseButtonCommandParameter<T>(this T contentdialog, Func<object> closeButtonCommandParameterFunc) where T : IRxContentDialog
        {
            contentdialog.CloseButtonCommandParameter = new PropertyValue<object>(closeButtonCommandParameterFunc);
            return contentdialog;
        }
        public static T CloseButtonStyle<T>(this T contentdialog, Style closeButtonStyle) where T : IRxContentDialog
        {
            contentdialog.CloseButtonStyle = new PropertyValue<Style>(closeButtonStyle);
            return contentdialog;
        }
        public static T CloseButtonStyle<T>(this T contentdialog, Func<Style> closeButtonStyleFunc) where T : IRxContentDialog
        {
            contentdialog.CloseButtonStyle = new PropertyValue<Style>(closeButtonStyleFunc);
            return contentdialog;
        }
        public static T CloseButtonText<T>(this T contentdialog, string closeButtonText) where T : IRxContentDialog
        {
            contentdialog.CloseButtonText = new PropertyValue<string>(closeButtonText);
            return contentdialog;
        }
        public static T CloseButtonText<T>(this T contentdialog, Func<string> closeButtonTextFunc) where T : IRxContentDialog
        {
            contentdialog.CloseButtonText = new PropertyValue<string>(closeButtonTextFunc);
            return contentdialog;
        }
        public static T CornerRadius<T>(this T contentdialog, CornerRadius cornerRadius) where T : IRxContentDialog
        {
            contentdialog.CornerRadius = new PropertyValue<CornerRadius>(cornerRadius);
            return contentdialog;
        }
        public static T CornerRadius<T>(this T contentdialog, Func<CornerRadius> cornerRadiusFunc) where T : IRxContentDialog
        {
            contentdialog.CornerRadius = new PropertyValue<CornerRadius>(cornerRadiusFunc);
            return contentdialog;
        }
        public static T DefaultButton<T>(this T contentdialog, ContentDialogButton defaultButton) where T : IRxContentDialog
        {
            contentdialog.DefaultButton = new PropertyValue<ContentDialogButton>(defaultButton);
            return contentdialog;
        }
        public static T DefaultButton<T>(this T contentdialog, Func<ContentDialogButton> defaultButtonFunc) where T : IRxContentDialog
        {
            contentdialog.DefaultButton = new PropertyValue<ContentDialogButton>(defaultButtonFunc);
            return contentdialog;
        }
        public static T FullSizeDesired<T>(this T contentdialog, bool fullSizeDesired) where T : IRxContentDialog
        {
            contentdialog.FullSizeDesired = new PropertyValue<bool>(fullSizeDesired);
            return contentdialog;
        }
        public static T FullSizeDesired<T>(this T contentdialog, Func<bool> fullSizeDesiredFunc) where T : IRxContentDialog
        {
            contentdialog.FullSizeDesired = new PropertyValue<bool>(fullSizeDesiredFunc);
            return contentdialog;
        }
        public static T IsPrimaryButtonEnabled<T>(this T contentdialog, bool isPrimaryButtonEnabled) where T : IRxContentDialog
        {
            contentdialog.IsPrimaryButtonEnabled = new PropertyValue<bool>(isPrimaryButtonEnabled);
            return contentdialog;
        }
        public static T IsPrimaryButtonEnabled<T>(this T contentdialog, Func<bool> isPrimaryButtonEnabledFunc) where T : IRxContentDialog
        {
            contentdialog.IsPrimaryButtonEnabled = new PropertyValue<bool>(isPrimaryButtonEnabledFunc);
            return contentdialog;
        }
        public static T IsSecondaryButtonEnabled<T>(this T contentdialog, bool isSecondaryButtonEnabled) where T : IRxContentDialog
        {
            contentdialog.IsSecondaryButtonEnabled = new PropertyValue<bool>(isSecondaryButtonEnabled);
            return contentdialog;
        }
        public static T IsSecondaryButtonEnabled<T>(this T contentdialog, Func<bool> isSecondaryButtonEnabledFunc) where T : IRxContentDialog
        {
            contentdialog.IsSecondaryButtonEnabled = new PropertyValue<bool>(isSecondaryButtonEnabledFunc);
            return contentdialog;
        }
        public static T IsShadowEnabled<T>(this T contentdialog, bool isShadowEnabled) where T : IRxContentDialog
        {
            contentdialog.IsShadowEnabled = new PropertyValue<bool>(isShadowEnabled);
            return contentdialog;
        }
        public static T IsShadowEnabled<T>(this T contentdialog, Func<bool> isShadowEnabledFunc) where T : IRxContentDialog
        {
            contentdialog.IsShadowEnabled = new PropertyValue<bool>(isShadowEnabledFunc);
            return contentdialog;
        }
        public static T PrimaryButtonCommand<T>(this T contentdialog, ICommand primaryButtonCommand) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonCommand = new PropertyValue<ICommand>(primaryButtonCommand);
            return contentdialog;
        }
        public static T PrimaryButtonCommand<T>(this T contentdialog, Func<ICommand> primaryButtonCommandFunc) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonCommand = new PropertyValue<ICommand>(primaryButtonCommandFunc);
            return contentdialog;
        }
        public static T PrimaryButtonCommand<T>(this T contentdialog, Action action) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonCommand = new PropertyValue<ICommand>(new ActionCommand(action));
            return contentdialog;
        }
        public static T PrimaryButtonCommandParameter<T>(this T contentdialog, object primaryButtonCommandParameter) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonCommandParameter = new PropertyValue<object>(primaryButtonCommandParameter);
            return contentdialog;
        }
        public static T PrimaryButtonCommandParameter<T>(this T contentdialog, Func<object> primaryButtonCommandParameterFunc) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonCommandParameter = new PropertyValue<object>(primaryButtonCommandParameterFunc);
            return contentdialog;
        }
        public static T PrimaryButtonStyle<T>(this T contentdialog, Style primaryButtonStyle) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonStyle = new PropertyValue<Style>(primaryButtonStyle);
            return contentdialog;
        }
        public static T PrimaryButtonStyle<T>(this T contentdialog, Func<Style> primaryButtonStyleFunc) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonStyle = new PropertyValue<Style>(primaryButtonStyleFunc);
            return contentdialog;
        }
        public static T PrimaryButtonText<T>(this T contentdialog, string primaryButtonText) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonText = new PropertyValue<string>(primaryButtonText);
            return contentdialog;
        }
        public static T PrimaryButtonText<T>(this T contentdialog, Func<string> primaryButtonTextFunc) where T : IRxContentDialog
        {
            contentdialog.PrimaryButtonText = new PropertyValue<string>(primaryButtonTextFunc);
            return contentdialog;
        }
        public static T SecondaryButtonCommand<T>(this T contentdialog, ICommand secondaryButtonCommand) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonCommand = new PropertyValue<ICommand>(secondaryButtonCommand);
            return contentdialog;
        }
        public static T SecondaryButtonCommand<T>(this T contentdialog, Func<ICommand> secondaryButtonCommandFunc) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonCommand = new PropertyValue<ICommand>(secondaryButtonCommandFunc);
            return contentdialog;
        }
        public static T SecondaryButtonCommand<T>(this T contentdialog, Action action) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonCommand = new PropertyValue<ICommand>(new ActionCommand(action));
            return contentdialog;
        }
        public static T SecondaryButtonCommandParameter<T>(this T contentdialog, object secondaryButtonCommandParameter) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonCommandParameter = new PropertyValue<object>(secondaryButtonCommandParameter);
            return contentdialog;
        }
        public static T SecondaryButtonCommandParameter<T>(this T contentdialog, Func<object> secondaryButtonCommandParameterFunc) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonCommandParameter = new PropertyValue<object>(secondaryButtonCommandParameterFunc);
            return contentdialog;
        }
        public static T SecondaryButtonStyle<T>(this T contentdialog, Style secondaryButtonStyle) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonStyle = new PropertyValue<Style>(secondaryButtonStyle);
            return contentdialog;
        }
        public static T SecondaryButtonStyle<T>(this T contentdialog, Func<Style> secondaryButtonStyleFunc) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonStyle = new PropertyValue<Style>(secondaryButtonStyleFunc);
            return contentdialog;
        }
        public static T SecondaryButtonText<T>(this T contentdialog, string secondaryButtonText) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonText = new PropertyValue<string>(secondaryButtonText);
            return contentdialog;
        }
        public static T SecondaryButtonText<T>(this T contentdialog, Func<string> secondaryButtonTextFunc) where T : IRxContentDialog
        {
            contentdialog.SecondaryButtonText = new PropertyValue<string>(secondaryButtonTextFunc);
            return contentdialog;
        }
        public static T Title<T>(this T contentdialog, object title) where T : IRxContentDialog
        {
            contentdialog.Title = new PropertyValue<object>(title);
            return contentdialog;
        }
        public static T Title<T>(this T contentdialog, Func<object> titleFunc) where T : IRxContentDialog
        {
            contentdialog.Title = new PropertyValue<object>(titleFunc);
            return contentdialog;
        }
    }
}
