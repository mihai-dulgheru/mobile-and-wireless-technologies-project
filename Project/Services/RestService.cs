using Newtonsoft.Json.Linq;
using Project.Configuration;
using Project.Models;
using Project.Utilities;

namespace Project.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public RestService()
        {
            _client = new HttpClient();
            _configuration = ConfigurationBuilder.Instance.Configuration;
        }

        public async Task<IList<Product>> SearchGroceryProductsAsync(string query)
        {
            IList<Product> products = new List<Product>();

            string RequestUri = string.Format(Constants.BaseUrl, $"food/products/search?query={query}&apiKey={_configuration.GetValue("API-Key")}");
            HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
            HttpResponseMessage response = await _client.SendAsync(request);
            _ = response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            dynamic body = JObject.Parse(content);
            foreach (dynamic product in body?.products)
            {
                int id = product?.id ?? 0;
                string title = product?.title ?? string.Empty;
                string image = product?.image ?? string.Empty;
                string imageType = product?.imageType ?? string.Empty;
                products.Add(new Product(id, title, image, imageType));
            }

            return products;
        }
    }
}
