using Project.Models;

namespace Project.Data
{
    public interface IRecipeDatabase
    {
        Task CreateRecipeAsync(Recipe recipe);
        Task<int> DeleteRecipeAsync(Recipe recipe);
        Task<Recipe> GetRecipeAsync(int id);
        Task<List<Recipe>> GetRecipesAsync();
        Task<bool> RecipeExistsAsync(string recipeId);
    }
}