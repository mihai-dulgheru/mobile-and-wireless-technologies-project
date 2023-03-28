using Microsoft.Extensions.Configuration;

namespace MWTProject.Configuration
{
    public sealed class ConfigurationBuilder : IConfigurationBuilder
    {
        private static volatile ConfigurationBuilder _instance;
        private static readonly object SyncLock = new();

        private ConfigurationBuilder()
        {
            Microsoft.Extensions.Configuration.IConfigurationBuilder builder =
                new Microsoft.Extensions.Configuration.ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot root = builder.Build();

            Configuration = new Configuration(root);
        }

        public static ConfigurationBuilder Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                lock (SyncLock)
                {
                    _instance ??= new ConfigurationBuilder();
                }
                return _instance;
            }
        }

        public IConfiguration Configuration { get; private set; }
    }
}
