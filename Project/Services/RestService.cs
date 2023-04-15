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

            string RequestUri = string.Format(Constants.BaseUrl, $"food/products/search?query={query}&number=10&apiKey={_configuration.GetValue("API-Key")}");
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

        public async Task<ProductInformation> GetProductInformationAsync(string id)
        {
            //TODO
            string RequestUri = string.Format(Constants.BaseUrl, $"food/products/{id}?apiKey={_configuration.GetValue("API-Key")}");
            HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
            HttpResponseMessage response = await _client.SendAsync(request);
            _ = response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            dynamic body = JObject.Parse(content);
            int productId = body?.id ?? 0;
            string title = body?.title ?? string.Empty;
            //string[] breadcrumbs = body?.breadcrumbs ?? Array.Empty<string>();
            string[] breadcrumbs = Array.Empty<string>();
            string imageType = body?.imageType ?? string.Empty;
            //string[] badges = body?.badges ?? Array.Empty<string>();
            string[] badges = Array.Empty<string>();
            //string[] importantBadges = body?.importantBadges ?? Array.Empty<string>();
            string[] importantBadges = Array.Empty<string>();
            int ingredientCount = body?.ingredientCount ?? 0;
            string generatedText = body?.generatedText ?? string.Empty;
            string ingredientList = body?.ingredientList ?? string.Empty;
            Ingredient[] ingredients = new Ingredient[ingredientCount];
            foreach (dynamic ingredient in body?.ingredients)
            {
                string description = ingredient?.description ?? string.Empty;
                string name = ingredient?.name ?? string.Empty;
                string safetyLevel = ingredient?.safety_level ?? string.Empty;
                _ = ingredients.Append(new Ingredient(description, name, safetyLevel));
            }
            int likes = body?.likes ?? 0;
            string aisle = body?.aisle ?? string.Empty;
            //Nutrition nutrition = body?.nutrition ?? null;
            Nutrition nutrition = new();
            int price = body?.price ?? 0;
            //Servings servings = body?.servings ?? null;
            Servings servings = new();

            return new ProductInformation(productId, title, breadcrumbs, imageType, badges, importantBadges, ingredientCount, generatedText, ingredientList, ingredients, likes, aisle, nutrition, price, servings);
        }
    }
}
