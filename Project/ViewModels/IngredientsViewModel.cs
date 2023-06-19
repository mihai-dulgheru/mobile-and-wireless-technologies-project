using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project.Models;
using Project.Services;
using Project.Utilities;
using Project.Views;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal class IngredientsViewModel : ObservableObject, IIngredientsViewModel
    {
        private IEnumerable<Ingredient> _ingredients = Enumerable.Empty<Ingredient>();
        private List<Ingredient> _cachedCollection = new();
        private bool _isSearchBarFocused = false;
        private readonly Action<IEnumerable<Ingredient>> _debounceAction = delegate { };
        private readonly IRestService _restService = new RestService();
        private string _searchText = string.Empty;

        public IngredientsViewModel()
        {
            GoToSearchRecipePageCommand = new AsyncRelayCommand(GoToSearchRecipePageAsync);
            _debounceAction = ActionDebounce.Debounce<IEnumerable<Ingredient>>(UpdateIngredients);
        }

        public ICommand GoToSearchRecipePageCommand { get; }

        public IEnumerable<Ingredient> Ingredients
        {
            get => _ingredients;
            set => SetProperty(ref _ingredients, value);
        }

        public bool IsSearchBarFocused
        {
            get => _isSearchBarFocused;
            set
            {
                if (SetProperty(ref _isSearchBarFocused, value))
                {
                    _ = UpdateCollectionViewAsync();
                    if (!_isSearchBarFocused && !string.IsNullOrWhiteSpace(SearchText))
                    {
                        SearchText = string.Empty;
                    }
                }
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    _ = UpdateCollectionViewAsync();
                }
            }
        }

        public ICommand AddIngredientCommand => new Command<Ingredient>((Ingredient ingredient) =>
        {
            _cachedCollection.Add(ingredient);
            IsSearchBarFocused = false;
        });

        public ICommand RemoveIngredientCommand => new Command<Ingredient>((Ingredient ingredient) =>
        {
            List<Ingredient> storedIngredientsList = _cachedCollection.Cast<Ingredient>().ToList();
            _ = storedIngredientsList.Remove(ingredient);
            _cachedCollection = storedIngredientsList;
            Ingredients = _cachedCollection;
        });

        public bool IsRemoveIngredientButtonVisible =>
            (_cachedCollection.Any() && !IsSearchBarFocused) ||
            (IsSearchBarFocused && (string.IsNullOrWhiteSpace(SearchText) || SearchText.Length <= 2));

        public bool IsImageVisible =>
#if __MOBILE__
                IsRemoveIngredientButtonVisible;
#else
                false;
#endif

        private async Task GoToSearchRecipePageAsync()
        {
            if (_cachedCollection.Any())
            {
                string ingredients = string.Join(",", _cachedCollection.Select(ingredient => ingredient.Name));
                if (!string.IsNullOrWhiteSpace(ingredients))
                {
#if __MOBILE__
                    await Shell.Current.GoToAsync($"{nameof(MobileAllRecipesPage)}?Ingredients={ingredients}");
#else
                    await Shell.Current.GoToAsync($"{nameof(AllRecipesPage)}?Ingredients={ingredients}");
#endif
                }
            }
        }

        private void UpdateIngredients(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        private async Task UpdateCollectionViewAsync()
        {
            if (IsSearchBarFocused && !string.IsNullOrWhiteSpace(SearchText) && SearchText.Length > 2)
            {
                IEnumerable<Ingredient> ingredients = await _restService.AutocompleteIngredientSearchAsync(SearchText);
                _debounceAction.Invoke(ingredients);
            }
            else
            {
                Ingredients = _cachedCollection;
            }
        }
    }
}