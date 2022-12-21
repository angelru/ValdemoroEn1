using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Platform = Microsoft.Maui.ApplicationModel.Platform;

namespace ValdemoroEn1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        FirebaseAuthImplementation.HandleActivityResultAsync(requestCode, resultCode, data);
        base.OnActivityResult(requestCode, resultCode, data);
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
        Window.SetStatusBarColor(Color.FromArgb("#043465").ToAndroid());
        base.OnCreate(savedInstanceState);
    }
}
