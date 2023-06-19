using Project.ViewModels;

namespace Project.Views;

public partial class AllFavoriteRecipesPage : ContentPage
{
    private readonly IAllFavoriteRecipesViewModel _viewModel;

    public AllFavoriteRecipesPage()
    {
        InitializeComponent();
        _viewModel = new AllFavoriteRecipesViewModel();
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnAppearing();
    }
}