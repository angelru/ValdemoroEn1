using Plugin.Firebase.Core.Exceptions;

namespace ValdemoroEn1.Features;

public partial class RegisterPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _fullName;

    [ObservableProperty]
    private string _password;

    [ObservableProperty]
    private string _email;

    public RegisterPageViewModel()
    {
    }

    [RelayCommand]
    private async Task RegisterAsync()
    {
        try
        {
            await CrossFirebaseAuth.Current.CreateUserAsync(Email, Password);
            var currentUser = CrossFirebaseAuth.Current.CurrentUser;

            if (currentUser != null)
            {
                await currentUser.SendEmailVerificationAsync();
                await currentUser.UpdateProfileAsync(FullName);
                await AlertService.SnackBarAsync(AppResources.SendEmail, SnackType.Success);
                await NavigationService.NavigationAsync("..");
            }
        }
        catch (Exception ex)
        {
            if (ex is FirebaseAuthException authEx)
            {
                switch (authEx.Reason)
                {
                    case FIRAuthError.EmailAlreadyInUse:
                        await AlertService.SnackBarAsync(AppResources.EmailExists, SnackType.Error);
                        break;
                    case FIRAuthError.InvalidEmail:
                    case FIRAuthError.InvalidCredential:
                        await AlertService.SnackBarAsync(AppResources.ErrorEmail, SnackType.Error);
                        break;
                    case FIRAuthError.WeakPassword:
                        await AlertService.SnackBarAsync(AppResources.WeakPassword, SnackType.Error);
                        break;
                    default:
                        await AlertService.SnackBarAsync(AppResources.Error, SnackType.Error);
                        break;
                }
            }
        }
    }
}
