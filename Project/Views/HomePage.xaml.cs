using Project.ViewModels;

namespace Project.Views;

public partial class HomePage : ContentPage
{
    private readonly HomeViewModel _homeViewModel;
    public HomePage()
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
        ((AppShell)Application.Current.MainPage).NavigateTo(nameof(IngredientsPage));
    }
}