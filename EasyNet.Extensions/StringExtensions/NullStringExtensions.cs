using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNet.Extensions.StringExtensions
{
    public static class NullStringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
