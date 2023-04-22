using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;

#if IOS
using UIKit;
#endif

namespace ValdemoroEn1.Effects;

internal class SearchBarTransparentEffect : RoutingEffect
{

}

internal class SearchBarTransparentPlatformEffect : PlatformEffect
{
    protected override void OnAttached()
    {
#if IOS
        if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
        {
            var searchBar = Control as UISearchBar;
            searchBar.SearchTextField.BackgroundColor = UIColor.Clear;
            searchBar.BackgroundImage = new UIImage();
        }
#endif
    }

    protected override void OnDetached()
    {
        // Cleanup the control customization here
    }
}
