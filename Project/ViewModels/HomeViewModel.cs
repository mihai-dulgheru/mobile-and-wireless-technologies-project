using CommunityToolkit.Mvvm.ComponentModel;
using Project.Services;

namespace Project.ViewModels
{
    internal class HomeViewModel : ObservableObject, IHomeViewModel
    {
        private readonly IRestService _restService;
        private string _randomFoodTrivia;

        public HomeViewModel()
        {
            _restService = new RestService();
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
