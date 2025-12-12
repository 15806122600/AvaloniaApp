using CommunityToolkit.Mvvm.Input;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

/// <summary>
/// 设置页面 ViewModel
/// </summary>
public partial class SettingsViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    public SettingsViewModel()
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
}
