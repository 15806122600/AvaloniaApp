using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaApp.Models;

namespace AvaloniaApp.Services;

/// <summary>
/// 菜单服务 - 模拟获取菜单数据
/// </summary>
public class MenuService
{
    /// <summary>
    /// 模拟异步获取菜单项列表
    /// </summary>
    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        // 模拟网络请求延迟
        await Task.Delay(300);

        return new List<MenuItem>
        {
            new() { Name = "调拨出库", Icon = "📝", Description = "调拨出库操作" },
            new() { Name = "调拨出库历史", Icon = "📝", Description = "调拨出库历史" },
            new() { Name = "后整流程报工", Icon = "📝", Description = "后整流程报工" },
            new() { Name = "移仓确认", Icon = "📝", Description = "移仓确认操作" },
            new() { Name = "剪样出库", Icon = "📝", Description = "剪样出库操作" },
            new() { Name = "白坯出库", Icon = "📝", Description = "白坯出库操作" },
            new() { Name = "白坯出库历史", Icon = "📝", Description = "白坯出库历史" },
            new() { Name = "成品出库", Icon = "📝", Description = "成品出库操作" },
            new() { Name = "成品出库历史", Icon = "📝", Description = "成品出库历史" },
            new() { Name = "色坯出库", Icon = "📝", Description = "色坯出库操作" },
            new() { Name = "色坯出库历史", Icon = "📝", Description = "色坯出库历史" },
            new() { Name = "后整理出库", Icon = "📝", Description = "后整理出库操作" }
        };
    }
}
