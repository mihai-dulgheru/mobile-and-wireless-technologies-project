namespace Project.Configuration
{
    public class Configuration : IConfiguration
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;

        public Configuration(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string key)
        {
            return _configuration.GetSection(key).Value ?? string.Empty;
        }
    }
}
