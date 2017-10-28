using System;
using System.Collections.Generic;
using GivenWhenThen.Extensions;
using GivenWhenThen.Fluent;
using GivenWhenThen.TestSteps;

namespace GivenWhenThen
{
    public sealed class Scenario : IGiven, IWhen, IThen, IExecutable
    {
        private const string GivenPrefix = "Given: ";
        private const string WhenPrefix = " When: ";
        private const string ThenPrefix = " Then: ";
        private const string AndPrefix = "  And:";
        private List<IExecutable> TestSteps { get; }

        private Scenario()
        {
            TestSteps = new List<IExecutable>();
        }

        public static IGiven Given(Action action)
        {
            var scenario = new Scenario();
            var testStep = CreateTestStep(GivenPrefix, action);
            scenario.TestSteps.Add(testStep);
            return scenario;
        }

        public static IGiven Given(string description, Action action)
        {
            var scenario = new Scenario();
            var testStep = CreateTestStep(GivenPrefix, action, description);
            scenario.TestSteps.Add(testStep);
            return scenario;
        }

        public static IGiven Given(IExecutable testStep)
        {
            var scenario = new Scenario();
            scenario.TestSteps.Add(testStep);
            return scenario;
        }

        IGiven IGiven.And(Action action) => AddTestStep(AndPrefix, action);

        IGiven IGiven.And(string description, Action action) => AddTestStep(AndPrefix, action, description);

        IGiven IGiven.And(IExecutable testStep) => AddTestStep(testStep);

        IWhen IGiven.When(Action action) => AddTestStep(WhenPrefix, action);

        IWhen IGiven.When(string description, Action action) => AddTestStep(WhenPrefix, action, description);

        IWhen IGiven.When(IExecutable testStep) => AddTestStep(testStep);

        IWhen IWhen.And(Action action) => AddTestStep(AndPrefix, action);

        IWhen IWhen.And(string description, Action action) => AddTestStep(AndPrefix, action, description);

        IWhen IWhen.And(IExecutable testStep) => AddTestStep(testStep);

        IThen IWhen.Then(Action action) => AddTestStep(ThenPrefix, action);

        IThen IWhen.Then(string description, Action action) => AddTestStep(ThenPrefix, action, description);

        IThen IWhen.Then(IExecutable testStep) => AddTestStep(testStep);

        IThen IThen.And(Action action) => AddTestStep(AndPrefix, action);

        IThen IThen.And(string description, Action action) => AddTestStep(AndPrefix, action, description);

        IThen IThen.And(IExecutable testStep) => AddTestStep(testStep);

        private Scenario AddTestStep(string prefix, Action action)
        {
            var testStep = CreateTestStep(prefix, action);
            TestSteps.Add(testStep);
            return this;
        }

        private Scenario AddTestStep(string prefix, Action action, string description)
        {
            var testStep = CreateTestStep(prefix, action, description);
            TestSteps.Add(testStep);
            return this;
        }

        private Scenario AddTestStep(IExecutable testStep)
        {
            TestSteps.Add(testStep);
            return this;
        }

        private static IExecutable CreateTestStep(string prefix, Action action)
        {
            IExecutable result;
            if (action.HasTestStepAttribute())
            {
                result = new AttributedActionTestStep(prefix, action);
            }
            else if (action.Method.Name.Contains("<") == false)
            {
                result = new DescribedActionTestStep(prefix, action.Method.Name, action);
            }
            else
            {
                result = new ActionTestStep(action);
            }
            return result;
        }

        private static IExecutable CreateTestStep(string prefix, Action action, string description)
        {
            return new DescribedActionTestStep(prefix, description, action);
        }

        public void Execute() => 
            TestSteps.ForEach(testStep => testStep.Execute());
    }
}