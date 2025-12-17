using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaApp.Services;
using System;
using System.IO;
using LiteDB;
using System.Linq;
using AvaloniaApp.Messages;
using CommunityToolkit.Mvvm.Messaging;

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

    private string _bodyID;

    public RawFabricOutViewModel()
    {
        _navigationService = App.NavigationService;
        _bodyID = DateTime.Now.ToString("yyyyMMddHHmmss"); // Simple ID generation
        
        // Receive message to update totals
        WeakReferenceMessenger.Default.Register<UpdateTotalsMessage>(this, (r, m) =>
        {
            CalculateTotals();
        });
    }

    private void CalculateTotals()
    {
        // Load from LiteDB based on _bodyID
        try
        {
            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AvaloniaApp")))
            {
                 Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AvaloniaApp"));
            }

            using var db = new LiteDatabase(Services.StorageService.DbConnectionString);
            var col = db.GetCollection<AvaloniaApp.Models.HalfOutBodyDetail>("half_out_details");
            var details = col.Find(x => x.BodyID == _bodyID).ToList();
            
            TotalCount = details.Count;
            TotalWeight = details.Sum(x => x.Weight ?? 0);
        }
        catch { }
    }

    /// <summary>
    /// 返回主页
    /// </summary>
    [RelayCommand]
    private void GoBack()
    {
        _navigationService.GoBack();
    }

    /// <summary>
    /// 新增出库
    /// </summary>
    [RelayCommand]
    private void AddNew()
    {
        var vm = new WarehouseSelectionViewModel(_bodyID);
        _navigationService.NavigateTo(vm);
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
    /// 选择出库日期
    /// </summary>
    [RelayCommand]
    private void SelectDate()
    {
        // TODO: Use a proper DatePicker Dialog
        OutDate = DateTime.Now.ToString("yyyy-MM-dd");
    }

    /// <summary>
    /// 选择出库类别
    /// </summary>
    [RelayCommand]
    private void SelectOutType()
    {
        var vm = new GenericSelectionViewModel("OutType", result => OutType = result);
        _navigationService.NavigateTo(vm);
    }

    /// <summary>
    /// 选择客户
    /// </summary>
    [RelayCommand]
    private void SelectCustomer()
    {
        var vm = new GenericSelectionViewModel("Customer", result => Customer = result);
        _navigationService.NavigateTo(vm);
    }

    /// <summary>
    /// 选择收货方
    /// </summary>
    [RelayCommand]
    private void SelectReceiver()
    {
        var vm = new GenericSelectionViewModel("Receiver", result => Receiver = result);
        _navigationService.NavigateTo(vm);
    }

    /// <summary>
    /// 选择货车信息
    /// </summary>
    [RelayCommand]
    private void SelectTruckInfo()
    {
        var vm = new GenericSelectionViewModel("TruckInfo", result => TruckInfo = result);
        _navigationService.NavigateTo(vm);
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
