using TestFramework.Stories;

namespace TestFramework
{
    public static class Story
    {
        public static IStory Create() =>
            new BasicStory();
        public static IStory WithName(string description) => 
            new DescribedStory(description);
    }
}