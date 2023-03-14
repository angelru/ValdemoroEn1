namespace ValdemoroEn1.Features;

public partial class EstablishmentsPage : ContentPage
{
	public EstablishmentsPage(EstablishmentsPageViewModel establishmentsPageViewModel)
	{
		InitializeComponent();
		BindingContext = establishmentsPageViewModel;
	}
}