using Project.Models;

namespace Project.Data
{
    public interface IRecipeDatabase
    {
        Task<int> CreateRecipeAsync(Recipe Recipe);
        Task<int> DeleteRecipeAsync(Recipe Recipe);
        Task<Recipe> GetRecipeAsync(int id);
        Task<List<Recipe>> GetRecipessAsync();
    }
}
