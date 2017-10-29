using System.Collections.Generic;
using GivenWhenThen.Scenarios;

namespace GivenWhenThen.Stories
{
    public interface IStory : IExecutable, IEnumerable<IScenario>
    {
        IStory Add(IScenario scenario);
        IStory Add(IEnumerable<IScenario> scenarios);
        IStory Add(params IScenario[] scenarios);
    }
}