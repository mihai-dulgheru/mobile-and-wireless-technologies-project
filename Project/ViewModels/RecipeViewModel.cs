using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Models;
using Project.Services;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class RecipeViewModel : ObservableObject, IRecipeViewModel
    {
        private Recipe _recipe;
        //private readonly IRecipeDatabase _recipeDatabase;
        private readonly IRestService _restService;
        public ICommand AddProductCommand { get; }

        public RecipeViewModel()
        {
           // _recipeDatabase = new RecipeDatabase();
            _restService = new RestService();
            AddProductCommand = new AsyncRelayCommand(AddProductAsync);
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

        private async Task AddProductAsync()
        {
           // _ = await _recipeDatabase.DeleteRecipeAsync(_recipe.Id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
