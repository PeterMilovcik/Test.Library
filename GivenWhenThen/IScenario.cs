using GivenWhenThen.Fluent;

namespace GivenWhenThen
{
    public interface IScenario : IDescriptive, IGiven, IWhen, IThen, IExecutable
    {
    }
}