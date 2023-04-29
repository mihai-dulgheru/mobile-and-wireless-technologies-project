using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Services;
using Project.Views;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class HomeViewModel : ObservableObject, IHomeViewModel
    {
        private readonly IRestService _restService;
        private string _randomFoodTrivia;
        public ICommand GoToSearchProductPageCommand { get; }

        public HomeViewModel()
        {
            _restService = new RestService();
            GoToSearchProductPageCommand = new AsyncRelayCommand(GoToSearchProductPageAsync);
        }

        public string RandomFoodTrivia
        {
            get => _randomFoodTrivia;
            set
            {
                if (_randomFoodTrivia != value)
                {
                    _randomFoodTrivia = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task GoToSearchProductPageAsync()
        {
            await Shell.Current.GoToAsync(nameof(IngredientsPage));
        }

        public async Task GetRandomFoodTriviaAsync()
        {
            string randomFoodTrivia = await _restService.RandomFoodTriviaAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                RandomFoodTrivia = randomFoodTrivia;
            });
        }
    }
}
