namespace ValdemoroEn1.Features;

public partial class GasStationsPage : ContentPage
{
	public GasStationsPage(GasStationsPageViewModel gasStationsPageViewModel)
	{
		InitializeComponent();
		BindingContext = gasStationsPageViewModel;
	}
}