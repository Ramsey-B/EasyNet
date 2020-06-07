using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EasyNet.Extensions.ObjectExtensions
{
    public static class CompareExtension
    {

        private static bool Compare(this object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null) return true;
            if (obj1 == null || obj2 == null) return false;
            var properties = obj1.GetType().GetProperties();
            var errorString = new StringBuilder();
            foreach (var property in properties)
            {
                var property2 = obj2.GetType().GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property2 == null) throw new Exception($"Object '{nameof(obj2)}' does not contain property with name '{property.Name}'.");
                var propValue = property.GetValue(obj1, null);
                var propValue2 = property2.GetValue(obj2, null);
                if (!CompareValues(propValue, propValue2)) errorString.AppendLine($"Object '{nameof(obj1)}' has property '{property.Name}' with value. Object '' has property '' with value.");
            }

            if (errorString.Length == 0) return true;
            throw new Exception(errorString.ToString());
        }

        private static bool CompareValues(object value1, object value2)
        {
            if (IsValueType(value1)) return value1.Equals(value2);
            return Compare(value1, value2);
        }

        private static bool IsValueType(object obj)
        {
            return obj.GetType().IsValueType;
        }
    }
}
