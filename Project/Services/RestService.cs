using Newtonsoft.Json.Linq;
using Project.Models;
using Project.Utilities;
using System.Diagnostics;

namespace Project.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<IList<Product>> SearchGroceryProductsAsync(string query)
        {
            try
            {
                IList<Product> products = new List<Product>();

                string RequestUri = string.Format(Constants.BaseUrl, $"food/products/search?query={query}&number=10&apiKey={Constants.APIKey}");
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
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return new List<Product>();
            }
        }

        public async Task<ProductInformation> GetProductInformationAsync(string id)
        {
            try
            {
                string RequestUri = string.Format(Constants.BaseUrl, $"food/products/{id}?apiKey={Constants.APIKey}");
                HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
                HttpResponseMessage response = await _client.SendAsync(request);
                _ = response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                return JObject.Parse(content).ToObject<ProductInformation>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }
        }
    }
}
