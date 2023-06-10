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

                string RequestUri = string.Format(Constants.BaseUrl, $"food/products/search?query={query}&number=30&apiKey={Constants.APIKey}");
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

        public async Task<string> RandomFoodTriviaAsync()
        {
            try
            {
                string RequestUri = string.Format(Constants.BaseUrl, $"food/trivia/random?apiKey={Constants.APIKey}");
                HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
                HttpResponseMessage response = await _client.SendAsync(request);
                _ = response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                dynamic body = JObject.Parse(content);

                return body?.text ?? string.Empty;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }
        }

        public async Task<IList<Ingredient>> AutocompleteIngredientSearchAsync(string query)
        {
            try
            {
                IList<Ingredient> ingredients = new List<Ingredient>();

                string RequestUri = string.Format(Constants.BaseUrl, $"food/ingredients/autocomplete?query={query}&number=5&apiKey={Constants.APIKey}");
                HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
                HttpResponseMessage response = await _client.SendAsync(request);
                _ = response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                dynamic body = JArray.Parse(content);
                foreach (dynamic ingredient in body)
                {
                    string name = ingredient?.name ?? string.Empty;
                    string image = ingredient?.image ?? string.Empty;
                    ingredients.Add(new Ingredient
                    {
                        Name = name,
                        Image = $"https://spoonacular.com/cdn/ingredients_500x500/{image}",
                    });
                }

                return ingredients;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return new List<Ingredient>();
            }
        }

        public async Task<Recipe> GetRecipeInformationAsync(string id)
        {
            try
            {
                string RequestUri = string.Format(Constants.BaseUrl, $"recipes/{id}/information?apiKey={Constants.APIKey}");
                HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
                HttpResponseMessage response = await _client.SendAsync(request);
                _ = response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                Recipe recipe = JObject.Parse(content).ToObject<Recipe>();
                recipe.SetIngredients();

                return recipe;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return null;
            }
        }

        async Task<IList<Recipe>> IRestService.SearchRecipesAsync(string query)
        {
            try
            {
                string RequestUri = string.Format(Constants.BaseUrl, $"recipes/findByIngredients?ingredients={query}&number=30&limitLicense=true&ranking=1&ignorePantry=false&apiKey={Constants.APIKey}");
                HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
                HttpResponseMessage response = await _client.SendAsync(request);
                _ = response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();

                return JArray.Parse(content).ToObject<IList<Recipe>>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return new List<Recipe>();
            }
        }
    }
}
