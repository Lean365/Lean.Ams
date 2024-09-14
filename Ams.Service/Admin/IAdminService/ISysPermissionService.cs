using Ams.Model.Admin;

namespace Ams.Service.Admin.IAdminService
{
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);
        public List<string> GetMenuPermission(SysUser user);
    }
}
