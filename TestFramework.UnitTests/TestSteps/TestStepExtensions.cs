namespace TestFramework.UnitTests.TestSteps
{
    public static class TestStepExtensions
    {
        public static TestCaseTestSteps TestCase(this TestStep testStep)
        {
            return new TestCaseTestSteps();
        }

        public static AssertTestSteps Assert(this TestStep testStep)
        {
            return new AssertTestSteps();
        }
    }
}