using System.Collections.ObjectModel;
using FluentAssertions;

namespace Test.Library.Samples
{
    [UseCase]
    public class MainViewModelTests : GWT
    {
        [Scenario]
        public void Load_Items_NotNullAndNotEmpty()
        {
            MainViewModel mainViewModel = null;
            Given(() => mainViewModel = new MainViewModel());
            When(() => mainViewModel.Load());
            Then(() => mainViewModel.Items.Should().NotBeNull())
                .And(() => mainViewModel.Items.Should().NotBeEmpty());
        }

        [Scenario]
        public void Descriptive_Load_Items_NotNullAndNotEmpty()
        {
            MainViewModel mainViewModel = null;
            Given("Create MainViewModel.",
                () => mainViewModel = new MainViewModel());
            When("Load MainViewModel.", 
                () => mainViewModel.Load());
            Then("MainViewModel.Items are not null.",
                    () => mainViewModel.Items.Should().NotBeNull())
                .And("MainViewModel.Items are not empty.",
                    () => mainViewModel.Items.Should().NotBeEmpty());
        }
    }

    public class MainViewModel
    {
        public void Load()
        {
            Items = new ObservableCollection<string> {"item1"};
        }

        public ObservableCollection<string> Items { get; private set; }
    }
}