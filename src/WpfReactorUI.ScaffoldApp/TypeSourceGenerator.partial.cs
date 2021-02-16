using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfReactorUI.ScaffoldApp
{
    public partial class TypeSourceGenerator
    {
        private readonly Type _typeToScaffold;

        public TypeSourceGenerator(Type typeToScaffold, string[] additionalUsings = null, string ns = "WpfReactorUI")
        {
            _typeToScaffold = typeToScaffold;
            
            Namespace = ns;

            var propertiesMap = _typeToScaffold.GetProperties()
                //generic types not supported
                .Where(_ => !_.PropertyType.IsGenericType || _.PropertyType.IsValueType)
                //excluding common properties not relevant to ReactorUI framework
                .Where(_ => !typeof(FrameworkTemplate).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(GroupStyleSelector).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(BindingGroup).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(StyleSelector).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(DataTemplateSelector).IsAssignableFrom(_.PropertyType))

                .Where(_ => !(_typeToScaffold == typeof(ContentControl) && _.Name == "Content"))

                .Distinct(new PropertyInfoEqualityComparer())
                .ToDictionary(_ => _.Name, _ => _);

            Properties = _typeToScaffold.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(_ => typeof(DependencyProperty).IsAssignableFrom(_.FieldType))
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .Select(_ => _.Name.Substring(0, _.Name.Length - "Property".Length))
                .Where(_ => propertiesMap.ContainsKey(_))
                .Select(_ => propertiesMap[_])
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .Where(_ => (_.GetSetMethod()?.IsPublic).GetValueOrDefault())
                .OrderBy(_ => _.Name)
                .ToArray();

            //var eventsMap = _typeToScaffold.GetEvents()
            //    .Distinct(new EventInfoEqualityComparer())
            //    .ToDictionary(_ => _.Name, _ => _);

            //Events = _typeToScaffold.GetFields(BindingFlags.Public | BindingFlags.Static)
            //    .Where(_ => typeof(RoutedEvent).IsAssignableFrom(_.FieldType))
            //    .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
            //    .Select(_ => _.Name.Substring(0, _.Name.Length - "Event".Length))
            //    .Where(_ => eventsMap.ContainsKey(_))
            //    .Select(_ => eventsMap[_])
            //    .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
            //    .OrderBy(_ => _.Name)
            //    .ToArray();
            Events = _typeToScaffold.GetEvents(System.Reflection.BindingFlags.Public
                    | System.Reflection.BindingFlags.Instance
                    | System.Reflection.BindingFlags.DeclaredOnly)
                .Distinct(new EventInfoEqualityComparer())
                .Where(_ => !_.EventHandlerType.GetMethod("Invoke").GetParameters()[1].ParameterType.IsGenericType)//<- to handle properly
                .OrderBy(_ => _.Name)
                .ToArray();

            AdditionalUsings = additionalUsings ?? Array.Empty<string>();
        }

        public string Namespace { get; }

        public string TypeName => _typeToScaffold.Name;

        public bool IsSealed => _typeToScaffold.IsSealed;

        public string BaseTypeName => _typeToScaffold.BaseType.Name == "DependencyObject" ? "VisualNode" : $"Rx{_typeToScaffold.BaseType.Name}";

        public bool IsTypeNotAbstractWithEmptyConstructor => !_typeToScaffold.IsAbstract && !_typeToScaffold.IsSealed && _typeToScaffold.GetConstructor(Array.Empty<Type>()) != null;

        public PropertyInfo[] Properties { get; }

        public EventInfo[] Events { get; }

        public string[] AdditionalUsings { get; }

        public string TransformAndPrettify()
        {
            var tree = CSharpSyntaxTree.ParseText(TransformText());

            var workSpace = new AdhocWorkspace();
            workSpace.AddSolution(
                      SolutionInfo.Create(SolutionId.CreateNewId("formatter"),
                      VersionStamp.Default)
            );

            var formatter = Formatter.Format(tree.GetCompilationUnitRoot(), workSpace);
            return formatter.ToString();
        }

        private bool IsCommand(Type type)
            => typeof(ICommand).IsAssignableFrom(type);

        private bool IsBrushAndTypeIsFrameworkElement(Type type)
            => typeof(Brush).IsAssignableFrom(type) && typeof(FrameworkElement).IsAssignableFrom(_typeToScaffold);
    }

    internal class PropertyInfoEqualityComparer : IEqualityComparer<PropertyInfo>
    {
        public bool Equals(PropertyInfo x, PropertyInfo y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(PropertyInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    internal class EventInfoEqualityComparer : IEqualityComparer<EventInfo>
    {
        public bool Equals(EventInfo x, EventInfo y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(EventInfo obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    internal static class StringExtensions
    {
        public static string CamelCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;
            return char.ToLowerInvariant(s[0]) + s[1..];
        }

        public static string ToResevedWordTypeName(this Type type)
        {
            var typename = type.Name;
            bool isGenericType = false;

            if (type.IsGenericType && type.IsValueType)
            {
                typename = type.GenericTypeArguments[0].Name;
                isGenericType = true;
            }

            return typename switch
            {
                "SByte" => "sbyte" + (isGenericType ? "?" : string.Empty),
                "Byte" => "byte" + (isGenericType ? "?" : string.Empty),
                "Int16" => "short" + (isGenericType ? "?" : string.Empty),
                "UInt16" => "ushort" + (isGenericType ? "?" : string.Empty),
                "Int32" => "int" + (isGenericType ? "?" : string.Empty),
                "UInt32" => "uint" + (isGenericType ? "?" : string.Empty),
                "Int64" => "long" + (isGenericType ? "?" : string.Empty),
                "UInt64" => "ulong" + (isGenericType ? "?" : string.Empty),
                "Char" => "char" + (isGenericType ? "?" : string.Empty),
                "Single" => "float" + (isGenericType ? "?" : string.Empty),
                "Double" => "double" + (isGenericType ? "?" : string.Empty),
                "Boolean" => "bool" + (isGenericType ? "?" : string.Empty),
                "Decimal" => "decimal" + (isGenericType ? "?" : string.Empty),
                "String" => "string" + (isGenericType ? "?" : string.Empty),
                "Object" => "object" + (isGenericType ? "?" : string.Empty),
                _ => typename,
            };
        }
    }

}
