using System;

namespace GivenWhenThen.TestSteps
{
    internal class AndTestStep : TestStep
    {
        public AndTestStep(Action action) : base("  And: ", action)
        {
        }
    }
}