using Avalonia;
using Avalonia.Controls;

namespace Mentor4U.DesktopApp.Components;

public partial class InputComponent : UserControl
{
    public static readonly StyledProperty<object> LabelContentProperty 
        = AvaloniaProperty.Register<InputComponent, object>(nameof(LabelContent));
    public object LabelContent
    {
        get => GetValue(LabelContentProperty);
        set => SetValue(LabelContentProperty, value);
    }

    public static readonly StyledProperty<string> InputValueProperty 
        = AvaloniaProperty.Register<InputComponent, string>(nameof(InputValue));
    public string InputValue
    {
        get => GetValue(InputValueProperty);
        set => SetValue(InputValueProperty, value);
    }

    public static readonly StyledProperty<bool> IsReadOnlyProperty 
        = AvaloniaProperty.Register<InputComponent, bool>(nameof(IsReadOnly), defaultValue: false);

    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }
    
    public static readonly StyledProperty<char?> PasswordCharProperty =
        AvaloniaProperty.Register<InputComponent, char?>(nameof(PasswordChar), defaultValue: null);

    public char? PasswordChar
    {
        get => GetValue(PasswordCharProperty);
        set => SetValue(PasswordCharProperty, value);
    }

    public static readonly StyledProperty<bool> RevealPasswordProperty =
        AvaloniaProperty.Register<InputComponent, bool>(nameof(RevealPassword), defaultValue: false);

    public bool RevealPassword
    {
        get => GetValue(RevealPasswordProperty);
        set => SetValue(RevealPasswordProperty, value);
    }
    
    public InputComponent()
    {
        InitializeComponent();
    }
}