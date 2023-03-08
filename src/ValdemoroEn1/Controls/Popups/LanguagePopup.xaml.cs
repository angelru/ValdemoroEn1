using CommunityToolkit.Maui.Views;
using System.Globalization;

namespace ValdemoroEn1.Controls;

public partial class LanguagePopup : Popup
{
    private AppLanguage appLanguage;

    public LanguagePopup()
    {
        InitializeComponent();
        BindingContext = this;
        LanguageCollectionView.ItemsSource = AppLanguages;
    }

    public List<AppLanguage> AppLanguages = new()
    {
        new AppLanguage("es-Es", AppResources.Spanish),
        new AppLanguage("en-US", AppResources.English)
    };

    private void LanguageChanged(object sender, SelectionChangedEventArgs e)
    {
        var cv = sender as CollectionView;
        appLanguage = cv.SelectedItem as AppLanguage;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (appLanguage != null)
        {
            LocalizationResourceManager.Instance.SetCulture(new CultureInfo(appLanguage.Culture));
        }

        Close();
    }
}