using Project.Models;
using Project.ViewModels;

namespace Project.Views;

public partial class MobileFavoriteRecipesPage : ContentPage
{
    private readonly IFavoriteRecipesViewModel _viewModel;

    public MobileFavoriteRecipesPage()
    {
        InitializeComponent();
        _viewModel = new FavoriteRecipesViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnAppearing();
    }

    private async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            if (e.CurrentSelection[0] is Recipe recipe)
            {
                await Shell.Current.GoToAsync($"{nameof(FavoriteRecipePage)}?RecipeId={recipe.Id}");
                collectionView.SelectedItem = null;
            }
        }
    }
}