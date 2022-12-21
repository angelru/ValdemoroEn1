namespace ValdemoroEn1.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}