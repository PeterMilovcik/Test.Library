using System;
using System.Collections;
using System.Collections.Generic;

namespace GivenWhenThen.TestCases
{
    internal class CommonTestCase : ITestCase
    {
        private readonly List<IExecutable> executables;

        public CommonTestCase()
        {
            executables = new List<IExecutable>();
        }

        public void Add(Action action)
        {
            executables.Add(TestStep.Create(action));
        }

        public void Add(string description, Action action)
        {
            executables.Add(TestStep.Create(description, action));
        }

        public void Add(IExecutable executable)
        {
            executables.Add(executable);
        }

        public virtual void Execute()
        {
            executables.ForEach(testStep => testStep.Execute());
        }

        public IEnumerator<IExecutable> GetEnumerator()
        {
            return executables.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)executables).GetEnumerator();
        }
    }
}