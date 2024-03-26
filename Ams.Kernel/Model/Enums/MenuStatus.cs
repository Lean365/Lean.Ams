using System.ComponentModel;

namespace Ams.Kernel.Model.System.Enums
{
    /// <summary>
    /// 菜单状态（0正常 1停用）
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public enum MenuStatus
    {
        [Description("正常")]
        正常 = 0,

        [Description("停用")]
        停用 = 1,
    }
}