using NUnit.Framework;

namespace CarManiacs.WebClient.UnitTests
{
    [TestFixture]
    public class TestTest
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void Test2()
        {
            Assert.IsFalse(false);
        }

        [Test]
        public void Test3()
        {
            Assert.IsNull(null);
        }
    }
}
