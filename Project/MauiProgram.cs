using Microsoft.Extensions.Logging;
using Project.Data;
using Project.Utilities;

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
        builder.Services.AddSingleton<IPersonRepository, PersonRepository>(provider => ActivatorUtilities.CreateInstance<PersonRepository>(provider, Constants.DatabasePath));

        return builder.Build();
    }
}
