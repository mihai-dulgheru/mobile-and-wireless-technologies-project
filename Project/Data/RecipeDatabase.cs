using Project.Models;
using Project.Utilities;
using SQLite;
using System.Diagnostics;

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
            try
            {
                return await Database.Table<Recipe>().ToListAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return new List<Recipe>();
            }
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            await InitAsync();
            Recipe recipe = await Database.Table<Recipe>().Where(v => v.Id == id).FirstOrDefaultAsync();
            if (recipe == null)
            {
                return null;
            }
            recipe.ExtendedIngredients = await Database.Table<Ingredient>().Where(x => x.RecipeId == id).ToListAsync();
            return recipe;
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
            List<Ingredient> extendedIngredients = (List<Ingredient>)recipe.ExtendedIngredients;
            foreach (Ingredient extendedIngredient in extendedIngredients)
            {
                _ = await Database.DeleteAsync(extendedIngredient);
            }
            return await Database.DeleteAsync(recipe);
        }
    }
}
