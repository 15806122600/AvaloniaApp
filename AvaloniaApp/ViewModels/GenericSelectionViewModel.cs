using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

public partial class GenericSelectionViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;
    private readonly Action<string> _onSelectionConfirmed;

    [ObservableProperty]
    private string _title = "选择";

    [ObservableProperty]
    private ObservableCollection<string> _items = new();

    [ObservableProperty]
    private string _selectedItem = string.Empty;

    public GenericSelectionViewModel(string type, Action<string> onSelectionConfirmed)
    {
        _navigationService = App.NavigationService;
        _onSelectionConfirmed = onSelectionConfirmed;
        LoadData(type);
    }

    private void LoadData(string type)
    {
        Title = $"选择{type}";
        Items.Clear();

        // 模拟数据
        if (type == "Customer")
        {
            Items.Add("客户A");
            Items.Add("客户B");
            Items.Add("客户C");
        }
        else if (type == "Receiver")
        {
            Items.Add("收货方X");
            Items.Add("收货方Y");
        }
        else if (type == "TruckInfo")
        {
            Items.Add("京A88888");
            Items.Add("沪B66666");
        }
    }

    [RelayCommand]
    private void Confirm()
    {
        if (!string.IsNullOrEmpty(SelectedItem))
        {
            _onSelectionConfirmed?.Invoke(SelectedItem);
            _navigationService.GoBack();
        }
    }

    [RelayCommand]
    private void GoBack()
    {
        _navigationService.GoBack();
    }
}
