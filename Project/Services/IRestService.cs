using Project.Data;

namespace Project.Services
{
    public interface IRestService
    {
        IList<Movie> Movies { get; }

        Task<IList<Movie>> RefreshDataAsync();
        Task<IList<Product>> SearchGroceryProductsAsync(string query);
    }
}