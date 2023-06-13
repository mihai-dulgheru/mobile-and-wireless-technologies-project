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
        private IList<Recipe> _recipes = null;
        private bool _isBusy = true;
        private readonly IRestService _restService;
        private string _ingredients;
        private string _label = "Recommended recipes";
        public ICommand SelectRecipeCommand { get; }

        public AllRecipesViewModel()
        {
            SelectRecipeCommand = new AsyncRelayCommand<Recipe>(SelectRecipeAsync);
            _restService = new RestService();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (_recipes != null && _recipes.Count > 0)
            {
                return;
            }
            if (query["Ingredients"] is string ingredients)
            {
                Ingredients = ingredients;
                Label = $"Recommended recipes for {ingredients.Replace("%20", " ").Replace(",", ", ")}";
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
                    _ = Task.Run(async () =>
                    {
                        await SearchRecipesAsync(_ingredients);
                    });
                }
            }
        }

        public string Label
        {
            get => _label;
            set
            {
                if (_label != value)
                {
                    _label = value;
                    OnPropertyChanged();
                }
            }
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
