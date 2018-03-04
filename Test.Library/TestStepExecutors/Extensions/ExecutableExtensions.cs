using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Library.TestStepExecutors.Extensions
{
    public static class ExecutableExtensions
    {
        public static void AsDescribed(this IExecutable executable, Action<IDescriptive> action)
        {
            if (executable is IDescriptive descriptive)
                action(descriptive);
        }

        public static void AsActionable(this IExecutable executable, Action<IActionable> action)
        {
            if (executable is IActionable actionable)
                action.Invoke(actionable);
        }

        public static void AsSequence(this IExecutable executable, Action<List<IExecutable>> action)
        {
            if (executable is IEnumerable<IExecutable> sequence)
                action(sequence.ToList());
        }
    }
}