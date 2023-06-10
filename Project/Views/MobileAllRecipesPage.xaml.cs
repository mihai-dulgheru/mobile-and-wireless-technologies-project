using Project.Models;

namespace Project.Views;

public partial class MobileAllRecipesPage : ContentPage
{
    public MobileAllRecipesPage()
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
                collectionView.SelectedItem = null;
            }
        }
    }
}