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
    private async Task DeleteAccountAsync()
    {
        bool accept = await AlertService.DisplayAlertAsync(AppResources.MyAccount, AppResources.DelAccountMsg, AppResources.Accept, AppResources.Cancel);

        if (accept)
        {
            try
            {
                if (CrossFirebaseAuth.Current?.CurrentUser != null)
                {
                    Preferences.Clear();
                    await CrossFirebaseAuth.Current.CurrentUser.DeleteAsync();
                    await NavigationService.NavigationAsync(AppSettings.Main);
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                await AlertService.SnackBarAsync(AppResources.DeleteError, SnackType.Success);
                await SignOutAsync();
            }
        }
    }

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

    [RelayCommand]
    private async Task LogoutAsync()
    {
        bool accept = await AlertService.DisplayAlertAsync(AppResources.Logout, AppResources.LogoutMsg, AppResources.Accept, AppResources.Cancel);

        if (accept)
        {
            await SignOutAsync();
        }
    }

    private async Task SignOutAsync()
    {
        await CrossFirebaseAuth.Current?.SignOutAsync();
        Preferences.Remove("login");
        await NavigationService.NavigationAsync(AppSettings.Main);
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