using CommunityToolkit.Maui.Views;
using Plugin.Firebase.CloudMessaging;
using ValdemoroEn1.Controls;

namespace ValdemoroEn1.Features;

public partial class AppShellViewModel : BaseViewModel
{
    private bool _initFirebase = false;

    [ObservableProperty]
    private string _currentVersion = "Ver: " + VersionTracking.Default.CurrentVersion.ToString() + " (" + VersionTracking.Default.CurrentBuild.ToString() + ")";

    [ObservableProperty]
    private ImageSource _photoUrl;

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _email;

    public AppShellViewModel()
    {
    }

    public static AppShellViewModel Instance { get; set; } = new AppShellViewModel();


    [RelayCommand]
    private async Task AboutAsync()
    {
        Shell.Current.FlyoutIsPresented = false;
        await NavigationService.NavigationAsync(AppSettings.About);
    }

    [RelayCommand]
    private async Task LanguagePopupAsync()
    {
        await PopupExtensions.ShowPopupAsync(Shell.Current, new LanguagePopup());
    }

    //TODO refactorizar
    public void InitFirebase()
    {
        if (_initFirebase) return;

        try
        {
            _ = CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
            _ = CrossFirebaseCloudMessaging.Current.SubscribeToTopicAsync("ValdemoroEn1");
            _initFirebase = true;
        }
        catch (Exception ex)
        {
            _ = ex.Message;
        }
    }
}