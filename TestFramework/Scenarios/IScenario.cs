using System;
using System.Collections.Generic;

namespace TestFramework.Scenarios
{
    public interface IScenario : IExecutable, IEnumerable<IExecutable>
    {
        IScenario Given(Action action);
        IScenario Given(string description, Action action);
        IScenario Given(IExecutable executable);
        IScenario When(Action action);
        IScenario When(string description, Action action);
        IScenario When(IExecutable testStep);
        IScenario Then(Action action);
        IScenario Then(string description, Action action);
        IScenario Then(IExecutable executable);
        IScenario And(Action action);
        IScenario And(string description, Action action);
        IScenario And(IExecutable executable);
    }
}