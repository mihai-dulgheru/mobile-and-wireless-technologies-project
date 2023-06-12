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
        private IEnumerable<Ingredient> _cachedCollection;
        private IEnumerable<Ingredient> _ingredients;
        private bool _isSearchBarFocused;
        private readonly IRestService _restService;
        private string _searchText = string.Empty;
        public ICommand GoToSearchRecipePageCommand { get; }

        public IngredientsViewModel()
        {
            _restService = new RestService();
            GoToSearchRecipePageCommand = new AsyncRelayCommand(GoToSearchRecipePageAsync);
        }

        private async Task GoToSearchRecipePageAsync()
        {
            if (_cachedCollection != null && _cachedCollection.Any())
            {
                string ingredients = _cachedCollection?.Select(ingredient => ingredient.Name).Aggregate((i, j) => i + "," + j);
                if (!string.IsNullOrWhiteSpace(ingredients))
                {
                    _cachedCollection = null;
                    Ingredients = null;
#if __MOBILE__
                    await Shell.Current.GoToAsync($"{nameof(MobileAllRecipesPage)}?Ingredients={ingredients}");
#else
                    await Shell.Current.GoToAsync($"{nameof(AllRecipesPage)}?Ingredients={ingredients}");
#endif
                }
            }
        }

        private async Task UpdateCollectionViewAsync()
        {
            if (IsSearchBarFocused && !string.IsNullOrWhiteSpace(SearchText) && SearchText.Length > 2)
            {
                await Task.Delay(Constants.MillisecondsDelay);
                Ingredients = await _restService.AutocompleteIngredientSearchAsync(SearchText);
            }
            else
            {
                Ingredients = _cachedCollection;
            }
        }

        public ICommand AddIngredientCommand => new Command<Ingredient>((Ingredient ingredient) =>
        {
            if (_cachedCollection == null)
            {
                _cachedCollection = new List<Ingredient> { ingredient };
            }
            else
            {
                IList<Ingredient> storedIngredientsList = _cachedCollection.Cast<Ingredient>().ToList();
                storedIngredientsList.Add(ingredient);
                _cachedCollection = storedIngredientsList;
            }
            IsSearchBarFocused = false;
        });

        public IEnumerable<Ingredient> Ingredients
        {
            get => _ingredients;
            set
            {
                if (_ingredients != value)
                {
                    _ingredients = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsSearchBarFocused
        {
            get => _isSearchBarFocused;
            set
            {
                if (_isSearchBarFocused != value)
                {
                    _isSearchBarFocused = value;
                    OnPropertyChanged();
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
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged();
                    _ = UpdateCollectionViewAsync();
                }
            }
        }

        public ICommand RemoveIngredientCommand => new Command<Ingredient>((Ingredient ingredient) =>
        {
            IList<Ingredient> storedIngredientsList = _cachedCollection.Cast<Ingredient>().ToList();
            _ = storedIngredientsList.Remove(ingredient);
            _cachedCollection = storedIngredientsList;
            Ingredients = _cachedCollection;
        });

        public bool IsImageVisible =>
#if __MOBILE__
                IsRemoveIngredientButtonVisible;
#else
                false;
#endif

        public bool IsRemoveIngredientButtonVisible =>
            _cachedCollection != null && _cachedCollection.Any() && !IsSearchBarFocused && string.IsNullOrWhiteSpace(SearchText);
    }
}
