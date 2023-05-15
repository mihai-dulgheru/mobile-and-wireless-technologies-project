using Project.Models;
using System.Windows.Input;

namespace Project.ViewModels
{
    internal interface IAllRecipesViewModel : IQueryAttributable
    {
        string Label { get; }
        IList<Recipe> Recipes { get; set; }
        ICommand PerformSearchRecipe { get; }
    }
}
