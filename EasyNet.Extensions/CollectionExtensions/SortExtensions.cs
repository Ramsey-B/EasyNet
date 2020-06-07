using EasyNet.Extensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EasyNet.Extensions.CollectionExtensions
{
    public static class SortExtensions
    {
        public static IEnumerable<T> SortObjects<T>(this IEnumerable<T> unsortedList, IEnumerable<string> sortValues)
        {
            IOrderedEnumerable<T> sortedList;

            if (sortValues == null || !sortValues.Any()) return unsortedList;

            if (GetOrder(sortValues.First()) == "DESC")
            {
                sortedList = unsortedList.OrderByDescending(obj => GetProperty(GetPropName(sortValues.First()), obj));
            }
            else
            {
                sortedList = unsortedList.OrderBy(obj => GetProperty(GetPropName(sortValues.First()), obj));
            }

            if (sortValues.Count() == 1) return sortedList;

            for (int i = 1; i < sortValues.Count(); i++)
            {
                var propName = GetPropName(sortValues.ElementAt(i));
                if (GetOrder(sortValues.ElementAt(i)) == "DESC")
                {
                    sortedList = sortedList.ThenByDescending(obj => GetProperty(GetPropName(propName), obj));
                }
                else
                {
                    sortedList = sortedList.ThenBy(obj => GetProperty(GetPropName(propName), obj));
                }
            }
            return sortedList;
        }

        private static object GetProperty(string propName, object obj)
        {
            var type = obj.GetType();
            PropertyInfo prop = type.GetProperty(propName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            try
            {
                if (prop == null)
                {
                    prop = type.GetProperties().FirstOrDefault(p =>
                    {
                        var att = p.GetCustomAttribute<SortNameAttribute>();
                        if (att == null) return false;
                        return att.SortName.ToUpper() == propName.ToUpper();
                    });
                }
            }
            catch (Exception)
            {
                prop = null;
            }

            if (prop == null) return null;
            return prop.GetValue(obj, null);
        }

        private static string GetPropName(string sort)
        {
            var propName = sort.Split('_').First();
            if (string.IsNullOrWhiteSpace(propName)) return "";
            return propName;
        }

        private static string GetOrder(string sort)
        {
            var propName = sort.Split('_').Last();
            if (string.IsNullOrWhiteSpace(propName)) return "";
            return propName.ToUpper();
        }

    }
}
