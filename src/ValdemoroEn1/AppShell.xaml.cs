namespace ValdemoroEn1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = AppShellViewModel.Instance;
    }

    private void Shell_Loaded(object sender, EventArgs e)
    {
        AppShellViewModel.Instance.InitFirebase();
    }
}
