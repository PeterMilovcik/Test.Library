using NUnit.Framework;
using TestFramework.TestCases;

namespace TestFramework.UnitTests
{
    public class TestCaseTests
    {
        [Test]
        public void Create_NotNull()
        {
            ITestCase testCase;
            Scenario.Create()
                .Given("Test case is not yet created.", 
                () => testCase = null)
                .When("TestCase.Create() method is called.", 
                () => testCase = TestCase.Create())
                .Then("Test case is created.", 
                () => Assert.That(TestCase.Create(), Is.Not.Null))
                .Execute();
        }
    }
}