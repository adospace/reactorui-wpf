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
    public partial interface IRxUIElement : IRxVisual
    {
        PropertyValue<bool> AllowDrop { get; set; }
        PropertyValue<CacheMode> CacheMode { get; set; }
        PropertyValue<Geometry> Clip { get; set; }
        PropertyValue<bool> ClipToBounds { get; set; }
        PropertyValue<Effect> Effect { get; set; }
        PropertyValue<bool> Focusable { get; set; }
        PropertyValue<bool> IsEnabled { get; set; }
        PropertyValue<bool> IsHitTestVisible { get; set; }
        PropertyValue<bool> IsManipulationEnabled { get; set; }
        PropertyValue<double> Opacity { get; set; }
        PropertyValue<Brush> OpacityMask { get; set; }
        PropertyValue<Transform> RenderTransform { get; set; }
        PropertyValue<Point> RenderTransformOrigin { get; set; }
        PropertyValue<bool> SnapsToDevicePixels { get; set; }
        PropertyValue<string> Uid { get; set; }
        PropertyValue<Visibility> Visibility { get; set; }

        Action DragEnterAction { get; set; }
        Action<DragEventArgs> DragEnterActionWithArgs { get; set; }
        Action DragLeaveAction { get; set; }
        Action<DragEventArgs> DragLeaveActionWithArgs { get; set; }
        Action DragOverAction { get; set; }
        Action<DragEventArgs> DragOverActionWithArgs { get; set; }
        Action DropAction { get; set; }
        Action<DragEventArgs> DropActionWithArgs { get; set; }
        Action GiveFeedbackAction { get; set; }
        Action<GiveFeedbackEventArgs> GiveFeedbackActionWithArgs { get; set; }
        Action GotFocusAction { get; set; }
        Action<RoutedEventArgs> GotFocusActionWithArgs { get; set; }
        Action GotKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> GotKeyboardFocusActionWithArgs { get; set; }
        Action GotMouseCaptureAction { get; set; }
        Action<MouseEventArgs> GotMouseCaptureActionWithArgs { get; set; }
        Action GotStylusCaptureAction { get; set; }
        Action<StylusEventArgs> GotStylusCaptureActionWithArgs { get; set; }
        Action GotTouchCaptureAction { get; set; }
        Action<TouchEventArgs> GotTouchCaptureActionWithArgs { get; set; }
        Action KeyDownAction { get; set; }
        Action<KeyEventArgs> KeyDownActionWithArgs { get; set; }
        Action KeyUpAction { get; set; }
        Action<KeyEventArgs> KeyUpActionWithArgs { get; set; }
        Action LostFocusAction { get; set; }
        Action<RoutedEventArgs> LostFocusActionWithArgs { get; set; }
        Action LostKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> LostKeyboardFocusActionWithArgs { get; set; }
        Action LostMouseCaptureAction { get; set; }
        Action<MouseEventArgs> LostMouseCaptureActionWithArgs { get; set; }
        Action LostStylusCaptureAction { get; set; }
        Action<StylusEventArgs> LostStylusCaptureActionWithArgs { get; set; }
        Action LostTouchCaptureAction { get; set; }
        Action<TouchEventArgs> LostTouchCaptureActionWithArgs { get; set; }
        Action ManipulationBoundaryFeedbackAction { get; set; }
        Action<ManipulationBoundaryFeedbackEventArgs> ManipulationBoundaryFeedbackActionWithArgs { get; set; }
        Action ManipulationCompletedAction { get; set; }
        Action<ManipulationCompletedEventArgs> ManipulationCompletedActionWithArgs { get; set; }
        Action ManipulationDeltaAction { get; set; }
        Action<ManipulationDeltaEventArgs> ManipulationDeltaActionWithArgs { get; set; }
        Action ManipulationInertiaStartingAction { get; set; }
        Action<ManipulationInertiaStartingEventArgs> ManipulationInertiaStartingActionWithArgs { get; set; }
        Action ManipulationStartedAction { get; set; }
        Action<ManipulationStartedEventArgs> ManipulationStartedActionWithArgs { get; set; }
        Action ManipulationStartingAction { get; set; }
        Action<ManipulationStartingEventArgs> ManipulationStartingActionWithArgs { get; set; }
        Action MouseDownAction { get; set; }
        Action<MouseButtonEventArgs> MouseDownActionWithArgs { get; set; }
        Action MouseEnterAction { get; set; }
        Action<MouseEventArgs> MouseEnterActionWithArgs { get; set; }
        Action MouseLeaveAction { get; set; }
        Action<MouseEventArgs> MouseLeaveActionWithArgs { get; set; }
        Action MouseLeftButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> MouseLeftButtonDownActionWithArgs { get; set; }
        Action MouseLeftButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> MouseLeftButtonUpActionWithArgs { get; set; }
        Action MouseMoveAction { get; set; }
        Action<MouseEventArgs> MouseMoveActionWithArgs { get; set; }
        Action MouseRightButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> MouseRightButtonDownActionWithArgs { get; set; }
        Action MouseRightButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> MouseRightButtonUpActionWithArgs { get; set; }
        Action MouseUpAction { get; set; }
        Action<MouseButtonEventArgs> MouseUpActionWithArgs { get; set; }
        Action MouseWheelAction { get; set; }
        Action<MouseWheelEventArgs> MouseWheelActionWithArgs { get; set; }
        Action PreviewDragEnterAction { get; set; }
        Action<DragEventArgs> PreviewDragEnterActionWithArgs { get; set; }
        Action PreviewDragLeaveAction { get; set; }
        Action<DragEventArgs> PreviewDragLeaveActionWithArgs { get; set; }
        Action PreviewDragOverAction { get; set; }
        Action<DragEventArgs> PreviewDragOverActionWithArgs { get; set; }
        Action PreviewDropAction { get; set; }
        Action<DragEventArgs> PreviewDropActionWithArgs { get; set; }
        Action PreviewGiveFeedbackAction { get; set; }
        Action<GiveFeedbackEventArgs> PreviewGiveFeedbackActionWithArgs { get; set; }
        Action PreviewGotKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> PreviewGotKeyboardFocusActionWithArgs { get; set; }
        Action PreviewKeyDownAction { get; set; }
        Action<KeyEventArgs> PreviewKeyDownActionWithArgs { get; set; }
        Action PreviewKeyUpAction { get; set; }
        Action<KeyEventArgs> PreviewKeyUpActionWithArgs { get; set; }
        Action PreviewLostKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> PreviewLostKeyboardFocusActionWithArgs { get; set; }
        Action PreviewMouseDownAction { get; set; }
        Action<MouseButtonEventArgs> PreviewMouseDownActionWithArgs { get; set; }
        Action PreviewMouseLeftButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> PreviewMouseLeftButtonDownActionWithArgs { get; set; }
        Action PreviewMouseLeftButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> PreviewMouseLeftButtonUpActionWithArgs { get; set; }
        Action PreviewMouseMoveAction { get; set; }
        Action<MouseEventArgs> PreviewMouseMoveActionWithArgs { get; set; }
        Action PreviewMouseRightButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> PreviewMouseRightButtonDownActionWithArgs { get; set; }
        Action PreviewMouseRightButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> PreviewMouseRightButtonUpActionWithArgs { get; set; }
        Action PreviewMouseUpAction { get; set; }
        Action<MouseButtonEventArgs> PreviewMouseUpActionWithArgs { get; set; }
        Action PreviewMouseWheelAction { get; set; }
        Action<MouseWheelEventArgs> PreviewMouseWheelActionWithArgs { get; set; }
        Action PreviewQueryContinueDragAction { get; set; }
        Action<QueryContinueDragEventArgs> PreviewQueryContinueDragActionWithArgs { get; set; }
        Action PreviewStylusButtonDownAction { get; set; }
        Action<StylusButtonEventArgs> PreviewStylusButtonDownActionWithArgs { get; set; }
        Action PreviewStylusButtonUpAction { get; set; }
        Action<StylusButtonEventArgs> PreviewStylusButtonUpActionWithArgs { get; set; }
        Action PreviewStylusDownAction { get; set; }
        Action<StylusDownEventArgs> PreviewStylusDownActionWithArgs { get; set; }
        Action PreviewStylusInAirMoveAction { get; set; }
        Action<StylusEventArgs> PreviewStylusInAirMoveActionWithArgs { get; set; }
        Action PreviewStylusInRangeAction { get; set; }
        Action<StylusEventArgs> PreviewStylusInRangeActionWithArgs { get; set; }
        Action PreviewStylusMoveAction { get; set; }
        Action<StylusEventArgs> PreviewStylusMoveActionWithArgs { get; set; }
        Action PreviewStylusOutOfRangeAction { get; set; }
        Action<StylusEventArgs> PreviewStylusOutOfRangeActionWithArgs { get; set; }
        Action PreviewStylusSystemGestureAction { get; set; }
        Action<StylusSystemGestureEventArgs> PreviewStylusSystemGestureActionWithArgs { get; set; }
        Action PreviewStylusUpAction { get; set; }
        Action<StylusEventArgs> PreviewStylusUpActionWithArgs { get; set; }
        Action PreviewTextInputAction { get; set; }
        Action<TextCompositionEventArgs> PreviewTextInputActionWithArgs { get; set; }
        Action PreviewTouchDownAction { get; set; }
        Action<TouchEventArgs> PreviewTouchDownActionWithArgs { get; set; }
        Action PreviewTouchMoveAction { get; set; }
        Action<TouchEventArgs> PreviewTouchMoveActionWithArgs { get; set; }
        Action PreviewTouchUpAction { get; set; }
        Action<TouchEventArgs> PreviewTouchUpActionWithArgs { get; set; }
        Action QueryContinueDragAction { get; set; }
        Action<QueryContinueDragEventArgs> QueryContinueDragActionWithArgs { get; set; }
        Action QueryCursorAction { get; set; }
        Action<QueryCursorEventArgs> QueryCursorActionWithArgs { get; set; }
        Action StylusButtonDownAction { get; set; }
        Action<StylusButtonEventArgs> StylusButtonDownActionWithArgs { get; set; }
        Action StylusButtonUpAction { get; set; }
        Action<StylusButtonEventArgs> StylusButtonUpActionWithArgs { get; set; }
        Action StylusDownAction { get; set; }
        Action<StylusDownEventArgs> StylusDownActionWithArgs { get; set; }
        Action StylusEnterAction { get; set; }
        Action<StylusEventArgs> StylusEnterActionWithArgs { get; set; }
        Action StylusInAirMoveAction { get; set; }
        Action<StylusEventArgs> StylusInAirMoveActionWithArgs { get; set; }
        Action StylusInRangeAction { get; set; }
        Action<StylusEventArgs> StylusInRangeActionWithArgs { get; set; }
        Action StylusLeaveAction { get; set; }
        Action<StylusEventArgs> StylusLeaveActionWithArgs { get; set; }
        Action StylusMoveAction { get; set; }
        Action<StylusEventArgs> StylusMoveActionWithArgs { get; set; }
        Action StylusOutOfRangeAction { get; set; }
        Action<StylusEventArgs> StylusOutOfRangeActionWithArgs { get; set; }
        Action StylusSystemGestureAction { get; set; }
        Action<StylusSystemGestureEventArgs> StylusSystemGestureActionWithArgs { get; set; }
        Action StylusUpAction { get; set; }
        Action<StylusEventArgs> StylusUpActionWithArgs { get; set; }
        Action TextInputAction { get; set; }
        Action<TextCompositionEventArgs> TextInputActionWithArgs { get; set; }
        Action TouchDownAction { get; set; }
        Action<TouchEventArgs> TouchDownActionWithArgs { get; set; }
        Action TouchEnterAction { get; set; }
        Action<TouchEventArgs> TouchEnterActionWithArgs { get; set; }
        Action TouchLeaveAction { get; set; }
        Action<TouchEventArgs> TouchLeaveActionWithArgs { get; set; }
        Action TouchMoveAction { get; set; }
        Action<TouchEventArgs> TouchMoveActionWithArgs { get; set; }
        Action TouchUpAction { get; set; }
        Action<TouchEventArgs> TouchUpActionWithArgs { get; set; }
    }

    public partial class RxUIElement<T> : RxVisual<T>, IRxUIElement where T : UIElement, new()
    {
        public RxUIElement()
        {

        }

        public RxUIElement(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool> IRxUIElement.AllowDrop { get; set; }
        PropertyValue<CacheMode> IRxUIElement.CacheMode { get; set; }
        PropertyValue<Geometry> IRxUIElement.Clip { get; set; }
        PropertyValue<bool> IRxUIElement.ClipToBounds { get; set; }
        PropertyValue<Effect> IRxUIElement.Effect { get; set; }
        PropertyValue<bool> IRxUIElement.Focusable { get; set; }
        PropertyValue<bool> IRxUIElement.IsEnabled { get; set; }
        PropertyValue<bool> IRxUIElement.IsHitTestVisible { get; set; }
        PropertyValue<bool> IRxUIElement.IsManipulationEnabled { get; set; }
        PropertyValue<double> IRxUIElement.Opacity { get; set; }
        PropertyValue<Brush> IRxUIElement.OpacityMask { get; set; }
        PropertyValue<Transform> IRxUIElement.RenderTransform { get; set; }
        PropertyValue<Point> IRxUIElement.RenderTransformOrigin { get; set; }
        PropertyValue<bool> IRxUIElement.SnapsToDevicePixels { get; set; }
        PropertyValue<string> IRxUIElement.Uid { get; set; }
        PropertyValue<Visibility> IRxUIElement.Visibility { get; set; }

        Action IRxUIElement.DragEnterAction { get; set; }
        Action<DragEventArgs> IRxUIElement.DragEnterActionWithArgs { get; set; }
        Action IRxUIElement.DragLeaveAction { get; set; }
        Action<DragEventArgs> IRxUIElement.DragLeaveActionWithArgs { get; set; }
        Action IRxUIElement.DragOverAction { get; set; }
        Action<DragEventArgs> IRxUIElement.DragOverActionWithArgs { get; set; }
        Action IRxUIElement.DropAction { get; set; }
        Action<DragEventArgs> IRxUIElement.DropActionWithArgs { get; set; }
        Action IRxUIElement.GiveFeedbackAction { get; set; }
        Action<GiveFeedbackEventArgs> IRxUIElement.GiveFeedbackActionWithArgs { get; set; }
        Action IRxUIElement.GotFocusAction { get; set; }
        Action<RoutedEventArgs> IRxUIElement.GotFocusActionWithArgs { get; set; }
        Action IRxUIElement.GotKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> IRxUIElement.GotKeyboardFocusActionWithArgs { get; set; }
        Action IRxUIElement.GotMouseCaptureAction { get; set; }
        Action<MouseEventArgs> IRxUIElement.GotMouseCaptureActionWithArgs { get; set; }
        Action IRxUIElement.GotStylusCaptureAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.GotStylusCaptureActionWithArgs { get; set; }
        Action IRxUIElement.GotTouchCaptureAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.GotTouchCaptureActionWithArgs { get; set; }
        Action IRxUIElement.KeyDownAction { get; set; }
        Action<KeyEventArgs> IRxUIElement.KeyDownActionWithArgs { get; set; }
        Action IRxUIElement.KeyUpAction { get; set; }
        Action<KeyEventArgs> IRxUIElement.KeyUpActionWithArgs { get; set; }
        Action IRxUIElement.LostFocusAction { get; set; }
        Action<RoutedEventArgs> IRxUIElement.LostFocusActionWithArgs { get; set; }
        Action IRxUIElement.LostKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> IRxUIElement.LostKeyboardFocusActionWithArgs { get; set; }
        Action IRxUIElement.LostMouseCaptureAction { get; set; }
        Action<MouseEventArgs> IRxUIElement.LostMouseCaptureActionWithArgs { get; set; }
        Action IRxUIElement.LostStylusCaptureAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.LostStylusCaptureActionWithArgs { get; set; }
        Action IRxUIElement.LostTouchCaptureAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.LostTouchCaptureActionWithArgs { get; set; }
        Action IRxUIElement.ManipulationBoundaryFeedbackAction { get; set; }
        Action<ManipulationBoundaryFeedbackEventArgs> IRxUIElement.ManipulationBoundaryFeedbackActionWithArgs { get; set; }
        Action IRxUIElement.ManipulationCompletedAction { get; set; }
        Action<ManipulationCompletedEventArgs> IRxUIElement.ManipulationCompletedActionWithArgs { get; set; }
        Action IRxUIElement.ManipulationDeltaAction { get; set; }
        Action<ManipulationDeltaEventArgs> IRxUIElement.ManipulationDeltaActionWithArgs { get; set; }
        Action IRxUIElement.ManipulationInertiaStartingAction { get; set; }
        Action<ManipulationInertiaStartingEventArgs> IRxUIElement.ManipulationInertiaStartingActionWithArgs { get; set; }
        Action IRxUIElement.ManipulationStartedAction { get; set; }
        Action<ManipulationStartedEventArgs> IRxUIElement.ManipulationStartedActionWithArgs { get; set; }
        Action IRxUIElement.ManipulationStartingAction { get; set; }
        Action<ManipulationStartingEventArgs> IRxUIElement.ManipulationStartingActionWithArgs { get; set; }
        Action IRxUIElement.MouseDownAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.MouseDownActionWithArgs { get; set; }
        Action IRxUIElement.MouseEnterAction { get; set; }
        Action<MouseEventArgs> IRxUIElement.MouseEnterActionWithArgs { get; set; }
        Action IRxUIElement.MouseLeaveAction { get; set; }
        Action<MouseEventArgs> IRxUIElement.MouseLeaveActionWithArgs { get; set; }
        Action IRxUIElement.MouseLeftButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.MouseLeftButtonDownActionWithArgs { get; set; }
        Action IRxUIElement.MouseLeftButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.MouseLeftButtonUpActionWithArgs { get; set; }
        Action IRxUIElement.MouseMoveAction { get; set; }
        Action<MouseEventArgs> IRxUIElement.MouseMoveActionWithArgs { get; set; }
        Action IRxUIElement.MouseRightButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.MouseRightButtonDownActionWithArgs { get; set; }
        Action IRxUIElement.MouseRightButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.MouseRightButtonUpActionWithArgs { get; set; }
        Action IRxUIElement.MouseUpAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.MouseUpActionWithArgs { get; set; }
        Action IRxUIElement.MouseWheelAction { get; set; }
        Action<MouseWheelEventArgs> IRxUIElement.MouseWheelActionWithArgs { get; set; }
        Action IRxUIElement.PreviewDragEnterAction { get; set; }
        Action<DragEventArgs> IRxUIElement.PreviewDragEnterActionWithArgs { get; set; }
        Action IRxUIElement.PreviewDragLeaveAction { get; set; }
        Action<DragEventArgs> IRxUIElement.PreviewDragLeaveActionWithArgs { get; set; }
        Action IRxUIElement.PreviewDragOverAction { get; set; }
        Action<DragEventArgs> IRxUIElement.PreviewDragOverActionWithArgs { get; set; }
        Action IRxUIElement.PreviewDropAction { get; set; }
        Action<DragEventArgs> IRxUIElement.PreviewDropActionWithArgs { get; set; }
        Action IRxUIElement.PreviewGiveFeedbackAction { get; set; }
        Action<GiveFeedbackEventArgs> IRxUIElement.PreviewGiveFeedbackActionWithArgs { get; set; }
        Action IRxUIElement.PreviewGotKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> IRxUIElement.PreviewGotKeyboardFocusActionWithArgs { get; set; }
        Action IRxUIElement.PreviewKeyDownAction { get; set; }
        Action<KeyEventArgs> IRxUIElement.PreviewKeyDownActionWithArgs { get; set; }
        Action IRxUIElement.PreviewKeyUpAction { get; set; }
        Action<KeyEventArgs> IRxUIElement.PreviewKeyUpActionWithArgs { get; set; }
        Action IRxUIElement.PreviewLostKeyboardFocusAction { get; set; }
        Action<KeyboardFocusChangedEventArgs> IRxUIElement.PreviewLostKeyboardFocusActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseDownAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.PreviewMouseDownActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseLeftButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.PreviewMouseLeftButtonDownActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseLeftButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.PreviewMouseLeftButtonUpActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseMoveAction { get; set; }
        Action<MouseEventArgs> IRxUIElement.PreviewMouseMoveActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseRightButtonDownAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.PreviewMouseRightButtonDownActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseRightButtonUpAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.PreviewMouseRightButtonUpActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseUpAction { get; set; }
        Action<MouseButtonEventArgs> IRxUIElement.PreviewMouseUpActionWithArgs { get; set; }
        Action IRxUIElement.PreviewMouseWheelAction { get; set; }
        Action<MouseWheelEventArgs> IRxUIElement.PreviewMouseWheelActionWithArgs { get; set; }
        Action IRxUIElement.PreviewQueryContinueDragAction { get; set; }
        Action<QueryContinueDragEventArgs> IRxUIElement.PreviewQueryContinueDragActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusButtonDownAction { get; set; }
        Action<StylusButtonEventArgs> IRxUIElement.PreviewStylusButtonDownActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusButtonUpAction { get; set; }
        Action<StylusButtonEventArgs> IRxUIElement.PreviewStylusButtonUpActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusDownAction { get; set; }
        Action<StylusDownEventArgs> IRxUIElement.PreviewStylusDownActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusInAirMoveAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.PreviewStylusInAirMoveActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusInRangeAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.PreviewStylusInRangeActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusMoveAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.PreviewStylusMoveActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusOutOfRangeAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.PreviewStylusOutOfRangeActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusSystemGestureAction { get; set; }
        Action<StylusSystemGestureEventArgs> IRxUIElement.PreviewStylusSystemGestureActionWithArgs { get; set; }
        Action IRxUIElement.PreviewStylusUpAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.PreviewStylusUpActionWithArgs { get; set; }
        Action IRxUIElement.PreviewTextInputAction { get; set; }
        Action<TextCompositionEventArgs> IRxUIElement.PreviewTextInputActionWithArgs { get; set; }
        Action IRxUIElement.PreviewTouchDownAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.PreviewTouchDownActionWithArgs { get; set; }
        Action IRxUIElement.PreviewTouchMoveAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.PreviewTouchMoveActionWithArgs { get; set; }
        Action IRxUIElement.PreviewTouchUpAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.PreviewTouchUpActionWithArgs { get; set; }
        Action IRxUIElement.QueryContinueDragAction { get; set; }
        Action<QueryContinueDragEventArgs> IRxUIElement.QueryContinueDragActionWithArgs { get; set; }
        Action IRxUIElement.QueryCursorAction { get; set; }
        Action<QueryCursorEventArgs> IRxUIElement.QueryCursorActionWithArgs { get; set; }
        Action IRxUIElement.StylusButtonDownAction { get; set; }
        Action<StylusButtonEventArgs> IRxUIElement.StylusButtonDownActionWithArgs { get; set; }
        Action IRxUIElement.StylusButtonUpAction { get; set; }
        Action<StylusButtonEventArgs> IRxUIElement.StylusButtonUpActionWithArgs { get; set; }
        Action IRxUIElement.StylusDownAction { get; set; }
        Action<StylusDownEventArgs> IRxUIElement.StylusDownActionWithArgs { get; set; }
        Action IRxUIElement.StylusEnterAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.StylusEnterActionWithArgs { get; set; }
        Action IRxUIElement.StylusInAirMoveAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.StylusInAirMoveActionWithArgs { get; set; }
        Action IRxUIElement.StylusInRangeAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.StylusInRangeActionWithArgs { get; set; }
        Action IRxUIElement.StylusLeaveAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.StylusLeaveActionWithArgs { get; set; }
        Action IRxUIElement.StylusMoveAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.StylusMoveActionWithArgs { get; set; }
        Action IRxUIElement.StylusOutOfRangeAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.StylusOutOfRangeActionWithArgs { get; set; }
        Action IRxUIElement.StylusSystemGestureAction { get; set; }
        Action<StylusSystemGestureEventArgs> IRxUIElement.StylusSystemGestureActionWithArgs { get; set; }
        Action IRxUIElement.StylusUpAction { get; set; }
        Action<StylusEventArgs> IRxUIElement.StylusUpActionWithArgs { get; set; }
        Action IRxUIElement.TextInputAction { get; set; }
        Action<TextCompositionEventArgs> IRxUIElement.TextInputActionWithArgs { get; set; }
        Action IRxUIElement.TouchDownAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.TouchDownActionWithArgs { get; set; }
        Action IRxUIElement.TouchEnterAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.TouchEnterActionWithArgs { get; set; }
        Action IRxUIElement.TouchLeaveAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.TouchLeaveActionWithArgs { get; set; }
        Action IRxUIElement.TouchMoveAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.TouchMoveActionWithArgs { get; set; }
        Action IRxUIElement.TouchUpAction { get; set; }
        Action<TouchEventArgs> IRxUIElement.TouchUpActionWithArgs { get; set; }

        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxUIElement = (IRxUIElement)this;
            NativeControl.Set(UIElement.AllowDropProperty, thisAsIRxUIElement.AllowDrop);
            NativeControl.Set(UIElement.CacheModeProperty, thisAsIRxUIElement.CacheMode);
            NativeControl.Set(UIElement.ClipProperty, thisAsIRxUIElement.Clip);
            NativeControl.Set(UIElement.ClipToBoundsProperty, thisAsIRxUIElement.ClipToBounds);
            NativeControl.Set(UIElement.EffectProperty, thisAsIRxUIElement.Effect);
            NativeControl.Set(UIElement.FocusableProperty, thisAsIRxUIElement.Focusable);
            NativeControl.Set(UIElement.IsEnabledProperty, thisAsIRxUIElement.IsEnabled);
            NativeControl.Set(UIElement.IsHitTestVisibleProperty, thisAsIRxUIElement.IsHitTestVisible);
            NativeControl.Set(UIElement.IsManipulationEnabledProperty, thisAsIRxUIElement.IsManipulationEnabled);
            NativeControl.Set(UIElement.OpacityProperty, thisAsIRxUIElement.Opacity);
            NativeControl.Set(UIElement.OpacityMaskProperty, thisAsIRxUIElement.OpacityMask);
            NativeControl.Set(UIElement.RenderTransformProperty, thisAsIRxUIElement.RenderTransform);
            NativeControl.Set(UIElement.RenderTransformOriginProperty, thisAsIRxUIElement.RenderTransformOrigin);
            NativeControl.Set(UIElement.SnapsToDevicePixelsProperty, thisAsIRxUIElement.SnapsToDevicePixels);
            NativeControl.Set(UIElement.UidProperty, thisAsIRxUIElement.Uid);
            NativeControl.Set(UIElement.VisibilityProperty, thisAsIRxUIElement.Visibility);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            if (thisAsIRxUIElement.DragEnterAction != null || thisAsIRxUIElement.DragEnterActionWithArgs != null)
            {
                NativeControl.DragEnter += NativeControl_DragEnter;
            }
            if (thisAsIRxUIElement.DragLeaveAction != null || thisAsIRxUIElement.DragLeaveActionWithArgs != null)
            {
                NativeControl.DragLeave += NativeControl_DragLeave;
            }
            if (thisAsIRxUIElement.DragOverAction != null || thisAsIRxUIElement.DragOverActionWithArgs != null)
            {
                NativeControl.DragOver += NativeControl_DragOver;
            }
            if (thisAsIRxUIElement.DropAction != null || thisAsIRxUIElement.DropActionWithArgs != null)
            {
                NativeControl.Drop += NativeControl_Drop;
            }
            if (thisAsIRxUIElement.GiveFeedbackAction != null || thisAsIRxUIElement.GiveFeedbackActionWithArgs != null)
            {
                NativeControl.GiveFeedback += NativeControl_GiveFeedback;
            }
            if (thisAsIRxUIElement.GotFocusAction != null || thisAsIRxUIElement.GotFocusActionWithArgs != null)
            {
                NativeControl.GotFocus += NativeControl_GotFocus;
            }
            if (thisAsIRxUIElement.GotKeyboardFocusAction != null || thisAsIRxUIElement.GotKeyboardFocusActionWithArgs != null)
            {
                NativeControl.GotKeyboardFocus += NativeControl_GotKeyboardFocus;
            }
            if (thisAsIRxUIElement.GotMouseCaptureAction != null || thisAsIRxUIElement.GotMouseCaptureActionWithArgs != null)
            {
                NativeControl.GotMouseCapture += NativeControl_GotMouseCapture;
            }
            if (thisAsIRxUIElement.GotStylusCaptureAction != null || thisAsIRxUIElement.GotStylusCaptureActionWithArgs != null)
            {
                NativeControl.GotStylusCapture += NativeControl_GotStylusCapture;
            }
            if (thisAsIRxUIElement.GotTouchCaptureAction != null || thisAsIRxUIElement.GotTouchCaptureActionWithArgs != null)
            {
                NativeControl.GotTouchCapture += NativeControl_GotTouchCapture;
            }
            if (thisAsIRxUIElement.KeyDownAction != null || thisAsIRxUIElement.KeyDownActionWithArgs != null)
            {
                NativeControl.KeyDown += NativeControl_KeyDown;
            }
            if (thisAsIRxUIElement.KeyUpAction != null || thisAsIRxUIElement.KeyUpActionWithArgs != null)
            {
                NativeControl.KeyUp += NativeControl_KeyUp;
            }
            if (thisAsIRxUIElement.LostFocusAction != null || thisAsIRxUIElement.LostFocusActionWithArgs != null)
            {
                NativeControl.LostFocus += NativeControl_LostFocus;
            }
            if (thisAsIRxUIElement.LostKeyboardFocusAction != null || thisAsIRxUIElement.LostKeyboardFocusActionWithArgs != null)
            {
                NativeControl.LostKeyboardFocus += NativeControl_LostKeyboardFocus;
            }
            if (thisAsIRxUIElement.LostMouseCaptureAction != null || thisAsIRxUIElement.LostMouseCaptureActionWithArgs != null)
            {
                NativeControl.LostMouseCapture += NativeControl_LostMouseCapture;
            }
            if (thisAsIRxUIElement.LostStylusCaptureAction != null || thisAsIRxUIElement.LostStylusCaptureActionWithArgs != null)
            {
                NativeControl.LostStylusCapture += NativeControl_LostStylusCapture;
            }
            if (thisAsIRxUIElement.LostTouchCaptureAction != null || thisAsIRxUIElement.LostTouchCaptureActionWithArgs != null)
            {
                NativeControl.LostTouchCapture += NativeControl_LostTouchCapture;
            }
            if (thisAsIRxUIElement.ManipulationBoundaryFeedbackAction != null || thisAsIRxUIElement.ManipulationBoundaryFeedbackActionWithArgs != null)
            {
                NativeControl.ManipulationBoundaryFeedback += NativeControl_ManipulationBoundaryFeedback;
            }
            if (thisAsIRxUIElement.ManipulationCompletedAction != null || thisAsIRxUIElement.ManipulationCompletedActionWithArgs != null)
            {
                NativeControl.ManipulationCompleted += NativeControl_ManipulationCompleted;
            }
            if (thisAsIRxUIElement.ManipulationDeltaAction != null || thisAsIRxUIElement.ManipulationDeltaActionWithArgs != null)
            {
                NativeControl.ManipulationDelta += NativeControl_ManipulationDelta;
            }
            if (thisAsIRxUIElement.ManipulationInertiaStartingAction != null || thisAsIRxUIElement.ManipulationInertiaStartingActionWithArgs != null)
            {
                NativeControl.ManipulationInertiaStarting += NativeControl_ManipulationInertiaStarting;
            }
            if (thisAsIRxUIElement.ManipulationStartedAction != null || thisAsIRxUIElement.ManipulationStartedActionWithArgs != null)
            {
                NativeControl.ManipulationStarted += NativeControl_ManipulationStarted;
            }
            if (thisAsIRxUIElement.ManipulationStartingAction != null || thisAsIRxUIElement.ManipulationStartingActionWithArgs != null)
            {
                NativeControl.ManipulationStarting += NativeControl_ManipulationStarting;
            }
            if (thisAsIRxUIElement.MouseDownAction != null || thisAsIRxUIElement.MouseDownActionWithArgs != null)
            {
                NativeControl.MouseDown += NativeControl_MouseDown;
            }
            if (thisAsIRxUIElement.MouseEnterAction != null || thisAsIRxUIElement.MouseEnterActionWithArgs != null)
            {
                NativeControl.MouseEnter += NativeControl_MouseEnter;
            }
            if (thisAsIRxUIElement.MouseLeaveAction != null || thisAsIRxUIElement.MouseLeaveActionWithArgs != null)
            {
                NativeControl.MouseLeave += NativeControl_MouseLeave;
            }
            if (thisAsIRxUIElement.MouseLeftButtonDownAction != null || thisAsIRxUIElement.MouseLeftButtonDownActionWithArgs != null)
            {
                NativeControl.MouseLeftButtonDown += NativeControl_MouseLeftButtonDown;
            }
            if (thisAsIRxUIElement.MouseLeftButtonUpAction != null || thisAsIRxUIElement.MouseLeftButtonUpActionWithArgs != null)
            {
                NativeControl.MouseLeftButtonUp += NativeControl_MouseLeftButtonUp;
            }
            if (thisAsIRxUIElement.MouseMoveAction != null || thisAsIRxUIElement.MouseMoveActionWithArgs != null)
            {
                NativeControl.MouseMove += NativeControl_MouseMove;
            }
            if (thisAsIRxUIElement.MouseRightButtonDownAction != null || thisAsIRxUIElement.MouseRightButtonDownActionWithArgs != null)
            {
                NativeControl.MouseRightButtonDown += NativeControl_MouseRightButtonDown;
            }
            if (thisAsIRxUIElement.MouseRightButtonUpAction != null || thisAsIRxUIElement.MouseRightButtonUpActionWithArgs != null)
            {
                NativeControl.MouseRightButtonUp += NativeControl_MouseRightButtonUp;
            }
            if (thisAsIRxUIElement.MouseUpAction != null || thisAsIRxUIElement.MouseUpActionWithArgs != null)
            {
                NativeControl.MouseUp += NativeControl_MouseUp;
            }
            if (thisAsIRxUIElement.MouseWheelAction != null || thisAsIRxUIElement.MouseWheelActionWithArgs != null)
            {
                NativeControl.MouseWheel += NativeControl_MouseWheel;
            }
            if (thisAsIRxUIElement.PreviewDragEnterAction != null || thisAsIRxUIElement.PreviewDragEnterActionWithArgs != null)
            {
                NativeControl.PreviewDragEnter += NativeControl_PreviewDragEnter;
            }
            if (thisAsIRxUIElement.PreviewDragLeaveAction != null || thisAsIRxUIElement.PreviewDragLeaveActionWithArgs != null)
            {
                NativeControl.PreviewDragLeave += NativeControl_PreviewDragLeave;
            }
            if (thisAsIRxUIElement.PreviewDragOverAction != null || thisAsIRxUIElement.PreviewDragOverActionWithArgs != null)
            {
                NativeControl.PreviewDragOver += NativeControl_PreviewDragOver;
            }
            if (thisAsIRxUIElement.PreviewDropAction != null || thisAsIRxUIElement.PreviewDropActionWithArgs != null)
            {
                NativeControl.PreviewDrop += NativeControl_PreviewDrop;
            }
            if (thisAsIRxUIElement.PreviewGiveFeedbackAction != null || thisAsIRxUIElement.PreviewGiveFeedbackActionWithArgs != null)
            {
                NativeControl.PreviewGiveFeedback += NativeControl_PreviewGiveFeedback;
            }
            if (thisAsIRxUIElement.PreviewGotKeyboardFocusAction != null || thisAsIRxUIElement.PreviewGotKeyboardFocusActionWithArgs != null)
            {
                NativeControl.PreviewGotKeyboardFocus += NativeControl_PreviewGotKeyboardFocus;
            }
            if (thisAsIRxUIElement.PreviewKeyDownAction != null || thisAsIRxUIElement.PreviewKeyDownActionWithArgs != null)
            {
                NativeControl.PreviewKeyDown += NativeControl_PreviewKeyDown;
            }
            if (thisAsIRxUIElement.PreviewKeyUpAction != null || thisAsIRxUIElement.PreviewKeyUpActionWithArgs != null)
            {
                NativeControl.PreviewKeyUp += NativeControl_PreviewKeyUp;
            }
            if (thisAsIRxUIElement.PreviewLostKeyboardFocusAction != null || thisAsIRxUIElement.PreviewLostKeyboardFocusActionWithArgs != null)
            {
                NativeControl.PreviewLostKeyboardFocus += NativeControl_PreviewLostKeyboardFocus;
            }
            if (thisAsIRxUIElement.PreviewMouseDownAction != null || thisAsIRxUIElement.PreviewMouseDownActionWithArgs != null)
            {
                NativeControl.PreviewMouseDown += NativeControl_PreviewMouseDown;
            }
            if (thisAsIRxUIElement.PreviewMouseLeftButtonDownAction != null || thisAsIRxUIElement.PreviewMouseLeftButtonDownActionWithArgs != null)
            {
                NativeControl.PreviewMouseLeftButtonDown += NativeControl_PreviewMouseLeftButtonDown;
            }
            if (thisAsIRxUIElement.PreviewMouseLeftButtonUpAction != null || thisAsIRxUIElement.PreviewMouseLeftButtonUpActionWithArgs != null)
            {
                NativeControl.PreviewMouseLeftButtonUp += NativeControl_PreviewMouseLeftButtonUp;
            }
            if (thisAsIRxUIElement.PreviewMouseMoveAction != null || thisAsIRxUIElement.PreviewMouseMoveActionWithArgs != null)
            {
                NativeControl.PreviewMouseMove += NativeControl_PreviewMouseMove;
            }
            if (thisAsIRxUIElement.PreviewMouseRightButtonDownAction != null || thisAsIRxUIElement.PreviewMouseRightButtonDownActionWithArgs != null)
            {
                NativeControl.PreviewMouseRightButtonDown += NativeControl_PreviewMouseRightButtonDown;
            }
            if (thisAsIRxUIElement.PreviewMouseRightButtonUpAction != null || thisAsIRxUIElement.PreviewMouseRightButtonUpActionWithArgs != null)
            {
                NativeControl.PreviewMouseRightButtonUp += NativeControl_PreviewMouseRightButtonUp;
            }
            if (thisAsIRxUIElement.PreviewMouseUpAction != null || thisAsIRxUIElement.PreviewMouseUpActionWithArgs != null)
            {
                NativeControl.PreviewMouseUp += NativeControl_PreviewMouseUp;
            }
            if (thisAsIRxUIElement.PreviewMouseWheelAction != null || thisAsIRxUIElement.PreviewMouseWheelActionWithArgs != null)
            {
                NativeControl.PreviewMouseWheel += NativeControl_PreviewMouseWheel;
            }
            if (thisAsIRxUIElement.PreviewQueryContinueDragAction != null || thisAsIRxUIElement.PreviewQueryContinueDragActionWithArgs != null)
            {
                NativeControl.PreviewQueryContinueDrag += NativeControl_PreviewQueryContinueDrag;
            }
            if (thisAsIRxUIElement.PreviewStylusButtonDownAction != null || thisAsIRxUIElement.PreviewStylusButtonDownActionWithArgs != null)
            {
                NativeControl.PreviewStylusButtonDown += NativeControl_PreviewStylusButtonDown;
            }
            if (thisAsIRxUIElement.PreviewStylusButtonUpAction != null || thisAsIRxUIElement.PreviewStylusButtonUpActionWithArgs != null)
            {
                NativeControl.PreviewStylusButtonUp += NativeControl_PreviewStylusButtonUp;
            }
            if (thisAsIRxUIElement.PreviewStylusDownAction != null || thisAsIRxUIElement.PreviewStylusDownActionWithArgs != null)
            {
                NativeControl.PreviewStylusDown += NativeControl_PreviewStylusDown;
            }
            if (thisAsIRxUIElement.PreviewStylusInAirMoveAction != null || thisAsIRxUIElement.PreviewStylusInAirMoveActionWithArgs != null)
            {
                NativeControl.PreviewStylusInAirMove += NativeControl_PreviewStylusInAirMove;
            }
            if (thisAsIRxUIElement.PreviewStylusInRangeAction != null || thisAsIRxUIElement.PreviewStylusInRangeActionWithArgs != null)
            {
                NativeControl.PreviewStylusInRange += NativeControl_PreviewStylusInRange;
            }
            if (thisAsIRxUIElement.PreviewStylusMoveAction != null || thisAsIRxUIElement.PreviewStylusMoveActionWithArgs != null)
            {
                NativeControl.PreviewStylusMove += NativeControl_PreviewStylusMove;
            }
            if (thisAsIRxUIElement.PreviewStylusOutOfRangeAction != null || thisAsIRxUIElement.PreviewStylusOutOfRangeActionWithArgs != null)
            {
                NativeControl.PreviewStylusOutOfRange += NativeControl_PreviewStylusOutOfRange;
            }
            if (thisAsIRxUIElement.PreviewStylusSystemGestureAction != null || thisAsIRxUIElement.PreviewStylusSystemGestureActionWithArgs != null)
            {
                NativeControl.PreviewStylusSystemGesture += NativeControl_PreviewStylusSystemGesture;
            }
            if (thisAsIRxUIElement.PreviewStylusUpAction != null || thisAsIRxUIElement.PreviewStylusUpActionWithArgs != null)
            {
                NativeControl.PreviewStylusUp += NativeControl_PreviewStylusUp;
            }
            if (thisAsIRxUIElement.PreviewTextInputAction != null || thisAsIRxUIElement.PreviewTextInputActionWithArgs != null)
            {
                NativeControl.PreviewTextInput += NativeControl_PreviewTextInput;
            }
            if (thisAsIRxUIElement.PreviewTouchDownAction != null || thisAsIRxUIElement.PreviewTouchDownActionWithArgs != null)
            {
                NativeControl.PreviewTouchDown += NativeControl_PreviewTouchDown;
            }
            if (thisAsIRxUIElement.PreviewTouchMoveAction != null || thisAsIRxUIElement.PreviewTouchMoveActionWithArgs != null)
            {
                NativeControl.PreviewTouchMove += NativeControl_PreviewTouchMove;
            }
            if (thisAsIRxUIElement.PreviewTouchUpAction != null || thisAsIRxUIElement.PreviewTouchUpActionWithArgs != null)
            {
                NativeControl.PreviewTouchUp += NativeControl_PreviewTouchUp;
            }
            if (thisAsIRxUIElement.QueryContinueDragAction != null || thisAsIRxUIElement.QueryContinueDragActionWithArgs != null)
            {
                NativeControl.QueryContinueDrag += NativeControl_QueryContinueDrag;
            }
            if (thisAsIRxUIElement.QueryCursorAction != null || thisAsIRxUIElement.QueryCursorActionWithArgs != null)
            {
                NativeControl.QueryCursor += NativeControl_QueryCursor;
            }
            if (thisAsIRxUIElement.StylusButtonDownAction != null || thisAsIRxUIElement.StylusButtonDownActionWithArgs != null)
            {
                NativeControl.StylusButtonDown += NativeControl_StylusButtonDown;
            }
            if (thisAsIRxUIElement.StylusButtonUpAction != null || thisAsIRxUIElement.StylusButtonUpActionWithArgs != null)
            {
                NativeControl.StylusButtonUp += NativeControl_StylusButtonUp;
            }
            if (thisAsIRxUIElement.StylusDownAction != null || thisAsIRxUIElement.StylusDownActionWithArgs != null)
            {
                NativeControl.StylusDown += NativeControl_StylusDown;
            }
            if (thisAsIRxUIElement.StylusEnterAction != null || thisAsIRxUIElement.StylusEnterActionWithArgs != null)
            {
                NativeControl.StylusEnter += NativeControl_StylusEnter;
            }
            if (thisAsIRxUIElement.StylusInAirMoveAction != null || thisAsIRxUIElement.StylusInAirMoveActionWithArgs != null)
            {
                NativeControl.StylusInAirMove += NativeControl_StylusInAirMove;
            }
            if (thisAsIRxUIElement.StylusInRangeAction != null || thisAsIRxUIElement.StylusInRangeActionWithArgs != null)
            {
                NativeControl.StylusInRange += NativeControl_StylusInRange;
            }
            if (thisAsIRxUIElement.StylusLeaveAction != null || thisAsIRxUIElement.StylusLeaveActionWithArgs != null)
            {
                NativeControl.StylusLeave += NativeControl_StylusLeave;
            }
            if (thisAsIRxUIElement.StylusMoveAction != null || thisAsIRxUIElement.StylusMoveActionWithArgs != null)
            {
                NativeControl.StylusMove += NativeControl_StylusMove;
            }
            if (thisAsIRxUIElement.StylusOutOfRangeAction != null || thisAsIRxUIElement.StylusOutOfRangeActionWithArgs != null)
            {
                NativeControl.StylusOutOfRange += NativeControl_StylusOutOfRange;
            }
            if (thisAsIRxUIElement.StylusSystemGestureAction != null || thisAsIRxUIElement.StylusSystemGestureActionWithArgs != null)
            {
                NativeControl.StylusSystemGesture += NativeControl_StylusSystemGesture;
            }
            if (thisAsIRxUIElement.StylusUpAction != null || thisAsIRxUIElement.StylusUpActionWithArgs != null)
            {
                NativeControl.StylusUp += NativeControl_StylusUp;
            }
            if (thisAsIRxUIElement.TextInputAction != null || thisAsIRxUIElement.TextInputActionWithArgs != null)
            {
                NativeControl.TextInput += NativeControl_TextInput;
            }
            if (thisAsIRxUIElement.TouchDownAction != null || thisAsIRxUIElement.TouchDownActionWithArgs != null)
            {
                NativeControl.TouchDown += NativeControl_TouchDown;
            }
            if (thisAsIRxUIElement.TouchEnterAction != null || thisAsIRxUIElement.TouchEnterActionWithArgs != null)
            {
                NativeControl.TouchEnter += NativeControl_TouchEnter;
            }
            if (thisAsIRxUIElement.TouchLeaveAction != null || thisAsIRxUIElement.TouchLeaveActionWithArgs != null)
            {
                NativeControl.TouchLeave += NativeControl_TouchLeave;
            }
            if (thisAsIRxUIElement.TouchMoveAction != null || thisAsIRxUIElement.TouchMoveActionWithArgs != null)
            {
                NativeControl.TouchMove += NativeControl_TouchMove;
            }
            if (thisAsIRxUIElement.TouchUpAction != null || thisAsIRxUIElement.TouchUpActionWithArgs != null)
            {
                NativeControl.TouchUp += NativeControl_TouchUp;
            }

            base.OnAttachNativeEvents();
        }

        private void NativeControl_DragEnter(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.DragEnterAction?.Invoke();
            thisAsIRxUIElement.DragEnterActionWithArgs?.Invoke(e);
        }
        private void NativeControl_DragLeave(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.DragLeaveAction?.Invoke();
            thisAsIRxUIElement.DragLeaveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_DragOver(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.DragOverAction?.Invoke();
            thisAsIRxUIElement.DragOverActionWithArgs?.Invoke(e);
        }
        private void NativeControl_Drop(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.DropAction?.Invoke();
            thisAsIRxUIElement.DropActionWithArgs?.Invoke(e);
        }
        private void NativeControl_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.GiveFeedbackAction?.Invoke();
            thisAsIRxUIElement.GiveFeedbackActionWithArgs?.Invoke(e);
        }
        private void NativeControl_GotFocus(object sender, RoutedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.GotFocusAction?.Invoke();
            thisAsIRxUIElement.GotFocusActionWithArgs?.Invoke(e);
        }
        private void NativeControl_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.GotKeyboardFocusAction?.Invoke();
            thisAsIRxUIElement.GotKeyboardFocusActionWithArgs?.Invoke(e);
        }
        private void NativeControl_GotMouseCapture(object sender, MouseEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.GotMouseCaptureAction?.Invoke();
            thisAsIRxUIElement.GotMouseCaptureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_GotStylusCapture(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.GotStylusCaptureAction?.Invoke();
            thisAsIRxUIElement.GotStylusCaptureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_GotTouchCapture(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.GotTouchCaptureAction?.Invoke();
            thisAsIRxUIElement.GotTouchCaptureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_KeyDown(object sender, KeyEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.KeyDownAction?.Invoke();
            thisAsIRxUIElement.KeyDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_KeyUp(object sender, KeyEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.KeyUpAction?.Invoke();
            thisAsIRxUIElement.KeyUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_LostFocus(object sender, RoutedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.LostFocusAction?.Invoke();
            thisAsIRxUIElement.LostFocusActionWithArgs?.Invoke(e);
        }
        private void NativeControl_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.LostKeyboardFocusAction?.Invoke();
            thisAsIRxUIElement.LostKeyboardFocusActionWithArgs?.Invoke(e);
        }
        private void NativeControl_LostMouseCapture(object sender, MouseEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.LostMouseCaptureAction?.Invoke();
            thisAsIRxUIElement.LostMouseCaptureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_LostStylusCapture(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.LostStylusCaptureAction?.Invoke();
            thisAsIRxUIElement.LostStylusCaptureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_LostTouchCapture(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.LostTouchCaptureAction?.Invoke();
            thisAsIRxUIElement.LostTouchCaptureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ManipulationBoundaryFeedback(object sender, ManipulationBoundaryFeedbackEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.ManipulationBoundaryFeedbackAction?.Invoke();
            thisAsIRxUIElement.ManipulationBoundaryFeedbackActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.ManipulationCompletedAction?.Invoke();
            thisAsIRxUIElement.ManipulationCompletedActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.ManipulationDeltaAction?.Invoke();
            thisAsIRxUIElement.ManipulationDeltaActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.ManipulationInertiaStartingAction?.Invoke();
            thisAsIRxUIElement.ManipulationInertiaStartingActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.ManipulationStartedAction?.Invoke();
            thisAsIRxUIElement.ManipulationStartedActionWithArgs?.Invoke(e);
        }
        private void NativeControl_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.ManipulationStartingAction?.Invoke();
            thisAsIRxUIElement.ManipulationStartingActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseDownAction?.Invoke();
            thisAsIRxUIElement.MouseDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseEnter(object sender, MouseEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseEnterAction?.Invoke();
            thisAsIRxUIElement.MouseEnterActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseLeave(object sender, MouseEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseLeaveAction?.Invoke();
            thisAsIRxUIElement.MouseLeaveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseLeftButtonDownAction?.Invoke();
            thisAsIRxUIElement.MouseLeftButtonDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseLeftButtonUpAction?.Invoke();
            thisAsIRxUIElement.MouseLeftButtonUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseMove(object sender, MouseEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseMoveAction?.Invoke();
            thisAsIRxUIElement.MouseMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseRightButtonDownAction?.Invoke();
            thisAsIRxUIElement.MouseRightButtonDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseRightButtonUpAction?.Invoke();
            thisAsIRxUIElement.MouseRightButtonUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseUpAction?.Invoke();
            thisAsIRxUIElement.MouseUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.MouseWheelAction?.Invoke();
            thisAsIRxUIElement.MouseWheelActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewDragEnter(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewDragEnterAction?.Invoke();
            thisAsIRxUIElement.PreviewDragEnterActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewDragLeave(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewDragLeaveAction?.Invoke();
            thisAsIRxUIElement.PreviewDragLeaveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewDragOver(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewDragOverAction?.Invoke();
            thisAsIRxUIElement.PreviewDragOverActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewDrop(object sender, DragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewDropAction?.Invoke();
            thisAsIRxUIElement.PreviewDropActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewGiveFeedbackAction?.Invoke();
            thisAsIRxUIElement.PreviewGiveFeedbackActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewGotKeyboardFocusAction?.Invoke();
            thisAsIRxUIElement.PreviewGotKeyboardFocusActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewKeyDownAction?.Invoke();
            thisAsIRxUIElement.PreviewKeyDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewKeyUpAction?.Invoke();
            thisAsIRxUIElement.PreviewKeyUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewLostKeyboardFocusAction?.Invoke();
            thisAsIRxUIElement.PreviewLostKeyboardFocusActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseDownAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseLeftButtonDownAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseLeftButtonDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseLeftButtonUpAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseLeftButtonUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseMoveAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseRightButtonDownAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseRightButtonDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseRightButtonUpAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseRightButtonUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseUpAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewMouseWheelAction?.Invoke();
            thisAsIRxUIElement.PreviewMouseWheelActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewQueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewQueryContinueDragAction?.Invoke();
            thisAsIRxUIElement.PreviewQueryContinueDragActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusButtonDownAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusButtonDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusButtonUp(object sender, StylusButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusButtonUpAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusButtonUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusDown(object sender, StylusDownEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusDownAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusInAirMove(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusInAirMoveAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusInAirMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusInRange(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusInRangeAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusInRangeActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusMove(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusMoveAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusOutOfRange(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusOutOfRangeAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusOutOfRangeActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusSystemGestureAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusSystemGestureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewStylusUp(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewStylusUpAction?.Invoke();
            thisAsIRxUIElement.PreviewStylusUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewTextInputAction?.Invoke();
            thisAsIRxUIElement.PreviewTextInputActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewTouchDownAction?.Invoke();
            thisAsIRxUIElement.PreviewTouchDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewTouchMove(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewTouchMoveAction?.Invoke();
            thisAsIRxUIElement.PreviewTouchMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.PreviewTouchUpAction?.Invoke();
            thisAsIRxUIElement.PreviewTouchUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.QueryContinueDragAction?.Invoke();
            thisAsIRxUIElement.QueryContinueDragActionWithArgs?.Invoke(e);
        }
        private void NativeControl_QueryCursor(object sender, QueryCursorEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.QueryCursorAction?.Invoke();
            thisAsIRxUIElement.QueryCursorActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusButtonDown(object sender, StylusButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusButtonDownAction?.Invoke();
            thisAsIRxUIElement.StylusButtonDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusButtonUp(object sender, StylusButtonEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusButtonUpAction?.Invoke();
            thisAsIRxUIElement.StylusButtonUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusDown(object sender, StylusDownEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusDownAction?.Invoke();
            thisAsIRxUIElement.StylusDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusEnter(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusEnterAction?.Invoke();
            thisAsIRxUIElement.StylusEnterActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusInAirMove(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusInAirMoveAction?.Invoke();
            thisAsIRxUIElement.StylusInAirMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusInRange(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusInRangeAction?.Invoke();
            thisAsIRxUIElement.StylusInRangeActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusLeave(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusLeaveAction?.Invoke();
            thisAsIRxUIElement.StylusLeaveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusMove(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusMoveAction?.Invoke();
            thisAsIRxUIElement.StylusMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusOutOfRange(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusOutOfRangeAction?.Invoke();
            thisAsIRxUIElement.StylusOutOfRangeActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusSystemGesture(object sender, StylusSystemGestureEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusSystemGestureAction?.Invoke();
            thisAsIRxUIElement.StylusSystemGestureActionWithArgs?.Invoke(e);
        }
        private void NativeControl_StylusUp(object sender, StylusEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.StylusUpAction?.Invoke();
            thisAsIRxUIElement.StylusUpActionWithArgs?.Invoke(e);
        }
        private void NativeControl_TextInput(object sender, TextCompositionEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.TextInputAction?.Invoke();
            thisAsIRxUIElement.TextInputActionWithArgs?.Invoke(e);
        }
        private void NativeControl_TouchDown(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.TouchDownAction?.Invoke();
            thisAsIRxUIElement.TouchDownActionWithArgs?.Invoke(e);
        }
        private void NativeControl_TouchEnter(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.TouchEnterAction?.Invoke();
            thisAsIRxUIElement.TouchEnterActionWithArgs?.Invoke(e);
        }
        private void NativeControl_TouchLeave(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.TouchLeaveAction?.Invoke();
            thisAsIRxUIElement.TouchLeaveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_TouchMove(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.TouchMoveAction?.Invoke();
            thisAsIRxUIElement.TouchMoveActionWithArgs?.Invoke(e);
        }
        private void NativeControl_TouchUp(object sender, TouchEventArgs e)
        {
            var thisAsIRxUIElement = (IRxUIElement)this;
            thisAsIRxUIElement.TouchUpAction?.Invoke();
            thisAsIRxUIElement.TouchUpActionWithArgs?.Invoke(e);
        }

        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
                NativeControl.DragEnter -= NativeControl_DragEnter;
                NativeControl.DragLeave -= NativeControl_DragLeave;
                NativeControl.DragOver -= NativeControl_DragOver;
                NativeControl.Drop -= NativeControl_Drop;
                NativeControl.GiveFeedback -= NativeControl_GiveFeedback;
                NativeControl.GotFocus -= NativeControl_GotFocus;
                NativeControl.GotKeyboardFocus -= NativeControl_GotKeyboardFocus;
                NativeControl.GotMouseCapture -= NativeControl_GotMouseCapture;
                NativeControl.GotStylusCapture -= NativeControl_GotStylusCapture;
                NativeControl.GotTouchCapture -= NativeControl_GotTouchCapture;
                NativeControl.KeyDown -= NativeControl_KeyDown;
                NativeControl.KeyUp -= NativeControl_KeyUp;
                NativeControl.LostFocus -= NativeControl_LostFocus;
                NativeControl.LostKeyboardFocus -= NativeControl_LostKeyboardFocus;
                NativeControl.LostMouseCapture -= NativeControl_LostMouseCapture;
                NativeControl.LostStylusCapture -= NativeControl_LostStylusCapture;
                NativeControl.LostTouchCapture -= NativeControl_LostTouchCapture;
                NativeControl.ManipulationBoundaryFeedback -= NativeControl_ManipulationBoundaryFeedback;
                NativeControl.ManipulationCompleted -= NativeControl_ManipulationCompleted;
                NativeControl.ManipulationDelta -= NativeControl_ManipulationDelta;
                NativeControl.ManipulationInertiaStarting -= NativeControl_ManipulationInertiaStarting;
                NativeControl.ManipulationStarted -= NativeControl_ManipulationStarted;
                NativeControl.ManipulationStarting -= NativeControl_ManipulationStarting;
                NativeControl.MouseDown -= NativeControl_MouseDown;
                NativeControl.MouseEnter -= NativeControl_MouseEnter;
                NativeControl.MouseLeave -= NativeControl_MouseLeave;
                NativeControl.MouseLeftButtonDown -= NativeControl_MouseLeftButtonDown;
                NativeControl.MouseLeftButtonUp -= NativeControl_MouseLeftButtonUp;
                NativeControl.MouseMove -= NativeControl_MouseMove;
                NativeControl.MouseRightButtonDown -= NativeControl_MouseRightButtonDown;
                NativeControl.MouseRightButtonUp -= NativeControl_MouseRightButtonUp;
                NativeControl.MouseUp -= NativeControl_MouseUp;
                NativeControl.MouseWheel -= NativeControl_MouseWheel;
                NativeControl.PreviewDragEnter -= NativeControl_PreviewDragEnter;
                NativeControl.PreviewDragLeave -= NativeControl_PreviewDragLeave;
                NativeControl.PreviewDragOver -= NativeControl_PreviewDragOver;
                NativeControl.PreviewDrop -= NativeControl_PreviewDrop;
                NativeControl.PreviewGiveFeedback -= NativeControl_PreviewGiveFeedback;
                NativeControl.PreviewGotKeyboardFocus -= NativeControl_PreviewGotKeyboardFocus;
                NativeControl.PreviewKeyDown -= NativeControl_PreviewKeyDown;
                NativeControl.PreviewKeyUp -= NativeControl_PreviewKeyUp;
                NativeControl.PreviewLostKeyboardFocus -= NativeControl_PreviewLostKeyboardFocus;
                NativeControl.PreviewMouseDown -= NativeControl_PreviewMouseDown;
                NativeControl.PreviewMouseLeftButtonDown -= NativeControl_PreviewMouseLeftButtonDown;
                NativeControl.PreviewMouseLeftButtonUp -= NativeControl_PreviewMouseLeftButtonUp;
                NativeControl.PreviewMouseMove -= NativeControl_PreviewMouseMove;
                NativeControl.PreviewMouseRightButtonDown -= NativeControl_PreviewMouseRightButtonDown;
                NativeControl.PreviewMouseRightButtonUp -= NativeControl_PreviewMouseRightButtonUp;
                NativeControl.PreviewMouseUp -= NativeControl_PreviewMouseUp;
                NativeControl.PreviewMouseWheel -= NativeControl_PreviewMouseWheel;
                NativeControl.PreviewQueryContinueDrag -= NativeControl_PreviewQueryContinueDrag;
                NativeControl.PreviewStylusButtonDown -= NativeControl_PreviewStylusButtonDown;
                NativeControl.PreviewStylusButtonUp -= NativeControl_PreviewStylusButtonUp;
                NativeControl.PreviewStylusDown -= NativeControl_PreviewStylusDown;
                NativeControl.PreviewStylusInAirMove -= NativeControl_PreviewStylusInAirMove;
                NativeControl.PreviewStylusInRange -= NativeControl_PreviewStylusInRange;
                NativeControl.PreviewStylusMove -= NativeControl_PreviewStylusMove;
                NativeControl.PreviewStylusOutOfRange -= NativeControl_PreviewStylusOutOfRange;
                NativeControl.PreviewStylusSystemGesture -= NativeControl_PreviewStylusSystemGesture;
                NativeControl.PreviewStylusUp -= NativeControl_PreviewStylusUp;
                NativeControl.PreviewTextInput -= NativeControl_PreviewTextInput;
                NativeControl.PreviewTouchDown -= NativeControl_PreviewTouchDown;
                NativeControl.PreviewTouchMove -= NativeControl_PreviewTouchMove;
                NativeControl.PreviewTouchUp -= NativeControl_PreviewTouchUp;
                NativeControl.QueryContinueDrag -= NativeControl_QueryContinueDrag;
                NativeControl.QueryCursor -= NativeControl_QueryCursor;
                NativeControl.StylusButtonDown -= NativeControl_StylusButtonDown;
                NativeControl.StylusButtonUp -= NativeControl_StylusButtonUp;
                NativeControl.StylusDown -= NativeControl_StylusDown;
                NativeControl.StylusEnter -= NativeControl_StylusEnter;
                NativeControl.StylusInAirMove -= NativeControl_StylusInAirMove;
                NativeControl.StylusInRange -= NativeControl_StylusInRange;
                NativeControl.StylusLeave -= NativeControl_StylusLeave;
                NativeControl.StylusMove -= NativeControl_StylusMove;
                NativeControl.StylusOutOfRange -= NativeControl_StylusOutOfRange;
                NativeControl.StylusSystemGesture -= NativeControl_StylusSystemGesture;
                NativeControl.StylusUp -= NativeControl_StylusUp;
                NativeControl.TextInput -= NativeControl_TextInput;
                NativeControl.TouchDown -= NativeControl_TouchDown;
                NativeControl.TouchEnter -= NativeControl_TouchEnter;
                NativeControl.TouchLeave -= NativeControl_TouchLeave;
                NativeControl.TouchMove -= NativeControl_TouchMove;
                NativeControl.TouchUp -= NativeControl_TouchUp;
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxUIElement : RxUIElement<UIElement>
    {
        public RxUIElement()
        {

        }

        public RxUIElement(Action<UIElement> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxUIElementExtensions
    {
        public static T AllowDrop<T>(this T uielement, bool allowDrop) where T : IRxUIElement
        {
            uielement.AllowDrop = new PropertyValue<bool>(allowDrop);
            return uielement;
        }
        public static T CacheMode<T>(this T uielement, CacheMode cacheMode) where T : IRxUIElement
        {
            uielement.CacheMode = new PropertyValue<CacheMode>(cacheMode);
            return uielement;
        }
        public static T Clip<T>(this T uielement, Geometry clip) where T : IRxUIElement
        {
            uielement.Clip = new PropertyValue<Geometry>(clip);
            return uielement;
        }
        public static T ClipToBounds<T>(this T uielement, bool clipToBounds) where T : IRxUIElement
        {
            uielement.ClipToBounds = new PropertyValue<bool>(clipToBounds);
            return uielement;
        }
        public static T Effect<T>(this T uielement, Effect effect) where T : IRxUIElement
        {
            uielement.Effect = new PropertyValue<Effect>(effect);
            return uielement;
        }
        public static T Focusable<T>(this T uielement, bool focusable) where T : IRxUIElement
        {
            uielement.Focusable = new PropertyValue<bool>(focusable);
            return uielement;
        }
        public static T IsEnabled<T>(this T uielement, bool isEnabled) where T : IRxUIElement
        {
            uielement.IsEnabled = new PropertyValue<bool>(isEnabled);
            return uielement;
        }
        public static T IsHitTestVisible<T>(this T uielement, bool isHitTestVisible) where T : IRxUIElement
        {
            uielement.IsHitTestVisible = new PropertyValue<bool>(isHitTestVisible);
            return uielement;
        }
        public static T IsManipulationEnabled<T>(this T uielement, bool isManipulationEnabled) where T : IRxUIElement
        {
            uielement.IsManipulationEnabled = new PropertyValue<bool>(isManipulationEnabled);
            return uielement;
        }
        public static T Opacity<T>(this T uielement, double opacity) where T : IRxUIElement
        {
            uielement.Opacity = new PropertyValue<double>(opacity);
            return uielement;
        }
        public static T OpacityMask<T>(this T uielement, Brush opacityMask) where T : IRxUIElement
        {
            uielement.OpacityMask = new PropertyValue<Brush>(opacityMask);
            return uielement;
        }
        public static T RenderTransform<T>(this T uielement, Transform renderTransform) where T : IRxUIElement
        {
            uielement.RenderTransform = new PropertyValue<Transform>(renderTransform);
            return uielement;
        }
        public static T RenderTransformOrigin<T>(this T uielement, Point renderTransformOrigin) where T : IRxUIElement
        {
            uielement.RenderTransformOrigin = new PropertyValue<Point>(renderTransformOrigin);
            return uielement;
        }
        public static T SnapsToDevicePixels<T>(this T uielement, bool snapsToDevicePixels) where T : IRxUIElement
        {
            uielement.SnapsToDevicePixels = new PropertyValue<bool>(snapsToDevicePixels);
            return uielement;
        }
        public static T Uid<T>(this T uielement, string uid) where T : IRxUIElement
        {
            uielement.Uid = new PropertyValue<string>(uid);
            return uielement;
        }
        public static T Visibility<T>(this T uielement, Visibility visibility) where T : IRxUIElement
        {
            uielement.Visibility = new PropertyValue<Visibility>(visibility);
            return uielement;
        }
        public static T OnDragEnter<T>(this T uielement, Action dragenterAction) where T : IRxUIElement
        {
            uielement.DragEnterAction = dragenterAction;
            return uielement;
        }

        public static T OnDragEnter<T>(this T uielement, Action<DragEventArgs> dragenterActionWithArgs) where T : IRxUIElement
        {
            uielement.DragEnterActionWithArgs = dragenterActionWithArgs;
            return uielement;
        }
        public static T OnDragLeave<T>(this T uielement, Action dragleaveAction) where T : IRxUIElement
        {
            uielement.DragLeaveAction = dragleaveAction;
            return uielement;
        }

        public static T OnDragLeave<T>(this T uielement, Action<DragEventArgs> dragleaveActionWithArgs) where T : IRxUIElement
        {
            uielement.DragLeaveActionWithArgs = dragleaveActionWithArgs;
            return uielement;
        }
        public static T OnDragOver<T>(this T uielement, Action dragoverAction) where T : IRxUIElement
        {
            uielement.DragOverAction = dragoverAction;
            return uielement;
        }

        public static T OnDragOver<T>(this T uielement, Action<DragEventArgs> dragoverActionWithArgs) where T : IRxUIElement
        {
            uielement.DragOverActionWithArgs = dragoverActionWithArgs;
            return uielement;
        }
        public static T OnDrop<T>(this T uielement, Action dropAction) where T : IRxUIElement
        {
            uielement.DropAction = dropAction;
            return uielement;
        }

        public static T OnDrop<T>(this T uielement, Action<DragEventArgs> dropActionWithArgs) where T : IRxUIElement
        {
            uielement.DropActionWithArgs = dropActionWithArgs;
            return uielement;
        }
        public static T OnGiveFeedback<T>(this T uielement, Action givefeedbackAction) where T : IRxUIElement
        {
            uielement.GiveFeedbackAction = givefeedbackAction;
            return uielement;
        }

        public static T OnGiveFeedback<T>(this T uielement, Action<GiveFeedbackEventArgs> givefeedbackActionWithArgs) where T : IRxUIElement
        {
            uielement.GiveFeedbackActionWithArgs = givefeedbackActionWithArgs;
            return uielement;
        }
        public static T OnGotFocus<T>(this T uielement, Action gotfocusAction) where T : IRxUIElement
        {
            uielement.GotFocusAction = gotfocusAction;
            return uielement;
        }

        public static T OnGotFocus<T>(this T uielement, Action<RoutedEventArgs> gotfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.GotFocusActionWithArgs = gotfocusActionWithArgs;
            return uielement;
        }
        public static T OnGotKeyboardFocus<T>(this T uielement, Action gotkeyboardfocusAction) where T : IRxUIElement
        {
            uielement.GotKeyboardFocusAction = gotkeyboardfocusAction;
            return uielement;
        }

        public static T OnGotKeyboardFocus<T>(this T uielement, Action<KeyboardFocusChangedEventArgs> gotkeyboardfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.GotKeyboardFocusActionWithArgs = gotkeyboardfocusActionWithArgs;
            return uielement;
        }
        public static T OnGotMouseCapture<T>(this T uielement, Action gotmousecaptureAction) where T : IRxUIElement
        {
            uielement.GotMouseCaptureAction = gotmousecaptureAction;
            return uielement;
        }

        public static T OnGotMouseCapture<T>(this T uielement, Action<MouseEventArgs> gotmousecaptureActionWithArgs) where T : IRxUIElement
        {
            uielement.GotMouseCaptureActionWithArgs = gotmousecaptureActionWithArgs;
            return uielement;
        }
        public static T OnGotStylusCapture<T>(this T uielement, Action gotstyluscaptureAction) where T : IRxUIElement
        {
            uielement.GotStylusCaptureAction = gotstyluscaptureAction;
            return uielement;
        }

        public static T OnGotStylusCapture<T>(this T uielement, Action<StylusEventArgs> gotstyluscaptureActionWithArgs) where T : IRxUIElement
        {
            uielement.GotStylusCaptureActionWithArgs = gotstyluscaptureActionWithArgs;
            return uielement;
        }
        public static T OnGotTouchCapture<T>(this T uielement, Action gottouchcaptureAction) where T : IRxUIElement
        {
            uielement.GotTouchCaptureAction = gottouchcaptureAction;
            return uielement;
        }

        public static T OnGotTouchCapture<T>(this T uielement, Action<TouchEventArgs> gottouchcaptureActionWithArgs) where T : IRxUIElement
        {
            uielement.GotTouchCaptureActionWithArgs = gottouchcaptureActionWithArgs;
            return uielement;
        }
        public static T OnKeyDown<T>(this T uielement, Action keydownAction) where T : IRxUIElement
        {
            uielement.KeyDownAction = keydownAction;
            return uielement;
        }

        public static T OnKeyDown<T>(this T uielement, Action<KeyEventArgs> keydownActionWithArgs) where T : IRxUIElement
        {
            uielement.KeyDownActionWithArgs = keydownActionWithArgs;
            return uielement;
        }
        public static T OnKeyUp<T>(this T uielement, Action keyupAction) where T : IRxUIElement
        {
            uielement.KeyUpAction = keyupAction;
            return uielement;
        }

        public static T OnKeyUp<T>(this T uielement, Action<KeyEventArgs> keyupActionWithArgs) where T : IRxUIElement
        {
            uielement.KeyUpActionWithArgs = keyupActionWithArgs;
            return uielement;
        }
        public static T OnLostFocus<T>(this T uielement, Action lostfocusAction) where T : IRxUIElement
        {
            uielement.LostFocusAction = lostfocusAction;
            return uielement;
        }

        public static T OnLostFocus<T>(this T uielement, Action<RoutedEventArgs> lostfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.LostFocusActionWithArgs = lostfocusActionWithArgs;
            return uielement;
        }
        public static T OnLostKeyboardFocus<T>(this T uielement, Action lostkeyboardfocusAction) where T : IRxUIElement
        {
            uielement.LostKeyboardFocusAction = lostkeyboardfocusAction;
            return uielement;
        }

        public static T OnLostKeyboardFocus<T>(this T uielement, Action<KeyboardFocusChangedEventArgs> lostkeyboardfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.LostKeyboardFocusActionWithArgs = lostkeyboardfocusActionWithArgs;
            return uielement;
        }
        public static T OnLostMouseCapture<T>(this T uielement, Action lostmousecaptureAction) where T : IRxUIElement
        {
            uielement.LostMouseCaptureAction = lostmousecaptureAction;
            return uielement;
        }

        public static T OnLostMouseCapture<T>(this T uielement, Action<MouseEventArgs> lostmousecaptureActionWithArgs) where T : IRxUIElement
        {
            uielement.LostMouseCaptureActionWithArgs = lostmousecaptureActionWithArgs;
            return uielement;
        }
        public static T OnLostStylusCapture<T>(this T uielement, Action loststyluscaptureAction) where T : IRxUIElement
        {
            uielement.LostStylusCaptureAction = loststyluscaptureAction;
            return uielement;
        }

        public static T OnLostStylusCapture<T>(this T uielement, Action<StylusEventArgs> loststyluscaptureActionWithArgs) where T : IRxUIElement
        {
            uielement.LostStylusCaptureActionWithArgs = loststyluscaptureActionWithArgs;
            return uielement;
        }
        public static T OnLostTouchCapture<T>(this T uielement, Action losttouchcaptureAction) where T : IRxUIElement
        {
            uielement.LostTouchCaptureAction = losttouchcaptureAction;
            return uielement;
        }

        public static T OnLostTouchCapture<T>(this T uielement, Action<TouchEventArgs> losttouchcaptureActionWithArgs) where T : IRxUIElement
        {
            uielement.LostTouchCaptureActionWithArgs = losttouchcaptureActionWithArgs;
            return uielement;
        }
        public static T OnManipulationBoundaryFeedback<T>(this T uielement, Action manipulationboundaryfeedbackAction) where T : IRxUIElement
        {
            uielement.ManipulationBoundaryFeedbackAction = manipulationboundaryfeedbackAction;
            return uielement;
        }

        public static T OnManipulationBoundaryFeedback<T>(this T uielement, Action<ManipulationBoundaryFeedbackEventArgs> manipulationboundaryfeedbackActionWithArgs) where T : IRxUIElement
        {
            uielement.ManipulationBoundaryFeedbackActionWithArgs = manipulationboundaryfeedbackActionWithArgs;
            return uielement;
        }
        public static T OnManipulationCompleted<T>(this T uielement, Action manipulationcompletedAction) where T : IRxUIElement
        {
            uielement.ManipulationCompletedAction = manipulationcompletedAction;
            return uielement;
        }

        public static T OnManipulationCompleted<T>(this T uielement, Action<ManipulationCompletedEventArgs> manipulationcompletedActionWithArgs) where T : IRxUIElement
        {
            uielement.ManipulationCompletedActionWithArgs = manipulationcompletedActionWithArgs;
            return uielement;
        }
        public static T OnManipulationDelta<T>(this T uielement, Action manipulationdeltaAction) where T : IRxUIElement
        {
            uielement.ManipulationDeltaAction = manipulationdeltaAction;
            return uielement;
        }

        public static T OnManipulationDelta<T>(this T uielement, Action<ManipulationDeltaEventArgs> manipulationdeltaActionWithArgs) where T : IRxUIElement
        {
            uielement.ManipulationDeltaActionWithArgs = manipulationdeltaActionWithArgs;
            return uielement;
        }
        public static T OnManipulationInertiaStarting<T>(this T uielement, Action manipulationinertiastartingAction) where T : IRxUIElement
        {
            uielement.ManipulationInertiaStartingAction = manipulationinertiastartingAction;
            return uielement;
        }

        public static T OnManipulationInertiaStarting<T>(this T uielement, Action<ManipulationInertiaStartingEventArgs> manipulationinertiastartingActionWithArgs) where T : IRxUIElement
        {
            uielement.ManipulationInertiaStartingActionWithArgs = manipulationinertiastartingActionWithArgs;
            return uielement;
        }
        public static T OnManipulationStarted<T>(this T uielement, Action manipulationstartedAction) where T : IRxUIElement
        {
            uielement.ManipulationStartedAction = manipulationstartedAction;
            return uielement;
        }

        public static T OnManipulationStarted<T>(this T uielement, Action<ManipulationStartedEventArgs> manipulationstartedActionWithArgs) where T : IRxUIElement
        {
            uielement.ManipulationStartedActionWithArgs = manipulationstartedActionWithArgs;
            return uielement;
        }
        public static T OnManipulationStarting<T>(this T uielement, Action manipulationstartingAction) where T : IRxUIElement
        {
            uielement.ManipulationStartingAction = manipulationstartingAction;
            return uielement;
        }

        public static T OnManipulationStarting<T>(this T uielement, Action<ManipulationStartingEventArgs> manipulationstartingActionWithArgs) where T : IRxUIElement
        {
            uielement.ManipulationStartingActionWithArgs = manipulationstartingActionWithArgs;
            return uielement;
        }
        public static T OnMouseDown<T>(this T uielement, Action mousedownAction) where T : IRxUIElement
        {
            uielement.MouseDownAction = mousedownAction;
            return uielement;
        }

        public static T OnMouseDown<T>(this T uielement, Action<MouseButtonEventArgs> mousedownActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseDownActionWithArgs = mousedownActionWithArgs;
            return uielement;
        }
        public static T OnMouseEnter<T>(this T uielement, Action mouseenterAction) where T : IRxUIElement
        {
            uielement.MouseEnterAction = mouseenterAction;
            return uielement;
        }

        public static T OnMouseEnter<T>(this T uielement, Action<MouseEventArgs> mouseenterActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseEnterActionWithArgs = mouseenterActionWithArgs;
            return uielement;
        }
        public static T OnMouseLeave<T>(this T uielement, Action mouseleaveAction) where T : IRxUIElement
        {
            uielement.MouseLeaveAction = mouseleaveAction;
            return uielement;
        }

        public static T OnMouseLeave<T>(this T uielement, Action<MouseEventArgs> mouseleaveActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseLeaveActionWithArgs = mouseleaveActionWithArgs;
            return uielement;
        }
        public static T OnMouseLeftButtonDown<T>(this T uielement, Action mouseleftbuttondownAction) where T : IRxUIElement
        {
            uielement.MouseLeftButtonDownAction = mouseleftbuttondownAction;
            return uielement;
        }

        public static T OnMouseLeftButtonDown<T>(this T uielement, Action<MouseButtonEventArgs> mouseleftbuttondownActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseLeftButtonDownActionWithArgs = mouseleftbuttondownActionWithArgs;
            return uielement;
        }
        public static T OnMouseLeftButtonUp<T>(this T uielement, Action mouseleftbuttonupAction) where T : IRxUIElement
        {
            uielement.MouseLeftButtonUpAction = mouseleftbuttonupAction;
            return uielement;
        }

        public static T OnMouseLeftButtonUp<T>(this T uielement, Action<MouseButtonEventArgs> mouseleftbuttonupActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseLeftButtonUpActionWithArgs = mouseleftbuttonupActionWithArgs;
            return uielement;
        }
        public static T OnMouseMove<T>(this T uielement, Action mousemoveAction) where T : IRxUIElement
        {
            uielement.MouseMoveAction = mousemoveAction;
            return uielement;
        }

        public static T OnMouseMove<T>(this T uielement, Action<MouseEventArgs> mousemoveActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseMoveActionWithArgs = mousemoveActionWithArgs;
            return uielement;
        }
        public static T OnMouseRightButtonDown<T>(this T uielement, Action mouserightbuttondownAction) where T : IRxUIElement
        {
            uielement.MouseRightButtonDownAction = mouserightbuttondownAction;
            return uielement;
        }

        public static T OnMouseRightButtonDown<T>(this T uielement, Action<MouseButtonEventArgs> mouserightbuttondownActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseRightButtonDownActionWithArgs = mouserightbuttondownActionWithArgs;
            return uielement;
        }
        public static T OnMouseRightButtonUp<T>(this T uielement, Action mouserightbuttonupAction) where T : IRxUIElement
        {
            uielement.MouseRightButtonUpAction = mouserightbuttonupAction;
            return uielement;
        }

        public static T OnMouseRightButtonUp<T>(this T uielement, Action<MouseButtonEventArgs> mouserightbuttonupActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseRightButtonUpActionWithArgs = mouserightbuttonupActionWithArgs;
            return uielement;
        }
        public static T OnMouseUp<T>(this T uielement, Action mouseupAction) where T : IRxUIElement
        {
            uielement.MouseUpAction = mouseupAction;
            return uielement;
        }

        public static T OnMouseUp<T>(this T uielement, Action<MouseButtonEventArgs> mouseupActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseUpActionWithArgs = mouseupActionWithArgs;
            return uielement;
        }
        public static T OnMouseWheel<T>(this T uielement, Action mousewheelAction) where T : IRxUIElement
        {
            uielement.MouseWheelAction = mousewheelAction;
            return uielement;
        }

        public static T OnMouseWheel<T>(this T uielement, Action<MouseWheelEventArgs> mousewheelActionWithArgs) where T : IRxUIElement
        {
            uielement.MouseWheelActionWithArgs = mousewheelActionWithArgs;
            return uielement;
        }
        public static T OnPreviewDragEnter<T>(this T uielement, Action previewdragenterAction) where T : IRxUIElement
        {
            uielement.PreviewDragEnterAction = previewdragenterAction;
            return uielement;
        }

        public static T OnPreviewDragEnter<T>(this T uielement, Action<DragEventArgs> previewdragenterActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewDragEnterActionWithArgs = previewdragenterActionWithArgs;
            return uielement;
        }
        public static T OnPreviewDragLeave<T>(this T uielement, Action previewdragleaveAction) where T : IRxUIElement
        {
            uielement.PreviewDragLeaveAction = previewdragleaveAction;
            return uielement;
        }

        public static T OnPreviewDragLeave<T>(this T uielement, Action<DragEventArgs> previewdragleaveActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewDragLeaveActionWithArgs = previewdragleaveActionWithArgs;
            return uielement;
        }
        public static T OnPreviewDragOver<T>(this T uielement, Action previewdragoverAction) where T : IRxUIElement
        {
            uielement.PreviewDragOverAction = previewdragoverAction;
            return uielement;
        }

        public static T OnPreviewDragOver<T>(this T uielement, Action<DragEventArgs> previewdragoverActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewDragOverActionWithArgs = previewdragoverActionWithArgs;
            return uielement;
        }
        public static T OnPreviewDrop<T>(this T uielement, Action previewdropAction) where T : IRxUIElement
        {
            uielement.PreviewDropAction = previewdropAction;
            return uielement;
        }

        public static T OnPreviewDrop<T>(this T uielement, Action<DragEventArgs> previewdropActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewDropActionWithArgs = previewdropActionWithArgs;
            return uielement;
        }
        public static T OnPreviewGiveFeedback<T>(this T uielement, Action previewgivefeedbackAction) where T : IRxUIElement
        {
            uielement.PreviewGiveFeedbackAction = previewgivefeedbackAction;
            return uielement;
        }

        public static T OnPreviewGiveFeedback<T>(this T uielement, Action<GiveFeedbackEventArgs> previewgivefeedbackActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewGiveFeedbackActionWithArgs = previewgivefeedbackActionWithArgs;
            return uielement;
        }
        public static T OnPreviewGotKeyboardFocus<T>(this T uielement, Action previewgotkeyboardfocusAction) where T : IRxUIElement
        {
            uielement.PreviewGotKeyboardFocusAction = previewgotkeyboardfocusAction;
            return uielement;
        }

        public static T OnPreviewGotKeyboardFocus<T>(this T uielement, Action<KeyboardFocusChangedEventArgs> previewgotkeyboardfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewGotKeyboardFocusActionWithArgs = previewgotkeyboardfocusActionWithArgs;
            return uielement;
        }
        public static T OnPreviewKeyDown<T>(this T uielement, Action previewkeydownAction) where T : IRxUIElement
        {
            uielement.PreviewKeyDownAction = previewkeydownAction;
            return uielement;
        }

        public static T OnPreviewKeyDown<T>(this T uielement, Action<KeyEventArgs> previewkeydownActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewKeyDownActionWithArgs = previewkeydownActionWithArgs;
            return uielement;
        }
        public static T OnPreviewKeyUp<T>(this T uielement, Action previewkeyupAction) where T : IRxUIElement
        {
            uielement.PreviewKeyUpAction = previewkeyupAction;
            return uielement;
        }

        public static T OnPreviewKeyUp<T>(this T uielement, Action<KeyEventArgs> previewkeyupActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewKeyUpActionWithArgs = previewkeyupActionWithArgs;
            return uielement;
        }
        public static T OnPreviewLostKeyboardFocus<T>(this T uielement, Action previewlostkeyboardfocusAction) where T : IRxUIElement
        {
            uielement.PreviewLostKeyboardFocusAction = previewlostkeyboardfocusAction;
            return uielement;
        }

        public static T OnPreviewLostKeyboardFocus<T>(this T uielement, Action<KeyboardFocusChangedEventArgs> previewlostkeyboardfocusActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewLostKeyboardFocusActionWithArgs = previewlostkeyboardfocusActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseDown<T>(this T uielement, Action previewmousedownAction) where T : IRxUIElement
        {
            uielement.PreviewMouseDownAction = previewmousedownAction;
            return uielement;
        }

        public static T OnPreviewMouseDown<T>(this T uielement, Action<MouseButtonEventArgs> previewmousedownActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseDownActionWithArgs = previewmousedownActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseLeftButtonDown<T>(this T uielement, Action previewmouseleftbuttondownAction) where T : IRxUIElement
        {
            uielement.PreviewMouseLeftButtonDownAction = previewmouseleftbuttondownAction;
            return uielement;
        }

        public static T OnPreviewMouseLeftButtonDown<T>(this T uielement, Action<MouseButtonEventArgs> previewmouseleftbuttondownActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseLeftButtonDownActionWithArgs = previewmouseleftbuttondownActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseLeftButtonUp<T>(this T uielement, Action previewmouseleftbuttonupAction) where T : IRxUIElement
        {
            uielement.PreviewMouseLeftButtonUpAction = previewmouseleftbuttonupAction;
            return uielement;
        }

        public static T OnPreviewMouseLeftButtonUp<T>(this T uielement, Action<MouseButtonEventArgs> previewmouseleftbuttonupActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseLeftButtonUpActionWithArgs = previewmouseleftbuttonupActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseMove<T>(this T uielement, Action previewmousemoveAction) where T : IRxUIElement
        {
            uielement.PreviewMouseMoveAction = previewmousemoveAction;
            return uielement;
        }

        public static T OnPreviewMouseMove<T>(this T uielement, Action<MouseEventArgs> previewmousemoveActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseMoveActionWithArgs = previewmousemoveActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseRightButtonDown<T>(this T uielement, Action previewmouserightbuttondownAction) where T : IRxUIElement
        {
            uielement.PreviewMouseRightButtonDownAction = previewmouserightbuttondownAction;
            return uielement;
        }

        public static T OnPreviewMouseRightButtonDown<T>(this T uielement, Action<MouseButtonEventArgs> previewmouserightbuttondownActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseRightButtonDownActionWithArgs = previewmouserightbuttondownActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseRightButtonUp<T>(this T uielement, Action previewmouserightbuttonupAction) where T : IRxUIElement
        {
            uielement.PreviewMouseRightButtonUpAction = previewmouserightbuttonupAction;
            return uielement;
        }

        public static T OnPreviewMouseRightButtonUp<T>(this T uielement, Action<MouseButtonEventArgs> previewmouserightbuttonupActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseRightButtonUpActionWithArgs = previewmouserightbuttonupActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseUp<T>(this T uielement, Action previewmouseupAction) where T : IRxUIElement
        {
            uielement.PreviewMouseUpAction = previewmouseupAction;
            return uielement;
        }

        public static T OnPreviewMouseUp<T>(this T uielement, Action<MouseButtonEventArgs> previewmouseupActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseUpActionWithArgs = previewmouseupActionWithArgs;
            return uielement;
        }
        public static T OnPreviewMouseWheel<T>(this T uielement, Action previewmousewheelAction) where T : IRxUIElement
        {
            uielement.PreviewMouseWheelAction = previewmousewheelAction;
            return uielement;
        }

        public static T OnPreviewMouseWheel<T>(this T uielement, Action<MouseWheelEventArgs> previewmousewheelActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewMouseWheelActionWithArgs = previewmousewheelActionWithArgs;
            return uielement;
        }
        public static T OnPreviewQueryContinueDrag<T>(this T uielement, Action previewquerycontinuedragAction) where T : IRxUIElement
        {
            uielement.PreviewQueryContinueDragAction = previewquerycontinuedragAction;
            return uielement;
        }

        public static T OnPreviewQueryContinueDrag<T>(this T uielement, Action<QueryContinueDragEventArgs> previewquerycontinuedragActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewQueryContinueDragActionWithArgs = previewquerycontinuedragActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusButtonDown<T>(this T uielement, Action previewstylusbuttondownAction) where T : IRxUIElement
        {
            uielement.PreviewStylusButtonDownAction = previewstylusbuttondownAction;
            return uielement;
        }

        public static T OnPreviewStylusButtonDown<T>(this T uielement, Action<StylusButtonEventArgs> previewstylusbuttondownActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusButtonDownActionWithArgs = previewstylusbuttondownActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusButtonUp<T>(this T uielement, Action previewstylusbuttonupAction) where T : IRxUIElement
        {
            uielement.PreviewStylusButtonUpAction = previewstylusbuttonupAction;
            return uielement;
        }

        public static T OnPreviewStylusButtonUp<T>(this T uielement, Action<StylusButtonEventArgs> previewstylusbuttonupActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusButtonUpActionWithArgs = previewstylusbuttonupActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusDown<T>(this T uielement, Action previewstylusdownAction) where T : IRxUIElement
        {
            uielement.PreviewStylusDownAction = previewstylusdownAction;
            return uielement;
        }

        public static T OnPreviewStylusDown<T>(this T uielement, Action<StylusDownEventArgs> previewstylusdownActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusDownActionWithArgs = previewstylusdownActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusInAirMove<T>(this T uielement, Action previewstylusinairmoveAction) where T : IRxUIElement
        {
            uielement.PreviewStylusInAirMoveAction = previewstylusinairmoveAction;
            return uielement;
        }

        public static T OnPreviewStylusInAirMove<T>(this T uielement, Action<StylusEventArgs> previewstylusinairmoveActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusInAirMoveActionWithArgs = previewstylusinairmoveActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusInRange<T>(this T uielement, Action previewstylusinrangeAction) where T : IRxUIElement
        {
            uielement.PreviewStylusInRangeAction = previewstylusinrangeAction;
            return uielement;
        }

        public static T OnPreviewStylusInRange<T>(this T uielement, Action<StylusEventArgs> previewstylusinrangeActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusInRangeActionWithArgs = previewstylusinrangeActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusMove<T>(this T uielement, Action previewstylusmoveAction) where T : IRxUIElement
        {
            uielement.PreviewStylusMoveAction = previewstylusmoveAction;
            return uielement;
        }

        public static T OnPreviewStylusMove<T>(this T uielement, Action<StylusEventArgs> previewstylusmoveActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusMoveActionWithArgs = previewstylusmoveActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusOutOfRange<T>(this T uielement, Action previewstylusoutofrangeAction) where T : IRxUIElement
        {
            uielement.PreviewStylusOutOfRangeAction = previewstylusoutofrangeAction;
            return uielement;
        }

        public static T OnPreviewStylusOutOfRange<T>(this T uielement, Action<StylusEventArgs> previewstylusoutofrangeActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusOutOfRangeActionWithArgs = previewstylusoutofrangeActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusSystemGesture<T>(this T uielement, Action previewstylussystemgestureAction) where T : IRxUIElement
        {
            uielement.PreviewStylusSystemGestureAction = previewstylussystemgestureAction;
            return uielement;
        }

        public static T OnPreviewStylusSystemGesture<T>(this T uielement, Action<StylusSystemGestureEventArgs> previewstylussystemgestureActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusSystemGestureActionWithArgs = previewstylussystemgestureActionWithArgs;
            return uielement;
        }
        public static T OnPreviewStylusUp<T>(this T uielement, Action previewstylusupAction) where T : IRxUIElement
        {
            uielement.PreviewStylusUpAction = previewstylusupAction;
            return uielement;
        }

        public static T OnPreviewStylusUp<T>(this T uielement, Action<StylusEventArgs> previewstylusupActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewStylusUpActionWithArgs = previewstylusupActionWithArgs;
            return uielement;
        }
        public static T OnPreviewTextInput<T>(this T uielement, Action previewtextinputAction) where T : IRxUIElement
        {
            uielement.PreviewTextInputAction = previewtextinputAction;
            return uielement;
        }

        public static T OnPreviewTextInput<T>(this T uielement, Action<TextCompositionEventArgs> previewtextinputActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewTextInputActionWithArgs = previewtextinputActionWithArgs;
            return uielement;
        }
        public static T OnPreviewTouchDown<T>(this T uielement, Action previewtouchdownAction) where T : IRxUIElement
        {
            uielement.PreviewTouchDownAction = previewtouchdownAction;
            return uielement;
        }

        public static T OnPreviewTouchDown<T>(this T uielement, Action<TouchEventArgs> previewtouchdownActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewTouchDownActionWithArgs = previewtouchdownActionWithArgs;
            return uielement;
        }
        public static T OnPreviewTouchMove<T>(this T uielement, Action previewtouchmoveAction) where T : IRxUIElement
        {
            uielement.PreviewTouchMoveAction = previewtouchmoveAction;
            return uielement;
        }

        public static T OnPreviewTouchMove<T>(this T uielement, Action<TouchEventArgs> previewtouchmoveActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewTouchMoveActionWithArgs = previewtouchmoveActionWithArgs;
            return uielement;
        }
        public static T OnPreviewTouchUp<T>(this T uielement, Action previewtouchupAction) where T : IRxUIElement
        {
            uielement.PreviewTouchUpAction = previewtouchupAction;
            return uielement;
        }

        public static T OnPreviewTouchUp<T>(this T uielement, Action<TouchEventArgs> previewtouchupActionWithArgs) where T : IRxUIElement
        {
            uielement.PreviewTouchUpActionWithArgs = previewtouchupActionWithArgs;
            return uielement;
        }
        public static T OnQueryContinueDrag<T>(this T uielement, Action querycontinuedragAction) where T : IRxUIElement
        {
            uielement.QueryContinueDragAction = querycontinuedragAction;
            return uielement;
        }

        public static T OnQueryContinueDrag<T>(this T uielement, Action<QueryContinueDragEventArgs> querycontinuedragActionWithArgs) where T : IRxUIElement
        {
            uielement.QueryContinueDragActionWithArgs = querycontinuedragActionWithArgs;
            return uielement;
        }
        public static T OnQueryCursor<T>(this T uielement, Action querycursorAction) where T : IRxUIElement
        {
            uielement.QueryCursorAction = querycursorAction;
            return uielement;
        }

        public static T OnQueryCursor<T>(this T uielement, Action<QueryCursorEventArgs> querycursorActionWithArgs) where T : IRxUIElement
        {
            uielement.QueryCursorActionWithArgs = querycursorActionWithArgs;
            return uielement;
        }
        public static T OnStylusButtonDown<T>(this T uielement, Action stylusbuttondownAction) where T : IRxUIElement
        {
            uielement.StylusButtonDownAction = stylusbuttondownAction;
            return uielement;
        }

        public static T OnStylusButtonDown<T>(this T uielement, Action<StylusButtonEventArgs> stylusbuttondownActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusButtonDownActionWithArgs = stylusbuttondownActionWithArgs;
            return uielement;
        }
        public static T OnStylusButtonUp<T>(this T uielement, Action stylusbuttonupAction) where T : IRxUIElement
        {
            uielement.StylusButtonUpAction = stylusbuttonupAction;
            return uielement;
        }

        public static T OnStylusButtonUp<T>(this T uielement, Action<StylusButtonEventArgs> stylusbuttonupActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusButtonUpActionWithArgs = stylusbuttonupActionWithArgs;
            return uielement;
        }
        public static T OnStylusDown<T>(this T uielement, Action stylusdownAction) where T : IRxUIElement
        {
            uielement.StylusDownAction = stylusdownAction;
            return uielement;
        }

        public static T OnStylusDown<T>(this T uielement, Action<StylusDownEventArgs> stylusdownActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusDownActionWithArgs = stylusdownActionWithArgs;
            return uielement;
        }
        public static T OnStylusEnter<T>(this T uielement, Action stylusenterAction) where T : IRxUIElement
        {
            uielement.StylusEnterAction = stylusenterAction;
            return uielement;
        }

        public static T OnStylusEnter<T>(this T uielement, Action<StylusEventArgs> stylusenterActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusEnterActionWithArgs = stylusenterActionWithArgs;
            return uielement;
        }
        public static T OnStylusInAirMove<T>(this T uielement, Action stylusinairmoveAction) where T : IRxUIElement
        {
            uielement.StylusInAirMoveAction = stylusinairmoveAction;
            return uielement;
        }

        public static T OnStylusInAirMove<T>(this T uielement, Action<StylusEventArgs> stylusinairmoveActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusInAirMoveActionWithArgs = stylusinairmoveActionWithArgs;
            return uielement;
        }
        public static T OnStylusInRange<T>(this T uielement, Action stylusinrangeAction) where T : IRxUIElement
        {
            uielement.StylusInRangeAction = stylusinrangeAction;
            return uielement;
        }

        public static T OnStylusInRange<T>(this T uielement, Action<StylusEventArgs> stylusinrangeActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusInRangeActionWithArgs = stylusinrangeActionWithArgs;
            return uielement;
        }
        public static T OnStylusLeave<T>(this T uielement, Action stylusleaveAction) where T : IRxUIElement
        {
            uielement.StylusLeaveAction = stylusleaveAction;
            return uielement;
        }

        public static T OnStylusLeave<T>(this T uielement, Action<StylusEventArgs> stylusleaveActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusLeaveActionWithArgs = stylusleaveActionWithArgs;
            return uielement;
        }
        public static T OnStylusMove<T>(this T uielement, Action stylusmoveAction) where T : IRxUIElement
        {
            uielement.StylusMoveAction = stylusmoveAction;
            return uielement;
        }

        public static T OnStylusMove<T>(this T uielement, Action<StylusEventArgs> stylusmoveActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusMoveActionWithArgs = stylusmoveActionWithArgs;
            return uielement;
        }
        public static T OnStylusOutOfRange<T>(this T uielement, Action stylusoutofrangeAction) where T : IRxUIElement
        {
            uielement.StylusOutOfRangeAction = stylusoutofrangeAction;
            return uielement;
        }

        public static T OnStylusOutOfRange<T>(this T uielement, Action<StylusEventArgs> stylusoutofrangeActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusOutOfRangeActionWithArgs = stylusoutofrangeActionWithArgs;
            return uielement;
        }
        public static T OnStylusSystemGesture<T>(this T uielement, Action stylussystemgestureAction) where T : IRxUIElement
        {
            uielement.StylusSystemGestureAction = stylussystemgestureAction;
            return uielement;
        }

        public static T OnStylusSystemGesture<T>(this T uielement, Action<StylusSystemGestureEventArgs> stylussystemgestureActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusSystemGestureActionWithArgs = stylussystemgestureActionWithArgs;
            return uielement;
        }
        public static T OnStylusUp<T>(this T uielement, Action stylusupAction) where T : IRxUIElement
        {
            uielement.StylusUpAction = stylusupAction;
            return uielement;
        }

        public static T OnStylusUp<T>(this T uielement, Action<StylusEventArgs> stylusupActionWithArgs) where T : IRxUIElement
        {
            uielement.StylusUpActionWithArgs = stylusupActionWithArgs;
            return uielement;
        }
        public static T OnTextInput<T>(this T uielement, Action textinputAction) where T : IRxUIElement
        {
            uielement.TextInputAction = textinputAction;
            return uielement;
        }

        public static T OnTextInput<T>(this T uielement, Action<TextCompositionEventArgs> textinputActionWithArgs) where T : IRxUIElement
        {
            uielement.TextInputActionWithArgs = textinputActionWithArgs;
            return uielement;
        }
        public static T OnTouchDown<T>(this T uielement, Action touchdownAction) where T : IRxUIElement
        {
            uielement.TouchDownAction = touchdownAction;
            return uielement;
        }

        public static T OnTouchDown<T>(this T uielement, Action<TouchEventArgs> touchdownActionWithArgs) where T : IRxUIElement
        {
            uielement.TouchDownActionWithArgs = touchdownActionWithArgs;
            return uielement;
        }
        public static T OnTouchEnter<T>(this T uielement, Action touchenterAction) where T : IRxUIElement
        {
            uielement.TouchEnterAction = touchenterAction;
            return uielement;
        }

        public static T OnTouchEnter<T>(this T uielement, Action<TouchEventArgs> touchenterActionWithArgs) where T : IRxUIElement
        {
            uielement.TouchEnterActionWithArgs = touchenterActionWithArgs;
            return uielement;
        }
        public static T OnTouchLeave<T>(this T uielement, Action touchleaveAction) where T : IRxUIElement
        {
            uielement.TouchLeaveAction = touchleaveAction;
            return uielement;
        }

        public static T OnTouchLeave<T>(this T uielement, Action<TouchEventArgs> touchleaveActionWithArgs) where T : IRxUIElement
        {
            uielement.TouchLeaveActionWithArgs = touchleaveActionWithArgs;
            return uielement;
        }
        public static T OnTouchMove<T>(this T uielement, Action touchmoveAction) where T : IRxUIElement
        {
            uielement.TouchMoveAction = touchmoveAction;
            return uielement;
        }

        public static T OnTouchMove<T>(this T uielement, Action<TouchEventArgs> touchmoveActionWithArgs) where T : IRxUIElement
        {
            uielement.TouchMoveActionWithArgs = touchmoveActionWithArgs;
            return uielement;
        }
        public static T OnTouchUp<T>(this T uielement, Action touchupAction) where T : IRxUIElement
        {
            uielement.TouchUpAction = touchupAction;
            return uielement;
        }

        public static T OnTouchUp<T>(this T uielement, Action<TouchEventArgs> touchupActionWithArgs) where T : IRxUIElement
        {
            uielement.TouchUpActionWithArgs = touchupActionWithArgs;
            return uielement;
        }
    }
}
