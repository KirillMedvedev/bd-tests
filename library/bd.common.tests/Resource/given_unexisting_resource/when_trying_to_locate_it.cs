using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bd.mstest;

namespace bd.common.tests.Resource.given_unexisting_resource
{
    [TestClass]
    public class when_trying_to_locate_it : SUT
    {
        [TestMethod]
        public void then_error_occurs()
        {
            Action action = () => common.Resource.ReadAsString("unexisting_resource.txt");

            action.ShouldThrow<ResourceResolveException>();
        }
    }
}