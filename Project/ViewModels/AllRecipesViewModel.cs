using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Models;
using Project.Services;
using Project.Views;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class AllRecipesViewModel : ObservableObject, IAllRecipesViewModel
    {
        private IList<Recipe> _recipes;
        private bool _isBusy = true;
        private readonly IRestService _restService;
        private string _ingredients;
        public ICommand SelectRecipeCommand { get; }
        public string Label { get; } = "Recommended recipes";

        public AllRecipesViewModel()
        {
            _restService = new RestService();
            SelectRecipeCommand = new AsyncRelayCommand<Recipe>(SelectRecipeAsync);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query["Ingredients"] is string ingredients)
            {
                Ingredients = ingredients;
            }
        }

        public IList<Recipe> Recipes
        {

            get => _recipes;
            set
            {
                if (_recipes != value)
                {
                    _recipes = (List<Recipe>)value;
                    IsBusy = false;
                    OnPropertyChanged();
                }
            }
        }

        public string Ingredients
        {
            set
            {
                if (_ingredients != value)
                {
                    _ingredients = value;
                    OnPropertyChanged();
                    _ = Task.Run(() => SearchRecipesAsync(_ingredients));
                }
            }
        }

        public async Task SearchRecipesAsync(string ingredients)
        {
            IList<Recipe> recipes = await _restService.SearchRecipesAsync(ingredients);
            Recipes = recipes.OrderByDescending(r => r.Likes).ToList();
        }

        private async Task SelectRecipeAsync(Recipe recipe)
        {
            if (recipe != null)
            {
                await Shell.Current.GoToAsync($"{nameof(RecipePage)}?RecipeId={recipe.Id}");
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
    }
}
