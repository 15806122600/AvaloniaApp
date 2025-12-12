using System;

namespace AvaloniaApp.Services;

/// <summary>
/// 导航服务实现
/// </summary>
public class NavigationService : INavigationService
{
    /// <summary>
    /// 当前 ViewModel 变更事件
    /// </summary>
    public event Action<object>? CurrentViewModelChanged;

    /// <summary>
    /// 导航到指定的 ViewModel
    /// </summary>
    public void NavigateTo<T>() where T : class
    {
        var viewModel = Activator.CreateInstance<T>();
        CurrentViewModelChanged?.Invoke(viewModel);
    }
    
    /// <summary>
    /// 导航到指定的 ViewModel 实例
    /// </summary>
    public void NavigateTo(object viewModel)
    {
        CurrentViewModelChanged?.Invoke(viewModel);
    }
}
