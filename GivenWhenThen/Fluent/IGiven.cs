using System;

namespace GivenWhenThen.Fluent
{
    public interface IGiven
    {
        IGiven And(Action action);
        IGiven And(string description, Action action);
        IWhen When(Action action);
        IWhen When(string description, Action action);
    }
}