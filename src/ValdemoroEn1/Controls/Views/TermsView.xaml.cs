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
            await Helper.OpenUrlAsync(AppSettings.TermsGoogleURL);
        }

        private async void Privacy_Tapped(object sender, TappedEventArgs e)
        {
            await Helper.OpenUrlAsync(AppSettings.PrivacyGoogleURL);
        }
    }
}