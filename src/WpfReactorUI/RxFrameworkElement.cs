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

namespace WpfReactorUI
{
    public partial interface IRxFrameworkElement : IRxUIElement
    {
        PropertyValue<BindingGroup> BindingGroup { get; set; }
        PropertyValue<ContextMenu> ContextMenu { get; set; }
        PropertyValue<Cursor> Cursor { get; set; }
        PropertyValue<object> DataContext { get; set; }
        PropertyValue<FlowDirection> FlowDirection { get; set; }
        PropertyValue<Style> FocusVisualStyle { get; set; }
        PropertyValue<bool> ForceCursor { get; set; }
        PropertyValue<double> Height { get; set; }
        PropertyValue<HorizontalAlignment> HorizontalAlignment { get; set; }
        PropertyValue<InputScope> InputScope { get; set; }
        PropertyValue<XmlLanguage> Language { get; set; }
        PropertyValue<Transform> LayoutTransform { get; set; }
        PropertyValue<Thickness> Margin { get; set; }
        PropertyValue<double> MaxHeight { get; set; }
        PropertyValue<double> MaxWidth { get; set; }
        PropertyValue<double> MinHeight { get; set; }
        PropertyValue<double> MinWidth { get; set; }
        PropertyValue<string> Name { get; set; }
        PropertyValue<bool> OverridesDefaultStyle { get; set; }
        PropertyValue<Style> Style { get; set; }
        PropertyValue<object> Tag { get; set; }
        PropertyValue<object> ToolTip { get; set; }
        PropertyValue<bool> UseLayoutRounding { get; set; }
        PropertyValue<VerticalAlignment> VerticalAlignment { get; set; }
        PropertyValue<double> Width { get; set; }

        Action ContextMenuClosingAction { get; set; }
        Action<ContextMenuEventArgs> ContextMenuClosingActionWithArgs { get; set; }
        Action ContextMenuOpeningAction { get; set; }
        Action<ContextMenuEventArgs> ContextMenuOpeningActionWithArgs { get; set; }
        Action LoadedAction { get; set; }
        Action<RoutedEventArgs> LoadedActionWithArgs { get; set; }
        Action RequestBringIntoViewAction { get; set; }
        Action<RequestBringIntoViewEventArgs> RequestBringIntoViewActionWithArgs { get; set; }
        Action SizeChangedAction { get; set; }
        Action<SizeChangedEventArgs> SizeChangedActionWithArgs { get; set; }
        Action ToolTipClosingAction { get; set; }
        Action<ToolTipEventArgs> ToolTipClosingActionWithArgs { get; set; }
        Action ToolTipOpeningAction { get; set; }
        Action<ToolTipEventArgs> ToolTipOpeningActionWithArgs { get; set; }
        Action UnloadedAction { get; set; }
        Action<RoutedEventArgs> UnloadedActionWithArgs { get; set; }
    }

    public partial class RxFrameworkElement<T> : RxUIElement<T>, IRxFrameworkElement where T : FrameworkElement, new()
    {
        public RxFrameworkElement()
        {

        }

