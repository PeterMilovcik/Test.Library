using NUnit.Framework;

namespace TestFramework.Examples
{
    internal class DelegateOnlyExample
    {
        /// <summary>
        /// Console Output: n.a.
        /// </summary>
        [Test]
        public void Sum()
        {
            int x = 0;
            int y = 0;
            int sum = 0;

            Scenario.Create()
                .Given(() => { x = 2; y = 3; })
                .When(() => sum = x + y)
                .Then(() => Assert.That(sum, Is.EqualTo(5)))
                .Execute();
        }
    }
}