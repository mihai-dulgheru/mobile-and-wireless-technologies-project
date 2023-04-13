using Project.Models;

namespace Project.Services
{
    public interface IRestService
    {
        Task<IList<Product>> SearchGroceryProductsAsync(string query);
    }
}