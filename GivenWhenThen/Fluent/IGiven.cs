using System;

namespace GivenWhenThen.Fluent
{
    public interface IGiven
    {
        IGiven And(Action action);
        IWhen When(Action action);

    }
}