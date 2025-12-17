using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using AvaloniaApp.Models;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

public partial class WarehouseSelectionViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    [ObservableProperty]
    private ObservableCollection<HalfOutBody> _stockRecords = new();

    private readonly string _parentBodyID;

    public WarehouseSelectionViewModel(string parentBodyID)
    {
        _navigationService = App.NavigationService;
        _parentBodyID = parentBodyID;
        LoadStockRecords();
    }

    private void LoadStockRecords()
    {
        // 模拟库存数据
        StockRecords.Add(new HalfOutBody { BatchNo = "BATCH001", SpecName = "规格A", WareHouseName = "仓库1", Weight = 1000m, PNums = 50 });
        StockRecords.Add(new HalfOutBody { BatchNo = "BATCH002", SpecName = "规格B", WareHouseName = "仓库2", Weight = 2000m, PNums = 80 });
    }

    [RelayCommand]
    private void SelectStock(HalfOutBody item)
    {
        NavigateToDetail(item);
    }

    private void NavigateToDetail(HalfOutBody item)
    {
        var detailVm = new OutboundDetailViewModel(item, _parentBodyID);
        _navigationService.NavigateTo(detailVm);
    }

    [RelayCommand]
    private void GoBack()
    {
        _navigationService.GoBack();
    }
}
