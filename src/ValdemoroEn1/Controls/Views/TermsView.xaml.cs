namespace ValdemoroEn1.Controls
{
    public partial class TermsView : ContentView
    {
        public TermsView()
        {
            InitializeComponent();
        }

        private async void OpenUrl_Tapped(object sender, TappedEventArgs e)
        {
            string url = e.Parameter?.ToString();
            await Helper.OpenUrlAsync(url);
        }
    }
}