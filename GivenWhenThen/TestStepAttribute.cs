using System;

namespace GivenWhenThen
{
    public class TestStepAttribute : Attribute
    {
        public TestStepAttribute(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Value cannot be null or empty.", nameof(description));
            Description = description;
        }

        public string Description { get; }
    }
}