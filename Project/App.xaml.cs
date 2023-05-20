namespace Project;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
   
        Application.Current.UserAppTheme = Application.Current.RequestedTheme; ;

#if __MOBILE__
        MainPage = new AppShellMobile();
#else
        MainPage = new AppShell();
#endif
    }
}
