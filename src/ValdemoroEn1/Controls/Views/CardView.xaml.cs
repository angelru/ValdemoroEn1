namespace ValdemoroEn1.Controls;

public partial class CardView : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(CardView), default(string));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public IList<IView> CardContent => StackContent.Children;

    public CardView()
	{
		InitializeComponent();
	}
}