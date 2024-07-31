namespace Ams.Model.Kernel
{
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