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
                
                // 加载菜单
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
