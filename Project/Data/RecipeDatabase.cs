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

        Task<int> IRecipeDatabase.CreateRecipeAsync(Recipe Recipe)
        {
            throw new NotImplementedException();
        }

        Task<int> IRecipeDatabase.DeleteRecipeAsync(Recipe Recipe)
        {
            throw new NotImplementedException();
        }

        Task<Recipe> IRecipeDatabase.GetRecipeAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<Recipe>> IRecipeDatabase.GetRecipessAsync()
        {
            throw new NotImplementedException();
        }
    }
}
