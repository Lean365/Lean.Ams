using SqlSugar;

namespace Ams.Kernel.Model.System
{
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
