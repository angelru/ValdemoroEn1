namespace ValdemoroEn1.Features;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}