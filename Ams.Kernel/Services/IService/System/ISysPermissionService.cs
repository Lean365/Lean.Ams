using Ams.Kernel.Model.System;

namespace Ams.Kernel.Services.IService.System
{
    /// <summary>
    /// 用色权限
    /// 业务层接口
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// <summary>
    public interface ISysPermissionService
    {
        public List<string> GetRolePermission(SysUser user);

        public List<string> GetMenuPermission(SysUser user);
    }
}