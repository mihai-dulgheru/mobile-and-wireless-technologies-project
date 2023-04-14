using CommunityToolkit.Mvvm.Input;
using Project.Views;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class HomeViewModel : IHomeViewModel
    {
        public ICommand GoToSearchProductPageCommand { get; }

        public HomeViewModel()
        {
            GoToSearchProductPageCommand = new AsyncRelayCommand(GoToSearchProductPageAsync);
        }

        private async Task GoToSearchProductPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(SearchProductPage));
        }
    }
}
