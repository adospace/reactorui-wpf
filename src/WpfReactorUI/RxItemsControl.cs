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

using WpfReactorUI.Internals;

namespace WpfReactorUI
{
    public partial interface IRxItemsControl : IRxControl
    {
        PropertyValue<int> AlternationCount { get; set; }
        PropertyValue<string> DisplayMemberPath { get; set; }
        PropertyValue<bool> IsTextSearchCaseSensitive { get; set; }
        PropertyValue<bool> IsTextSearchEnabled { get; set; }
        PropertyValue<Style> ItemContainerStyle { get; set; }
        PropertyValue<IEnumerable> ItemsSource { get; set; }
        PropertyValue<string> ItemStringFormat { get; set; }

    }

    public partial class RxItemsControl<T> : RxControl<T>, IRxItemsControl where T : ItemsControl, new()
    {
        public RxItemsControl()
        {

        }

        public RxItemsControl(Action<T> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<int> IRxItemsControl.AlternationCount { get; set; }
        PropertyValue<string> IRxItemsControl.DisplayMemberPath { get; set; }
        PropertyValue<bool> IRxItemsControl.IsTextSearchCaseSensitive { get; set; }
        PropertyValue<bool> IRxItemsControl.IsTextSearchEnabled { get; set; }
        PropertyValue<Style> IRxItemsControl.ItemContainerStyle { get; set; }
        PropertyValue<IEnumerable> IRxItemsControl.ItemsSource { get; set; }
        PropertyValue<string> IRxItemsControl.ItemStringFormat { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxItemsControl = (IRxItemsControl)this;
            NativeControl.Set(this, ItemsControl.AlternationCountProperty, thisAsIRxItemsControl.AlternationCount);
            NativeControl.Set(this, ItemsControl.DisplayMemberPathProperty, thisAsIRxItemsControl.DisplayMemberPath);
            NativeControl.Set(this, ItemsControl.IsTextSearchCaseSensitiveProperty, thisAsIRxItemsControl.IsTextSearchCaseSensitive);
            NativeControl.Set(this, ItemsControl.IsTextSearchEnabledProperty, thisAsIRxItemsControl.IsTextSearchEnabled);
            NativeControl.Set(this, ItemsControl.ItemContainerStyleProperty, thisAsIRxItemsControl.ItemContainerStyle);
            NativeControl.Set(this, ItemsControl.ItemsSourceProperty, thisAsIRxItemsControl.ItemsSource);
            NativeControl.Set(this, ItemsControl.ItemStringFormatProperty, thisAsIRxItemsControl.ItemStringFormat);

            base.OnUpdate();

            OnEndUpdate();
        }

        partial void OnBeginUpdate();
        partial void OnEndUpdate();

        protected override void OnAttachNativeEvents()
        {
            var thisAsIRxItemsControl = (IRxItemsControl)this;

            base.OnAttachNativeEvents();
        }


        protected override void OnDetachNativeEvents()
        {
            if (NativeControl != null)
            {
            }

            base.OnDetachNativeEvents();
        }

    }
    public partial class RxItemsControl : RxItemsControl<ItemsControl>
    {
        public RxItemsControl()
        {

        }

        public RxItemsControl(Action<ItemsControl> componentRefAction)
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
        public static T DisplayMemberPath<T>(this T itemscontrol, string displayMemberPath) where T : IRxItemsControl
        {
            itemscontrol.DisplayMemberPath = new PropertyValue<string>(displayMemberPath);
            return itemscontrol;
        }
        public static T IsTextSearchCaseSensitive<T>(this T itemscontrol, bool isTextSearchCaseSensitive) where T : IRxItemsControl
        {
            itemscontrol.IsTextSearchCaseSensitive = new PropertyValue<bool>(isTextSearchCaseSensitive);
            return itemscontrol;
        }
        public static T IsTextSearchEnabled<T>(this T itemscontrol, bool isTextSearchEnabled) where T : IRxItemsControl
        {
            itemscontrol.IsTextSearchEnabled = new PropertyValue<bool>(isTextSearchEnabled);
            return itemscontrol;
        }
        public static T ItemContainerStyle<T>(this T itemscontrol, Style itemContainerStyle) where T : IRxItemsControl
        {
            itemscontrol.ItemContainerStyle = new PropertyValue<Style>(itemContainerStyle);
            return itemscontrol;
        }
        public static T ItemsSource<T>(this T itemscontrol, IEnumerable itemsSource) where T : IRxItemsControl
        {
            itemscontrol.ItemsSource = new PropertyValue<IEnumerable>(itemsSource);
            return itemscontrol;
        }
        public static T ItemStringFormat<T>(this T itemscontrol, string itemStringFormat) where T : IRxItemsControl
        {
            itemscontrol.ItemStringFormat = new PropertyValue<string>(itemStringFormat);
            return itemscontrol;
        }
    }
}
