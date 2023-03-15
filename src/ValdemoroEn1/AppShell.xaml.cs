namespace ValdemoroEn1;

public partial class AppShell : Shell
{
    private AppShellViewModel Vm => (AppShellViewModel)BindingContext;

    public AppShell()
    {
        InitializeComponent();
        BindingContext = new AppShellViewModel();

        RegisterRoutes();
        CheckLogin();
    }

    private void CheckLogin()
    {
        bool login = Preferences.ContainsKey("login");
        if (!login) _ = GoToAsync(AppSettings.Menu);
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(AppSettings.About, typeof(AboutPage));
        Routing.RegisterRoute(AppSettings.SchedulesRealTime, typeof(SchedulesRealTimePage));
        Routing.RegisterRoute(AppSettings.InfoMenuDetail, typeof(InfoMenuDetailPage));
        Routing.RegisterRoute(AppSettings.InfoMenu, typeof(InfoMenuPage));
        Routing.RegisterRoute(AppSettings.Register, typeof(RegisterPage));
        Routing.RegisterRoute(AppSettings.Login, typeof(LoginPage));
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        string previous = args.Previous?.Location?.ToString();

        if (previous == AppSettings.Main || previous == AppSettings.MainLogin)
        {
            Vm.User();
        }
    }
}
