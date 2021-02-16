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
    public partial interface IRxPath : IRxShape
    {
        PropertyValue<Geometry>? Data { get; set; }

    }
    public partial class RxPath : RxShape<Path>, IRxPath
    {
        public RxPath()
        {

        }

        public RxPath(Action<Path?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<Geometry>? IRxPath.Data { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxPath = (IRxPath)this;
            SetPropertyValue(NativeControl, Path.DataProperty, thisAsIRxPath.Data);

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
    public static partial class RxPathExtensions
    {
        public static T Data<T>(this T path, Geometry data) where T : IRxPath
        {
            path.Data = new PropertyValue<Geometry>(data);
            return path;
        }
        public static T Data<T>(this T path, Func<Geometry> dataFunc) where T : IRxPath
        {
            path.Data = new PropertyValue<Geometry>(dataFunc);
            return path;
        }
    }
}
