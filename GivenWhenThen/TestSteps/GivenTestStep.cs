using System;

namespace GivenWhenThen.TestSteps
{
    internal class GivenTestStep : TestStep
    {
        public GivenTestStep(Action action) : base("Given: ", action)
        {
        }
    }
}