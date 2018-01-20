using System;

namespace Test.Library
{
    public abstract class GWT : IGiven, IWhen, IThen, ISetup, ICleanUp, ITestSteps
    {
        public virtual IGiven Given(Action action)
        {
            Execute(action);
            return this;
        }

        public virtual IGiven Given(string description, Action action)
        {
            Execute($"Given: {description}", action);
            return this;
        }

        public virtual IWhen When(string description, Action action)
        {
            Execute($"When : {description}", action);
            return this;
        }

        public virtual IWhen When(Action action)
        {
            Execute(action);
            return this;
        }

        public virtual IThen Then(string description, Action action)
        {
            Execute($"Then : {description}", action);
            return this;
        }

        public virtual IThen Then(Action action)
        {
            Execute(action);
            return this;
        }

        public virtual IAnd And(Action action)
        {
            Execute(action);
            return this;
        }

        public virtual IAnd And(string description, Action action)
        {
            Execute($"  And: {description}", action);
            return this;
        }

        public virtual ISetup Setup => this;

        public virtual ICleanUp CleanUp => this;

        public virtual ITestSteps TestSteps => this;

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
}