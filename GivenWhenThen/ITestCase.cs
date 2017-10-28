using System.Collections.Generic;

namespace GivenWhenThen
{
    public interface ITestCase : IDescriptive, IExecutable, IEnumerable<IExecutable>
    {
    }
}