using Project.Models;

namespace Project.Views;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    //private async void OnCounterClicked(object sender, EventArgs e)
    //{
    //    IList<Data.Movie> movies = await new RestService().RefreshDataAsync();
    //    IList<Data.Product> products = await new RestService().SearchGroceryProductsAsync("burger");

    //    count++;

    //    if (count == 1)
    //        CounterBtn.Text = $"Clicked {count} time";
    //    else
    //        CounterBtn.Text = $"Clicked {count} times";

    //    SemanticScreenReader.Announce(CounterBtn.Text);
    //}

    public async void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

    public async void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Person> people = await App.PersonRepo.GetAllPeopleAsync();
        peopleList.ItemsSource = people;
    }

}
