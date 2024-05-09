using Ams.Model;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 用户角色
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ISysUserRoleService : IBaseService<SysUserRole>
    {
        public int CountUserRoleByRoleId(long roleId);

        /// <summary>
        /// 删除用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int DeleteUserRoleByUserId(int userId);

        /// <summary>
        /// 批量删除角色对应用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public int DeleteRoleUserByUserIds(long roleId, List<long> userIds);

        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="sysUsers"></param>
        /// <returns></returns>
        public int AddUserRole(List<SysUserRole> sysUsers);

        /// <summary>
        /// 获取用户数据根据角色id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SysUser> GetSysUsersByRoleId(long roleId);

        /// <summary>
        /// 获取用户数据根据角色id
        /// </summary>
        /// <param name="SysRoleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetSysUsersByRoleId(SysRoleUserQueryDto SysRoleUserQueryDto);

        /// <summary>
        /// 获取尚未指派的用户数据根据角色id
        /// </summary>
        /// <param name="SysRoleUserQueryDto"></param>
        /// <returns></returns>
        public PagedInfo<SysUser> GetExcludedSysUsersByRoleId(SysRoleUserQueryDto SysRoleUserQueryDto);

        /// <summary>
        /// 新增用户角色信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int InsertUserRole(SysUser user);

        /// <summary>
        /// 新增加角色用户
        /// </summary>
        /// <param name="SysRoleUsersCreateDto"></param>
        /// <returns></returns>
        public int InsertRoleUser(SysRoleUsersCreateDto SysRoleUsersCreateDto);
    }
}