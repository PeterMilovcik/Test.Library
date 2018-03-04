using System;
using Test.Library.Executors.Console;
using Test.Library.TestSteps;

namespace Test.Library
{
    public abstract class GWT : IGivenWhenThen, IAnd
    {
        protected GWT() => Executor = new ConsoleTestStepExecutor();

        public virtual IAnd Given(Action action)
        {
            Executor.Execute(new SimpleTestStep(action));
            return this;
        }

        public IAnd Given(string description, Action action)
        {
            Executor.Execute(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd Given(ITestStep testStep)
        {
            Executor.Execute(testStep);
            return this;
        }

        public IAnd When(string description, Action action)
        {
            Executor.Execute(new SimpleTestStep(description, action));
            return this;
        }

        public IAnd When(ITestStep testStep)
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

        public IAnd Then(ITestStep testStep)
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

        public IAnd And(ITestStep testStep)
        {
            Executor.Execute(testStep);
            return this;
        }

        protected ITestStepExecutor Executor { get; set; }
    }
}