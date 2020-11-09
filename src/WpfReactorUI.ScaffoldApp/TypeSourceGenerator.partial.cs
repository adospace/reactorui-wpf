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

namespace WpfReactorUI.ScaffoldApp
{
    public partial class TypeSourceGenerator
    {
        private readonly Type _typeToScaffold;

        public TypeSourceGenerator(Type typeToScaffold)
        {
            _typeToScaffold = typeToScaffold;

            var propertiesMap = _typeToScaffold.GetProperties()
                //generic types not supported
                .Where(_ => !_.PropertyType.IsGenericType)
                //excluding common properties not relevant to ReactorUI framework
                .Where(_ => !typeof(FrameworkTemplate).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(GroupStyleSelector).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(BindingGroup).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(StyleSelector).IsAssignableFrom(_.PropertyType))
                .Where(_ => !typeof(DataTemplateSelector).IsAssignableFrom(_.PropertyType))

                .Distinct(new PropertyInfoEqualityComparer())
                .ToDictionary(_ => _.Name, _ => _);

            Properties = _typeToScaffold.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(_ => typeof(DependencyProperty).IsAssignableFrom(_.FieldType))
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .Select(_ => _.Name.Substring(0, _.Name.Length - "Property".Length))
                .Where(_ => propertiesMap.ContainsKey(_))
                .Select(_ => propertiesMap[_])
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .Where(_ => !_.PropertyType.IsGenericType)
                .Where(_ => (_.GetSetMethod()?.IsPublic).GetValueOrDefault())
                .OrderBy(_ => _.Name)
                .ToArray();

            var eventsMap = _typeToScaffold.GetEvents()
                .Distinct(new EventInfoEqualityComparer())
                .ToDictionary(_ => _.Name, _ => _);

            Events = _typeToScaffold.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(_ => typeof(RoutedEvent).IsAssignableFrom(_.FieldType))
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .Select(_ => _.Name.Substring(0, _.Name.Length - "Event".Length))
                .Where(_ => eventsMap.ContainsKey(_))
                .Select(_ => eventsMap[_])
                .Where(_ => _.GetCustomAttribute<ObsoleteAttribute>() == null)
                .OrderBy(_ => _.Name)
                .ToArray();
        }

        public string TypeName => _typeToScaffold.Name;

        public string BaseTypeName => _typeToScaffold.BaseType.Name == "DependencyObject" ? "VisualNode" : $"Rx{_typeToScaffold.BaseType.Name}";

        public bool IsTypeNotAbstractWithEmptyConstructur => !_typeToScaffold.IsAbstract && _typeToScaffold.GetConstructor(new Type[] { }) != null;

        public PropertyInfo[] Properties { get; }

        public EventInfo[] Events { get; }

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
            return Char.ToLowerInvariant(s[0]) + s.Substring(1, s.Length - 1);
        }

        public static string ToResevedWordTypeName(this string typename)
        {
            return typename switch
            {
                "SByte" => "sbyte",
                "Byte" => "byte",
                "Int16" => "short",
                "UInt16" => "ushort",
                "Int32" => "int",
                "UInt32" => "uint",
                "Int64" => "long",
                "UInt64" => "ulong",
                "Char" => "char",
                "Single" => "float",
                "Double" => "double",
                "Boolean" => "bool",
                "Decimal" => "decimal",
                "String" => "string",
                "Object" => "object",
                _ => typename,
            };
        }
    }

}
