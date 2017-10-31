using NUnit.Framework;
using TestFramework.TestCases;
using TestFramework.UnitTests.TestSteps;

namespace TestFramework.UnitTests
{
    public class TestCaseTests
    {
        [Test]
        public void Create_NotNull()
        {
            ITestCase testCase = null;

            TestCase.Create()
                .Add(() => new TestStep().TestCase().Create(out testCase))
                .Add(() => new TestStep().Assert().IsNotNull(testCase))
                .Execute();
        }
    }
}