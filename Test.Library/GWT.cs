using System;
using Test.Library.TestStepRunners;

namespace Test.Library
{
    public abstract class GWT : IGivenWhenThen, IAnd
    {
        protected GWT() => Executor = new ConsoleTestStepExecutor();

        public virtual IAnd Given(Action action)
        {
            Executor.Execute(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        public IAnd Given(string description, Action action)
        {
            Executor.Execute(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd Given(IExecutable testStep)
        {
            Executor.Execute(testStep);
            return this;
        }

        public IAnd When(string description, Action action)
        {
            Executor.Execute(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd When(IExecutable testStep)
        {
            Executor.Execute(testStep);
            return this;
        }

        public IAnd When(Action action)
        {
            Executor.Execute(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        public IAnd Then(string description, Action action)
        {
            Executor.Execute(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd Then(IExecutable testStep)
        {
            Executor.Execute(testStep);
            return this;
        }        

        public IAnd Then(Action action)
        {
            Executor.Execute(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        IAnd IAnd.And(Action action)
        {
            Executor.Execute(new SimpleTestStep(action.Method.Name, action));
            return this;
        }

        IAnd IAnd.And(string description, Action action)
        {
            Executor.Execute(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd And(IExecutable testStep)
        {
            Executor.Execute(testStep);
            return this;
        }

        protected virtual ITestStepExecutor Executor { get; set; }

        protected virtual TestSteps TestSteps => new TestSteps();

        protected virtual TestSteps _ => new TestSteps();
    }
}