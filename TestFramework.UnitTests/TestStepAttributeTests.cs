using System;
using NUnit.Framework;

namespace TestFramework.UnitTests
{
    internal class TestStepAttributeTests
    {
        private string description;
        private TestStepAttribute sut;

        [SetUp]
        public void SetUp()
        {
            description = "TestDescription";
            CreateSut();
        }

        private void CreateSut()
        {
            sut = new TestStepAttribute(description);
        }

        [Test]
        public void Description_IsRequired()
        {
            description = null;
            Assert.Throws<ArgumentException>(CreateSut);
        }

        [Test]
        public void Description_IsSetFromConstructor()
        {
            Assert.That(sut.Description, Is.EqualTo(description));
        }
    }
}
