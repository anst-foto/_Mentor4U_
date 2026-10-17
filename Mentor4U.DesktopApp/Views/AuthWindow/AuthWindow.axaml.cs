using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Mentor4U.DesktopApp.Views;

public partial class AuthWindow : Window
{
    public AuthWindow()
    {
        InitializeComponent();
    }

    private void OnWindowPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (!e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
        {
            return;
        }

        if (e.Source is Control source && IsInteractive(source))
        {
            return;
        }

        BeginMoveDrag(e);
    }

    private static bool IsInteractive(Control control)
    {
        for (Control? current = control; current is not null; current = current.Parent as Control)
        {
            if (current is Button or TextBox)
            {
                return true;
            }
        }

        return false;
    }

    private void OnCloseClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
    }

    private async void OnLoginClick(object? sender, RoutedEventArgs e)
    {
       //
    }
}