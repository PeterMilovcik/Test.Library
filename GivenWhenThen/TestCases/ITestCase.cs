using System;
using System.Collections.Generic;

namespace GivenWhenThen.TestCases
{
    public interface ITestCase : IExecutable, IEnumerable<IExecutable>
    {
        void Add(Action action);
        void Add(string description, Action action);
        void Add(IExecutable executable);
    }
}