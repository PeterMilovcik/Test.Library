using System;
using Test.Library.TestStepExecutors.Extensions;
using static System.Console;

namespace Test.Library.TestStepExecutors.Console
{
    public class ConsoleTestStepExecutor : ITestStepExecutor
    {
        public void Execute(IExecutable testStep)
        {
            testStep.AsDescribed(t => Write(t.Description));
            try
            {
                testStep.AsActionable(t => t.Action());
                testStep.AsSequence(t => t.ForEach(e => e.Execute(this)));
                testStep.AsDescribed(t => WriteLine(" -> Passed"));
            }
            catch (NotImplementedException)
            {
                testStep.AsDescribed(t => WriteLine(" -> Not implemented"));
            }
            catch (Exception e)
            {
                testStep.AsDescribed(t => WriteLine(" -> Failed"));
                WriteLine(e);
            }
        }
    }
}