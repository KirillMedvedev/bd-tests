using NUnit.Framework;

namespace bd.nunit
{
    public class SUT
    {
        [SetUp]
        public void TestInitialize()
        {
            Arrange();
            Act();
        }

        [TearDown]
        public void TestCleanup()
        {
            Clean();
        }

        protected virtual void Arrange() { }
        protected virtual void Act() { }
        protected virtual void Clean() { }
    }
}
