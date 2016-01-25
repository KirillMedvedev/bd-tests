using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bd.mstest
{
    public class SUT
    {
        [TestInitialize]
        public void TestInitialize()
        {
            Arrange();
            Act();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Clean();
        }

        protected virtual void Arrange() { }
        protected virtual void Act() { }
        protected virtual void Clean() { }
    }
}
