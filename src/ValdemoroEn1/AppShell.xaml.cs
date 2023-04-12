namespace ValdemoroEn1;

public partial class AppShell : Shell
{
    private AppShellViewModel Vm => (AppShellViewModel)BindingContext;

    public AppShell()
    {
        InitializeComponent();
        BindingContext = new AppShellViewModel();
        CheckLogin();
    }

    private void CheckLogin()
    {
        bool login = Preferences.ContainsKey("login");
        if (!login) _ = GoToAsync(AppSettings.Menu);
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        string previous = args.Previous?.Location?.ToString();

        if (previous == AppSettings.Main || previous == AppSettings.MainLogin)
        {
            Vm.InitFirebase();
        }
    }
}
