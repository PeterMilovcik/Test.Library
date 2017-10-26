using System;
using System.Reflection;
using NUnit.Framework;

namespace GivenWhenThen.TestSteps
{
    internal class TestStep
    {
        private readonly string prefix;
        public Action Action { get; }
        public string Description => prefix + GetTestStepAttribute(Action).Description;

        public TestStep(string prefix, Action action)
        {
            this.prefix = prefix;
            Action = action;
        }

        private static TestStepAttribute GetTestStepAttribute(Action action)
        {
            var attribute = action.Method.GetCustomAttribute(typeof(TestStepAttribute)) as TestStepAttribute;
            if (attribute == null)
                throw new InvalidOperationException(
                    $"Please, add TestStep attribute for method: {action.Method.Name}.");
            return attribute;
        }

        public void Execute()
        {
            try
            {
                Console.Write(Description);
                Action.Invoke();
                Console.WriteLine(" -> Passed");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine(" -> Not implemented");
                Assert.Fail($"'{Description}' is not implemented.");
            }
            catch (Exception e)
            {
                Console.WriteLine(" -> Failed");
                Assert.Fail($"Failed: {Description}\n" +
                            $"Error message:\n{e.Message}\n" +
                            $"{e.StackTrace}");
            }
        }
    }
}