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
    public partial interface IRxUniformGrid : IRxPanel
    {
        PropertyValue<int>? Columns { get; set; }
        PropertyValue<int>? FirstColumn { get; set; }
        PropertyValue<int>? Rows { get; set; }

    }
    public partial class RxUniformGrid<T> : RxPanel<T>, IRxUniformGrid where T : UniformGrid, new()
    {
        public RxUniformGrid()
        {

        }

        public RxUniformGrid(Action<T?> componentRefAction)
            : base(componentRefAction)
        {

        }

        PropertyValue<int>? IRxUniformGrid.Columns { get; set; }
        PropertyValue<int>? IRxUniformGrid.FirstColumn { get; set; }
        PropertyValue<int>? IRxUniformGrid.Rows { get; set; }


        protected override void OnUpdate()
        {
            OnBeginUpdate();

            var thisAsIRxUniformGrid = (IRxUniformGrid)this;
            SetPropertyValue(NativeControl, UniformGrid.ColumnsProperty, thisAsIRxUniformGrid.Columns);
            SetPropertyValue(NativeControl, UniformGrid.FirstColumnProperty, thisAsIRxUniformGrid.FirstColumn);
            SetPropertyValue(NativeControl, UniformGrid.RowsProperty, thisAsIRxUniformGrid.Rows);

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
    public partial class RxUniformGrid : RxUniformGrid<UniformGrid>
    {
        public RxUniformGrid()
        {

        }

        public RxUniformGrid(Action<UniformGrid?> componentRefAction)
            : base(componentRefAction)
        {

        }
    }
    public static partial class RxUniformGridExtensions
    {
        public static T Columns<T>(this T uniformgrid, int columns) where T : IRxUniformGrid
        {
            uniformgrid.Columns = new PropertyValue<int>(columns);
            return uniformgrid;
        }
        public static T Columns<T>(this T uniformgrid, Func<int> columnsFunc) where T : IRxUniformGrid
        {
            uniformgrid.Columns = new PropertyValue<int>(columnsFunc);
            return uniformgrid;
        }
        public static T FirstColumn<T>(this T uniformgrid, int firstColumn) where T : IRxUniformGrid
        {
            uniformgrid.FirstColumn = new PropertyValue<int>(firstColumn);
            return uniformgrid;
        }
        public static T FirstColumn<T>(this T uniformgrid, Func<int> firstColumnFunc) where T : IRxUniformGrid
        {
            uniformgrid.FirstColumn = new PropertyValue<int>(firstColumnFunc);
            return uniformgrid;
        }
        public static T Rows<T>(this T uniformgrid, int rows) where T : IRxUniformGrid
        {
            uniformgrid.Rows = new PropertyValue<int>(rows);
            return uniformgrid;
        }
        public static T Rows<T>(this T uniformgrid, Func<int> rowsFunc) where T : IRxUniformGrid
        {
            uniformgrid.Rows = new PropertyValue<int>(rowsFunc);
            return uniformgrid;
        }
    }
}
