using System;

namespace GivenWhenThen.TestSteps
{
    internal class WhenTestStep : TestStep
    {
        public WhenTestStep(Action action) : base(" When: ", action)
        {
        }
    }
}