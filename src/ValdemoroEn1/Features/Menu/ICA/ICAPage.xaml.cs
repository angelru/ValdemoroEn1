namespace ValdemoroEn1.Features;

public partial class ICAPage : ContentPage
{
	public ICAPage(ICAPageViewModel iCAPageViewModel)
	{
		InitializeComponent();
		BindingContext = iCAPageViewModel;
	}
}