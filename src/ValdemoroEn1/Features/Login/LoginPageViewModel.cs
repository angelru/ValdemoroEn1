using Plugin.Firebase.Common;

namespace ValdemoroEn1.Features;

public partial class LoginPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _email;

    public LoginPageViewModel()
    {
    }

    [RelayCommand]
    private async Task RecoveryPasswordAsync()
    {
        string email = await AlertService.PromptAsync(AppResources.Email, null, AppResources.Accept, AppResources.Cancel);
        bool isValid = Helper.ValidateEmail(email);

        if (isValid)
        {
            await CrossFirebaseAuth.Current.SendPasswordResetEmailAsync(email);
            await AlertService.SnackBarAsync(AppResources.SendEmail, SnackType.Success);
        }
    }

    [RelayCommand]
    private async Task LoginAsync()
    {
        try
        {
            var user = await CrossFirebaseAuth.Current.SignInWithEmailAndPasswordAsync(Email, Password);

            if (user != null && user.IsEmailVerified)
            {
                Preferences.Set("login", true);
                await NavigationService.NavigationAsync(AppSettings.Menu);
            }
        }
        catch (Exception ex)
        {
            if (ex is FirebaseAuthException authEx)
            {
                switch (authEx.Reason)
                {
                    case FIRAuthError.WrongPassword:
                    case FIRAuthError.UserNotFound:
                    case FIRAuthError.InvalidCredential:
                        await AlertService.SnackBarAsync(AppResources.InvalidEmailPassword, SnackType.Error);
                        break;
                    default:
                        await AlertService.SnackBarAsync(AppResources.Error, SnackType.Error);
                        break;
                }
            }
        }
    }
}
