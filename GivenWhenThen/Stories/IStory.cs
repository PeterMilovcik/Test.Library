using System.Collections.Generic;
using GivenWhenThen.Scenarios;

namespace GivenWhenThen.Stories
{
    public interface IStory : IDescriptive, IExecutable, IEnumerable<IScenario>
    {
        IStory Add(IScenario scenario);
    }
}