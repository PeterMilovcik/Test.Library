using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test.Library.TestSteps
{
    public class CompositeTestStep : ITestStep, IDescriptive, IEnumerable<ITestStep>
    {
        public List<ITestStep> Sequence { get; }

        public CompositeTestStep(string description, IEnumerable<ITestStep> sequence)
        {
            Description = description;
            Sequence = sequence.ToList();
        }

        public string Description { get; }

        public void Execute(ITestStepExecutor executor) => executor.Execute(this);

        public IEnumerator<ITestStep> GetEnumerator() => Sequence.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) Sequence).GetEnumerator();
    }
}