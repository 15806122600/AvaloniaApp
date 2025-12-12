using CommunityToolkit.Mvvm.ComponentModel;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

/// <summary>
/// 主窗口 ViewModel - 管理导航状态
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// 当前显示的 ViewModel
    /// </summary>
    [ObservableProperty] 
    private ViewModelBase _currentViewModel;

    public MainWindowViewModel()
    {
        // 订阅导航事件
        App.NavigationService.CurrentViewModelChanged += OnCurrentViewModelChanged;
        
        // 默认显示登录页面
        _currentViewModel = new LoginViewModel();
    }

    private void OnCurrentViewModelChanged(object viewModel)
    {
        if (viewModel is ViewModelBase vm)
        {
            CurrentViewModel = vm;
        }
    }
}
