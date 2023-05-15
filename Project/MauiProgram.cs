using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace Project;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("GothamRound-Bold.otf", "GothamRoundBold");
                fonts.AddFont("GothamRound-Light.otf", "GothamRoundLight");
                fonts.AddFont("GothamRound-Medium.otf", "GothamRoundMedium");
            })
            .ConfigureSyncfusionCore();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Data.IProductDatabase, Data.ProductDatabase>();
        builder.Services.AddSingleton<Data.IRecipeDatabase, Data.RecipeDatabase>();
        builder.Services.AddSingleton<Services.IRestService, Services.RestService>();

        return builder.Build();
    }
}
