namespace Ams.Kernel.Services
{
    /// <summary>
    /// 系统权限
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
    /// </summary>
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);

        public List<string> GetMenuPermission(SysUser user);
    }
}