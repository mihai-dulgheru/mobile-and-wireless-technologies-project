using Project.Models;

namespace Project.ViewModels
{
    internal interface IFavoriteRecipesViewModel
    {
        string Label { get; }
        IList<Recipe> Recipes { get; set; }
    }
}