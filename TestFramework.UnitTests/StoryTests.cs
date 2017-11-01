using System;
using NUnit.Framework;

namespace TestFramework.UnitTests
{
    internal class StoryTests
    {
        [Test]
        public void Create_NotNull() => 
            Assert.That(Story.Create(), Is.Not.Null);

        [Test]
        public void WithName_NotNull() => 
            Assert.That(Story.WithName("story name"), Is.Not.Null);

        [Test]
        public void WithName_NameIsNull_ArgumentException() => 
            Assert.Throws<ArgumentException>(() => Story.WithName(null));
    }
}