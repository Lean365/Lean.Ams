namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 角色部门
    /// 数据实体类：sys_role_dept
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("sys_role_dept", "角色部门")]
    [Tenant(0)]
    public class SysRoleDept : SysBase
    {
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, IsPrimaryKey = true)]
        public long RoleId { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, IsPrimaryKey = false)]
        public long DeptId { get; set; }
    }
}