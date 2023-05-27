using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Data;
using Project.Models;
using Project.Services;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class RecipeViewModel : ObservableObject, IRecipeViewModel
    {
        private Recipe _recipe;
        private readonly IRecipeDatabase _recipeDatabase;
        private readonly IRestService _restService;
        public ICommand AddOrDeleteRecipeCommand { get; }

        public RecipeViewModel()
        {
            _recipeDatabase = new RecipeDatabase();
            _restService = new RestService();
            AddOrDeleteRecipeCommand = new AsyncRelayCommand(AddRecipeAsync);
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            string recipeId = query["RecipeId"] as string;
            Recipe recipe = await _restService.GetRecipeInformationAsync(recipeId);
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

        private async Task AddRecipeAsync()
        {
            _ = await _recipeDatabase.CreateRecipeAsync(new Recipe(_recipe.Id, _recipe.Title, _recipe.Image, _recipe.UsedIngredients, _recipe.Instructions));
            await Shell.Current.GoToAsync("..");
        }

        private async Task DeleteRecipeAsync()
        {
            if (_recipe != null)
            {
                await _recipeDatabase.DeleteRecipeAsync(_recipe);
            }
            await Shell.Current.GoToAsync("..");
        }
    }
}
