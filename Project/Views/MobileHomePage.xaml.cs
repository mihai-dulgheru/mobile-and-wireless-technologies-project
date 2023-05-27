using Project.ViewModels;

namespace Project.Views;

public partial class MobileHomePage : ContentPage
{
    private readonly HomeViewModel _homeViewModel;
    public MobileHomePage()
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

    private void OnButtonClicked(object sender, EventArgs e)
    {
        ((AppShellMobile)Application.Current.MainPage).NavigateTo(nameof(IngredientsPage));
    }
}