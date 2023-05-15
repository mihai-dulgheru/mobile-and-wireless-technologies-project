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

                string RequestUri = string.Format(Constants.BaseUrl, $"food/ingredients/autocomplete?query={query}&number=10&apiKey={Constants.APIKey}");
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

        async Task<IList<Recipe>> IRestService.SearchRecipesAsync(string query)
        {
            try
            {
                IList<Recipe> recipes = new List<Recipe>();

                string RequestUri = string.Format(Constants.BaseUrl, $"/recipes/findByIngredients?ingredients={query}&number=10&apiKey={Constants.APIKey}");
                HttpRequestMessage request = new(HttpMethod.Get, RequestUri);
                HttpResponseMessage response = await _client.SendAsync(request);
                _ = response.EnsureSuccessStatusCode();
                string content = await response.Content.ReadAsStringAsync();
                dynamic body = JObject.Parse(content);
                foreach (dynamic recipe in body?.recipes)
                {
                    int id = recipe?.id ?? 0;
                    string title = recipe?.title ?? string.Empty;
                    string image = recipe?.image ?? string.Empty;
                    string imageType = recipe?.imageType ?? string.Empty;
                    int usedIngredientCount = recipe?.usedIngredientCount ?? string.Empty;
                    int missedIngredientCount = recipe?.missedIngredientCount ?? string.Empty;
                    IList<Ingredient> missedIngredients = recipe?.missedIngredients ?? string.Empty;
                    IList<Ingredient> usedIngredients = recipe?.usedIngredients ?? string.Empty;
                    IList<Ingredient> unusedIngredients = recipe?.unusedIngredients ?? string.Empty;
                    int likes = recipe?.likes ?? string.Empty;
                    string instructions = recipe?.instructions ?? string.Empty;
                    int readyInMinutes = recipe?.readyInMinutes ?? string.Empty;
                    recipes.Add(new Recipe(id, title, image, imageType, usedIngredientCount, missedIngredientCount, missedIngredients, usedIngredients, unusedIngredients, likes, instructions, readyInMinutes));
                }

                return recipes;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
                return new List<Recipe>();
            }
        }
    }
}
