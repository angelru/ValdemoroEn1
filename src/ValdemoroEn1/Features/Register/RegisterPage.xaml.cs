namespace ValdemoroEn1.Features;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel registerPageViewModel)
	{
		InitializeComponent();
		BindingContext= registerPageViewModel;
	}
}