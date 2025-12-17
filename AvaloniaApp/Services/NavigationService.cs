using System;

namespace AvaloniaApp.Services;

/// <summary>
/// 导航服务实现
/// </summary>
public class NavigationService : INavigationService
{
    private readonly System.Collections.Generic.Stack<object> _history = new();

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
        NavigateTo(viewModel);
    }
    
    /// <summary>
    /// 导航到指定的 ViewModel 实例
    /// </summary>
    public void NavigateTo(object viewModel)
    {
        if (viewModel != null)
        {
            _history.Push(viewModel);
            CurrentViewModelChanged?.Invoke(viewModel);
        }
    }

    /// <summary>
    /// 返回上一个 ViewModel
    /// </summary>
    public void GoBack()
    {
        if (_history.Count > 1)
        {
            _history.Pop(); // Pop current
            var previous = _history.Peek();
            CurrentViewModelChanged?.Invoke(previous);
        }
    }
}
