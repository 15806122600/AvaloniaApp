namespace AvaloniaApp.Services;

/// <summary>
/// 导航服务接口
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// 导航到指定的 ViewModel
    /// </summary>
    void NavigateTo<T>() where T : class;

    /// <summary>
    /// 导航到指定的 ViewModel 实例
    /// </summary>
    void NavigateTo(object viewModel);

    /// <summary>
    /// 返回上一个 ViewModel
    /// </summary>
    void GoBack();
}
