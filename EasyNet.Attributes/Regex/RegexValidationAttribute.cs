using System.ComponentModel.DataAnnotations;

namespace EasyNet.Attributes.Regex
{
    public class RegexValidationAttribute : ValidationAttribute
    {
        private readonly string _pattern;

        public RegexValidationAttribute(string pattern)
        {
            _pattern = pattern;
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            var valueAsString = value as string;
            if (string.IsNullOrWhiteSpace(valueAsString)) return true;
            return System.Text.RegularExpressions.Regex.IsMatch(valueAsString, _pattern);
        }
    }
}
