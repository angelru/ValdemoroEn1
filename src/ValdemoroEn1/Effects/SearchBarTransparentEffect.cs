using Microsoft.Maui.Controls.Platform;

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

            searchBar.SearchTextField.BackgroundColor = UIColor.White;
        }
#endif
    }

    protected override void OnDetached()
    {
        // Cleanup the control customization here
    }
}
