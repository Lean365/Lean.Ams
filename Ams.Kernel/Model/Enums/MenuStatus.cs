using System.ComponentModel;

namespace Ams.Model.System.Enums
{
    /// <summary>
    /// 菜单状态（0正常 1停用）
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public enum MenuStatus
    {
        [Description("正常")]
        正常 = 0,

        [Description("停用")]
        停用 = 1,
    }
}