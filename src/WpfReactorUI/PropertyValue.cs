using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfReactorUI
{
    public interface IPropertyValue
    { 
        bool SetDefault { get; }

        object GetValue();
    }

    public class PropertyValue<T> : IPropertyValue
    {
        public PropertyValue(T value)
        {
            Value = value;
        }

        private PropertyValue()
        {
            SetDefault = true;
        }

        public static IPropertyValue Default { get; } = new PropertyValue<T>();

        public T Value { get; }

        public bool SetDefault { get; }

        public object GetValue() => Value;

        public override string ToString()
        {
            return $"{{{(Value == null ? "null" : Value.ToString())}}}";
        }
    }

    internal static class PropertyValueExtenstions
    {
        public static void Set(this DependencyObject dependencyObject, IVisualNodeWithNativeControl visualNode, DependencyProperty property, IPropertyValue propertyValue)
        {
            if (propertyValue != null)
            {
                visualNode.SetDefaultPropertyValue(property, dependencyObject.GetValue(property));
                dependencyObject.SetValue(property, propertyValue.GetValue());
            }
            else
            {
                if (visualNode.TryGetDefaultPropertyValue(property, out var defaultValue))
                {
                    dependencyObject.SetValue(property, defaultValue);
                }            
            }            
        }
    }
}
