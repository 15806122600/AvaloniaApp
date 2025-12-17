using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaApp.ViewModels;

namespace AvaloniaApp.Views;

public partial class GenericSelectionView : UserControl
{
    public GenericSelectionView()
    {
        InitializeComponent();
    }

    private void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (DataContext is GenericSelectionViewModel vm && e.AddedItems.Count > 0)
        {
            vm.ConfirmCommand.Execute(null);
        }
    }
}
