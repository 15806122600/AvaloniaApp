namespace AvaloniaApp.Models;

/// <summary>
/// 菜单项模型
/// </summary>
public class MenuItem
{
    /// <summary>
    /// 菜单名称
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// 菜单图标（emoji 或图标名称）
    /// </summary>
    public string Icon { get; set; } = string.Empty;
    
    /// <summary>
    /// 菜单描述
    /// </summary>
    public string Description { get; set; } = string.Empty;
}
