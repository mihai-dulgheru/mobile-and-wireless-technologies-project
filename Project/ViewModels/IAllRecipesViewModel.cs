using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IAllRecipesViewModel : IQueryAttributable
    {
        string Ingredients { set; }
        string Label { get; }
        IList<Recipe> Recipes { get; set; }

        Task SearchRecipesAsync(string ingredients);
        ICommand SelectRecipeCommand { get; }
    }
}