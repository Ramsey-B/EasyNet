using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EasyNet.Extensions.ObjectExtensions
{
    public static class ValidateObjectExtensions
    {
       public static bool ModelStateIsValid(this object obj)
        {
			try
			{
				var context = new ValidationContext(obj, null, null);
				Validator.ValidateObject(obj, context, true);
				return true;
			}
			catch
			{
				return false;
			}
        }
    }
}
