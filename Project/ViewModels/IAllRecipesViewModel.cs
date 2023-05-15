using Project.Models;

namespace Project.ViewModels
{
    internal interface IAllRecipesViewModel : IQueryAttributable
    {
        string Label { get; }
        IList<Recipe> Recipes { get; set; }
    }
}
