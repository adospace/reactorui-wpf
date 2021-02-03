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
    public partial interface IRxPage : IRxFrameworkElement
    {
        PropertyValue<Brush>? Background { get; set; }
        PropertyValue<object>? Content { get; set; }
        PropertyValue<FontFamily>? FontFamily { get; set; }
        PropertyValue<double>? FontSize { get; set; }
        PropertyValue<Brush>? Foreground { get; set; }
        PropertyValue<bool>? KeepAlive { get; set; }
        PropertyValue<string>? Title { get; set; }

    }
    public partial class RxPage<T> : RxFrameworkElement<T>, IRxPage where T : Page, new()
    {
        public RxPage()
        {

        }

        public RxPage(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Brush>? IRxPage.Background { get; set; }
        PropertyValue<object>? IRxPage.Content { get; set; }
        PropertyValue<FontFamily>? IRxPage.FontFamily { get; set; }
        PropertyValue<double>? IRxPage.FontSize { get; set; }
        PropertyValue<Brush>? IRxPage.Foreground { get; set; }
        PropertyValue<bool>? IRxPage.KeepAlive { get; set; }
        PropertyValue<string>? IRxPage.Title { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxPage = (IRxPage)this;
            SetPropertyValue(NativeControl, Page.BackgroundProperty, thisAsIRxPage.Background);
            SetPropertyValue(NativeControl, Page.ContentProperty, thisAsIRxPage.Content);
            SetPropertyValue(NativeControl, Page.FontFamilyProperty, thisAsIRxPage.FontFamily);
            SetPropertyValue(NativeControl, Page.FontSizeProperty, thisAsIRxPage.FontSize);
            SetPropertyValue(NativeControl, Page.ForegroundProperty, thisAsIRxPage.Foreground);
            SetPropertyValue(NativeControl, Page.KeepAliveProperty, thisAsIRxPage.KeepAlive);
            SetPropertyValue(NativeControl, Page.TitleProperty, thisAsIRxPage.Title);

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
    public partial class RxPage : RxPage<Page>
    {
        public RxPage()
        {

        }

        public RxPage(Action<Page?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxPageExtensions
    {
        public static T Background<T>(this T page, Brush background) where T : IRxPage
        {
            page.Background = new PropertyValue<Brush>(background);
            return page;
        }
        public static T Background<T>(this T page, Func<Brush> backgroundFunc) where T : IRxPage
        {
            page.Background = new PropertyValue<Brush>(backgroundFunc);
            return page;
        }
        public static T Content<T>(this T page, object content) where T : IRxPage
        {
            page.Content = new PropertyValue<object>(content);
            return page;
        }
        public static T Content<T>(this T page, Func<object> contentFunc) where T : IRxPage
        {
            page.Content = new PropertyValue<object>(contentFunc);
            return page;
        }
        public static T FontFamily<T>(this T page, FontFamily fontFamily) where T : IRxPage
        {
            page.FontFamily = new PropertyValue<FontFamily>(fontFamily);
            return page;
        }
        public static T FontFamily<T>(this T page, Func<FontFamily> fontFamilyFunc) where T : IRxPage
        {
            page.FontFamily = new PropertyValue<FontFamily>(fontFamilyFunc);
            return page;
        }
        public static T FontSize<T>(this T page, double fontSize) where T : IRxPage
        {
            page.FontSize = new PropertyValue<double>(fontSize);
            return page;
        }
        public static T FontSize<T>(this T page, Func<double> fontSizeFunc) where T : IRxPage
        {
            page.FontSize = new PropertyValue<double>(fontSizeFunc);
            return page;
        }
        public static T Foreground<T>(this T page, Brush foreground) where T : IRxPage
        {
            page.Foreground = new PropertyValue<Brush>(foreground);
            return page;
        }
        public static T Foreground<T>(this T page, Func<Brush> foregroundFunc) where T : IRxPage
        {
            page.Foreground = new PropertyValue<Brush>(foregroundFunc);
            return page;
        }
        public static T KeepAlive<T>(this T page, bool keepAlive) where T : IRxPage
        {
            page.KeepAlive = new PropertyValue<bool>(keepAlive);
            return page;
        }
        public static T KeepAlive<T>(this T page, Func<bool> keepAliveFunc) where T : IRxPage
        {
            page.KeepAlive = new PropertyValue<bool>(keepAliveFunc);
            return page;
        }
        public static T Title<T>(this T page, string title) where T : IRxPage
        {
            page.Title = new PropertyValue<string>(title);
            return page;
        }
        public static T Title<T>(this T page, Func<string> titleFunc) where T : IRxPage
        {
            page.Title = new PropertyValue<string>(titleFunc);
            return page;
        }
    }
}
