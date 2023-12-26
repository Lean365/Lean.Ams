using Ams.Kernel.Model.System;

namespace Ams.Kernel.Services.IService.System
{
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);
        public List<string> GetMenuPermission(SysUser user);
    }
}
