using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaApp.Models;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

/// <summary>
/// 首页 ViewModel
/// </summary>
public partial class MainViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    /// <summary>
    /// 菜单项列表
    /// </summary>
    [ObservableProperty] 
    private ObservableCollection<MenuItem> _menuItems = new();

    /// <summary>
    /// 是否正在加载
    /// </summary>
    [ObservableProperty] 
    private bool _isLoading;

    /// <summary>
    /// 欢迎信息
    /// </summary>
    [ObservableProperty] 
    private string _welcomeMessage = "欢迎使用仓库管理系统";

    /// <summary>
    /// 侧边抽屉是否打开
    /// </summary>
    [ObservableProperty]
    private bool _isDrawerOpen;

    public MainViewModel()
    {
        _navigationService = App.NavigationService;
    }

    /// <summary>
    /// 异步加载菜单
    /// </summary>
    public async Task LoadMenuAsync()
    {
        IsLoading = true;

        try
        {
            var menuCacheService = new MenuCacheService();
            // 从缓存加载菜单
            var items = await menuCacheService.LoadMenuCacheAsync();
            
            // 如果缓存为空（异常情况），尝试直接获取作为后备
            if (items == null || items.Count == 0)
            {
                 var menuService = new MenuService();
                 items = await menuService.GetMenuItemsAsync();
            }
            
            MenuItems = new ObservableCollection<MenuItem>(items);
        }
        finally
        {
            IsLoading = false;
        }
    }

    /// <summary>
    /// 打开侧边抽屉
    /// </summary>
    [RelayCommand]
    private void OpenDrawer()
    {
        IsDrawerOpen = true;
    }

    /// <summary>
    /// 关闭侧边抽屉
    /// </summary>
    [RelayCommand]
    private void CloseDrawer()
    {
        IsDrawerOpen = false;
    }

    /// <summary>
    /// 导航到主页
    /// </summary>
    [RelayCommand]
    private void GoHome()
    {
        IsDrawerOpen = false;
        // 已经在主页，无需导航
    }

    /// <summary>
    /// 导航到设置页面
    /// </summary>
    [RelayCommand]
    private void GoSettings()
    {
        IsDrawerOpen = false;
        _navigationService.NavigateTo(new SettingsViewModel());
    }

    /// <summary>
    /// 导航到关于页面
    /// </summary>
    [RelayCommand]
    private void GoAbout()
    {
        IsDrawerOpen = false;
        _navigationService.NavigateTo(new AboutViewModel());
    }

    /// <summary>
    /// 导航到菜单项对应的页面
    /// </summary>
    [RelayCommand]
    private void NavigateToMenu(MenuItem? menuItem)
    {
        if (menuItem == null) return;
        
        // 根据菜单项名称导航到对应页面
        switch (menuItem.Name)
        {
            case "白坯出库":
                _navigationService.NavigateTo(new RawFabricOutViewModel());
                break;
            // 其他菜单项可以在这里添加导航逻辑
            default:
                // 暂时不处理其他菜单项
                break;
        }
    }

    /// <summary>
    /// 是否显示退出确认弹窗
    /// </summary>
    [ObservableProperty]
    private bool _isLogoutDialogOpen;

    /// <summary>
    /// 退出登录命令（显示弹窗）
    /// </summary>
    [RelayCommand]
    private void Logout()
    {
        IsLogoutDialogOpen = true;
    }

    /// <summary>
    /// 取消退出
    /// </summary>
    [RelayCommand]
    private void CancelLogout()
    {
        IsLogoutDialogOpen = false;
    }

    /// <summary>
    /// 确认退出
    /// </summary>
    [RelayCommand]
    private void ConfirmLogout()
    {
        IsLogoutDialogOpen = false;
        
        // 清除菜单缓存
        var menuCacheService = new MenuCacheService();
        menuCacheService.ClearCache();
        
        _navigationService.NavigateTo(new LoginViewModel());
    }
}
