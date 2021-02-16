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
    public partial interface IRxRectangle : IRxShape
    {
        PropertyValue<double>? RadiusX { get; set; }
        PropertyValue<double>? RadiusY { get; set; }

    }
    public partial class RxRectangle : RxShape<Rectangle>, IRxRectangle
    {
        public RxRectangle()
        {

        }

        public RxRectangle(Action<Rectangle?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<double>? IRxRectangle.RadiusX { get; set; }
        PropertyValue<double>? IRxRectangle.RadiusY { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxRectangle = (IRxRectangle)this;
            SetPropertyValue(NativeControl, Rectangle.RadiusXProperty, thisAsIRxRectangle.RadiusX);
            SetPropertyValue(NativeControl, Rectangle.RadiusYProperty, thisAsIRxRectangle.RadiusY);

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
    public static partial class RxRectangleExtensions
    {
        public static T RadiusX<T>(this T rectangle, double radiusX) where T : IRxRectangle
        {
            rectangle.RadiusX = new PropertyValue<double>(radiusX);
            return rectangle;
        }
        public static T RadiusX<T>(this T rectangle, Func<double> radiusXFunc) where T : IRxRectangle
        {
            rectangle.RadiusX = new PropertyValue<double>(radiusXFunc);
            return rectangle;
        }
        public static T RadiusY<T>(this T rectangle, double radiusY) where T : IRxRectangle
        {
            rectangle.RadiusY = new PropertyValue<double>(radiusY);
            return rectangle;
        }
        public static T RadiusY<T>(this T rectangle, Func<double> radiusYFunc) where T : IRxRectangle
        {
            rectangle.RadiusY = new PropertyValue<double>(radiusYFunc);
            return rectangle;
        }
    }
}
