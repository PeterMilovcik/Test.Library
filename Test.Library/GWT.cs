using System;
using Test.Library.Executors.Console;

namespace Test.Library
{
    public abstract class GWT : IGivenWhenThen, IAnd
    {
        protected GWT() => TestStepExecutor = new ConsoleTestStepExecutor();

        protected ITestStepExecutor TestStepExecutor { get; private set; }

        protected void SetTestStepExecutor(ITestStepExecutor executor) =>
            TestStepExecutor = executor ?? throw new ArgumentNullException(nameof(executor));

        protected ITestStepFactory TestStepFactory { get; private set; }

        protected void SetTestStepFactory(ITestStepFactory factory) =>
            TestStepFactory = factory ?? throw new ArgumentNullException(nameof(factory));

        public IAnd Given(Action action) => 
            Execute(TestStepFactory.Create(action));

        public IAnd Given(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        public IAnd Given(ITestStep testStep) => 
            Execute(testStep);

        public IAnd When(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        public IAnd When(ITestStep testStep) => 
            Execute(testStep);

        public IAnd When(Action action) => 
            Execute(TestStepFactory.Create(action));

        public IAnd Then(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        public IAnd Then(ITestStep testStep) => 
            Execute(testStep);

        public IAnd Then(Action action) => 
            Execute(TestStepFactory.Create(action));

        public IAnd And(Action action) => 
            Execute(TestStepFactory.Create(action));

        public IAnd And(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        public IAnd And(ITestStep testStep) => 
            Execute(testStep);

        private IAnd Execute(ITestStep testStep)
        {
            TestStepExecutor.Execute(testStep);
            return this;
        }
    }
}