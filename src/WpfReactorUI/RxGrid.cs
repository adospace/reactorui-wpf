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
    public partial interface IRxGrid : IRxPanel
    {
        PropertyValue<bool>? ShowGridLines { get; set; }

    }

    public partial class RxGrid<T> : RxPanel<T>, IRxGrid where T : Grid, new()
    {
        public RxGrid()
        {

        }

        public RxGrid(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<bool>? IRxGrid.ShowGridLines { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxGrid = (IRxGrid)this;
            SetPropertyValue(NativeControl, Grid.ShowGridLinesProperty, thisAsIRxGrid.ShowGridLines);

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
    public partial class RxGrid : RxGrid<Grid>
    {
        public RxGrid()
        {

        }

        public RxGrid(Action<Grid?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxGridExtensions
    {
        public static T ShowGridLines<T>(this T grid, bool showGridLines) where T : IRxGrid
        {
            grid.ShowGridLines = new PropertyValue<bool>(showGridLines);
            return grid;
        }
        public static T ShowGridLines<T>(this T grid, Func<bool> showGridLinesFunc) where T : IRxGrid
        {
            grid.ShowGridLines = new PropertyValue<bool>(showGridLinesFunc);
            return grid;
        }
    }
}
