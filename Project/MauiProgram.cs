using Microsoft.Extensions.Logging;

namespace Project;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Configuration.IConfiguration, Configuration.Configuration>();
        builder.Services.AddSingleton<Data.IPersonRepository, Data.PersonRepository>(provider => ActivatorUtilities.CreateInstance<Data.PersonRepository>(provider, Utilities.Constants.DatabasePath));
        builder.Services.AddSingleton<Data.IProductDatabase, Data.ProductDatabase>();
        builder.Services.AddSingleton<Services.IRestService, Services.RestService>();

        return builder.Build();
    }
}
