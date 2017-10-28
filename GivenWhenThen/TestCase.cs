using System.Collections;
using System.Collections.Generic;

namespace GivenWhenThen
{
    public class TestCase : ITestCase
    {
        private readonly List<IExecutable> testSteps;

        public TestCase()
            : this(string.Empty)
        {
        }

        public TestCase(string description)
        {
            Description = description;
            testSteps = new List<IExecutable>();
        }

        public string Description { get; }

        public void Execute()
        {
            testSteps.ForEach(testStep => testStep.Execute());
        }

        public IEnumerator<IExecutable> GetEnumerator()
        {
            return testSteps.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) testSteps).GetEnumerator();
        }
    }
}