using NUnit.Framework;

namespace GivenWhenThen.Examples
{
    internal class MethodUsage
    {
        private int sum;
        private int x;
        private int y;

        /// <summary>
        ///     Console Output:
        ///     Given: TwoNumbers2And3AreDeclared -> Passed
        ///     When: SumOperationIsPerformed -> Passed
        ///     Then: ResultIsEqualTo5 -> Passed
        /// </summary>
        [Test]
        public void Sum()
        {
            new Scenario()
                .Given(TwoNumbers2And3AreDeclared)
                .When(SumOperationIsPerformed)
                .Then(ResultIsEqualTo5)
                .Execute();
        }

        private void TwoNumbers2And3AreDeclared()
        {
            x = 2;
            y = 3;
        }

        private void SumOperationIsPerformed()
        {
            sum = x + y;
        }

        private void ResultIsEqualTo5()
        {
            Assert.That(sum, Is.EqualTo(5));
        }
    }
}