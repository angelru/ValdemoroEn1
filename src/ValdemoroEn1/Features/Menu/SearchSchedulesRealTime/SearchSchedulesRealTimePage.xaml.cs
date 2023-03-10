namespace ValdemoroEn1.Features;

public partial class SearchSchedulesRealTimePage : ContentPage
{
	public SearchSchedulesRealTimePage(SearchSchedulesRealTimePageViewModel 
		searchSchedulesRealTimePageViewModel)
	{
		InitializeComponent();
		BindingContext = searchSchedulesRealTimePageViewModel;
	}
}