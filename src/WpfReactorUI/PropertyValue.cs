using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfReactorUI
{
    public class PropertyValue<T>
    {
        public PropertyValue(T value)
        {
            Value = value;
        }

        public T Value { get; }
    }

    public static class PropertyValueExtenstions
    {
        public static void Set<T>(this DependencyObject dependencyObject, DependencyProperty property, PropertyValue<T> propertyValue)
        {
            if (propertyValue == null)
            {
                //var defaultValue = property.GetMetadata(dependencyObject).DefaultValue;
                //if (!object.Equals(defaultValue, dependencyObject.GetValue(property)))
                //{
                //    dependencyObject.SetValue(property, property.GetMetadata(dependencyObject).DefaultValue);
                //}
            }
            else
                dependencyObject.SetValue(property, propertyValue.Value);
        }
    }
}
