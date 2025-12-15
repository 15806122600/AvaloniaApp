using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using AvaloniaApp.Models;

namespace AvaloniaApp.Services;

/// <summary>
/// 菜单缓存服务
/// </summary>
public class MenuCacheService
{
    private readonly string _cacheFilePath;

    public MenuCacheService()
    {
        // 缓存文件路径：AppData/Local/AvaloniaApp/menu_cache.json
        var localDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var appDataPath = Path.Combine(localDataPath, "AvaloniaApp");
        
        if (!Directory.Exists(appDataPath))
        {
            Directory.CreateDirectory(appDataPath);
        }

        _cacheFilePath = Path.Combine(appDataPath, "menu_cache.json");
    }

    /// <summary>
    /// 保存菜单到缓存
    /// </summary>
    public async Task SaveMenuCacheAsync(IEnumerable<MenuItem> menuItems)
    {
        try
        {
            var json = JsonSerializer.Serialize(menuItems);
            await File.WriteAllTextAsync(_cacheFilePath, json);
        }
        catch (Exception ex)
        {
            // 记录日志或忽略
            System.Diagnostics.Debug.WriteLine($"Failed to save menu cache: {ex.Message}");
        }
    }

    /// <summary>
    /// 从缓存加载菜单
    /// </summary>
    public async Task<List<MenuItem>> LoadMenuCacheAsync()
    {
        if (!File.Exists(_cacheFilePath))
        {
            return new List<MenuItem>();
        }

        try
        {
            var json = await File.ReadAllTextAsync(_cacheFilePath);
            var items = JsonSerializer.Deserialize<List<MenuItem>>(json);
            return items ?? new List<MenuItem>();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to load menu cache: {ex.Message}");
            return new List<MenuItem>();
        }
    }

    /// <summary>
    /// 清除菜单缓存
    /// </summary>
    public void ClearCache()
    {
        try
        {
            if (File.Exists(_cacheFilePath))
            {
                File.Delete(_cacheFilePath);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Failed to clear menu cache: {ex.Message}");
        }
    }
    
    /// <summary>
    /// 检查是否存在缓存
    /// </summary>
    public bool HasCache()
    {
        return File.Exists(_cacheFilePath);
    }
}
