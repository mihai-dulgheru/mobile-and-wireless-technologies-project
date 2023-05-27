using Project.Views;

namespace Project;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AllRecipesPage), typeof(AllRecipesPage));
        Routing.RegisterRoute(nameof(FavoriteRecipesPage), typeof(FavoriteRecipesPage));
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(IngredientsPage), typeof(IngredientsPage));
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
                case nameof(HomePage):
                    Current.CurrentItem = homeItem;
                    break;
                case nameof(IngredientsPage):
                    Current.CurrentItem = ingredientsItem;
                    break;
                case nameof(FavoriteRecipesPage):
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
