using Project.Models;

namespace Project.Views;

public partial class AllRecipesPage : ContentPage
{
    public AllRecipesPage()
    {
        InitializeComponent();
    }

    private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection[0] is Recipe recipe)
            {
                await Shell.Current.GoToAsync($"{nameof(RecipePage)}?RecipeId={recipe.Id}");
            }
        }

    }
}