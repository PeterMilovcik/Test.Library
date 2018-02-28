using System;

namespace Test.Library
{
    public interface ITestStep
    {
        string Description { get; }

        void Execute(ITestStepRunner testStepRunner);
    }
}