namespace ValdemoroEn1.Features;

public partial class SearchSchedulesRealTimePage : ContentPage
{
	public SearchSchedulesRealTimePage(SearchSchedulesRealTimePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}