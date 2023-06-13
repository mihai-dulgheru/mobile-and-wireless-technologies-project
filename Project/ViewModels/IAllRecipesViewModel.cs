using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IAllRecipesViewModel : IQueryAttributable
    {
        string Ingredients { set; }
        bool IsBusy { get; set; }
        string Label { get; set; }
        IList<Recipe> Recipes { get; set; }
        ICommand SelectRecipeCommand { get; }

        Task SearchRecipesAsync(string ingredients);
    }
}