using System;
using GivenWhenThen.TestSteps;

namespace GivenWhenThen.Fluent
{
    public interface IWhen
    {
        IWhen And(Action action);
        IWhen And(string description, Action action);
        IWhen And(ITestStep testStep);
        IThen Then(Action action);
        IThen Then(string description, Action action);
        IThen Then(ITestStep testStep);
    }
}