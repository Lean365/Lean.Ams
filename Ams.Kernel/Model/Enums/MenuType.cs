using System.ComponentModel;

namespace Ams.Model.System.Enums
{
    /// <summary>
    /// 菜单信息类型
    /// M目录 C菜单信息 F按钮 L链接
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public enum MenuType
    {
        [Description("目录")]
        M,

        [Description("菜单信息")]
        C,

        [Description("按钮")]
        F,

        [Description("链接")]
        L
    }
}