        public RxFrameworkElement(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<BindingGroup> IRxFrameworkElement.BindingGroup { get; set; }
        PropertyValue<ContextMenu> IRxFrameworkElement.ContextMenu { get; set; }
        PropertyValue<Cursor> IRxFrameworkElement.Cursor { get; set; }
        PropertyValue<object> IRxFrameworkElement.DataContext { get; set; }
        PropertyValue<FlowDirection> IRxFrameworkElement.FlowDirection { get; set; }
        PropertyValue<Style> IRxFrameworkElement.FocusVisualStyle { get; set; }
        PropertyValue<bool> IRxFrameworkElement.ForceCursor { get; set; }
        PropertyValue<double> IRxFrameworkElement.Height { get; set; }
        PropertyValue<HorizontalAlignment> IRxFrameworkElement.HorizontalAlignment { get; set; }
        PropertyValue<InputScope> IRxFrameworkElement.InputScope { get; set; }
        PropertyValue<XmlLanguage> IRxFrameworkElement.Language { get; set; }
        PropertyValue<Transform> IRxFrameworkElement.LayoutTransform { get; set; }
        PropertyValue<Thickness> IRxFrameworkElement.Margin { get; set; }
        PropertyValue<double> IRxFrameworkElement.MaxHeight { get; set; }
        PropertyValue<double> IRxFrameworkElement.MaxWidth { get; set; }
        PropertyValue<double> IRxFrameworkElement.MinHeight { get; set; }
        PropertyValue<double> IRxFrameworkElement.MinWidth { get; set; }
        PropertyValue<string> IRxFrameworkElement.Name { get; set; }
        PropertyValue<bool> IRxFrameworkElement.OverridesDefaultStyle { get; set; }
        PropertyValue<Style> IRxFrameworkElement.Style { get; set; }
        PropertyValue<object> IRxFrameworkElement.Tag { get; set; }
        PropertyValue<object> IRxFrameworkElement.ToolTip { get; set; }
        PropertyValue<bool> IRxFrameworkElement.UseLayoutRounding { get; set; }
        PropertyValue<VerticalAlignment> IRxFrameworkElement.VerticalAlignment { get; set; }
        PropertyValue<double> IRxFrameworkElement.Width { get; set; }

        Action IRxFrameworkElement.ContextMenuClosingAction { get; set; }
        Action<ContextMenuEventArgs> IRxFrameworkElement.ContextMenuClosingActionWithArgs { get; set; }
        Action IRxFrameworkElement.ContextMenuOpeningAction { get; set; }
        Action<ContextMenuEventArgs> IRxFrameworkElement.ContextMenuOpeningActionWithArgs { get; set; }
        Action IRxFrameworkElement.LoadedAction { get; set; }
        Action<RoutedEventArgs> IRxFrameworkElement.LoadedActionWithArgs { get; set; }
        Action IRxFrameworkElement.RequestBringIntoViewAction { get; set; }
        Action<RequestBringIntoViewEventArgs> IRxFrameworkElement.RequestBringIntoViewActionWithArgs { get; set; }
        Action IRxFrameworkElement.SizeChangedAction { get; set; }
        Action<SizeChangedEventArgs> IRxFrameworkElement.SizeChangedActionWithArgs { get; set; }
        Action IRxFrameworkElement.ToolTipClosingAction { get; set; }
        Action<ToolTipEventArgs> IRxFrameworkElement.ToolTipClosingActionWithArgs { get; set; }
        Action IRxFrameworkElement.ToolTipOpeningAction { get; set; }
        Action<ToolTipEventArgs> IRxFrameworkElement.ToolTipOpeningActionWithArgs { get; set; }
        Action IRxFrameworkElement.UnloadedAction { get; set; }
        Action<RoutedEventArgs> IRxFrameworkElement.UnloadedActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            NativeControl.Set(FrameworkElement.BindingGroupProperty, thisAsIRxFrameworkElement.BindingGroup);
            NativeControl.Set(FrameworkElement.ContextMenuProperty, thisAsIRxFrameworkElement.ContextMenu);
            NativeControl.Set(FrameworkElement.CursorProperty, thisAsIRxFrameworkElement.Cursor);
            NativeControl.Set(FrameworkElement.DataContextProperty, thisAsIRxFrameworkElement.DataContext);
            NativeControl.Set(FrameworkElement.FlowDirectionProperty, thisAsIRxFrameworkElement.FlowDirection);
            NativeControl.Set(FrameworkElement.FocusVisualStyleProperty, thisAsIRxFrameworkElement.FocusVisualStyle);
            NativeControl.Set(FrameworkElement.ForceCursorProperty, thisAsIRxFrameworkElement.ForceCursor);
            NativeControl.Set(FrameworkElement.HeightProperty, thisAsIRxFrameworkElement.Height);
            NativeControl.Set(FrameworkElement.HorizontalAlignmentProperty, thisAsIRxFrameworkElement.HorizontalAlignment);
            NativeControl.Set(FrameworkElement.InputScopeProperty, thisAsIRxFrameworkElement.InputScope);
            NativeControl.Set(FrameworkElement.LanguageProperty, thisAsIRxFrameworkElement.Language);
            NativeControl.Set(FrameworkElement.LayoutTransformProperty, thisAsIRxFrameworkElement.LayoutTransform);
            NativeControl.Set(FrameworkElement.MarginProperty, thisAsIRxFrameworkElement.Margin);
            NativeControl.Set(FrameworkElement.MaxHeightProperty, thisAsIRxFrameworkElement.MaxHeight);
            NativeControl.Set(FrameworkElement.MaxWidthProperty, thisAsIRxFrameworkElement.MaxWidth);
            NativeControl.Set(FrameworkElement.MinHeightProperty, thisAsIRxFrameworkElement.MinHeight);
            NativeControl.Set(FrameworkElement.MinWidthProperty, thisAsIRxFrameworkElement.MinWidth);
            NativeControl.Set(FrameworkElement.NameProperty, thisAsIRxFrameworkElement.Name);
            NativeControl.Set(FrameworkElement.OverridesDefaultStyleProperty, thisAsIRxFrameworkElement.OverridesDefaultStyle);
            NativeControl.Set(FrameworkElement.StyleProperty, thisAsIRxFrameworkElement.Style);
            NativeControl.Set(FrameworkElement.TagProperty, thisAsIRxFrameworkElement.Tag);
            NativeControl.Set(FrameworkElement.ToolTipProperty, thisAsIRxFrameworkElement.ToolTip);
            NativeControl.Set(FrameworkElement.UseLayoutRoundingProperty, thisAsIRxFrameworkElement.UseLayoutRounding);
            NativeControl.Set(FrameworkElement.VerticalAlignmentProperty, thisAsIRxFrameworkElement.VerticalAlignment);
            NativeControl.Set(FrameworkElement.WidthProperty, thisAsIRxFrameworkElement.Width);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            if (thisAsIRxFrameworkElement.ContextMenuClosingAction != null || thisAsIRxFrameworkElement.ContextMenuClosingActionWithArgs != null)
            {
                NativeControl.ContextMenuClosing += NativeControl_ContextMenuClosing;
            }
            if (thisAsIRxFrameworkElement.ContextMenuOpeningAction != null || thisAsIRxFrameworkElement.ContextMenuOpeningActionWithArgs != null)
            {
                NativeControl.ContextMenuOpening += NativeControl_ContextMenuOpening;
            }
            if (thisAsIRxFrameworkElement.LoadedAction != null || thisAsIRxFrameworkElement.LoadedActionWithArgs != null)
            {
                NativeControl.Loaded += NativeControl_Loaded;
            }
            if (thisAsIRxFrameworkElement.RequestBringIntoViewAction != null || thisAsIRxFrameworkElement.RequestBringIntoViewActionWithArgs != null)
            {
                NativeControl.RequestBringIntoView += NativeControl_RequestBringIntoView;
            }
            if (thisAsIRxFrameworkElement.SizeChangedAction != null || thisAsIRxFrameworkElement.SizeChangedActionWithArgs != null)
            {
                NativeControl.SizeChanged += NativeControl_SizeChanged;
            }
            if (thisAsIRxFrameworkElement.ToolTipClosingAction != null || thisAsIRxFrameworkElement.ToolTipClosingActionWithArgs != null)
            {
                NativeControl.ToolTipClosing += NativeControl_ToolTipClosing;
            }
            if (thisAsIRxFrameworkElement.ToolTipOpeningAction != null || thisAsIRxFrameworkElement.ToolTipOpeningActionWithArgs != null)
            {
                NativeControl.ToolTipOpening += NativeControl_ToolTipOpening;
            }
            if (thisAsIRxFrameworkElement.UnloadedAction != null || thisAsIRxFrameworkElement.UnloadedActionWithArgs != null)
            {
                NativeControl.Unloaded += NativeControl_Unloaded;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.ContextMenuClosingAction?.Invoke();
            thisAsIRxFrameworkElement.ContextMenuClosingActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.ContextMenuOpeningAction?.Invoke();
            thisAsIRxFrameworkElement.ContextMenuOpeningActionWithArgs?.Invoke(e);
        }
        private void NativeControl_Loaded(object sender, RoutedEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.LoadedAction?.Invoke();
            thisAsIRxFrameworkElement.LoadedActionWithArgs?.Invoke(e);
        }
        private void NativeControl_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.RequestBringIntoViewAction?.Invoke();
            thisAsIRxFrameworkElement.RequestBringIntoViewActionWithArgs?.Invoke(e);
        }
        private void NativeControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.SizeChangedAction?.Invoke();
            thisAsIRxFrameworkElement.SizeChangedActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ToolTipClosing(object sender, ToolTipEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.ToolTipClosingAction?.Invoke();
            thisAsIRxFrameworkElement.ToolTipClosingActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.ToolTipOpeningAction?.Invoke();
            thisAsIRxFrameworkElement.ToolTipOpeningActionWithArgs?.Invoke(e);
        }
        private void NativeControl_Unloaded(object sender, RoutedEventArgs e)
        {
            var thisAsIRxFrameworkElement = (IRxFrameworkElement)this;
            thisAsIRxFrameworkElement.UnloadedAction?.Invoke();
            thisAsIRxFrameworkElement.UnloadedActionWithArgs?.Invoke(e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.ContextMenuClosing -= NativeControl_ContextMenuClosing;
                NativeControl.ContextMenuOpening -= NativeControl_ContextMenuOpening;
                NativeControl.Loaded -= NativeControl_Loaded;
                NativeControl.RequestBringIntoView -= NativeControl_RequestBringIntoView;
                NativeControl.SizeChanged -= NativeControl_SizeChanged;
                NativeControl.ToolTipClosing -= NativeControl_ToolTipClosing;
                NativeControl.ToolTipOpening -= NativeControl_ToolTipOpening;
                NativeControl.Unloaded -= NativeControl_Unloaded;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxFrameworkElement : RxFrameworkElement<FrameworkElement>
    {
        public RxFrameworkElement()
        {

        }

        public RxFrameworkElement(Action<FrameworkElement> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxFrameworkElementExtensions
    {
        public static T BindingGroup<T>(this T frameworkelement, BindingGroup bindingGroup) where T : IRxFrameworkElement
        {
            frameworkelement.BindingGroup = new PropertyValue<BindingGroup>(bindingGroup);
            return frameworkelement;
        }
        public static T ContextMenu<T>(this T frameworkelement, ContextMenu contextMenu) where T : IRxFrameworkElement
        {
            frameworkelement.ContextMenu = new PropertyValue<ContextMenu>(contextMenu);
            return frameworkelement;
        }
        public static T Cursor<T>(this T frameworkelement, Cursor cursor) where T : IRxFrameworkElement
        {
            frameworkelement.Cursor = new PropertyValue<Cursor>(cursor);
            return frameworkelement;
        }
        public static T DataContext<T>(this T frameworkelement, object dataContext) where T : IRxFrameworkElement
        {
            frameworkelement.DataContext = new PropertyValue<object>(dataContext);
            return frameworkelement;
        }
        public static T FlowDirection<T>(this T frameworkelement, FlowDirection flowDirection) where T : IRxFrameworkElement
        {
            frameworkelement.FlowDirection = new PropertyValue<FlowDirection>(flowDirection);
            return frameworkelement;
        }
        public static T FocusVisualStyle<T>(this T frameworkelement, Style focusVisualStyle) where T : IRxFrameworkElement
        {
            frameworkelement.FocusVisualStyle = new PropertyValue<Style>(focusVisualStyle);
            return frameworkelement;
        }
        public static T ForceCursor<T>(this T frameworkelement, bool forceCursor) where T : IRxFrameworkElement
        {
            frameworkelement.ForceCursor = new PropertyValue<bool>(forceCursor);
            return frameworkelement;
        }
        public static T Height<T>(this T frameworkelement, double height) where T : IRxFrameworkElement
        {
            frameworkelement.Height = new PropertyValue<double>(height);
            return frameworkelement;
        }
        public static T HorizontalAlignment<T>(this T frameworkelement, HorizontalAlignment horizontalAlignment) where T : IRxFrameworkElement
        {
            frameworkelement.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(horizontalAlignment);
            return frameworkelement;
        }
        public static T InputScope<T>(this T frameworkelement, InputScope inputScope) where T : IRxFrameworkElement
        {
            frameworkelement.InputScope = new PropertyValue<InputScope>(inputScope);
            return frameworkelement;
        }
        public static T Language<T>(this T frameworkelement, XmlLanguage language) where T : IRxFrameworkElement
        {
            frameworkelement.Language = new PropertyValue<XmlLanguage>(language);
            return frameworkelement;
        }
        public static T LayoutTransform<T>(this T frameworkelement, Transform layoutTransform) where T : IRxFrameworkElement
        {
            frameworkelement.LayoutTransform = new PropertyValue<Transform>(layoutTransform);
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, Thickness margin) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(margin);
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, double leftRight, double topBottom) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(new Thickness(leftRight, topBottom, leftRight, topBottom));
            return frameworkelement;
        }
        public static T Margin<T>(this T frameworkelement, double uniformSize) where T : IRxFrameworkElement
        {
            frameworkelement.Margin = new PropertyValue<Thickness>(new Thickness(uniformSize));
            return frameworkelement;
        }
        public static T MaxHeight<T>(this T frameworkelement, double maxHeight) where T : IRxFrameworkElement
        {
            frameworkelement.MaxHeight = new PropertyValue<double>(maxHeight);
            return frameworkelement;
        }
        public static T MaxWidth<T>(this T frameworkelement, double maxWidth) where T : IRxFrameworkElement
        {
            frameworkelement.MaxWidth = new PropertyValue<double>(maxWidth);
            return frameworkelement;
        }
        public static T MinHeight<T>(this T frameworkelement, double minHeight) where T : IRxFrameworkElement
        {
            frameworkelement.MinHeight = new PropertyValue<double>(minHeight);
            return frameworkelement;
        }
        public static T MinWidth<T>(this T frameworkelement, double minWidth) where T : IRxFrameworkElement
        {
            frameworkelement.MinWidth = new PropertyValue<double>(minWidth);
            return frameworkelement;
        }
        public static T Name<T>(this T frameworkelement, string name) where T : IRxFrameworkElement
        {
            frameworkelement.Name = new PropertyValue<string>(name);
            return frameworkelement;
        }
        public static T OverridesDefaultStyle<T>(this T frameworkelement, bool overridesDefaultStyle) where T : IRxFrameworkElement
        {
            frameworkelement.OverridesDefaultStyle = new PropertyValue<bool>(overridesDefaultStyle);
            return frameworkelement;
        }
        public static T Style<T>(this T frameworkelement, Style style) where T : IRxFrameworkElement
        {
            frameworkelement.Style = new PropertyValue<Style>(style);
            return frameworkelement;
        }
        public static T Tag<T>(this T frameworkelement, object tag) where T : IRxFrameworkElement
        {
            frameworkelement.Tag = new PropertyValue<object>(tag);
            return frameworkelement;
        }
        public static T ToolTip<T>(this T frameworkelement, object toolTip) where T : IRxFrameworkElement
        {
            frameworkelement.ToolTip = new PropertyValue<object>(toolTip);
            return frameworkelement;
        }
        public static T UseLayoutRounding<T>(this T frameworkelement, bool useLayoutRounding) where T : IRxFrameworkElement
        {
            frameworkelement.UseLayoutRounding = new PropertyValue<bool>(useLayoutRounding);
            return frameworkelement;
        }
        public static T VerticalAlignment<T>(this T frameworkelement, VerticalAlignment verticalAlignment) where T : IRxFrameworkElement
        {
            frameworkelement.VerticalAlignment = new PropertyValue<VerticalAlignment>(verticalAlignment);
            return frameworkelement;
        }
        public static T Width<T>(this T frameworkelement, double width) where T : IRxFrameworkElement
        {
            frameworkelement.Width = new PropertyValue<double>(width);
            return frameworkelement;
        }
        public static T OnContextMenuClosing<T>(this T frameworkelement, Action contextmenuclosingAction) where T : IRxFrameworkElement
        {
            frameworkelement.ContextMenuClosingAction = contextmenuclosingAction;
            return frameworkelement;
        }

        public static T OnContextMenuClosing<T>(this T frameworkelement, Action<ContextMenuEventArgs> contextmenuclosingActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.ContextMenuClosingActionWithArgs = contextmenuclosingActionWithArgs;
            return frameworkelement;
        }
        public static T OnContextMenuOpening<T>(this T frameworkelement, Action contextmenuopeningAction) where T : IRxFrameworkElement
        {
            frameworkelement.ContextMenuOpeningAction = contextmenuopeningAction;
            return frameworkelement;
        }

        public static T OnContextMenuOpening<T>(this T frameworkelement, Action<ContextMenuEventArgs> contextmenuopeningActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.ContextMenuOpeningActionWithArgs = contextmenuopeningActionWithArgs;
            return frameworkelement;
        }
        public static T OnLoaded<T>(this T frameworkelement, Action loadedAction) where T : IRxFrameworkElement
        {
            frameworkelement.LoadedAction = loadedAction;
            return frameworkelement;
        }

        public static T OnLoaded<T>(this T frameworkelement, Action<RoutedEventArgs> loadedActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.LoadedActionWithArgs = loadedActionWithArgs;
            return frameworkelement;
        }
        public static T OnRequestBringIntoView<T>(this T frameworkelement, Action requestbringintoviewAction) where T : IRxFrameworkElement
        {
            frameworkelement.RequestBringIntoViewAction = requestbringintoviewAction;
            return frameworkelement;
        }

        public static T OnRequestBringIntoView<T>(this T frameworkelement, Action<RequestBringIntoViewEventArgs> requestbringintoviewActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.RequestBringIntoViewActionWithArgs = requestbringintoviewActionWithArgs;
            return frameworkelement;
        }
        public static T OnSizeChanged<T>(this T frameworkelement, Action sizechangedAction) where T : IRxFrameworkElement
        {
            frameworkelement.SizeChangedAction = sizechangedAction;
            return frameworkelement;
        }

        public static T OnSizeChanged<T>(this T frameworkelement, Action<SizeChangedEventArgs> sizechangedActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.SizeChangedActionWithArgs = sizechangedActionWithArgs;
            return frameworkelement;
        }
        public static T OnToolTipClosing<T>(this T frameworkelement, Action tooltipclosingAction) where T : IRxFrameworkElement
        {
            frameworkelement.ToolTipClosingAction = tooltipclosingAction;
            return frameworkelement;
        }

        public static T OnToolTipClosing<T>(this T frameworkelement, Action<ToolTipEventArgs> tooltipclosingActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.ToolTipClosingActionWithArgs = tooltipclosingActionWithArgs;
            return frameworkelement;
        }
        public static T OnToolTipOpening<T>(this T frameworkelement, Action tooltipopeningAction) where T : IRxFrameworkElement
        {
            frameworkelement.ToolTipOpeningAction = tooltipopeningAction;
            return frameworkelement;
        }

        public static T OnToolTipOpening<T>(this T frameworkelement, Action<ToolTipEventArgs> tooltipopeningActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.ToolTipOpeningActionWithArgs = tooltipopeningActionWithArgs;
            return frameworkelement;
        }
        public static T OnUnloaded<T>(this T frameworkelement, Action unloadedAction) where T : IRxFrameworkElement
        {
            frameworkelement.UnloadedAction = unloadedAction;
            return frameworkelement;
        }

        public static T OnUnloaded<T>(this T frameworkelement, Action<RoutedEventArgs> unloadedActionWithArgs) where T : IRxFrameworkElement
        {
            frameworkelement.UnloadedActionWithArgs = unloadedActionWithArgs;
            return frameworkelement;
        }
    }
}