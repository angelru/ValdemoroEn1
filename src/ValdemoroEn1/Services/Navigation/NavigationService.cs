namespace ValdemoroEn1.Services;

public class NavigationService
{
    private static IDictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();

    public NavigationService()
    {
    }

    public static async Task NavigationAsync(ShellNavigationState state)
    {
        if (Parameters.Any())
        {
            await Shell.Current.GoToAsync(state, Parameters);
            Parameters.Clear();
        }
        else
        {
            await Shell.Current.GoToAsync(state);
        }
    }

    public static void AddParameter(string key, object value)
    {
        Parameters[key] = value;
    }
}
