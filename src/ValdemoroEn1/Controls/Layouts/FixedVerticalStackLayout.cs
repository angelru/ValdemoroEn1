namespace ValdemoroEn1.Controls;

//TODO BUG: https://github.com/dotnet/maui/issues/13577

public class FixedVerticalStackLayout : VerticalStackLayout
{

    public FixedVerticalStackLayout() : base()
    {

    }

    protected override void OnAdd(int index, IView view)
    {
        base.OnAdd(index, view);
#if ANDROID
        Dispatcher.Dispatch(InvalidateMeasure);
#endif
    }
}