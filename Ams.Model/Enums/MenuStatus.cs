using System.ComponentModel;

namespace Ams.Model.Enums
{
    /// <summary>
    /// 菜单状态（0正常 1停用）
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public enum MenuStatus
    {
        [Description("正常")]
        正常 = 0,

        [Description("停用")]
        停用 = 1,
    }
}