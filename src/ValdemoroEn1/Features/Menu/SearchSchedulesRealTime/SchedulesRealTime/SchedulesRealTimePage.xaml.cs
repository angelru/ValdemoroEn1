namespace ValdemoroEn1.Features;

public partial class SchedulesRealTimePage : ContentPage
{
	public SchedulesRealTimePage(SchedulesRealTimePageViewModel schedulesRealTimePageViewModel)
	{
		InitializeComponent();
        BindingContext = schedulesRealTimePageViewModel;
    }
}