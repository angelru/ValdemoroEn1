namespace ValdemoroEn1.Features;

public partial class InfoMenuPage : ContentPage
{
	public InfoMenuPage(InfoMenuPageViewModel vm)
	{
		InitializeComponent();
		BindingContext= vm;
	}
}