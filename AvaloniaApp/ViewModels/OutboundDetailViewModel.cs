using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using AvaloniaApp.Models;
using AvaloniaApp.Services;
using System.Linq;
using LiteDB;
using System.IO;
using System;
using AvaloniaApp.Messages;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApp.ViewModels;

public partial class OutboundDetailViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;
    private readonly HalfOutBody _stockItem;

    [ObservableProperty]
    private string _title = "出库明细";

    [ObservableProperty]
    private ObservableCollection<HalfOutBodyDetail> _details = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CanReselectSpec))]
    private bool _hasDetails;

    public bool CanReselectSpec => !HasDetails;

    [ObservableProperty]
    private decimal _totalWeight;

    [ObservableProperty]
    private int _totalCount;

    private readonly string _parentBodyID;

    [ObservableProperty]
    private bool _isKeypadVisible;

    [ObservableProperty]
    private KeypadViewModel _keypad;

    public OutboundDetailViewModel(HalfOutBody stockItem, string parentBodyID)
    {
        _navigationService = App.NavigationService;
        _stockItem = stockItem;
        _parentBodyID = parentBodyID;
        Title = $"{stockItem.BatchNo} - {stockItem.SpecName}";

        _keypad = new KeypadViewModel(OnWeightInput, OnKeypadCancel);

        LoadDetails();
    }

    private void LoadDetails()
    {
        // 从LiteDB加载明细
        try
        {
            // Ensure directory exists
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AvaloniaApp");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            using var db = new LiteDatabase(Services.StorageService.DbConnectionString);
            var col = db.GetCollection<HalfOutBodyDetail>("half_out_details");
            var items = col.Find(x => x.BodyID == _parentBodyID).ToList();
            
            Details.Clear();
            foreach (var item in items)
            {
                Details.Add(item);
            }
        }
        catch { } // Ignore if db not ready

        UpdateTotals();
    }

    private void UpdateTotals()
    {
        HasDetails = Details.Count > 0;
        TotalCount = Details.Count;
        TotalWeight = Details.Sum(x => x.Weight ?? 0);
    }

    [RelayCommand]
    private void GoBack()
    {
        _navigationService.GoBack();
    }

    [RelayCommand]
    private void ReselectSpec()
    {
        // 返回上一页重新选择
        _navigationService.GoBack();
    }

    private void OnKeypadCancel()
    {
        IsKeypadVisible = false;
    }

    [RelayCommand]
    private void InputWeight()
    {
        // Show embedded keypad
        IsKeypadVisible = true;
    }

    private void OnWeightInput(decimal weight)
    {
        // IsKeypadVisible = false;

        // 保存并更新
        var detail = new HalfOutBodyDetail
        {
            Guid = Guid.NewGuid().ToString(),
            BodyID = _stockItem.BodyID,
            Weight = weight,
            DoDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        // Save to LiteDB
        try 
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AvaloniaApp");
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            using (var db = new LiteDatabase(Services.StorageService.DbConnectionString))
            {
                var col = db.GetCollection<HalfOutBodyDetail>("half_out_details");
                col.Insert(detail);
            }
        }
        catch (Exception ex)
        {
             // Log error or show message?
             System.Diagnostics.Debug.WriteLine($"DB Error: {ex.Message}");
        }

        Details.Add(detail);
        UpdateTotals();
    }



    [RelayCommand]
    private void Submit()
    {
        // Notify RawFabricOutViewModel to update
        WeakReferenceMessenger.Default.Send(new UpdateTotalsMessage("Update"));

        // Return to main logic
        _navigationService.GoBack(); 
        _navigationService.GoBack();
    }
}
