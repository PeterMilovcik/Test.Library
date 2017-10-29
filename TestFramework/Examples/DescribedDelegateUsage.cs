using NUnit.Framework;
using TestFramework.Scenarios;

namespace TestFramework.Examples
{
    internal class DescribedDelegateUsage
    {
        /// <summary>
        ///     Console Output:
        ///     Given: Two numbers x=2 and y = 3. -> Passed
        ///     When: Sum of those numbers is performed. -> Passed
        ///     Then: Result value of sum operation is 5. -> Passed
        /// </summary>
        [Test]
        public void Sum()
        {
            var x = 0;
            var y = 0;
            var sum = 0;

            new BasicScenario()
                .Given("Two numbers x=2 and y=3.", () =>
                {
                    x = 2;
                    y = 3;
                })
                .When("Sum of those numbers is performed.", () =>
                    sum = x + y)
                .Then("Result value of sum operation is 5.", () =>
                    Assert.That(sum, Is.EqualTo(5)))
                .Execute();
        }
    }
}