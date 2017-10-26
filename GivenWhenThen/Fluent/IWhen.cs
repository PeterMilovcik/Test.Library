using System;

namespace GivenWhenThen.Fluent
{
    public interface IWhen
    {
        IWhen And(Action action);
        IThen Then(Action action);
    }
}