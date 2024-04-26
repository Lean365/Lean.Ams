namespace Ams.Kernel.Services.System
{
    /// <summary>
    /// 角色菜单
    /// 业务层处理
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(ISysRoleMenuService), ServiceLifetime = LifeTime.Transient)]
    public class SysRoleMenuService : BaseService<SysRoleMenu>, ISysRoleMenuService
    {
        public int AddRoleMenu(List<SysRoleMenu> sysRoleMenus)
        {
            return Insert(sysRoleMenus);
        }

        public bool CheckMenuExistRole(long menuId)
        {
            return Count(it => it.Menu_id == menuId) > 0;
        }

        public int DeleteRoleMenuByRoleId(long roleId)
        {
            return Delete(roleId);
        }

        public bool DeleteRoleMenuByRoleIdMenuIds(long roleId, long[] menuIds)
        {
            return Delete(f => f.Role_id == roleId && menuIds.Contains(f.Menu_id));
        }

        /// <summary>
        /// 根据角色信息获取菜单信息id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SysRoleMenu> SelectRoleMenuByRoleId(long roleId)
        {
            return GetList(f => f.Role_id == roleId);
        }

        /// <summary>
        /// 根据用户所有角色信息获取菜单信息
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        public List<SysRoleMenu> SelectRoleMenuByRoleIds(long[] roleIds)
        {
            return GetList(it => roleIds.Contains(it.Role_id));
        }
    }
}