using NUnit.Framework;

namespace GivenWhenThen.Examples
{
    internal class TestStepClassUsage
    {
        /// <summary>
        ///     Console Output: n.a.
        /// </summary>
        [Test]
        public void Sum1()
        {
            var xyNumbers = new XYTestStep(2, 3);
            var sumOperation = new SumTestStep(xyNumbers);
            var sumResult = new SumResultVerification(sumOperation, 5);

            new Scenario()
                .Given(xyNumbers)
                .When(sumOperation)
                .Then(sumResult)
                .Execute();
        }

        /// <summary>
        ///     Console Output: n.a.
        /// </summary>
        [Test]
        public void Sum2()
        {
            var xyNumbers = TestSteps.XY(2, 3);
            var sumOperation = TestSteps.Sum(xyNumbers);
            var sumResult = TestSteps.SumResult(sumOperation, 5);

            new Scenario()
                .Given(xyNumbers)
                .When(sumOperation)
                .Then(sumResult)
                .Execute();
        }
    }

    internal static class TestSteps
    {
        public static XYTestStep XY(int x, int y)
        {
            return new XYTestStep(x, y);
        }

        public static SumTestStep Sum(XYTestStep xyTestStep)
        {
            return new SumTestStep(xyTestStep);
        }

        public static SumResultVerification SumResult(SumTestStep sumTestStep, int expectedResult)
        {
            return new SumResultVerification(sumTestStep, expectedResult);
        }
    }

    internal class XYTestStep : IExecutable
    {
        public XYTestStep(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public void Execute()
        {
        }
    }

    internal class SumTestStep : IExecutable
    {
        private readonly XYTestStep xyTestStep;

        public SumTestStep(XYTestStep xyTestStep)
        {
            this.xyTestStep = xyTestStep;
        }

        public int Sum { get; private set; }

        public void Execute()
        {
            Sum = xyTestStep.X + xyTestStep.Y;
        }
    }

    internal class SumResultVerification : IExecutable
    {
        private readonly int expectedValue;
        private readonly SumTestStep sumTestStep;

        public SumResultVerification(SumTestStep sumTestStep, int expectedValue)
        {
            this.sumTestStep = sumTestStep;
            this.expectedValue = expectedValue;
        }

        public void Execute()
        {
            Assert.That(sumTestStep.Sum, Is.EqualTo(expectedValue));
        }
    }
}