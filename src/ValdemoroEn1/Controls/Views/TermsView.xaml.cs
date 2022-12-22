namespace ValdemoroEn1.Controls
{
    public partial class TermsView : ContentView
    {
        public TermsView()
        {
            InitializeComponent();
        }

        private async void Terms_Tapped(object sender, TappedEventArgs e)
        {
            await Browser.OpenAsync(new Uri(AppSettings.TermsGoogleURL), BrowserLaunchMode.SystemPreferred);
        }

        private async void Privacy_Tapped(object sender, TappedEventArgs e)
        {
            await Browser.OpenAsync(new Uri(AppSettings.PrivacyGoogleURL), BrowserLaunchMode.SystemPreferred);
        }
    }
}