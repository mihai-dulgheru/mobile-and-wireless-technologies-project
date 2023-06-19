using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IIngredientsViewModel
    {
        ICommand AddIngredientCommand { get; }
        ICommand GoToSearchRecipePageCommand { get; }
        IEnumerable<Ingredient> Ingredients { get; set; }
        bool IsImageVisible { get; }
        bool IsRemoveIngredientButtonVisible { get; }
        bool IsSearchBarFocused { get; set; }
        ICommand RemoveIngredientCommand { get; }
        string SearchText { get; set; }
    }
}