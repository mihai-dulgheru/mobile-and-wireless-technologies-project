namespace Project;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

#if ANDROID || IOS
        MainPage = new AppShellMobile();
#else
        MainPage = new AppShell();
#endif
    }
}