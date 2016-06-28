using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bd.common.tests.Resource.given_resource_in_referenced_assembly
{
    [TestClass]
    public class when_locating_by_short_name_and_reading : SUT
    {
        protected override void Act()
        {
            resource = common.Resource.ReadAsString("resource.txt");
        }

        [TestMethod]
        public void then_closest_resource_from_current_assembly_is_found()
        {
            resource.Should()
                    .Be("bd.common.tests.Resource.resource.txt");
        }

        [TestMethod]
        public void then_closest_resource_in_referenced_assembly_is_not_in_priority()
        {
            resource.Should()
                    .NotBe("bd.common.tests.resources.folder.resource.txt");
        }

        private string resource;
    }
}