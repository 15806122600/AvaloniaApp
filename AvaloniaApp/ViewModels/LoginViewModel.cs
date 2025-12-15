using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaApp.Services;

namespace AvaloniaApp.ViewModels;

/// <summary>
/// 登录页面 ViewModel
/// </summary>
public partial class LoginViewModel : ViewModelBase
{
    private readonly NavigationService _navigationService;

    /// <summary>
    /// 用户名
    /// </summary>
    [ObservableProperty] 
    private string _username = string.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    [ObservableProperty] 
    private string _password = string.Empty;

    /// <summary>
    /// 是否正在登录
    /// </summary>
    [ObservableProperty] 
    private bool _isLoggingIn;

    /// <summary>
    /// 是否显示错误弹窗
    /// </summary>
    [ObservableProperty]
    private bool _isErrorDialogOpen;

    /// <summary>
    /// 错误信息
    /// </summary>
    [ObservableProperty]
    private string _errorMessage = string.Empty;

    public LoginViewModel()
    {
        _navigationService = App.NavigationService;
        Initialize();
    }

    public LoginViewModel(NavigationService navigationService)
    {
        _navigationService = navigationService;
        Initialize();
    }

    /// <summary>
    /// 显示错误提示弹窗
    /// </summary>
    private void ShowError(string message)
    {
        ErrorMessage = message;
        IsErrorDialogOpen = true;
    }

    /// <summary>
    /// 关闭错误弹窗
    /// </summary>
    [RelayCommand]
    private void CloseErrorDialog()
    {
        IsErrorDialogOpen = false;
        ErrorMessage = string.Empty;
    }

    /// <summary>
    /// 是否记住密码
    /// </summary>
    [ObservableProperty]
    private bool _isRememberPasswordChecked;

    private readonly StorageService _storageService = new StorageService();

    // Initialize in constructor
    private void Initialize()
    {
        var config = _storageService.LoadLoginConfig();
        if (config.IsRemembered)
        {
            Username = config.Username;
            Password = config.Password;
            IsRememberPasswordChecked = true;
        }
    }

    /// <summary>
    /// 退出程序命令
    /// </summary>
    [RelayCommand]
    private void Exit()
    {
        System.Environment.Exit(0);
    }

    /// <summary>
    /// 登录命令
    /// </summary>
    [RelayCommand]
    private async Task LoginAsync()
    {
        // 验证输入
        if (string.IsNullOrWhiteSpace(Username))
        {
            ShowError("请输入用户名");
            return;
        }

        if (string.IsNullOrWhiteSpace(Password))
        {
            ShowError("请输入密码");
            return;
        }

        IsLoggingIn = true;

        try
        {
            // 模拟登录验证延迟
            await Task.Delay(500);

            // 简单的登录验证（实际项目中应该调用 API）
            if (Username == "admin" && Password == "123456")
            {
                // 保存登录状态
                _storageService.SaveLoginConfig(Username, Password, IsRememberPasswordChecked);

                // 登录成功，导航到首页
                var mainViewModel = new MainViewModel();
                _navigationService.NavigateTo(mainViewModel);
                
                // 获取并缓存菜单
                try 
                {
                    // 获取最新菜单
                    var menuService = new MenuService();
                    var menuItems = await menuService.GetMenuItemsAsync();
                    
                    // 缓存菜单
                    var menuCacheService = new MenuCacheService();
                    await menuCacheService.SaveMenuCacheAsync(menuItems);
                }
                catch (Exception ex)
                {
                    // 即使缓存失败，也不应阻止登录流程，但可以记录日志
                    System.Diagnostics.Debug.WriteLine($"Menu caching failed: {ex.Message}");
                }

                // 加载菜单 (现在 MainViewModel 将从缓存读取，但如果是刚登录，其实也可以直接传进去或者让它自己读)
                // 由于 MainViewModel 的 LoadMenuAsync 现在改为读缓存，而我们刚刚写入了缓存，所以这里调用是安全的
                await mainViewModel.LoadMenuAsync();
            }
            else
            {
                ShowError("用户名或密码错误");
            }
        }
        finally
        {
            IsLoggingIn = false;
        }
    }
}
