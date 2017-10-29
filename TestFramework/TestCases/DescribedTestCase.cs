using System;

namespace TestFramework.TestCases
{
    internal class DescribedTestCase : BasicTestCase
    {
        private readonly string description;

        public DescribedTestCase(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Value cannot be null or empty.", nameof(description));
            this.description = description;
        }

        public override void Execute()
        {
            Console.WriteLine(description);
            base.Execute();
        }
    }
}