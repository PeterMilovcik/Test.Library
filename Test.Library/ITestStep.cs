using System;

namespace Test.Library
{
    public interface ITestStep
    {
        string Description { get; }
        Action Action { get; }

        void Execute(ITestStepRunner testStepRunner);
    }
}