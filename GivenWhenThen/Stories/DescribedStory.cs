using System;
using System.Collections;
using System.Collections.Generic;
using GivenWhenThen.Scenarios;

namespace GivenWhenThen.Stories
{
    public class DescribedStory : IStory
    {
        private readonly List<IScenario> scenarios;

        public DescribedStory(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("Value cannot be null or empty.", nameof(description));
            Description = description;
            scenarios = new List<IScenario>();
        }

        public string Description { get; }

        public IEnumerator<IScenario> GetEnumerator()
        {
            return scenarios.GetEnumerator();
        }

        public void Add(IScenario scenario)
        {
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));
            scenarios.Add(scenario);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) scenarios).GetEnumerator();
        }

        public void Execute()
        {
            Console.WriteLine(Description);
            scenarios.ForEach(scenario => scenario.Execute());
        }
    }
}