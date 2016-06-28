using bd.mstest;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bd.common.tests.Resource.given_resource_in_root_of_the_assembly
{
    [TestClass]
    public class when_locating_resource_in_current_assembly_root : SUT
    {
        [TestMethod]
        public void then_closest_resource_in_parent_folder_is_found_and_read_correctly()
        {
            common.Resource.ReadAsString("root_resource.txt")
                    .Should()
                    .Be("bd.common.root_resource.txt");
        }
    }
}