using System;
using TestFramework.TestSteps;

namespace TestFramework
{
    public class TestStep
    {
        public static IExecutable Create(Action action)
        {
            if (AttributedMethodTestStep.CanUse(action))
                return new AttributedMethodTestStep(action);
            if (MethodTestStep.CanUse(action))
                return new MethodTestStep(action);
            return new ActionTestStep(action);
        }

        public static IExecutable Create(string description, Action action) => 
            new DescribedActionTestStep(description, action);

        public static IExecutable Create(IExecutable executable) => 
            new ExecutableTestStep(executable);
    }
}