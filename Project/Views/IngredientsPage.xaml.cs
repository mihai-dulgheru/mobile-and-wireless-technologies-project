using Project.Models;
using Project.Services;

namespace Project.Views;

public partial class IngredientsPage : ContentPage
{
    private IEnumerable<Ingredient> _storedIngredients = null;
    private bool _isSearchBarFocused = false;
    private readonly IRestService _restService;

    public IngredientsPage()
    {
        InitializeComponent();

        _restService = new RestService();
    }

    private async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        if (searchBar.Text.Length > 2)
        {
            ingredientListView.ItemsSource = await _restService.AutocompleteIngredientSearchAsync(searchBar.Text);
        }
    }

    private void ingredientListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (_isSearchBarFocused)
        {
            if (e.SelectedItem == null || e.SelectedItem is not Ingredient selectedItem)
            {
                return;
            }
            searchBar.Text = string.Empty;
            if (_storedIngredients == null)
            {
                _storedIngredients = new List<Ingredient> { selectedItem };
            }
            else
            {
                IList<Ingredient> storedIngredientsList = _storedIngredients.Cast<Ingredient>().ToList();
                storedIngredientsList.Add(selectedItem);
                _storedIngredients = storedIngredientsList;
            }
            ingredientListView.ItemsSource = _storedIngredients;
            SetCommandParameter();
        }
    }

    private void searchBar_Focused(object sender, FocusEventArgs e)
    {
        _isSearchBarFocused = true;
        ingredientListView.ItemsSource = null;
    }

    private void searchBar_Unfocused(object sender, FocusEventArgs e)
    {
        _isSearchBarFocused = false;
        ingredientListView.ItemsSource = _storedIngredients;
    }

    private void SetCommandParameter()
    {
        findRecipeButton.CommandParameter = _storedIngredients?.Select(ingredient => ingredient.Name).Aggregate((i, j) => i + "," + j);
    }
}