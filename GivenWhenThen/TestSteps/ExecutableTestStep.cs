using System;

namespace GivenWhenThen.TestSteps
{
    internal class ExecutableTestStep : IExecutable
    {
        private readonly IExecutable executable;

        public ExecutableTestStep(IExecutable executable)
        {
            this.executable = executable ?? throw new ArgumentNullException(nameof(executable));
        }

        public void Execute()
        {
            executable.Execute();
        }
    }
}