namespace ValdemoroEn1;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = AppShellViewModel.Instance;
    }
}
