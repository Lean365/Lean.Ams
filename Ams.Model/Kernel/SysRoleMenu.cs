namespace Ams.Model.Kernel
{
    /// <summary>
    /// 角色菜单
    /// </summary>
    [SugarTable("sys_role_menu", "角色菜单")]
    [Tenant("0")]
    public class SysRoleMenu : SysBase
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [JsonProperty("roleId")]
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long Role_id { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        [JsonProperty("menuId")]
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long Menu_id { get; set; }
    }
}