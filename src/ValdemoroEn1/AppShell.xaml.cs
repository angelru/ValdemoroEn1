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
        if (login) _ = GoToAsync(AppSettings.Menu);
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute("about", typeof(AboutPage));
        Routing.RegisterRoute("schedulesrealtime", typeof(SchedulesRealTimePage));
        Routing.RegisterRoute("infomenudetails", typeof(InfoMenuDetailPage));
        Routing.RegisterRoute("register", typeof(RegisterPage));
        Routing.RegisterRoute("login", typeof(LoginPage));
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
