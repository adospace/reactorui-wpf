using System;
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

        

        public static void CopyPropertiesTo<T>(this T source, object dest, PropertyInfo[] destProps)
        {
            var sourceProps = typeof(T).GetProperties()
                .Where(x => x.CanRead)
                .ToList();

            foreach (var sourceProp in sourceProps)
            {
                var targetProperty = destProps.FirstOrDefault(x => x.Name == sourceProp.Name);
                if (targetProperty != null)
                {
                    var sourceValue = sourceProp.GetValue(source, null);

                    try
                    {                    
                        if (sourceValue != null)
                        {
                            var sourceValueType = sourceValue.GetType();
                            if (sourceValueType.IsEnum)
                            {
                                sourceValue = Convert.ChangeType(sourceValue, Enum.GetUnderlyingType(sourceProp.PropertyType));
                            }
                            else if (!IsPrimitive(sourceValueType) &&
                                sourceValueType.Assembly != targetProperty.PropertyType.Assembly)
                            {
                                sourceValue = sourceValue.Adapt(sourceValueType, targetProperty.PropertyType);                            
                            }
                        }

                        targetProperty.SetValue(dest, sourceValue, null);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Unable to copy property '{targetProperty.Name}' of state ({source.GetType()}) to new state after hot reload (Exception: '{ex.Message}')");
                    }
                }
            }
        }
    }
}
