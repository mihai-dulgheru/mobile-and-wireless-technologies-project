using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IAllFavoriteRecipesViewModel
    {
        bool IsBusy { get; set; }
        string Label { get; }
        IList<Recipe> Recipes { get; set; }
        ICommand SelectRecipeCommand { get; }

        Task OnAppearing();
    }
}