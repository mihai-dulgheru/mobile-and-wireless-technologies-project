using Project.Views;

namespace Project;

public partial class AppShellMobile : Shell
{
    public AppShellMobile()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AboutUsPage), typeof(AboutUsPage));
        Routing.RegisterRoute(nameof(FavoriteRecipePage), typeof(FavoriteRecipePage));
        Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
        Routing.RegisterRoute(nameof(MobileAllFavoriteRecipesPage), typeof(MobileAllFavoriteRecipesPage));
        Routing.RegisterRoute(nameof(MobileAllRecipesPage), typeof(MobileAllRecipesPage));
        Routing.RegisterRoute(nameof(MobileHomePage), typeof(MobileHomePage));
        Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
    }

    public void NavigateTo(string name)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            switch (name)
            {
                case nameof(MobileHomePage):
                    tabBar.CurrentItem = mobileHomeItem;
                    break;
                case nameof(IngredientsPage):
                    tabBar.CurrentItem = ingredientsItem;
                    break;
                case nameof(MobileAllFavoriteRecipesPage):
                    tabBar.CurrentItem = mobileFavoriteRecipesItem;
                    break;
                case nameof(AboutUsPage):
                    tabBar.CurrentItem = aboutUsItem;
                    break;
                default:
                    break;
            }
        });
    }
}