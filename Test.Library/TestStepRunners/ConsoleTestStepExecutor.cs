using System;
using System.Collections.Generic;

namespace Test.Library.TestStepRunners
{
    public class ConsoleTestStepExecutor : ITestStepExecutor
    {
        public void Execute(IExecutable testStep)
        {
            Console.Write(testStep.Description);
            try
            {
                testStep.Execute();
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