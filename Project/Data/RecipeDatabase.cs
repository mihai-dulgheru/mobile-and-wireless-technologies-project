using Project.Models;
using Project.Utilities;
using SQLite;

namespace Project.Data
{
    public class RecipeDatabase : IRecipeDatabase
    {
        private SQLiteAsyncConnection Database;

        public RecipeDatabase()
        {

        }

        private async Task InitAsync()
        {
            if (Database is not null)
            {
                return;
            }

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _ = await Database.CreateTableAsync<Ingredient>();
            _ = await Database.CreateTableAsync<Recipe>();
        }

        public async Task<List<Recipe>> GetRecipesAsync()
        {
            await InitAsync();
            return await Database.Table<Recipe>().ToListAsync();
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            await InitAsync();
            return await Database.Table<Recipe>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateRecipeAsync(Recipe recipe)
        {
            List<Ingredient> ingredients = (List<Ingredient>)recipe.ExtendedIngredients;
            await InitAsync();
            await Database.InsertAsync(recipe).ContinueWith((t) =>
            {
                foreach (Ingredient ingredient in ingredients)
                {
                    ingredient.RecipeId = recipe.Id;
                }
                _ = Database.InsertAllAsync(ingredients);
            });
        }

        public async Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            await InitAsync();
            return await Database.DeleteAsync(recipe);
        }
    }
}
