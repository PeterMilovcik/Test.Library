using System;
using NUnit.Framework;

namespace GivenWhenThen.TestSteps
{
    internal class DescribedActionTestStep : ActionTestStep
    {
        public DescribedActionTestStep(string description, Action action)
            : base(action)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public string Description { get; }

        public override void Execute()
        {
            try
            {
                Console.Write($"{Description}");
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