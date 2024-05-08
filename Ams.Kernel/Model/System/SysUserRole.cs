namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 用户角色" 用户N-1 角色
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("sys_user_role", "用户角色")]
    [Tenant("0")]
    public class SysUserRole : SysBase
    {
        [SugarColumn(ColumnName = "user_id", IsPrimaryKey = true)]
        public long UserId { get; set; }

        [SugarColumn(ColumnName = "role_id", IsPrimaryKey = true)]
        public long RoleId { get; set; }
    }
}