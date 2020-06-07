using EasyNet.Extensions.Exceptions;
using EasyNet.Extensions.ObjectExtensions;
using System;
using System.Text;
using Xunit;
using Xunit.Extensions;

namespace EasyNet.Extensions.Test.CompareExtensions
{
    public class CompareExtenionTests
    {
        [Fact]
        public void CompareObject_ObjectsMatch()
        {
            var dob = DateTime.Now.AddYears(10);
            var obj1 = new
            {
                Name = "Joe",
                DateOfBirth = dob,
                Address = new
                {
                    Street = "1234 E Fun st",
                    City = "Neverland",
                    State = "Atlantis",
                    PostCode = 12345
                }
            };

            var obj2 = new
            {
                Name = "Joe",
                DateOfBirth = dob,
                Address = new
                {
                    Street = "1234 E Fun st",
                    City = "Neverland",
                    State = "Atlantis",
                    PostCode = 12345
                }
            };

            var result = obj1.Compare(obj2);

            result.ShouldBeTrue();
        }

        [Fact]
        public void CompareObject_ObjectsDiffer()
        {
            var obj1 = new
            {
                Name = "Joe",
                DateOfBirth = DateTime.Now.AddYears(9),
                Address = new
                {
                    Street = "1234 E Fun st.",
                    City = "Neverland",
                    State = "Atlantis",
                    PostCode = 12345
                }
            };

            var obj2 = new
            {
                Name = "Joe",
                DateOfBirth = DateTime.Now.AddYears(10),
                Address = new
                {
                    Street = "1234 E Fun st",
                    City = "Neverland",
                    State = "Atlantis",
                    PostCode = 12346
                }
            };

            var exception = Assert.Throws<ComparisonException>(() => obj1.Compare(obj2));
            var expectedMsg = new StringBuilder();
            expectedMsg.AppendLine($"Object 'obj1.DateOfBirth' has value '{obj1.DateOfBirth}'. Object 'obj2.DateOfBirth' has value '{obj2.DateOfBirth}'.");
            expectedMsg.AppendLine($"Object 'obj1.Address.Street' has value '{obj1.Address.Street}'. Object 'obj2.Address.Street' has value '{obj2.Address.Street}'.");
            expectedMsg.AppendLine($"Object 'obj1.Address.PostCode' has value '{obj1.Address.PostCode}'. Object 'obj2.Address.PostCode' has value '{obj2.Address.PostCode}'.");
            exception.Message.ShouldEqual(expectedMsg.ToString());
        }
    }
}
