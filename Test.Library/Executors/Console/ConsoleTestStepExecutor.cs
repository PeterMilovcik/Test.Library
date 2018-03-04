using System;
using Test.Library.Extensions;

namespace Test.Library.Executors.Console
{
    public class ConsoleTestStepExecutor : ITestStepExecutor
    {
        public void Execute(ITestStep testStep)
        {
            if (testStep == null) throw new ArgumentNullException(nameof(testStep));

            testStep.AsDescriptive(t => System.Console.Write(t.Description));
            try
            {
                testStep.AsActionable(t => t.Action());
                testStep.AsSequence(t => t.ForEach(e => e.Execute(this)));
                testStep.AsDescriptive(t => System.Console.WriteLine(" -> Passed"));
            }
            catch (NotImplementedException)
            {
                testStep.AsDescriptive(t => System.Console.WriteLine(" -> Not implemented"));
            }
            catch (Exception e)
            {
                testStep.AsDescriptive(t => System.Console.WriteLine(" -> Failed"));
                System.Console.WriteLine(e);
            }
        }
    }
}