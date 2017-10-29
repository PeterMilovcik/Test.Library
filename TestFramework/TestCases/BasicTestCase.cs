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

        public void Add(Action action) => 
            Executables.Add(TestStep.Create(action));

        public void Add(string description, Action action) => 
            Executables.Add(TestStep.Create(description, action));

        public void Add(IExecutable executable) => 
            Executables.Add(executable);

        public void Add(IEnumerable<IExecutable> executables) => 
            Executables.AddRange(executables);

        public void Add(params IExecutable[] executables) => 
            Executables.AddRange(executables);

        public virtual void Execute() => 
            Executables.ForEach(testStep => testStep.Execute());

        public IEnumerator<IExecutable> GetEnumerator() => 
            Executables.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            ((IEnumerable)Executables).GetEnumerator();
    }
}