namespace ValdemoroEn1.Features;

public partial class SchedulesRealTimePage : ContentPage
{
	public SchedulesRealTimePage(SchedulesRealTimePageViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}