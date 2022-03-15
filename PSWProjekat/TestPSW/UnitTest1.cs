using NUnit.Framework;

namespace TestPSW
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            int a = 5 + 6;

            Assert.AreEqual(a, 11);
        }
    }
}