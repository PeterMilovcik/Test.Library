using System;
using NUnit.Framework;

namespace TestFramework.UnitTests
{
    internal class ScenarioTests
    {
        [Test]
        public void Create_NotNull() =>
            Assert.That(Scenario.Create(), Is.Not.Null);

        [Test]
        public void WithName_NotNull() =>
            Assert.That(Scenario.WithName("scenario name"), Is.Not.Null);

        [Test]
        public void WithName_NameIsNull_ArgumentException() =>
            Assert.Throws<ArgumentException>(() => Scenario.WithName(null));
    }
}