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
        private IList<Recipe> _recipes = new List<Recipe>();
        private bool _isBusy = true;
        private readonly IRestService _restService = new RestService();
        private string _ingredients = string.Empty;
        private string _label = "Recommended recipes";
        public ICommand SelectRecipeCommand { get; }

        public AllRecipesViewModel()
        {
            SelectRecipeCommand = new AsyncRelayCommand<Recipe>(SelectRecipeAsync);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (_recipes.Count > 0)
            {
                return;
            }

            if (query.TryGetValue("Ingredients", out object ingredientsObj) && ingredientsObj is string ingredients)
            {
                Ingredients = ingredients;
                Label = $"Recommended recipes for {ingredients.Replace("%20", " ").Replace(",", ", ")}";
            }
        }

        public IList<Recipe> Recipes
        {
            get => _recipes;
            set => SetProperty(ref _recipes, value);
        }

        public string Ingredients
        {
            set
            {
                if (SetProperty(ref _ingredients, value))
                {
                    _ = Task.Run(async () => await SearchRecipesAsync(_ingredients));
                }
            }
        }

        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public async Task SearchRecipesAsync(string ingredients)
        {
            Recipes = await _restService.SearchRecipesAsync(ingredients);
            IsBusy = false;
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
            set => SetProperty(ref _isBusy, value);
        }
    }
}