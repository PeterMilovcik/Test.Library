using System;
using System.Collections.Generic;
using GivenWhenThen.Fluent;

namespace GivenWhenThen
{
    public class Scenario : IScenario
    {
        private readonly List<IExecutable> executables;

        public Scenario()
            :this(null)
        {
        }

        public Scenario(string description)
        {
            this.executables = new List<IExecutable>();
            Description = description;
        }

        public string Description { get; }

        public void Execute()
        {
            Console.WriteLine(Description);
            foreach (var e in executables)
            {
                e.Execute();
            }
        }

        public IGiven Given(Action action) => Add(TestStep.Create(action));
        public IGiven Given(string description, Action action) => Add(TestStep.Create(description, action));
        public IGiven Given(IExecutable executable) => Add(executable);
        IGiven IGiven.And(Action action) => Add(TestStep.Create(action));
        IGiven IGiven.And(string description, Action action) => Add(TestStep.Create(description, action));
        IGiven IGiven.And(IExecutable executable) => Add(executable);
        IWhen IGiven.When(Action action) => Add(TestStep.Create(action));
        IWhen IGiven.When(string description, Action action) => Add(TestStep.Create(description, action));
        IWhen IGiven.When(IExecutable executable) => Add(executable);
        IWhen IWhen.And(Action action) => Add(TestStep.Create(action));
        IWhen IWhen.And(string description, Action action) => Add(TestStep.Create(description, action));
        IWhen IWhen.And(IExecutable executable) => Add(executable);
        IThen IWhen.Then(Action action) => Add(TestStep.Create(action));
        IThen IWhen.Then(string description, Action action) => Add(TestStep.Create(description, action));
        IThen IWhen.Then(IExecutable executable) => Add(executable);
        IThen IThen.And(Action action) => Add(TestStep.Create(action));
        IThen IThen.And(string description, Action action) => Add(TestStep.Create(description, action));
        IThen IThen.And(IExecutable executable) => Add(executable);

        private Scenario Add(IExecutable executable)
        {
            executables.Add(executable);
            return this;
        }
    }
}