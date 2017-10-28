using System;

namespace GivenWhenThen.Fluent
{
    public interface IGiven
    {
        IGiven Given(Action action);
        IGiven Given(string description, Action action);
        IGiven Given(IExecutable executable);
        IGiven And(Action action);
        IGiven And(string description, Action action);
        IGiven And(IExecutable executable);
        IWhen When(Action action);
        IWhen When(string description, Action action);
        IWhen When(IExecutable testStep);
    }
}