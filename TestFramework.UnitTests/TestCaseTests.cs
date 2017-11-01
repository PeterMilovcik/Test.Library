using System;
using System.IO;
using Moq;
using NUnit.Framework;

namespace TestFramework.UnitTests
{
    public class TestCaseTests
    {
        [Test]
        public void Create_NotNull() => Assert.That(TestCase.Create(), Is.Not.Null);

        [Test]
        public void AddExecutable_AddedExecutableIsExecuted()
        {
            var executable = Mock.Of<IExecutable>();
            TestCase.Create().Add(executable).Execute();
            Mock.Get(executable).Verify(e => e.Execute());
        }

        [Test]
        public void AddAction_AddedActionIsExecuted()
        {
            bool isExecuted = false;
            TestCase.Create().Add(() => isExecuted = true).Execute();
            Assert.That(isExecuted);
        }

        [Test]
        public void AddDescribedAction_AddedActionIsExecutedAndDescriptionIsDisplayed()
        {
            using (var stringWriter = new StringWriter())
            {
                bool isExecuted = false;
                const string description = "Test Description";
                Console.SetOut(stringWriter);
                TestCase.Create().Add(description, () => isExecuted = true).Execute();
                Assert.That(isExecuted);
                Assert.That(stringWriter.ToString(), 
                    Contains.Substring(description + " -> Passed"));
            }
        }
    }
}