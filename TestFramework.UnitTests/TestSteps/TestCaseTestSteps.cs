using TestFramework.TestCases;

namespace TestFramework.UnitTests.TestSteps
{
    public class TestCaseTestSteps
    {
        public void Create(out ITestCase testCase)
        {
            testCase = TestCase.Create();
        }
    }
}