using GivenWhenThen.TestCases;

namespace GivenWhenThen
{
    public static class TestCase
    {
        public static ITestCase Create() => 
            new BasicTestCase();

        public static ITestCase Create(string description) => 
            new DescribedTestCase(description);
    }
}