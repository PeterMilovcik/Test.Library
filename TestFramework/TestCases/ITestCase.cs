using System;
using System.Collections.Generic;

namespace TestFramework.TestCases
{
    public interface ITestCase : IExecutable, IEnumerable<IExecutable>
    {
        ITestCase Add(Action action);
        ITestCase Add(string description, Action action);
        ITestCase Add(IExecutable executable);
        ITestCase Add(IEnumerable<IExecutable> executables);
        ITestCase Add(params IExecutable[] executables);
    }
}