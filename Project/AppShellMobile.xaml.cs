using Project.Views;

namespace Project;

public partial class AppShellMobile : Shell
{
    public AppShellMobile()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AllRecipesPage), typeof(AllRecipesPage));
        Routing.RegisterRoute(nameof(FavoriteRecipesPage), typeof(FavoriteRecipesPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
        Routing.RegisterRoute(nameof(MobileAllRecipesPage), typeof(MobileAllRecipesPage));
        Routing.RegisterRoute(nameof(MobileFavoriteRecipesPage), typeof(MobileFavoriteRecipesPage));
        Routing.RegisterRoute(nameof(MobileHomePage), typeof(MobileHomePage));
        Routing.RegisterRoute(nameof(ProductPage), typeof(ProductPage));
        Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
        Routing.RegisterRoute(nameof(SearchProductPage), typeof(SearchProductPage));
        Routing.RegisterRoute(nameof(StatisticsPage), typeof(StatisticsPage));
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
                case nameof(MobileFavoriteRecipesPage):
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