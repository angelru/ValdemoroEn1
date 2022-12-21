namespace ValdemoroEn1.Pages;

public partial class SchedulesRealTimePage : ContentPage
{
	public SchedulesRealTimePage(SchedulesRealTimePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}