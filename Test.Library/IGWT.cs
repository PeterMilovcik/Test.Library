using System;

namespace Test.Library
{
    public interface IGivenWhenThen
    {
        IAnd Given(Action action);
        IAnd Given(string description, Action action);
        IAnd Given(ITestStep testStep);
        IAnd When(Action action);
        IAnd When(string description, Action action);
        IAnd When(ITestStep testStep);
        IAnd Then(Action action);
        IAnd Then(string description, Action action);
        IAnd Then(ITestStep testStep);
    }
}