using Project.Models;

namespace Project.Services
{
    public interface IRestService
    {
        Task<IList<Product>> SearchGroceryProductsAsync(string query);
        Task<ProductInformation> GetProductInformationAsync(string id);
        Task<string> RandomFoodTriviaAsync();
    }
}