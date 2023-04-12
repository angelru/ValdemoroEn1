using CommunityToolkit.Maui.Views;
using Plugin.Firebase.CloudMessaging;
using ValdemoroEn1.Controls;

namespace ValdemoroEn1.Features;

public partial class AppShellViewModel : BaseViewModel
{
    [ObservableProperty]
    private ImageSource _photoUrl;

    [ObservableProperty]
    private string _name;

    [ObservableProperty]
    private string _email;

    public AppShellViewModel()
    {
        RegisterRoutes();
    }

    [RelayCommand]
    private async Task DeleteAccountAsync()
    {
        bool accept = await AlertService.DisplayAlertAsync(AppResources.MyAccount, AppResources.DelAccountMsg, AppResources.Accept, AppResources.Cancel);

        if (accept)
        {
            if (CrossFirebaseAuth.Current?.CurrentUser != null)
            {
                Preferences.Clear();
                await CrossFirebaseAuth.Current.CurrentUser.DeleteAsync();
                await NavigationService.NavigationAsync(AppSettings.Main);
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
            await CrossFirebaseAuth.Current?.SignOutAsync();
            Preferences.Remove("login");
            await NavigationService.NavigationAsync(AppSettings.Main);
        }
    }

    private void RegisterRoutes()
    {
        Routing.RegisterRoute(AppSettings.About, typeof(AboutPage));
        Routing.RegisterRoute(AppSettings.SchedulesRealTime, typeof(SchedulesRealTimePage));
        Routing.RegisterRoute(AppSettings.InfoMenuDetail, typeof(InfoMenuDetailPage));
        Routing.RegisterRoute(AppSettings.InfoMenu, typeof(InfoMenuPage));
        Routing.RegisterRoute(AppSettings.Register, typeof(RegisterPage));
        Routing.RegisterRoute(AppSettings.Login, typeof(LoginPage));
    }

    public void InitFirebase()
    {
        Name = CrossFirebaseAuth.Current?.CurrentUser?.DisplayName;
        Email = CrossFirebaseAuth.Current?.CurrentUser?.Email;
        PhotoUrl = CrossFirebaseAuth.Current?.CurrentUser?.PhotoUrl ?? "profile";

        _ = RunSafeAsync(async () =>
        {
            await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
            await CrossFirebaseCloudMessaging.Current.SubscribeToTopicAsync("ValdemoroEn1");
        });
    }
}