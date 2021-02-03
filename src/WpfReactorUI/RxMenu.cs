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
    public partial interface IRxMenu : IRxMenuBase
    {
        PropertyValue<bool>? IsMainMenu { get; set; }

    }
    public partial class RxMenu<T> : RxMenuBase<T>, IRxMenu where T : Menu, new()
    {
        public RxMenu()
        {

        }

        public RxMenu(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxMenu.IsMainMenu { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxMenu = (IRxMenu)this;
            SetPropertyValue(NativeControl, Menu.IsMainMenuProperty, thisAsIRxMenu.IsMainMenu);

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
    public partial class RxMenu : RxMenu<Menu>
    {
        public RxMenu()
        {

        }

        public RxMenu(Action<Menu?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxMenuExtensions
    {
        public static T IsMainMenu<T>(this T menu, bool isMainMenu) where T : IRxMenu
        {
            menu.IsMainMenu = new PropertyValue<bool>(isMainMenu);
            return menu;
        }
        public static T IsMainMenu<T>(this T menu, Func<bool> isMainMenuFunc) where T : IRxMenu
        {
            menu.IsMainMenu = new PropertyValue<bool>(isMainMenuFunc);
            return menu;
        }
    }
}
