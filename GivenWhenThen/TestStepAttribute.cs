using System;
using NUnit.Framework;

namespace GivenWhenThen
{
    public class TestStepAttribute : Attribute
    {
        public TestStepAttribute(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }

    public class ScenarioAttribute : TestAttribute
    {
        public ScenarioAttribute(string description)
        {
            Description = description;
        }
    }
}