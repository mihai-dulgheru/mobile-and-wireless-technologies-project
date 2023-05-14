using CommunityToolkit.Mvvm.Input;
using Project.Views;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class IngredientsViewModel : IIngredientsViewModel
    {
        public ICommand GoToSearchRecipePageCommand { get; }

        public IngredientsViewModel()
        {
            GoToSearchRecipePageCommand = new AsyncRelayCommand<string>(GoToSearchRecipePageAsync);
        }

        private async Task GoToSearchRecipePageAsync(string ingredients)
        {
            if (!string.IsNullOrWhiteSpace(ingredients))
            {
                await Shell.Current.GoToAsync($"{nameof(AllRecipesPage)}?Ingredients={ingredients}");
            }
        }
    }
}
