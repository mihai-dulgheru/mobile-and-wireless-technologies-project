using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<Data.IRecipeDatabase, Data.RecipeDatabase>();
        builder.Services.AddSingleton<Services.IRestService, Services.RestService>();
        builder.Services.AddTransient<ViewModels.IAllRecipesViewModel, ViewModels.AllRecipesViewModel>();
        builder.Services.AddTransient<ViewModels.IFavoriteRecipeViewModel, ViewModels.FavoriteRecipeViewModel>();
        builder.Services.AddTransient<ViewModels.IAllFavoriteRecipesViewModel, ViewModels.AllFavoriteRecipesViewModel>();
        builder.Services.AddTransient<ViewModels.IHomeViewModel, ViewModels.HomeViewModel>();
        builder.Services.AddTransient<ViewModels.IIngredientsViewModel, ViewModels.IngredientsViewModel>();
        builder.Services.AddTransient<ViewModels.IRecipeViewModel, ViewModels.RecipeViewModel>();
        builder.Services.AddSingleton<Views.IngredientsPage>();
        builder.Services.AddTransient<Views.AboutUsPage>();
        builder.Services.AddTransient<Views.AllFavoriteRecipesPage>();
        builder.Services.AddTransient<Views.AllRecipesPage>();
        builder.Services.AddTransient<Views.FavoriteRecipePage>();
        builder.Services.AddTransient<Views.HomePage>();
        builder.Services.AddTransient<Views.MobileAllFavoriteRecipesPage>();
        builder.Services.AddTransient<Views.MobileAllRecipesPage>();
        builder.Services.AddTransient<Views.MobileHomePage>();
        builder.Services.AddTransient<Views.RecipePage>();

        return builder.Build();
    }
}