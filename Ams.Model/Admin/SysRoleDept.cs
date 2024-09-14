namespace Ams.Model.Admin
{
    /// <summary>
    /// 角色部门
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("sys_role_dept", "角色部门")]
    [Tenant(0)]
    public class SysRoleDept : SysBase
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, IsPrimaryKey = true)]
        public long RoleId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, IsPrimaryKey = false)]
        public long DeptId { get; set; }
    }
}