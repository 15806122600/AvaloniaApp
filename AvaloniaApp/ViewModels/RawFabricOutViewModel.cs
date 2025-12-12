using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

/// <summary>
/// 白坯出库 ViewModel
/// </summary>
public partial class RawFabricOutViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    [ObservableProperty]
    private string _outDate = string.Empty;

    [ObservableProperty]
    private string _outType = string.Empty;

    [ObservableProperty]
    private string _customer = string.Empty;

    [ObservableProperty]
    private string _customerOrder = string.Empty;

    [ObservableProperty]
    private string _receiver = string.Empty;

    [ObservableProperty]
    private string _truckInfo = string.Empty;

    [ObservableProperty]
    private int _totalCount = 0;

    [ObservableProperty]
    private decimal _totalWeight = 0.00m;

    [ObservableProperty]
    private string _remarks = string.Empty;

    public RawFabricOutViewModel()
    {
        _navigationService = App.NavigationService;
    }

    /// <summary>
    /// 返回主页
    /// </summary>
    [RelayCommand]
    private void GoBack()
    {
        var mainVm = new MainViewModel();
        _navigationService.NavigateTo(mainVm);
        _ = mainVm.LoadMenuAsync();
    }

    /// <summary>
    /// 新增出库
    /// </summary>
    [RelayCommand]
    private void AddNew()
    {
        // TODO: 实现新增出库逻辑
    }

    /// <summary>
    /// 保存出库单
    /// </summary>
    [RelayCommand]
    private void Save()
    {
        // TODO: 实现保存出库单逻辑
    }

    /// <summary>
    /// 选择客户
    /// </summary>
    [RelayCommand]
    private void SelectCustomer()
    {
        // TODO: 实现选择客户逻辑
    }

    /// <summary>
    /// 添加客户
    /// </summary>
    [RelayCommand]
    private void AddCustomer()
    {
        // TODO: 实现添加客户逻辑
    }
}
