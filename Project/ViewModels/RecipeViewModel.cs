using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Data;
using Project.Models;
using Project.Services;
using Project.Utilities;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class RecipeViewModel : ObservableObject, IRecipeViewModel
    {
        private Recipe _recipe = null;
        private bool _isBusy = true;
        private bool _recipeExists = false;
        private readonly IRecipeDatabase _recipeDatabase;
        private readonly IRestService _restService;
        public ICommand AddRecipeCommand { get; }

        public RecipeViewModel()
        {
            AddRecipeCommand = new AsyncRelayCommand(AddRecipeAsync);
            _recipeDatabase = new RecipeDatabase();
            _restService = new RestService();
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query["RecipeId"] is not string recipeId)
            {
                await Shell.Current.GoToAsync("..");
                return;
            }
            IsBusy = true;
            Task<Recipe> recipeTask = _restService.GetRecipeInformationAsync(recipeId);
            Task<bool> recipeExistsTask = _recipeDatabase.RecipeExistsAsync(recipeId);
            await Task.WhenAll(recipeTask, recipeExistsTask);
            Recipe recipe = recipeTask.Result;
            bool recipeExists = recipeExistsTask.Result;
            if (recipe != null)
            {
                await Task.Run(() => { Recipe = recipe; });
                if (recipeExists)
                {
                    await Task.Run(() => { RecipeExists = true; });
                }
                await Task.Delay(Constants.MillisecondsDelay);
                IsBusy = false;
            }
            else
            {
                await Shell.Current.GoToAsync("..");
            }
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
            if (_recipe == null)
            {
                return;
            }
            await _recipeDatabase.CreateRecipeAsync(_recipe);
            await Shell.Current.GoToAsync("..");
        }

        public bool RecipeExists
        {
            get => _recipeExists;
            set
            {
                if (_recipeExists != value)
                {
                    _recipeExists = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
