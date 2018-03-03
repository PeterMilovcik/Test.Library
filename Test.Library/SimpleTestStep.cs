using System;

namespace Test.Library
{
    public sealed class SimpleTestStep : IDescriptive, IActionable, IExecutable
    {
        public SimpleTestStep(string description, Action action)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public string Description { get; }

        public Action Action { get; }

        public void Execute(ITestStepExecutor executor) => executor.Execute(this);
    }
}