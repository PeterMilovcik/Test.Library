using NUnit.Framework;
using TestFramework.Scenarios;

namespace TestFramework.Examples
{
    internal class StoryExample
    {
        private int x;
        private int y;
        private int z;

        private IScenario scenario1;
        private IScenario scenario2;

        [SetUp]
        public void SetUp()
        {
            scenario1 = Scenario.WithName("Scenario 1")
                .Given(() => x = 2)
                .And(() => y = 3)
                .When(() => z = x + y)
                .And(() => z = z * 2)
                .Then(() => Assert.That(z, Is.EqualTo(10)));

            scenario2 = Scenario.WithName("Scenario 2")
                .Given(() => x = 1)
                .When(() => x += y)
                .And(() => z = x * y)
                .Then(() => Assert.That(z, Is.EqualTo(12)));
        }

        [Test]
        public void Calculation()
        {
            Story.WithName("Calculation")
                .Add(scenario1)
                .Add(scenario2)
                .Execute();
        }
    }
}