using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Data;
using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class FavoriteRecipeViewModel : ObservableObject, IFavoriteRecipeViewModel
    {
        private Recipe _recipe = new();
        private readonly IRecipeDatabase _recipeDatabase = new RecipeDatabase();
        public ICommand RemoveRecipeCommand { get; }

        public FavoriteRecipeViewModel()
        {
            RemoveRecipeCommand = new AsyncRelayCommand(DeleteRecipeAsync);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            int recipeId = int.Parse(query["RecipeId"] as string);
            Recipe recipe = await _recipeDatabase.GetRecipeAsync(recipeId);
            if (recipe != null)
            {
                Recipe = recipe;
            }
        }

        public Recipe Recipe
        {
            get => _recipe;
            set
            {
                if (_recipe != value)
                {
                    _recipe = value;
                    OnPropertyChanged();
                }
            }
        }

        private async Task DeleteRecipeAsync()
        {
            if (_recipe == null)
            {
                return;
            }
            _ = await _recipeDatabase.DeleteRecipeAsync(_recipe);
            await Shell.Current.GoToAsync("..");
        }
    }
}