using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNet.Extensions.ObjectExtensions
{
    public static class TypeExtensions
    {
        public static bool IsValueOrPrimitiveType(this object obj)
        {
            var type = obj.GetType();
            return type.IsValueType || type.IsPrimitive || obj is string;
        }

        public static bool Is<T>(this object obj1)
        {
            return obj1 is T;
        }
    }
}
