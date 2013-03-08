using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        [TestFixtureSetUp]
        public virtual void Setup()
        {
            Arrange();
            Act();
        }

        [TestFixtureTearDown]
        protected virtual void CleanUp()
        {
            
        }

        public abstract void Arrange();

        public abstract void Act();
    }
}