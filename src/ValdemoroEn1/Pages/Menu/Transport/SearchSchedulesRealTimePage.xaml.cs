namespace ValdemoroEn1.Pages;

public partial class SearchSchedulesRealTimePage : ContentPage
{
	public SearchSchedulesRealTimePage(SearchSchedulesRealTimePageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}