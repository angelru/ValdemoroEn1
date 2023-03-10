namespace ValdemoroEn1.Features;

public partial class InfoMenuDetailPage : ContentPage
{
	public InfoMenuDetailPage(InfoMenuDetailPageViewModel infoMenuDetailPageViewModel)
	{
		InitializeComponent();
		BindingContext = infoMenuDetailPageViewModel;
	}
}