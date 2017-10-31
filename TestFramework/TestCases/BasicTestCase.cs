using System;
using System.Collections;
using System.Collections.Generic;

namespace TestFramework.TestCases
{
    internal class BasicTestCase : ITestCase
    {
        protected List<IExecutable> Executables { get; }

        public BasicTestCase() => 
            Executables = new List<IExecutable>();

        public ITestCase Add(Action action) => 
            AddExecutable(TestStep.Create(action));

        public ITestCase Add(string description, Action action) =>
            AddExecutable(TestStep.Create(description, action));

        public ITestCase Add(IExecutable executable) =>
            AddExecutable(executable);

        public ITestCase Add(IEnumerable<IExecutable> executables) =>
            AddExecutables(executables);

        public ITestCase Add(params IExecutable[] executables) =>
            AddExecutables(executables);

        public virtual void Execute() => 
            Executables.ForEach(testStep => testStep.Execute());

        private ITestCase AddExecutable(IExecutable executable)
        {
            Executables.Add(executable);
            return this;
        }

        private ITestCase AddExecutables(IEnumerable<IExecutable> executables)
        {
            Executables.AddRange(executables);
            return this;
        }

        public IEnumerator<IExecutable> GetEnumerator() => 
            Executables.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            ((IEnumerable)Executables).GetEnumerator();
    }
}