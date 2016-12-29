using System.Collections.Generic;
using NUnit.Framework;

namespace bd.nunit.tests.given_no_system_under_test
{
    [TestFixture]
    public class when_running_test : SUT
    {
        protected override void Arrange()
        {
            callsSequence.Add("Arrange");
        }

        protected override void Act()
        {
            callsSequence.Add("Act");
        }

        protected override void Clean()
        {
            callsSequence.Clear();
        }

        [Test]
        public void then_arrange_works_first()
        {
            Assert.AreEqual("Arrange", callsSequence[0]);
        }

        [Test]
        public void then_act_works_next()
        {
            Assert.AreEqual("Act", callsSequence[1]);
        }

        [Test]
        public void then_assert_called_next()
        {
            callsSequence.Add("Assert");
            
            Assert.AreEqual("Assert", callsSequence[2]);
        }

        List<string> callsSequence = new List<string>();
    }
}