using System.Windows.Input;

namespace ValdemoroEn1.Controls;

public partial class StateLayout : StackLayout
{
    public static readonly BindableProperty ErrorCommandProperty = BindableProperty.Create(nameof(ErrorCommand), typeof(ICommand), typeof(StateLayout), default(ICommand), BindingMode.TwoWay);
    public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(StateLayout), default);
    public static readonly BindableProperty CurrentStateProperty = BindableProperty.Create(nameof(CurrentState), typeof(string), typeof(StateLayout), default(string));
   
    public ICommand ErrorCommand
    {
        get => (ICommand)GetValue(ErrorCommandProperty);
        set => SetValue(ErrorCommandProperty, value);
    }

    public object CommandParameter
    {
        get => GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public string CurrentState
    {
        get => (string)GetValue(CurrentStateProperty);
        set => SetValue(CurrentStateProperty, value);
    }

    public IList<IView> SuccessContent => StackSuccess.Children;

    public StateLayout()
    {
        InitializeComponent();
    }

    public event EventHandler Clicked;

    private void Button_Clicked(object sender, EventArgs e)
    {
        Clicked?.Invoke(this, EventArgs.Empty);

        if (ErrorCommand == null || !ErrorCommand.CanExecute(CommandParameter))
            return;

        ErrorCommand.Execute(CommandParameter);
    }
}