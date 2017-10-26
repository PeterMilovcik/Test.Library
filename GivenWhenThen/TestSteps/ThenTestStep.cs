using System;

namespace GivenWhenThen.TestSteps
{
    internal class ThenTestStep : TestStep
    {
        public ThenTestStep(Action action) : base(" Then: ", action)
        {
        }
    }
}