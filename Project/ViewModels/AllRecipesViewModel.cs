using CommunityToolkit.Mvvm.ComponentModel;
using Project.Models;
using Project.Services;

namespace Project.ViewModels
{
    internal class AllRecipesViewModel : ObservableObject, IAllRecipesViewModel
    {
        private IList<Recipe> _recipes;
        private readonly IRestService _restService;
        private string _ingredients;
        public string Label { get; } = "Recommended recipes";

        public AllRecipesViewModel()
        {
            _restService = new RestService();
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
                    _recipes = value;
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
                    _ = SearchRecipesAsync(_ingredients);
                }
            }
        }

        public async Task SearchRecipesAsync(string ingredients)
        {
            IList<Recipe> recipes = await _restService.SearchRecipesAsync(ingredients);
            Recipes = recipes.OrderByDescending(r => r.Likes).ToList();
        }
    }
}
