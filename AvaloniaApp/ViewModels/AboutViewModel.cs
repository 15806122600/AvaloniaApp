using CommunityToolkit.Mvvm.Input;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

/// <summary>
/// 关于页面 ViewModel
/// </summary>
public partial class AboutViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    public AboutViewModel()
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
