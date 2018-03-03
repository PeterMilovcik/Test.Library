using System;

namespace Test.Library
{
    public interface IDescriptive
    {
        string Description { get; }
    }

    public interface IActionable
    {
        Action Action { get; }
    }

    public interface IExecutable
    {
        void Execute(ITestStepExecutor executor);
    }
}