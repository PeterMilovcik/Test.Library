using System;
using NUnit.Framework;

namespace Test.Library
{
    public abstract class GWT : IAnd
    {
        public virtual IAnd Given(Action action)
        {
            Execute(action);
            return this;
        }

        public IAnd Given(string description, Action action)
        {
            Execute($"Given: {description}", action);
            return this;
        }

        public IAnd When(string description, Action action)
        {
            Execute($"When : {description}", action);
            return this;
        }

        public IAnd When(Action action)
        {
            Execute(action);
            return this;
        }

        public IAnd Then(string description, Action action)
        {
            Execute($"Then : {description}", action);
            return this;
        }

        public IAnd Then(Action action)
        {
            Execute(action);
            return this;
        }

        public IAnd Then(bool expectation)
        {
            Execute(() => Assert.That(expectation));
            return this;
        }

        IAnd IAnd.And(Action action)
        {
            Execute(action);
            return this;
        }

        IAnd IAnd.And(bool expectation)
        {
            Execute(() => Assert.That(expectation));
            return this;
        }

        IAnd IAnd.And(string description, Action action)
        {
            Execute($"  And: {description}", action);
            return this;
        }

        IAnd IAnd.And(string description, bool expectation)
        {
            Execute($"  And: {description}", () => Assert.That(expectation));
            return this;
        }

        public virtual TestSteps TestSteps => new TestSteps();

        public virtual TestSteps _ => new TestSteps();

        protected virtual void Execute(string description, Action action)
        {
            try
            {
                Console.Write($"{description} -> ");
                Execute(action);
                Console.WriteLine("Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Failed: {e.Message}");
                throw;
            }
        }

        protected virtual void Execute(Action action)
        {
            try
            {
                BeforeStep();
                action.Invoke();
            }
            finally
            {
                AfterStep();
            }
        }

        protected virtual void BeforeStep()
        {
        }

        protected virtual void AfterStep()
        {
        }
    }

    public interface IAnd
    {
        IAnd And(Action action);

        IAnd And(bool expectation);

        IAnd And(string description, Action action);

        IAnd And(string description, bool expectation);
    }
}