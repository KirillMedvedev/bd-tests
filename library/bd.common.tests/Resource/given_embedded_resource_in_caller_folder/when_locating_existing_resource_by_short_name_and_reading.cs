using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bd.common.tests.Resource.given_embedded_resource_in_caller_folder
{
    using bd.common;

    [TestClass]
    public class when_locating_existing_resource_by_short_name_and_reading : SUT
    {
        [TestMethod]
        public void then_closest_resource_is_found_and_read_correctly()
        {
            Resource.ReadAsString("resource.txt")
                    .Should()
                    .Be("bd.common.tests.Resource.given_embedded_resource_in_current_assemly.resource.txt");
        }

        [TestMethod]
        public void then_resource_with_same_name_in_parent_folder_is_skipped()
        {
            Resource.ReadAsString("resource.txt")
                    .Should()
                    .NotBe("bd.common.tests.Resource.resource.txt");
        }
    }
}