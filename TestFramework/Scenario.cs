using TestFramework.Scenarios;

namespace TestFramework
{
    public static class Scenario
    {
        public static IScenario Create() => 
            new BasicScenario();

        public static IScenario WithName(string description) => 
            new DescribedScenario(description);
    }
}