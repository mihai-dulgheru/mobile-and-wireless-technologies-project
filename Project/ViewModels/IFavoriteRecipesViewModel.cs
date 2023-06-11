using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IFavoriteRecipesViewModel
    {
        bool IsBusy { get; set; }
        string Label { get; }
        IList<Recipe> Recipes { get; set; }
        ICommand SelectRecipeCommand { get; }

        Task OnAppearing();
    }
}