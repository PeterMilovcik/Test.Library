using System;

namespace Test.Library
{
    public interface IAnd
    {
        IAnd And(Action action);
        IAnd And(string description, Action action);
        IAnd And(IExecutable testStep);
    }
}