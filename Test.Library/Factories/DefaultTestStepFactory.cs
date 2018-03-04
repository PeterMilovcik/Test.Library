using System;
using Test.Library.TestSteps;

namespace Test.Library.Factories
{
    public class DefaultTestStepFactory : ITestStepFactory
    {
        public ITestStep Create(Action action) => 
            new SimpleTestStep(action);

        public ITestStep Create(string description, Action action) => 
            new SimpleTestStep(description, action);
    }
}