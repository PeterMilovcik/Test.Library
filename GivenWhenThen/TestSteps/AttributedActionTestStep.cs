using System;
using System.Reflection;

namespace GivenWhenThen.TestSteps
{
    internal class AttributedActionTestStep : DescribedActionTestStep
    {
        public AttributedActionTestStep(string prefix, Action action)
            :base(prefix, GetTestStepAttribute(action).Description, action)
        {
        }

        private static TestStepAttribute GetTestStepAttribute(Action action)
        {
            var testStepAttribute = action.Method.GetCustomAttribute(typeof(TestStepAttribute)) as TestStepAttribute;
            if (testStepAttribute == null)
                throw new InvalidOperationException(
                    $"Please, add action with {typeof(TestStepAttribute).FullName} " +
                    "for AttributeTestStep constructor.");
            return testStepAttribute;
        }
    }
}