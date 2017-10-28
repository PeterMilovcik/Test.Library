using System;
using GivenWhenThen.TestCases;

namespace GivenWhenThen
{
    internal class DescribedTestCase : CommonTestCase, IDescriptive
    {
        public DescribedTestCase(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Value cannot be null or empty.", nameof(description));
            Description = description;
        }
        
        public string Description { get; }

        public override void Execute()
        {
            Console.WriteLine(Description);
            base.Execute();
        }
    }
}