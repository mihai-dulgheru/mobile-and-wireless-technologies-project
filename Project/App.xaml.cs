namespace Project;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Application.Current.UserAppTheme = AppTheme.Light;

#if ANDROID || IOS
        MainPage = new AppShellMobile();
#else
        MainPage = new AppShell();
#endif
    }
}