using CommunityToolkit.Maui.Views;
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
    }

    [RelayCommand]
    private async Task AboutAsync()
    {
        Shell.Current.FlyoutIsPresented = false;
        await NavigationService.NavigationAsync("about");
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

    public void User()
    {
        //Name = CrossFirebaseAuth.Current?.CurrentUser?.DisplayName;
        //Email = CrossFirebaseAuth.Current?.CurrentUser?.Email;
        //PhotoUrl = CrossFirebaseAuth.Current?.CurrentUser?.PhotoUrl ?? "profile";
    }
}