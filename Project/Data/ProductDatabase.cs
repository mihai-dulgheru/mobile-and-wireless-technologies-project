using Project.Models;
using Project.Utilities;
using SQLite;

namespace Project.Data
{
    public class ProductDatabase : IProductDatabase
    {
        private SQLiteAsyncConnection Database;

        public ProductDatabase()
        {

        }

        private async Task InitAsync()
        {
            if (Database is not null)
            {
                return;
            }

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            _ = await Database.CreateTableAsync<Product>();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            await InitAsync();
            return await Database.Table<Product>().ToListAsync();
        }

        public async Task<Product> GetProductAsync(int id)
        {
            await InitAsync();
            return await Database.Table<Product>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> CreateProductAsync(Product Product)
        {
            await InitAsync();
            return await Database.InsertAsync(Product);
        }

        public async Task<int> UpdateProductAsync(Product Product)
        {
            await InitAsync();
            return await Database.UpdateAsync(Product);
        }

        public async Task<int> DeleteProductAsync(Product Product)
        {
            await InitAsync();
            return await Database.DeleteAsync(Product);
        }
    }
}
