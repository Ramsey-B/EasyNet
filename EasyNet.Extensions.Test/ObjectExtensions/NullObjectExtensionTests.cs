using EasyNet.Extensions.ObjectExtensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace EasyNet.Extensions.Test.ObjectExtensions
{
    public class NullObjectExtensionTests
    {
        [Fact]
        public void ObjectIsNull_ObjectNull()
        {
            object obj = null;

            var result = obj.IsNull();

            result.ShouldBeTrue();
        }
    }
}
