namespace Ams.Kernel.Model.System
{
    /// <summary>
    /// 角色菜单
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("sys_role_menu", "角色菜单")]
    [Tenant("0")]
    public class SysRoleMenu : SysBase
    {
        [JsonProperty("roleId")]
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long Role_id { get; set; }

        [JsonProperty("menuId")]
        [SugarColumn(IsPrimaryKey = true, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public long Menu_id { get; set; }
    }
}