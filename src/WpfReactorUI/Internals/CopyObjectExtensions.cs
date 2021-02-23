using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Mapster;

namespace WpfReactorUI.Internals
{
    internal static class CopyObjectExtensions
    {
        private static bool IsPrimitive(Type type)
        {
            if (type == typeof(String)) return true;
            return (type.IsValueType & type.IsPrimitive);
        }

        private static bool IsEnumerable(Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }

        public static void CopyPropertiesTo(this object source, object dest)//, PropertyInfo[] destProps
        {
            var sourceProps = source
                .GetType()
                .GetProperties()
                .Where(x => x.CanRead)
                .ToList();

            var destProps = dest
                .GetType()
                .GetProperties()
                .Where(_ => _.CanWrite)
                .ToDictionary(_ => _.Name, _ => _);

            foreach (var sourceProp in sourceProps)
            {
                if (!destProps.TryGetValue(sourceProp.Name, out var destProp))
                    continue;

                var sourceValue = sourceProp.GetValue(source, null);

                try
                {                    
                    if (sourceValue != null && 
                        sourceProp.PropertyType != destProp.PropertyType)
                    {
                        var sourceValueType = sourceValue.GetType();
                        if (sourceValueType.IsEnum)
                        {
                            var underlyingTypeAsNullable = Nullable.GetUnderlyingType(sourceProp.PropertyType);
                            if (underlyingTypeAsNullable != null)
                                sourceValue = Convert.ChangeType(sourceValue, Enum.GetUnderlyingType(underlyingTypeAsNullable));
                            else
                                sourceValue = Convert.ChangeType(sourceValue, Enum.GetUnderlyingType(sourceProp.PropertyType));
                        }
                        else if (!IsPrimitive(sourceValueType))
                        {
                            sourceValue = sourceValue.Adapt(sourceValueType, destProp.PropertyType);
                            //if (IsEnumerable(sourceValueType) ||
                            //    sourceValueType.Assembly != destProp.PropertyType.Assembly)
                            //{
                            //    sourceValue = sourceValue.Adapt(sourceValueType, destProp.PropertyType);
                            //}
                        }
                    }

                    destProp.SetValue(dest, sourceValue, null);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Unable to copy property '{destProp.Name}' of state ({source?.GetType()}) to new state after hot reload (Exception: '{ex.Message}')");
                }
            }
        }
    }
}
