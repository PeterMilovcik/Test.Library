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

        IAnd IGivenWhenThen.Given(Action action) => 
            Execute(TestStepFactory.Create(action));

        IAnd IGivenWhenThen.Given(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        IAnd IGivenWhenThen.Given(ITestStep testStep) => 
            Execute(testStep);

        IAnd IGivenWhenThen.When(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        IAnd IGivenWhenThen.When(ITestStep testStep) => 
            Execute(testStep);

        IAnd IGivenWhenThen.When(Action action) => 
            Execute(TestStepFactory.Create(action));

        IAnd IGivenWhenThen.Then(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        IAnd IGivenWhenThen.Then(ITestStep testStep) => 
            Execute(testStep);

        IAnd IGivenWhenThen.Then(Action action) => 
            Execute(TestStepFactory.Create(action));

        IAnd IAnd.And(Action action) => 
            Execute(TestStepFactory.Create(action));

        IAnd IAnd.And(string description, Action action) => 
            Execute(TestStepFactory.Create(description, action));

        IAnd IAnd.And(ITestStep testStep) => 
            Execute(testStep);

        private IAnd Execute(ITestStep testStep)
        {
            TestStepExecutor.Execute(testStep);
            return this;
        }
    }
}