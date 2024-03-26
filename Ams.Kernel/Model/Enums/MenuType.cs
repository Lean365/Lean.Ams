using System.ComponentModel;

namespace Ams.Kernel.Model.System.Enums
{
    /// <summary>
    /// M目录 C菜单 F按钮 L链接
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
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