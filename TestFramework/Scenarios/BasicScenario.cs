using System;
using System.Collections;
using System.Collections.Generic;

namespace TestFramework.Scenarios
{
    internal class BasicScenario : IScenario
    {
        protected List<IExecutable> Executables { get; }

        public BasicScenario() => 
            Executables = new List<IExecutable>();

        public virtual void Execute() => 
            Executables.ForEach(e => e.Execute());

        public IScenario Given(Action action) => 
            Add(TestStep.Create(action));

        public IScenario Given(string description, Action action) => 
            Add(TestStep.Create(description, action));

        public IScenario Given(IExecutable executable) => 
            Add(executable);

        public IScenario When(Action action) => 
            Add(TestStep.Create(action));

        public IScenario When(string description, Action action) => 
            Add(TestStep.Create(description, action));

        public IScenario When(IExecutable executable) => 
            Add(executable);

        public IScenario Then(Action action) => 
            Add(TestStep.Create(action));

        public IScenario Then(string description, Action action) => 
            Add(TestStep.Create(description, action));

        public IScenario Then(IExecutable executable) => 
            Add(executable);

        public IScenario And(Action action) => 
            Add(TestStep.Create(action));

        public IScenario And(string description, Action action) => 
            Add(TestStep.Create(description, action));

        public IScenario And(IExecutable executable) => 
            Add(executable);

        public IEnumerator<IExecutable> GetEnumerator() => 
            Executables.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            ((IEnumerable) Executables).GetEnumerator();

        private BasicScenario Add(IExecutable executable)
        {
            Executables.Add(executable);
            return this;
        }
    }
}