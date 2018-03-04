using NUnit.Framework;
using System;
using System.Reflection;

namespace Test.Library.TestSteps
{
    public sealed class SimpleTestStep : IDescriptive, IActionable, ITestStep
    {
        public SimpleTestStep(string description, Action action)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public SimpleTestStep(Action action)
            : this(GetDescription(action), action)
        {
        }

        private static string GetDescription(Action action)
        {
            if (action == null) throw new ArgumentNullException(nameof(action));
            var attribute = action.Method.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Properties.Get("Description").ToString() ?? action.Method.Name;
        }

        public string Description { get; }

        public Action Action { get; }

        public void Execute(ITestStepExecutor executor) => executor.Execute(this);
    }
}