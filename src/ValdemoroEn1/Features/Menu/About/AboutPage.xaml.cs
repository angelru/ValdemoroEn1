namespace ValdemoroEn1.Features;

public partial class AboutPage : ContentPage
{
    public AboutPage(AboutPageViewModel aboutPageViewModel)
    {
        InitializeComponent();
        BindingContext = aboutPageViewModel;
    }

    private async void SendEmail_Tapped(object sender, TappedEventArgs e)
    {
        if (Email.Default.IsComposeSupported)
        {
            List<string> recipients = new()
            {
               AppSettings.ContactEmail
            };

            var message = new EmailMessage
            {
                Subject = "ValdemoroEn1",
                Body = AppResources.BodyEmail,
                To = recipients
            };

            await Email.Default.ComposeAsync(message);
        }
    }

    private async void OpenWeb_Tapped(object sender, TappedEventArgs e)
    {
       string url = e.Parameter?.ToString();
       await Helper.OpenUrlAsync(url);
    }
}