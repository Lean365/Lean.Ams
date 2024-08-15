namespace Ams.Service.Kernel.IKernelService
{
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);

        public List<string> GetMenuPermission(SysUser user);
    }
}