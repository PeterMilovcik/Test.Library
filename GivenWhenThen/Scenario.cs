using System;
using System.Collections.Generic;
using GivenWhenThen.Fluent;
using GivenWhenThen.TestSteps;

namespace GivenWhenThen
{
    public sealed class Scenario : IGiven, IWhen, IThen
    {
        private List<TestStep> TestSteps { get; }

        private Scenario()
        {
            TestSteps = new List<TestStep>();
        }

        public static IGiven Given(Action action)
        {
            var scenario = new Scenario();
            scenario.AddTestStep(new GivenTestStep(action));
            return scenario;
        }

        IGiven IGiven.And(Action action) => AddTestStep(new AndTestStep(action));

        IWhen IGiven.When(Action action) => AddTestStep(new WhenTestStep(action));

        IWhen IWhen.And(Action action) => AddTestStep(new AndTestStep(action));

        IThen IWhen.Then(Action action) => AddTestStep(new ThenTestStep(action));

        IThen IThen.And(Action action) => AddTestStep(new AndTestStep(action));

        private Scenario AddTestStep(TestStep testStep)
        {
            TestSteps.Add(testStep);
            return this;
        }

        public void Execute() => 
            TestSteps.ForEach(testStep => testStep.Execute());
    }
}