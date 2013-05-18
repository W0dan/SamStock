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
        public virtual void CleanUp()
        {
            
        }

        public abstract void Arrange();

        public abstract void Act();
    }
}