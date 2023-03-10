namespace ValdemoroEn1.Features;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
		BindingContext= loginPageViewModel;
	}
}