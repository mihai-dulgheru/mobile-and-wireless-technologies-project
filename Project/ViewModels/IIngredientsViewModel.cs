using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IIngredientsViewModel
    {
        ICommand AddIngredientCommand { get; }
        ICommand GoToSearchRecipePageCommand { get; }
        IEnumerable<Ingredient> Ingredients { get; set; }
        bool IsSearchBarFocused { get; set; }
        string SearchText { get; set; }
    }
}