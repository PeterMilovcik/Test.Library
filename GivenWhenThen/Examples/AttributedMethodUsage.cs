using NUnit.Framework;

namespace GivenWhenThen.Examples
{
    internal class AttributedMethodUsage
    {
        private int x;
        private int y;
        private int sum;

        /// <summary>
        /// Console Output:
        /// Given: Two numbers 2 and 3 are declared. -> Passed
        ///  When: Sum operation is performed. -> Passed
        ///  Then: Result is equal to 5. -> Passed
        /// </summary>
        [Test]
        public void Sum()
        {
            Scenario
                .Given(TwoNumbers2And3AreDeclared)
                .When(SumOperationIsPerformed)
                .Then(ResultIsEqualTo5)
                .Execute();
        }

        [TestStep("Two numbers 2 and 3 are declared.")]
        private void TwoNumbers2And3AreDeclared()
        {
            x = 2;
            y = 3;
        }

        [TestStep("Sum operation is performed.")]
        private void SumOperationIsPerformed()
        {
            sum = x + y;
        }

        [TestStep("Result is equal to 5.")]
        private void ResultIsEqualTo5()
        {
            Assert.That(sum, Is.EqualTo(5));
        }
    }
}