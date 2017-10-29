using NUnit.Framework;
using TestFramework.Scenarios;

namespace TestFramework.Examples
{
    internal class DelegateOnlyUsage
    {
        /// <summary>
        ///     Console Output: n.a.
        /// </summary>
        [Test]
        public void Sum()
        {
            var x = 0;
            var y = 0;
            var sum = 0;

            new BasicScenario()
                .Given(() =>
                {
                    x = 2;
                    y = 3;
                })
                .When(() => sum = x + y)
                .Then(() => Assert.That(sum, Is.EqualTo(5)))
                .Execute();
        }
    }
}