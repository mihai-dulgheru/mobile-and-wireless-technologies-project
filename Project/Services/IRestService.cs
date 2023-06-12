using Project.Models;

namespace Project.Services
{
    public interface IRestService
    {
        Task<IList<Recipe>> SearchRecipesAsync(string query);
        Task<Recipe> GetRecipeInformationAsync(string id);
        Task<string> RandomFoodTriviaAsync();
        Task<IList<Ingredient>> AutocompleteIngredientSearchAsync(string query);
    }
}