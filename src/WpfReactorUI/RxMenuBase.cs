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
    public partial interface IRxMenuBase : IRxItemsControl
    {
        PropertyValue<ItemContainerTemplateSelector>? ItemContainerTemplateSelector { get; set; }
        PropertyValue<bool>? UsesItemContainerTemplate { get; set; }

    }
    public partial class RxMenuBase<T> : RxItemsControl<T>, IRxMenuBase where T : MenuBase, new()
    {
        public RxMenuBase()
        {

        }

        public RxMenuBase(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<ItemContainerTemplateSelector>? IRxMenuBase.ItemContainerTemplateSelector { get; set; }
        PropertyValue<bool>? IRxMenuBase.UsesItemContainerTemplate { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxMenuBase = (IRxMenuBase)this;
            SetPropertyValue(NativeControl, MenuBase.ItemContainerTemplateSelectorProperty, thisAsIRxMenuBase.ItemContainerTemplateSelector);
            SetPropertyValue(NativeControl, MenuBase.UsesItemContainerTemplateProperty, thisAsIRxMenuBase.UsesItemContainerTemplate);

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
    public static partial class RxMenuBaseExtensions
    {
        public static T ItemContainerTemplateSelector<T>(this T menubase, ItemContainerTemplateSelector itemContainerTemplateSelector) where T : IRxMenuBase
        {
            menubase.ItemContainerTemplateSelector = new PropertyValue<ItemContainerTemplateSelector>(itemContainerTemplateSelector);
            return menubase;
        }
        public static T ItemContainerTemplateSelector<T>(this T menubase, Func<ItemContainerTemplateSelector> itemContainerTemplateSelectorFunc) where T : IRxMenuBase
        {
            menubase.ItemContainerTemplateSelector = new PropertyValue<ItemContainerTemplateSelector>(itemContainerTemplateSelectorFunc);
            return menubase;
        }
        public static T UsesItemContainerTemplate<T>(this T menubase, bool usesItemContainerTemplate) where T : IRxMenuBase
        {
            menubase.UsesItemContainerTemplate = new PropertyValue<bool>(usesItemContainerTemplate);
            return menubase;
        }
        public static T UsesItemContainerTemplate<T>(this T menubase, Func<bool> usesItemContainerTemplateFunc) where T : IRxMenuBase
        {
            menubase.UsesItemContainerTemplate = new PropertyValue<bool>(usesItemContainerTemplateFunc);
            return menubase;
        }
    }
}
