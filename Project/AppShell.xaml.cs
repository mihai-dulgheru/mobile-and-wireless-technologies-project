namespace Project;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(MVVM.Views.FirstPage), typeof(MVVM.Views.FirstPage));
    }
}
