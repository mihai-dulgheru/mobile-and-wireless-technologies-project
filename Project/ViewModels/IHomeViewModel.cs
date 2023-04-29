using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IHomeViewModel
    {
        ICommand GoToSearchProductPageCommand { get; }
        string RandomFoodTrivia { get; set; }

        Task GetRandomFoodTriviaAsync();
    }
}