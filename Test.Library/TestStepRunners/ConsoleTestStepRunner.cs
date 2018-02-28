using System;

namespace Test.Library.TestStepRunners
{
    public class ConsoleTestStepRunner : ITestStepRunner
    {
        public void Run(ITestStep testStep)
        {
            Console.Write(testStep.Description);
            try
            {
                testStep.Action();
                Console.WriteLine(" -> Passed");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine(" -> Not implemented");
            }
            catch (Exception e)
            {
                Console.WriteLine(" -> Failed");
                Console.WriteLine(e);
            }
        }
    }
}