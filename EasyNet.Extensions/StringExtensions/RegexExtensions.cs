using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EasyNet.Extensions.StringExtensions
{
    public static class RegexExtensions
    {
        public static bool IsMatch(this string str, string pattern)
        {
            return Regex.IsMatch(str, pattern);
        }

        public static string Replace(this string str, string pattern, string replacementString = "")
        {
            return Regex.Replace(str, pattern, replacementString);
        }

        public static string MakeAlphabetic(this string str)
        {
            // This is often more performant than a Regex.
            return  new String(str.Where(char.IsLetter).ToArray());
        }

        public static string MakeNumeric(this string str)
        {
            return new String(str.Where(char.IsDigit).ToArray());
        }

        public static string MakeAlphaNumeric(this string str)
        {
            return new String(str.Where(char.IsLetterOrDigit).ToArray());
        }
    }
}
