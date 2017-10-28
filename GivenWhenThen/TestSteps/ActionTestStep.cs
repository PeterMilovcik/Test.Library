using System;
using NUnit.Framework;

namespace GivenWhenThen.TestSteps
{
    internal class ActionTestStep : IExecutable
    {
        public ActionTestStep(Action action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public Action Action { get; }

        public virtual void Execute()
        {
            try
            {
                Action.Invoke();
            }
            catch (NotImplementedException)
            {
                Assert.Fail("Not implemented.");
            }
            catch (Exception e)
            {
                Assert.Fail("Failed\n" +
                            $"Error message:\n{e.Message}\n" +
                            $"{e.StackTrace}");
            }
        }
    }
}