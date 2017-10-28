using System;
using System.Collections.Generic;
using GivenWhenThen.Extensions;
using GivenWhenThen.Fluent;
using GivenWhenThen.TestSteps;

namespace GivenWhenThen
{
    public sealed class Scenario : IGiven, IWhen, IThen
    {
        private const string GivenPrefix = "Given: ";
        private const string WhenPrefix = " When: ";
        private const string ThenPrefix = " Then: ";
        private const string AndPrefix = "  And:";
        private List<ITestStep> TestSteps { get; }

        private Scenario()
        {
            TestSteps = new List<ITestStep>();
        }

        public static IGiven Given(Action action)
        {
            var scenario = new Scenario();
            var testStep = CreateTestStep(GivenPrefix, action);
            scenario.TestSteps.Add(testStep);
            return scenario;
        }

        IGiven IGiven.And(Action action) => AddTestStep(AndPrefix, action);

        IWhen IGiven.When(Action action) => AddTestStep(WhenPrefix, action);

        IWhen IWhen.And(Action action) => AddTestStep(AndPrefix, action);

        IThen IWhen.Then(Action action) => AddTestStep(ThenPrefix, action);

        IThen IThen.And(Action action) => AddTestStep(AndPrefix, action);

        private Scenario AddTestStep(string prefix, Action action)
        {
            var testStep = CreateTestStep(prefix, action);
            TestSteps.Add(testStep);
            return this;
        }

        private static ActionTestStep CreateTestStep(string prefix, Action action)
        {
            return action.HasTestStepAttribute()
                ? new AttributedActionTestStep(prefix, action)
                : new ActionTestStep(action);
        }

        public void Execute() => 
            TestSteps.ForEach(testStep => testStep.Execute());
    }
}