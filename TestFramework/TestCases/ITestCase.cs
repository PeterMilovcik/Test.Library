using System;
using System.Collections.Generic;

namespace TestFramework.TestCases
{
    public interface ITestCase : IExecutable, IEnumerable<IExecutable>
    {
        void Add(Action action);
        void Add(string description, Action action);
        void Add(IExecutable executable);
        void Add(IEnumerable<IExecutable> executables);
        void Add(params IExecutable[] executables);
    }
}