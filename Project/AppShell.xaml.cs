using Project.Views;

namespace Project;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AboutUsPage), typeof(AboutUsPage));
        Routing.RegisterRoute(nameof(AllFavoriteRecipesPage), typeof(AllFavoriteRecipesPage));
        Routing.RegisterRoute(nameof(AllRecipesPage), typeof(AllRecipesPage));
        Routing.RegisterRoute(nameof(FavoriteRecipePage), typeof(FavoriteRecipePage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
        Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
    }

    public void NavigateTo(string name)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            switch (name)
            {
                case nameof(HomePage):
                    Current.CurrentItem = homeItem;
                    break;
                case nameof(IngredientsPage):
                    Current.CurrentItem = ingredientsItem;
                    break;
                case nameof(AllFavoriteRecipesPage):
                    Current.CurrentItem = favoriteRecipesItem;
                    break;
                case nameof(AboutUsPage):
                    Current.CurrentItem = aboutUsItem;
                    break;
                default:
                    break;
            }
        });
    }
}
