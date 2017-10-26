using System;

namespace GivenWhenThen.Fluent
{
    public interface IThen
    {
        IThen And(Action action);
        void Execute();
    }
}