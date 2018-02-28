using System.Collections.Generic;

namespace Test.Library.Samples
{
    [UseCase]
    public class ListTests : GWT
    {
        [Scenario]
        public void Add()
        {
            List<int> list = null;
            Given(() => list = new List<int>());
            When(() => list.Add(1));
            Then(list.Contains(1));
        }
    }
}