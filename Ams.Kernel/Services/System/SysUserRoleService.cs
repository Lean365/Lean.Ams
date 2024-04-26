using Ams.Repository;

namespace Ams.Kernel.Services.System
{
    /// <summary>
    /// 用户角色信息
    /// 业务层处理
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [AppService(ServiceType = typeof(ISysUserRoleService), ServiceLifetime = LifeTime.Transient)]
    public class SysUserRoleService : BaseService<SysUserRole>, ISysUserRoleService
    {
        /// <summary>
        /// 通过角色信息ID查询角色信息使用数量
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public int CountUserRoleByRoleId(long roleId)
        {
            return Count(it => it.RoleId == roleId);
        }

        /// <summary>
        /// 删除用户角色信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUserRoleByUserId(int userId)
        {
            return Delete(it => it.UserId == userId) ? 1 : 0;
        }

        /// <summary>
        /// 批量删除角色信息对应用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public int DeleteRoleUserByUserIds(long roleId, List<long> userIds)
        {
            return Delete(it => it.RoleId == roleId && userIds.Contains(it.UserId)) ? 1 : 0;
        }

        /// <summary>
        /// 添加用户角色信息
        /// </summary>
        /// <param name="sysUserRoles"></param>
        /// <returns></returns>
        public int AddUserRole(List<SysUserRole> sysUserRoles)
        {
            return Insert(sysUserRoles);
        }

        /// <summary>
        /// 获取用户数据根据角色信息id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SysUser> GetSysUsersByRoleId(long roleId)
        {
            return Context.Queryable<SysUserRole, SysUser>((t1, u) => new JoinQueryInfos(
                   JoinType.Left, t1.UserId == u.UserId))
                .WithCache(60 * 10)
                .Where((t1, u) => t1.RoleId == roleId && u.IsDeleted == 0)
                .Select((t1, u) => u)
                .ToList();
        }

        /// <summary>
        /// 获取用户数据根据角色信息id
        /// </summary>
        /// <param name="SysRoleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetSysUsersByRoleId(SysRoleUserQueryDto SysRoleUserQueryDto)
        {
            var query = Context.Queryable<SysUserRole, SysUser>((t1, u) => new JoinQueryInfos(
                JoinType.Left, t1.UserId == u.UserId))
                .Where((t1, u) => t1.RoleId == SysRoleUserQueryDto.RoleId && u.IsDeleted == 0);
            if (!string.IsNullOrEmpty(SysRoleUserQueryDto.UserName))
            {
                query = query.Where((t1, u) => u.UserName.Contains(SysRoleUserQueryDto.UserName));
            }
            return query.Select((t1, u) => u).ToPage(SysRoleUserQueryDto);
        }

        /// <summary>
        /// 获取尚未指派的用户数据根据角色信息id
        /// </summary>
        /// <param name="SysRoleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetExcludedSysUsersByRoleId(SysRoleUserQueryDto SysRoleUserQueryDto)
        {
            var query = Context.Queryable<SysUser>()
                .Where(it => it.IsDeleted == 0)
                .Where(it => SqlFunc.Subqueryable<SysUserRole>().Where(s => s.UserId == it.UserId && s.RoleId == SysRoleUserQueryDto.RoleId).NotAny())
                .WhereIF(SysRoleUserQueryDto.UserName.IsNotEmpty(), it => it.UserName.Contains(SysRoleUserQueryDto.UserName));

            return query.ToPage(SysRoleUserQueryDto);
        }

        /// <summary>
        /// 新增用户角色信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int InsertUserRole(SysUser user)
        {
            //if(user.RoleIds == null) return 0;
            List<SysUserRole> userRoles = new();
            foreach (var item in user.RoleIds)
            {
                userRoles.Add(new SysUserRole() { RoleId = item, UserId = user.UserId });
            }

            return userRoles.Count > 0 ? AddUserRole(userRoles) : 0;
        }

        /// <summary>
        /// 新增加角色用户
        /// </summary>
        /// <param name="SysRoleUsersCreateDto"></param>
        /// <returns></returns>
        public int InsertRoleUser(SysRoleUsersCreateDto SysRoleUsersCreateDto)
        {
            List<SysUserRole> userRoles = new();
            foreach (var item in SysRoleUsersCreateDto.UserIds)
            {
                userRoles.Add(new SysUserRole() { RoleId = SysRoleUsersCreateDto.RoleId, UserId = item });
            }

            return userRoles.Count > 0 ? AddUserRole(userRoles) : 0;
        }
    }
}