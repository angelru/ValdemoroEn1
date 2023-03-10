namespace ValdemoroEn1.Features;

public partial class InfoMenuPage : ContentPage
{
	public InfoMenuPage(InfoMenuPageViewModel infoMenuPageViewModel)
	{
		InitializeComponent();
		BindingContext= infoMenuPageViewModel;
	}
}