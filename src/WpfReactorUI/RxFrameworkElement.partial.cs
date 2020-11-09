﻿using System;
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
    public static partial class RxFrameworkElementExtensions
    {
        public static T HLeft<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(System.Windows.HorizontalAlignment.Left);
            return layoutable;
        }

        public static T HCenter<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(System.Windows.HorizontalAlignment.Center);
            return layoutable;
        }

        public static T HRight<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(System.Windows.HorizontalAlignment.Right);
            return layoutable;
        }

        public static T HStretch<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.HorizontalAlignment = new PropertyValue<HorizontalAlignment>(System.Windows.HorizontalAlignment.Stretch);
            return layoutable;
        }

        public static T VTop<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(System.Windows.VerticalAlignment.Top);
            return layoutable;
        }

        public static T VCenter<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(System.Windows.VerticalAlignment.Center);
            return layoutable;
        }

        public static T VBottom<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(System.Windows.VerticalAlignment.Bottom);
            return layoutable;
        }

        public static T VStretch<T>(this T layoutable) where T : IRxFrameworkElement
        {
            layoutable.VerticalAlignment = new PropertyValue<VerticalAlignment>(System.Windows.VerticalAlignment.Stretch);
            return layoutable;
        }
    }
}