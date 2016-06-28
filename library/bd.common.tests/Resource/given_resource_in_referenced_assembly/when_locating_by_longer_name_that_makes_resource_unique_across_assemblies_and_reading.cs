using System.Reflection;
using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bd.common.tests.Resource.given_resource_in_referenced_assembly
{
    [TestClass]
    public class when_locating_by_longer_name_that_makes_resource_unique_across_assemblies_and_reading : SUT
    {
        protected override void Arrange()
        {
            Assembly.LoadFrom("bd.common.tests.resources.dll");
        }

        [TestMethod]
        public void then_closest_resource_from_referenced_assembly_is_found()
        {
            common.Resource.ReadAsString("bd.common.tests.resources.folder.resource.txt")
                           .Should()
                           .Be("bd.common.tests.resources.folder.resource.txt");
        }
    }
}