namespace Ams.Model.Admin
{
    /// <summary>
    /// 用户角色 用户N-1 角色
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("sys_user_role", "用户角色")]
    [Tenant("0")]
    public class SysUserRole : SysBase
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        [SugarColumn(ColumnName = "user_id", IsPrimaryKey = true)]
        public long UserId { get; set; }

        /// <summary>
        /// 角色ID
        /// </summary>
        [SugarColumn(ColumnName = "role_id", IsPrimaryKey = true)]
        public long RoleId { get; set; }
    }
}