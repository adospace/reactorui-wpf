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
    public partial interface IRxItemsControl : IRxControl
    {
        PropertyValue<int>? AlternationCount { get; set; }
        PropertyValue<string>? DisplayMemberPath { get; set; }
        PropertyValue<bool>? IsTextSearchCaseSensitive { get; set; }
        PropertyValue<bool>? IsTextSearchEnabled { get; set; }
        PropertyValue<Style>? ItemContainerStyle { get; set; }
        PropertyValue<IEnumerable>? ItemsSource { get; set; }
        PropertyValue<string>? ItemStringFormat { get; set; }

    }
    public partial class RxItemsControl<T> : RxControl<T>, IRxItemsControl where T : ItemsControl, new()
    {
        public RxItemsControl()
        {

        }

        public RxItemsControl(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<int>? IRxItemsControl.AlternationCount { get; set; }
        PropertyValue<string>? IRxItemsControl.DisplayMemberPath { get; set; }
        PropertyValue<bool>? IRxItemsControl.IsTextSearchCaseSensitive { get; set; }
        PropertyValue<bool>? IRxItemsControl.IsTextSearchEnabled { get; set; }
        PropertyValue<Style>? IRxItemsControl.ItemContainerStyle { get; set; }
        PropertyValue<IEnumerable>? IRxItemsControl.ItemsSource { get; set; }
        PropertyValue<string>? IRxItemsControl.ItemStringFormat { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxItemsControl = (IRxItemsControl)this;
            SetPropertyValue(NativeControl, ItemsControl.AlternationCountProperty, thisAsIRxItemsControl.AlternationCount);
            SetPropertyValue(NativeControl, ItemsControl.DisplayMemberPathProperty, thisAsIRxItemsControl.DisplayMemberPath);
            SetPropertyValue(NativeControl, ItemsControl.IsTextSearchCaseSensitiveProperty, thisAsIRxItemsControl.IsTextSearchCaseSensitive);
            SetPropertyValue(NativeControl, ItemsControl.IsTextSearchEnabledProperty, thisAsIRxItemsControl.IsTextSearchEnabled);
            SetPropertyValue(NativeControl, ItemsControl.ItemContainerStyleProperty, thisAsIRxItemsControl.ItemContainerStyle);
            SetPropertyValue(NativeControl, ItemsControl.ItemsSourceProperty, thisAsIRxItemsControl.ItemsSource);
            SetPropertyValue(NativeControl, ItemsControl.ItemStringFormatProperty, thisAsIRxItemsControl.ItemStringFormat);

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
    public partial class RxItemsControl : RxItemsControl<ItemsControl>
    {
        public RxItemsControl()
        {

        }

        public RxItemsControl(Action<ItemsControl?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxItemsControlExtensions
    {
        public static T AlternationCount<T>(this T itemscontrol, int alternationCount) where T : IRxItemsControl
        {
            itemscontrol.AlternationCount = new PropertyValue<int>(alternationCount);
            return itemscontrol;
        }
        public static T AlternationCount<T>(this T itemscontrol, Func<int> alternationCountFunc) where T : IRxItemsControl
        {
            itemscontrol.AlternationCount = new PropertyValue<int>(alternationCountFunc);
            return itemscontrol;
        }
        public static T DisplayMemberPath<T>(this T itemscontrol, string displayMemberPath) where T : IRxItemsControl
        {
            itemscontrol.DisplayMemberPath = new PropertyValue<string>(displayMemberPath);
            return itemscontrol;
        }
        public static T DisplayMemberPath<T>(this T itemscontrol, Func<string> displayMemberPathFunc) where T : IRxItemsControl
        {
            itemscontrol.DisplayMemberPath = new PropertyValue<string>(displayMemberPathFunc);
            return itemscontrol;
        }
        public static T IsTextSearchCaseSensitive<T>(this T itemscontrol, bool isTextSearchCaseSensitive) where T : IRxItemsControl
        {
            itemscontrol.IsTextSearchCaseSensitive = new PropertyValue<bool>(isTextSearchCaseSensitive);
            return itemscontrol;
        }
        public static T IsTextSearchCaseSensitive<T>(this T itemscontrol, Func<bool> isTextSearchCaseSensitiveFunc) where T : IRxItemsControl
        {
            itemscontrol.IsTextSearchCaseSensitive = new PropertyValue<bool>(isTextSearchCaseSensitiveFunc);
            return itemscontrol;
        }
        public static T IsTextSearchEnabled<T>(this T itemscontrol, bool isTextSearchEnabled) where T : IRxItemsControl
        {
            itemscontrol.IsTextSearchEnabled = new PropertyValue<bool>(isTextSearchEnabled);
            return itemscontrol;
        }
        public static T IsTextSearchEnabled<T>(this T itemscontrol, Func<bool> isTextSearchEnabledFunc) where T : IRxItemsControl
        {
            itemscontrol.IsTextSearchEnabled = new PropertyValue<bool>(isTextSearchEnabledFunc);
            return itemscontrol;
        }
        public static T ItemContainerStyle<T>(this T itemscontrol, Style itemContainerStyle) where T : IRxItemsControl
        {
            itemscontrol.ItemContainerStyle = new PropertyValue<Style>(itemContainerStyle);
            return itemscontrol;
        }
        public static T ItemContainerStyle<T>(this T itemscontrol, Func<Style> itemContainerStyleFunc) where T : IRxItemsControl
        {
            itemscontrol.ItemContainerStyle = new PropertyValue<Style>(itemContainerStyleFunc);
            return itemscontrol;
        }
        public static T ItemsSource<T>(this T itemscontrol, IEnumerable itemsSource) where T : IRxItemsControl
        {
            itemscontrol.ItemsSource = new PropertyValue<IEnumerable>(itemsSource);
            return itemscontrol;
        }
        public static T ItemsSource<T>(this T itemscontrol, Func<IEnumerable> itemsSourceFunc) where T : IRxItemsControl
        {
            itemscontrol.ItemsSource = new PropertyValue<IEnumerable>(itemsSourceFunc);
            return itemscontrol;
        }
        public static T ItemStringFormat<T>(this T itemscontrol, string itemStringFormat) where T : IRxItemsControl
        {
            itemscontrol.ItemStringFormat = new PropertyValue<string>(itemStringFormat);
            return itemscontrol;
        }
        public static T ItemStringFormat<T>(this T itemscontrol, Func<string> itemStringFormatFunc) where T : IRxItemsControl
        {
            itemscontrol.ItemStringFormat = new PropertyValue<string>(itemStringFormatFunc);
            return itemscontrol;
        }
    }
}
