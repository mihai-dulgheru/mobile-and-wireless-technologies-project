using Project.Data;

namespace Project;

public partial class App : Application
{
    public static IPersonRepository PersonRepo { get; private set; }

    public App(IPersonRepository repo)
    {
        InitializeComponent();

        MainPage = new AppShell();
        //MainPage = new NavigationPage(new Views.HomePage());

        PersonRepo = repo;
    }
}
