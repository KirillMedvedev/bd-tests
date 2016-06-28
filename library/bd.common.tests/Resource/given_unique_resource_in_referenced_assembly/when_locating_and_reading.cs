using System.Reflection;
using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bd.common.tests.Resource.given_unique_resource_in_referenced_assembly
{
    [TestClass]
    public class when_locating_and_reading : SUT
    {
        protected override void Arrange()
        {
            Assembly.LoadFrom("bd.common.tests.resources.dll");
        }

        [TestMethod]
        public void then_resource_is_found_successfully()
        {
            common.Resource.ReadAsString("referenced_assembly_resource.txt")
                           .Should()
                           .Be("bd.common.tests.resources.referenced_assembly_resource.txt");
        }
    }
}