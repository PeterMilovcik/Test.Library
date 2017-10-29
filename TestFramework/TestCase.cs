using TestFramework.TestCases;

namespace TestFramework
{
    public static class TestCase
    {
        public static ITestCase Create() => 
            new BasicTestCase();

        public static ITestCase Create(string description) => 
            new DescribedTestCase(description);
    }
}