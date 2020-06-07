using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNet.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SortNameAttribute : Attribute
    {
        public string SortName;
        public SortNameAttribute(string sortName)
        {
            SortName = sortName;
        }
    }
}
