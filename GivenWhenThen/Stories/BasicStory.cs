using System;
using System.Collections;
using System.Collections.Generic;
using GivenWhenThen.Scenarios;

namespace GivenWhenThen.Stories
{
    public class BasicStory : IStory
    {
        protected List<IScenario> Scenarios { get; }

        public BasicStory() => 
            Scenarios = new List<IScenario>();

        public virtual void Execute() => 
            Scenarios.ForEach(scenario => scenario.Execute());

        public IStory Add(IScenario scenario)
        {
            if (scenario == null) throw new ArgumentNullException(nameof(scenario));
            Scenarios.Add(scenario);
            return this;
        }

        public IStory Add(IEnumerable<IScenario> scenarios)
        {
            if (scenarios == null) throw new ArgumentNullException(nameof(scenarios));
            Scenarios.AddRange(scenarios);
            return this;
        }

        public IStory Add(params IScenario[] scenarios)
        {
            if (scenarios == null) throw new ArgumentNullException(nameof(scenarios));
            Scenarios.AddRange(scenarios);
            return this;
        }

        public IEnumerator<IScenario> GetEnumerator() => 
            Scenarios.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            ((IEnumerable) Scenarios).GetEnumerator();
    }
}