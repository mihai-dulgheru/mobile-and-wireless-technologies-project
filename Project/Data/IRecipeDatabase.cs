using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
