using System;

namespace Test.Library
{
    public interface ITestStepFactory
    {
        ITestStep Create(Action action);
        ITestStep Create(string description, Action action);
    }
}