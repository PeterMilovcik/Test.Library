using System;
using System.Collections.Generic;
using System.Linq;

namespace Test.Library.Extensions
{
    public static class TestStepExtensions
    {
        public static void AsDescriptive(this ITestStep testStep, Action<IDescriptive> action)
        {
            if (testStep is IDescriptive descriptive)
                action(descriptive);
        }

        public static void AsActionable(this ITestStep testStep, Action<IActionable> action)
        {
            if (testStep is IActionable actionable)
                action.Invoke(actionable);
        }

        public static void AsSequence(this ITestStep testStep, Action<List<ITestStep>> action)
        {
            if (testStep is IEnumerable<ITestStep> sequence)
                action(sequence.ToList());
        }
    }
}