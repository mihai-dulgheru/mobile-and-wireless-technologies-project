using Project.Models;

namespace Project.Data
{
    public interface IRecipeDatabase
    {
        Task CreateRecipeAsync(Recipe Recipe);
        Task<int> DeleteRecipeAsync(Recipe Recipe);
        Task<Recipe> GetRecipeAsync(int id);
        Task<List<Recipe>> GetRecipesAsync();
    }
}
