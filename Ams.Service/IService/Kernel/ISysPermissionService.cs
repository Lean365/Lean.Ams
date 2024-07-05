namespace Ams.Service.IService.Kernel
{
    /// <summary>
    /// 权限
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);

        public List<string> GetMenuPermission(SysUser user);
    }
}