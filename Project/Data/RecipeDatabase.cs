using Project.Models;
using SQLite;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _ = await Database.CreateTableAsync<Recipe>();
        }

        public async Task<List<Recipe>> GetRecipessAsync()
        {
            await InitAsync();
            return await Database.Table<Recipe>().ToListAsync();
        }

        public async Task<Recipe> GetRecipeAsync(int id)
        {
            await InitAsync();
            return await Database.Table<Recipe>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateRecipeAsync(Recipe Recipe)
        {
            await InitAsync();
            return await Database.InsertAsync(Recipe);
        }

        public async Task<int> DeleteRecipeAsync(Recipe Recipe)
        {
            await InitAsync();
            return await Database.DeleteAsync(Recipe);
        }
    }
}
