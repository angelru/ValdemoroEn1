using System.Windows.Input;

namespace ValdemoroEn1.Controls
{
    public partial class TermsView : ContentView
    {
        public TermsView()
        {
            InitializeComponent();
        }

        public string TermsGoogleURL { get; private set; } = AppSettings.TermsGoogleURL;
        public string PrivacyGoogleURL { get; private set; } = AppSettings.PrivacyGoogleURL;

        public ICommand OpenURLCommand => new Command<string>(OpenURL);

        private void OpenURL(string url)
        {
            _ = Browser.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
        }
    }
}