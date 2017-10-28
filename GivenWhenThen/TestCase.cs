using GivenWhenThen.TestCases;

namespace GivenWhenThen
{
    public static class TestCase
    {
        public static ITestCase Create()
        {
            return new CommonTestCase();
        }

        public static ITestCase Create(string description)
        {
            return new DescribedTestCase(description);
        }
    }
}