using EasyNet.Extensions.Exceptions;
using System;
using System.Reflection;
using System.Text;

namespace EasyNet.Extensions.ObjectExtensions
{
    public static class CompareExtension
    {
        public static bool DeepEquals(this object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null) return true;
            if (obj1.GetType() != obj1.GetType()) return false;
            var properties = obj1.GetType().GetProperties();
            foreach (var property1 in properties)
            {
                var property2 = obj2.GetType().GetProperty(property1.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property2 == null) return false;
                var propValue1 = property1.GetValue(obj1, null);
                var propValue2 = property2.GetValue(obj2, null);
                if (IsValueType(propValue1))
                {
                    if (!propValue1.Equals(propValue2)) return false;
                    continue;
                }
                if (!DeepEquals(propValue1, propValue2)) return false;
            }
            return true;
        }

        public static bool Compare(this object obj1, object obj2, string obj1Name = "obj1", string obj2Name = "obj2")
        {
            if (obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;
            var errorString = new StringBuilder();
            var result = DeepCompare(ref errorString, obj1, obj2, obj1Name, obj2Name);
            if (errorString.Length != 0) throw new ComparisonException(result.ToString());
            return true;
        }

        private static string DeepCompare(ref StringBuilder errorString, object obj1, object obj2, string obj1Name = "obj1", string obj2Name = "obj2")
        {
            var properties = obj1.GetType().GetProperties();
            foreach (var property1 in properties)
            {
                var property2 = obj2.GetType().GetProperty(property1.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property2 == null) throw new ArgumentException($"Object '{obj1Name}' does not contain property with name '{property1.Name}'.");
                var propValue1 = property1.GetValue(obj1, null);
                var propValue2 = property2.GetValue(obj2, null);
                var property1Name = $"{obj1Name}.{property1.Name}";
                var property2Name = $"{obj2Name}.{property2.Name}";
                if (!IsValueType(propValue1))
                {
                    DeepCompare(ref errorString, propValue1, propValue2, property1Name, property2Name);
                    continue;
                }
                if (!propValue1.Equals(propValue2))
                {
                    errorString.AppendLine($"Object '{property1Name}' has value '{propValue1}'. Object '{property2Name}' has value '{propValue2}'.");
                }
            }
            return errorString.ToString();
        }

        private static bool IsValueType(object obj)
        {
            var type = obj.GetType();
            return type.IsValueType || type.IsPrimitive || obj is string;
        }
    }
}
