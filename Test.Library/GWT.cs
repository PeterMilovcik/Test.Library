using System;
using Test.Library.TestStepRunners;

namespace Test.Library
{
    public abstract class GWT : IGivenWhenThen, IAnd
    {
        protected GWT() => Runner = new ConsoleTestStepRunner();

        public virtual IAnd Given(Action action)
        {
            Runner.Run(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        public IAnd Given(string description, Action action)
        {
            Runner.Run(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd Given(ITestStep testStep)
        {
            Runner.Run(testStep);
            return this;
        }

        public IAnd When(string description, Action action)
        {
            Runner.Run(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd When(ITestStep testStep)
        {
            Runner.Run(testStep);
            return this;
        }

        public IAnd When(Action action)
        {
            Runner.Run(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        public IAnd Then(string description, Action action)
        {
            Runner.Run(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd Then(ITestStep testStep)
        {
            Runner.Run(testStep);
            return this;
        }

        public IAnd Then(Action action)
        {
            Runner.Run(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        IAnd IAnd.And(Action action)
        {
            Runner.Run(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        IAnd IAnd.And(string description, Action action)
        {
            Runner.Run(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd And(ITestStep testStep)
        {
            Runner.Run(testStep);
            return this;
        }

        protected ITestStepRunner Runner { get; set; }

        public virtual TestSteps TestSteps => new TestSteps();

        public virtual TestSteps _ => new TestSteps();
    }
}