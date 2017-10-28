using System;

namespace GivenWhenThen.Fluent
{
    public interface IThen
    {
        IThen And(Action action);
        IThen And(string description, Action action);
        void Execute();
    }
}