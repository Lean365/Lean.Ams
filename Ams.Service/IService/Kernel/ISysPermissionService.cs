using Ams.Model.Kernel;

namespace Ams.Service.IService.Kernel
{
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);

        public List<string> GetMenuPermission(SysUser user);
    }
}