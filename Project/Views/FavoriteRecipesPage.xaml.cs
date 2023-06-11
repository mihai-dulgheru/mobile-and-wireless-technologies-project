using Project.ViewModels;

namespace Project.Views;

public partial class FavoriteRecipesPage : ContentPage
{
    private readonly IFavoriteRecipesViewModel _viewModel;

    public FavoriteRecipesPage()
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
}