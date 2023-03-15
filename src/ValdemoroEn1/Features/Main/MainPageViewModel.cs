namespace ValdemoroEn1.Features;

public partial class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel()
    {

    }

    [RelayCommand]
    private async Task RegisterAsync()
    {
        await NavigationService.NavigationAsync(AppSettings.Register);
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        await NavigationService.NavigationAsync(AppSettings.Login);
    }

    //[RelayCommand]
    //private async Task FacebookLoginAsync()
    //{
    //    await RunSafeAsync(async () =>
    //    {
    //        var firebaseUser = await CrossFirebaseAuth.Current.LinkWithFacebookAsync();
    //    });
    //}

    [RelayCommand]
    private async Task GoogleLoginAsync()
    {
        await RunSafeAsync(async () =>
        {
            var firebaseUser = await CrossFirebaseAuth.Current.SignInWithGoogleAsync();
            Preferences.Set("login", true);
            await NavigationService.NavigationAsync(AppSettings.Menu);
        });
    }
}
