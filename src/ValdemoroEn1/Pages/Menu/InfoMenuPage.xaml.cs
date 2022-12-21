namespace ValdemoroEn1.Pages;

public partial class InfoMenuPage : ContentPage
{
	public InfoMenuPage(InfoMenuPageViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}