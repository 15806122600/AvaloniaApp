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
}
