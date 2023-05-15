using Project.Models;

namespace Project.Services
{
    public interface IRestService
    {
        Task<IList<Product>> SearchGroceryProductsAsync(string query);
        Task<IList<Recipe>> SearchRecipesAsync(string query);
        Task<ProductInformation> GetProductInformationAsync(string id);
        Task<Recipe> GetRecipeInformationAsync(string id);
        Task<string> RandomFoodTriviaAsync();
        Task<IList<Ingredient>> AutocompleteIngredientSearchAsync(string query);
    }
}