using System.Collections.ObjectModel;
using FluentAssertions;
using NUnit.Framework;

namespace Test.Library.Samples
{
    public class MainViewModel
    {
        public void Load()
        {
            Items = new ObservableCollection<string> {"item1"};
        }

        public ObservableCollection<string> Items { get; private set; }
    }

    internal class MainViewModelSut
    {
        public MainViewModel MainViewModel { get; set; }
    }

    [TestFixture]
    public class MainViewModelTests : GWT
    {
        [Test]
        public void Load_Items_NotNullAndNotEmpty()
        {
            var sut = new MainViewModelSut();
            Given(sut.CreateMainViewModel);
            When(sut.LoadMainViewModel);
            Then(sut.ItemsAreLoaded);
        }

        [Test]
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

    internal static class MainViewModelSutTestSteps
    {
        [Description("Create MainViewModel.")]
        public static void CreateMainViewModel(this MainViewModelSut sut) => 
            sut.MainViewModel = new MainViewModel();

        [Description("Load MainViewModel.")]
        public static void LoadMainViewModel(this MainViewModelSut sut) =>
            sut.MainViewModel.Load();

        [Description("MainViewModel.Items are loaded.")]
        public static void ItemsAreLoaded(this MainViewModelSut sut) =>
            Assert.That(sut.MainViewModel.Items, Is.Not.Empty);
    }
}