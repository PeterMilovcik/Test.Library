using System;

namespace GivenWhenThen.Scenarios
{
    internal class DescribedScenario : BasicScenario
    {
        protected string Description { get; }

        public DescribedScenario(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Value cannot be null or empty.", nameof(description));
            Description = description;
        }

        public override void Execute()
        {
            Console.WriteLine(Description);
            base.Execute();
        }
    }
}