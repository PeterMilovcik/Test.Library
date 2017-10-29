using GivenWhenThen.Scenarios;

namespace GivenWhenThen
{
    public static class Scenario
    {
        public static IScenario Create() => 
            new BasicScenario();

        public static IScenario WithName(string description) => 
            new DescribedScenario(description);
    }
}