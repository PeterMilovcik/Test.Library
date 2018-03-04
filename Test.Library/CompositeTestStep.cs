using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test.Library
{
    public class CompositeTestStep : IExecutable, IDescriptive, IEnumerable<IExecutable>
    {
        private readonly List<IExecutable> list;

        public CompositeTestStep(string description, IEnumerable<IExecutable> sequence)
        {
            Description = description;
            list = sequence.ToList();
        }

        public string Description { get; }
        public Action Action { get; }
        public void Execute(ITestStepExecutor executor)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IExecutable> GetEnumerator() => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) list).GetEnumerator();
    }
}