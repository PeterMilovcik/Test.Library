namespace Test.Library
{
    public interface ITestStep
    {
        void Execute(ITestStepExecutor executor);
    }
}