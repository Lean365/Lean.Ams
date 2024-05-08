using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.System
{
    /// <summary>
    /// 用户角色管理
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("system/user/role")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysUserRoleController : BaseController
    {
        private readonly ISysUserRoleService _SysUserRoleService;
        private readonly ISysUserService _SysUserService;

        public SysUserRoleController(
            ISysUserRoleService sysUserRoleService,
            ISysUserService userService)
        {
            _SysUserRoleService = sysUserRoleService;
            _SysUserService = userService;
        }

        /// <summary>
        /// 根据角色编号获取已分配的用户
        /// </summary>
        /// <param name="SysRoleUserQueryDto"></param>
        /// <returns></returns>
        [HttpGet("list")]
        [ActionPermissionFilter(Permission = "system:roleusers:list")]
        public IActionResult GetList([FromQuery] SysRoleUserQueryDto SysRoleUserQueryDto)
        {
            var list = _SysUserRoleService.GetSysUsersByRoleId(SysRoleUserQueryDto);

            return SUCCESS(list, TIME_FORMAT_FULL);
        }

        /// <summary>
        /// 添加角色用户
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        [ActionPermissionFilter(Permission = "system:roleusers:add")]
        [Log(Title = "添加角色用户", BusinessType = BusinessType.INSERT)]
        public IActionResult Create([FromBody] SysRoleUsersCreateDto SysRoleUsersCreateDto)
        {
            var response = _SysUserRoleService.InsertRoleUser(SysRoleUsersCreateDto);

            return SUCCESS(response);
        }

        /// <summary>
        /// 删除角色用户
        /// </summary>
        /// <param name="SysRoleUsersCreateDto"></param>
        /// <returns></returns>
        [HttpPost("delete")]
        [ActionPermissionFilter(Permission = "system:roleusers:delete")]
        [Log(Title = "删除角色用户", BusinessType = BusinessType.DELETE)]
        public IActionResult Delete([FromBody] SysRoleUsersCreateDto SysRoleUsersCreateDto)
        {
            return SUCCESS(_SysUserRoleService.DeleteRoleUserByUserIds(SysRoleUsersCreateDto.RoleId, SysRoleUsersCreateDto.UserIds));
        }

        /// <summary>
        /// 获取未分配用户角色
        /// </summary>
        /// <param name="SysRoleUserQueryDto"></param>
        /// <returns></returns>
        [HttpGet("GetExcludeUsers")]
        public IActionResult GetExcludeUsers([FromQuery] SysRoleUserQueryDto SysRoleUserQueryDto)
        {
            if (SysRoleUserQueryDto.RoleId <= 0)
            {
                throw new CustomException(ResultCode.PARAM_ERROR, "roleId不能为空");
            }

            // 获取未添加用户
            var list = _SysUserRoleService.GetExcludedSysUsersByRoleId(SysRoleUserQueryDto);

            return SUCCESS(list, TIME_FORMAT_FULL);
        }
    }
}