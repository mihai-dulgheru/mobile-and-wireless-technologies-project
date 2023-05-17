using Project.Models;

namespace Project.ViewModels
{
    internal interface IAllRecipesViewModel: IQueryAttributable
    {
        string Ingredients { set; }
        string Label { get; }
        IList<Recipe> Recipes { get; set; }

        Task SearchRecipesAsync(string ingredients);
    }
}