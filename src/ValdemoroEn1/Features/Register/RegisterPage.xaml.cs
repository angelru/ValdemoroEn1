namespace ValdemoroEn1.Features;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterPageViewModel registerPageViewModel)
	{
		InitializeComponent();
		BindingContext= registerPageViewModel;
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        Helper.HideKeyBoard();
    }
}