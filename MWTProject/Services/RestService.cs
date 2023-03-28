using MWTProject.Configuration;
using MWTProject.Data;
using MWTProject.Utility;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace MWTProject.Services
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;
        public List<Movie> Movies { get; private set; }

        public RestService()
        {
            _client = new HttpClient();
            _configuration = ConfigurationBuilder.Instance.Configuration;
        }

        public async Task<List<Movie>> RefreshDataAsync()
        {
            Movies = new List<Movie>();

            try
            {
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new(string.Format(Constants.RestUrl, "titles")),
                    Headers = {
                        { "X-RapidAPI-Key", _configuration.GetValue("X-RapidAPI-Key") },
                        { "X-RapidAPI-Host", _configuration.GetValue("X-RapidAPI-Host") },
                    },
                };
                HttpResponseMessage response = await _client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    dynamic body = JObject.Parse(content);
                    foreach (dynamic item in body?.results)
                    {
                        string title = item.titleText.text ?? string.Empty;
                        int year = item.releaseYear.year ?? 0;
                        Movies.Add(new Movie(title, year));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Movies;
        }
    }
}
