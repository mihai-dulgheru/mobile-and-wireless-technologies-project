using Project.Models;

namespace Project.Data
{
    public interface IProductDatabase
    {
        Task<int> CreateProductAsync(Product Product);
        Task<int> DeleteProductAsync(Product Product);
        Task<Product> GetProductAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task<int> UpdateProductAsync(Product Product);
    }
}