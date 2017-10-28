using System;
using System.Collections.Generic;
using GivenWhenThen.Scenarios;

namespace GivenWhenThen
{
    public class Scenario : IScenario
    {
        private readonly List<IExecutable> executables;

        public Scenario()
            : this(null)
        {
        }

        public Scenario(string description)
        {
            executables = new List<IExecutable>();
            Description = description;
        }

        public string Description { get; }

        public void Execute()
        {
            Console.WriteLine(Description);
            foreach (var executable in executables)
            {
                DisplayDescription(executable);
                executable.Execute();
            }
        }

        public IScenario Given(Action action) => Add(TestStep.Create(action));

        public IScenario Given(string description, Action action) => Add(TestStep.Create(description, action));

        public IScenario Given(IExecutable executable) => Add(executable);

        public IScenario When(Action action) => Add(TestStep.Create(action));

        public IScenario When(string description, Action action) => Add(TestStep.Create(description, action));

        public IScenario When(IExecutable executable) => Add(executable);

        public IScenario Then(Action action) => Add(TestStep.Create(action));

        public IScenario Then(string description, Action action) => Add(TestStep.Create(description, action));

        public IScenario Then(IExecutable executable) => Add(executable);

        public IScenario And(Action action) => Add(TestStep.Create(action));

        public IScenario And(string description, Action action) => Add(TestStep.Create(description, action));

        public IScenario And(IExecutable executable) => Add(executable);

        private Scenario Add(IExecutable executable)
        {
            executables.Add(executable);
            return this;
        }
        
        private static void DisplayDescription(IExecutable executable)
        {
            var descriptive = executable as IDescriptive;
            if (descriptive != null)
            {
                Console.WriteLine(descriptive.Description);
            }
        }
    }
}