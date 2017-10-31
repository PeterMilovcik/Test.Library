using NUnit.Framework;

namespace TestFramework.UnitTests
{
    public class TestCaseTests
    {
        [Test]
        public void Create_NotNull()
        {
            Assert.That(TestCase.Create(), Is.Not.Null);
        }
    }
}