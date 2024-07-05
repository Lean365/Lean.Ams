using System.ComponentModel;

namespace Ams.Model.Enums
{
    /// <summary>
    /// M目录 C菜单 F按钮 L链接
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public enum MenuType
    {
        [Description("目录")]
        M,

        [Description("菜单")]
        C,

        [Description("按钮")]
        F,

        [Description("链接")]
        L
    }
}