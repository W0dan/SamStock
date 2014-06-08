using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        [TestInitialize]
        public virtual void Setup()
        {
            Arrange();
            Act();
        }

        [TestCleanup]
        public virtual void CleanUp()
        {
            
        }

        public abstract void Arrange();

        public abstract void Act();
    }
}