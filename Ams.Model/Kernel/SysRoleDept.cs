namespace Ams.Model.Kernel
{
    /// <summary>
    /// 角色部门关系表
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
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