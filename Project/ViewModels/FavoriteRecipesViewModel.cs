using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Data;
using Project.Models;
using Project.Views;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class FavoriteRecipesViewModel : ObservableObject, IFavoriteRecipesViewModel
    {
        private bool _isBusy = true;
        private List<Recipe> _recipes = new();
        private readonly IRecipeDatabase _recipeDatabase;
        public ICommand SelectRecipeCommand { get; }
        public string Label { get; } = "Your favorite recipes";

        public FavoriteRecipesViewModel()
        {
            _recipeDatabase = new RecipeDatabase();
            SelectRecipeCommand = new AsyncRelayCommand<Recipe>(SelectRecipeAsync);
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await OnAppearing();
            });
        }

        public IList<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                if (_recipes != value)
                {
                    _recipes = (List<Recipe>)value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task SelectRecipeAsync(Recipe recipe)
        {
            if (recipe != null)
            {
                await Shell.Current.GoToAsync($"{nameof(FavoriteRecipePage)}?RecipeId={recipe.Id}");
            }
        }

        public async Task OnAppearing()
        {
            IList<Recipe> recipes = await _recipeDatabase.GetRecipesAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Recipes = recipes;
                IsBusy = false;
            });
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
