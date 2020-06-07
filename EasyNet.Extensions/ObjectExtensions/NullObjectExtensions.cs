using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNet.Extensions.ObjectExtensions
{
    public static class NullObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}
