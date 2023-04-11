using MWTProject.Services;

namespace MWTProject;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        IList<Data.Movie> movies = await new RestService().RefreshDataAsync();
        IList<Data.Product> products = await new RestService().SearchGroceryProductsAsync("burger");

        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}
