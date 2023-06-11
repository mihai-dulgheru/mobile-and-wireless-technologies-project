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
        builder.Services.AddSingleton<ViewModels.IAllRecipesViewModel, ViewModels.AllRecipesViewModel>();
        builder.Services.AddSingleton<ViewModels.IFavoriteRecipeViewModel, ViewModels.FavoriteRecipeViewModel>();
        builder.Services.AddSingleton<ViewModels.IFavoriteRecipesViewModel, ViewModels.FavoriteRecipesViewModel>();
        builder.Services.AddSingleton<ViewModels.IHomeViewModel, ViewModels.HomeViewModel>();
        builder.Services.AddSingleton<ViewModels.IIngredientsViewModel, ViewModels.IngredientsViewModel>();
        builder.Services.AddSingleton<ViewModels.IRecipeViewModel, ViewModels.RecipeViewModel>();
        builder.Services.AddSingleton<Views.AboutUsPage>();
        builder.Services.AddSingleton<Views.AllRecipesPage>();
        builder.Services.AddSingleton<Views.FavoriteRecipePage>();
        builder.Services.AddSingleton<Views.AllFavoriteRecipesPage>();
        builder.Services.AddSingleton<Views.HomePage>();
        builder.Services.AddSingleton<Views.IngredientsPage>();
        builder.Services.AddSingleton<Views.MobileAllFavoriteRecipesPage>();
        builder.Services.AddSingleton<Views.MobileAllRecipesPage>();
        builder.Services.AddSingleton<Views.MobileHomePage>();
        builder.Services.AddSingleton<Views.RecipePage>();

        return builder.Build();
    }
}
