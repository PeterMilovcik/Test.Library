using System.Collections.Generic;
using GivenWhenThen.TestSteps;

namespace GivenWhenThen
{
    public interface IScenario : IEnumerable<ITestStep>
    {
        void Execute();
    }
}