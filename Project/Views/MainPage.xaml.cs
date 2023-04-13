using Project.Models;

namespace Project.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnNewButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        await App.PersonRepo.AddNewPersonAsync(newPerson.Text);
        statusMessage.Text = App.PersonRepo.StatusMessage;
    }

    private async void OnGetButtonClicked(object sender, EventArgs args)
    {
        statusMessage.Text = "";

        List<Person> people = await App.PersonRepo.GetAllPeopleAsync();
        peopleList.ItemsSource = people;
    }

}
