namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 角色信息
    /// 数据实体类：sys_role
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("sys_role", "角色信息")]
    [Tenant("0")]
    public class SysRole : SysBase
    {
        /// <summary>
        /// 角色信息ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long RoleId { get; set; }

        /// <summary>
        /// 角色信息名称
        /// </summary>
        [SugarColumn(Length = 30, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色信息权限
        /// </summary>
        [SugarColumn(Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string RoleKey { get; set; }

        /// <summary>
        /// 角色信息排序
        /// </summary>
        [SugarColumn(ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int RoleSort { get; set; }

        /// <summary>
        /// 帐号状态（0正常 1停用）
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStated { get; set; }

        /// <summary>
        /// 删除标志（0代表存在 2代表删除）
        /// </summary>
        [SugarColumn(DefaultValue = "0")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 数据范围（1：全部数据权限 2：自定数据权限 3：本部门信息数据权限 4：本部门信息及以下数据权限））
        /// </summary>
        [SugarColumn(DefaultValue = "1")]
        public int DataScope { get; set; }

        /// <summary>
        /// 菜单信息树选择项是否关联显示
        /// </summary>
        [SugarColumn(ColumnName = "menu_check_strictly")]
        public bool MenuCheckStrictly { get; set; } = true;

        /// <summary>
        /// 部门信息树选择项是否关联显示
        /// </summary>
        [SugarColumn(ColumnName = "dept_check_strictly")]
        public bool DeptCheckStrictly { get; set; } = true;

        /// <summary>
        /// 菜单信息组
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public long[] MenuIds { get; set; }

        /// <summary>
        /// 部门信息组（数据权限）
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public long[] DeptIds { get; set; }

        /// <summary>
        /// 用户个数
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public int UserNum { get; set; }

        public SysRole()
        { }

        public SysRole(long roleId)
        {
            RoleId = roleId;
        }

        public bool IsAdmin()
        {
            return IsAdmin(RoleId);
        }

        public static bool IsAdmin(long roleId)
        {
            return 1 == roleId;
        }
    }
}