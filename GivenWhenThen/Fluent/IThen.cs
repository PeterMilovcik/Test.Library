using System;
using GivenWhenThen.TestSteps;

namespace GivenWhenThen.Fluent
{
    public interface IThen
    {
        IThen And(Action action);
        IThen And(string description, Action action);
        IThen And(IExecutable executable);
        void Execute();
    }
}