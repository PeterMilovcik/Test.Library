using System;
using Moq;
using NUnit.Framework;

namespace TestFramework.UnitTests
{
    internal class TestStepTests
    {
        private const string Description = "test description";

        [Test]
        public void Create_Action_NotNull() => 
            Assert.That(TestStep.Create(() => { }), Is.Not.Null);

        [Test]
        public void Create_DescriptionAction_NotNull() =>
            Assert.That(TestStep.Create(Description, () => { }), Is.Not.Null);

        [Test]
        public void Create_Executable_NotNull() =>
            Assert.That(TestStep.Create(Mock.Of<IExecutable>()), Is.Not.Null);

        [Test]
        public void Create_Action_Execute()
        {
            bool isActionExecuted = false;
            var executable = TestStep.Create(() => isActionExecuted = true);
            executable.Execute();
            Assert.That(isActionExecuted);
        }

        [Test]
        public void Create_DescriptionAction_Execute()
        {
            bool isActionExecuted = false;
            var executable = TestStep.Create(Description, () => isActionExecuted = true);
            executable.Execute();
            Assert.That(isActionExecuted);
        }

        [Test]
        public void Create_Executable_Execute()
        {
            var executable = Mock.Of<IExecutable>();
            var sut = TestStep.Create(executable);
            sut.Execute();
            Mock.Get(executable).Verify(x => x.Execute());
        }

        [Test]
        public void Create_ActionIsNull_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                TestStep.Create((Action) null));

        [Test]
        public void Create_DescriptionIsNull_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                TestStep.Create(null, () => { }));

        [Test]
        public void Create_DescriptionEmpty_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => 
                TestStep.Create(string.Empty, () => { }));

        [Test]
        public void Create_DescriptionNotEmptyActionIsNull_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() =>
                TestStep.Create(Description, null));

        [Test]
        public void Create_ExecutableIsNull_ArgumentNullException() => 
            Assert.Throws<ArgumentNullException>(() => 
                TestStep.Create((IExecutable) null));
    }
}