namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 角色部门
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// </summary>
    [SugarTable("sys_role_dept", "角色部门")]
    [Tenant(0)]
    public class SysRoleDept : SysBase
    {
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, IsPrimaryKey = true)]
        public long RoleId { get; set; }

        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL, IsPrimaryKey = true)]
        public long DeptId { get; set; }
    }
}