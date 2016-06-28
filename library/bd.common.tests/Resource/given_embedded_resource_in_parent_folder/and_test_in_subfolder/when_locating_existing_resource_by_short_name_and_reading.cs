using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bd.common.tests.Resource.given_embedded_resource_in_parent_folder.and_test_in_subfolder
{
    [TestClass]
    public class when_locating_existing_resource_by_short_name_and_reading : SUT
    {
        [TestMethod]
        public void then_closest_resource_in_parent_folder_is_found_and_read_correctly()
        {
            common.Resource.ReadAsString("resource.txt")
                    .Should()
                    .Be("bd.common.tests.Resource.given_embedded_resource_in_parent_folder.resource.txt");
        }
    }
}