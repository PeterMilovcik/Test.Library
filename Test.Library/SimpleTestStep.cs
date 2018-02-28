using System;

namespace Test.Library
{
    internal class SimpleTestStep : ITestStep
    {
        public SimpleTestStep(string description, Action action)
        {
            Action = action;
            Description = description;
        }

        public string Description { get; }
        public Action Action { get; }

        public void Execute(ITestStepRunner testStepRunner) => testStepRunner.Run(this);
    }
}