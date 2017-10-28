using GivenWhenThen.Stories;

namespace GivenWhenThen
{
    public static class Story
    {
        public static IStory Create(string description)
        {
            return new DescribedStory(description);
        }
    }
}