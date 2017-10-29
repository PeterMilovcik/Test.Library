using NUnit.Framework;

namespace TestFramework.Examples
{
    public class TestCaseExample
    {
        /// <summary>
        /// Console Output: n.a.
        /// </summary>
        [Test]
        public void Sum1()
        {
            int x = 0;
            int y = 0;
            int sum = 0;
            var testCase = TestCase.Create();
            testCase.Add(() => x = 2);
            testCase.Add(() => y = 3);
            testCase.Add(() => sum = x + y);
            testCase.Add(() => Assert.That(sum, Is.EqualTo(5)));
            testCase.Execute();
        }

        /// <summary>
        /// Console Output:
        /// X = 2 -> Passed
        /// Y = 3 -> Passed
        /// Sum = X + Y->Passed
        /// Sum == 5 -> Passed
        /// </summary>
        [Test]
        public void Sum2()
        {
            int x = 0;
            int y = 0;
            int sum = 0;
            var testCase = TestCase.Create();
            testCase.Add("X = 2", () => x = 2);
            testCase.Add("Y = 3", () => y = 3);
            testCase.Add("Sum = X + Y", () => sum = x + y);
            testCase.Add("Sum == 5", () => Assert.That(sum, Is.EqualTo(5)));
            testCase.Execute();
        }
        
        /// <summary>
        /// Console Output: n.a.
        /// </summary>
        [Test]
        public void Sum3()
        {
            int x = 0;
            int y = 0;
            int sum = 0;
            var testCase = TestCase.Create();
            testCase.Add(TestStep.Create(() => x = 2));
            testCase.Add(TestStep.Create(() => y = 3));
            testCase.Add(TestStep.Create(() => sum = x + y));
            testCase.Add(TestStep.Create(() => Assert.That(sum, Is.EqualTo(5))));
            testCase.Execute();
        }
    }
}