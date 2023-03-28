using Foundation;
using UIKit;

namespace ValdemoroEn1;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

    public override bool ContinueUserActivity(UIApplication application, NSUserActivity userActivity, UIApplicationRestorationHandler completionHandler)
    {
        return base.ContinueUserActivity(application, userActivity, completionHandler);
    }

    public override bool OpenUrl(UIApplication application, NSUrl url, NSDictionary options)
    {
        return base.OpenUrl(application, url, options);
    }
}
