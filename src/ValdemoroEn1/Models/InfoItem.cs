namespace ValdemoroEn1.Models;

public class InfoItem
{
    public InfoItem()
    {
    }

    public InfoItem(string icon, string title)
    {
        Icon = icon;
        Title = title;
    }

    public string Icon { get; set; }
    public string Title { get; set; }
}
