using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Data;
using Project.Models;
using Project.Views;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class AllFavoriteRecipesViewModel : ObservableObject, IAllFavoriteRecipesViewModel
    {
        private List<Recipe> _recipes = new();
        private bool _isBusy = true;
        private readonly IRecipeDatabase _recipeDatabase = new RecipeDatabase();
        public ICommand SelectRecipeCommand { get; }
        public string Label { get; } = "Your favorite recipes";

        public AllFavoriteRecipesViewModel()
        {
            SelectRecipeCommand = new AsyncRelayCommand<Recipe>(SelectRecipeAsync);
            _ = Task.Run(OnAppearing);
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