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
        builder.Services.AddSingleton<Services.IRestService, Services.RestService>();
        builder.Services.AddSingleton<ViewModels.IIngredientsViewModel, ViewModels.IngredientsViewModel>();
        builder.Services.AddSingleton<Views.IngredientsPage>();
        builder.Services.AddTransient<ViewModels.IAllRecipesViewModel, ViewModels.AllRecipesViewModel>();
        builder.Services.AddTransient<ViewModels.IFavoriteRecipesViewModel, ViewModels.FavoriteRecipesViewModel>();
        builder.Services.AddTransient<ViewModels.IHomeViewModel, ViewModels.HomeViewModel>();
        builder.Services.AddTransient<ViewModels.IRecipeViewModel, ViewModels.RecipeViewModel>();
        builder.Services.AddTransient<ViewModels.IStatisticsViewModel, ViewModels.StatisticsViewModel>();
        builder.Services.AddTransient<Views.AllRecipesPage>();
        builder.Services.AddTransient<Views.FavoriteRecipesPage>();
        builder.Services.AddTransient<Views.HomePage>();
        builder.Services.AddTransient<Views.RecipePage>();
        builder.Services.AddTransient<Views.StatisticsPage>();

        return builder.Build();
    }
}
