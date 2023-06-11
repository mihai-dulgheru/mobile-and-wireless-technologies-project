namespace Project;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        Current.UserAppTheme = AppTheme.Light;

#if __MOBILE__
        MainPage = new AppShellMobile();
#else
        MainPage = new AppShell();
#endif
    }
}
