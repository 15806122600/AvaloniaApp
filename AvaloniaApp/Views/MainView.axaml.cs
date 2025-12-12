using Avalonia.Controls;
using Avalonia.Input;

namespace AvaloniaApp.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    
    private void OnDrawerOverlayPressed(object? sender, PointerPressedEventArgs e)
    {
        if (DataContext is ViewModels.MainViewModel vm)
        {
            vm.CloseDrawerCommand.Execute(null);
        }
    }
}