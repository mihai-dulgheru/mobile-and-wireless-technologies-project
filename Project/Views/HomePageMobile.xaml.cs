using Project.ViewModels;

namespace Project.Views;

public partial class HomePageMobile : ContentPage
{
    private readonly HomeViewModel _homeViewModel;
    public HomePageMobile()
    {
        InitializeComponent();
        _homeViewModel = new HomeViewModel();
        BindingContext = _homeViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _homeViewModel.GetRandomFoodTriviaAsync();
    }
}