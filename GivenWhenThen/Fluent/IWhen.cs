using System;
using GivenWhenThen.TestSteps;

namespace GivenWhenThen.Fluent
{
    public interface IWhen
    {
        IWhen And(Action action);
        IWhen And(string description, Action action);
        IWhen And(IExecutable testStep);
        IThen Then(Action action);
        IThen Then(string description, Action action);
        IThen Then(IExecutable testStep);
    }
}