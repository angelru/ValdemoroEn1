using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ValdemoroEn1.Services;

public class AlertService
{
    public static async Task SnackBarAsync(string message, SnackType snackType)
    {
        var duration = TimeSpan.FromSeconds(5);

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = snackType is SnackType.Success ? Colors.Green : Colors.DarkRed,
            TextColor = Colors.White,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(14),
            ActionButtonTextColor = Colors.White,
        };

        await Shell.Current.DisplaySnackbar(message, duration: duration, visualOptions: snackbarOptions);
    }

    public static async Task<string> PromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, Keyboard keyboard = null, string initialValue = "")
    {
        return await Shell.Current.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
    }

    public static async Task<bool> DisplayAlertAsync(string title, string message, string accept, string cancel)
    {
        return await Shell.Current.DisplayAlert(title, message, accept, cancel);
    }
}

public enum SnackType
{
    Success,
    Error
}
