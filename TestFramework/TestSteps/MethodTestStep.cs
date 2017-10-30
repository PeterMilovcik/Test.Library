using System;

namespace TestFramework.TestSteps
{
    internal class MethodTestStep : DescribedActionTestStep
    {
        public MethodTestStep(Action action) : base(action.Method.Name, action)
        {
        }

        public static bool CanUse(Action action)
        {
            return action?.Method.Name.Contains("<") == false;
        }
    }
}