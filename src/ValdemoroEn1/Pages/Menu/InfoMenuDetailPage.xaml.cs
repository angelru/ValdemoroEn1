namespace ValdemoroEn1.Pages;

public partial class InfoMenuDetailPage : ContentPage
{
	public InfoMenuDetailPage(InfoMenuDetailPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}