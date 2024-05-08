using Ams.Model.System;
using Microsoft.AspNetCore.Mvc;

namespace Ams.WebApi.Controllers.System
{
    /// <summary>
    /// 系统菜单
    /// API控制器
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [Verify]
    [Route("/system/menu")]
    [ApiExplorerSettings(GroupName = "system")]
    public class SysMenuController : BaseController
    {
        private readonly ISysRoleService _SysRoleService;
        private readonly ISysMenuService _SysMenuService;
        private readonly ISysRoleMenuService _SysRoleMenuService;

        public SysMenuController(
            ISysRoleService SysRoleService,
            ISysMenuService SysMenuService,
            ISysRoleMenuService SysRoleMenuService)
        {
            this._SysRoleService = SysRoleService;
            this._SysMenuService = SysMenuService;
            this._SysRoleMenuService = SysRoleMenuService;
        }

        /// <summary>
        /// 获取菜单树列表
        /// </summary>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:menu:list")]
        [HttpGet("treelist")]
        public IActionResult TreeMenuList([FromQuery] SysMenuQueryDto menu)
        {
            long userId = HttpContext.GetUId();
            return SUCCESS(_SysMenuService.SelectTreeMenuList(menu, userId), "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:menu:list")]
        [HttpGet("list")]
        public IActionResult MenuList([FromQuery] SysMenuQueryDto menu)
        {
            long userId = HttpContext.GetUId();
            return SUCCESS(_SysMenuService.SelectMenuList(menu, userId), "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 根据菜单编号获取详细信息
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpGet("{menuId}")]
        [ActionPermissionFilter(Permission = "system:menu:query")]
        public IActionResult GetMenuInfo(int menuId = 0)
        {
            return SUCCESS(_SysMenuService.GetMenuByMenuId(menuId), "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 根据菜单编号获取菜单列表，菜单管理首次进入
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpGet("list/{menuId}")]
        [ActionPermissionFilter(Permission = "system:menu:query")]
        public IActionResult GetMenuList(int menuId = 0)
        {
            long userId = HttpContext.GetUId();
            return SUCCESS(_SysMenuService.GetMenusByMenuId(menuId, userId), "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取角色菜单信息
        /// 加载对应角色菜单列表树
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("roleMenuTreeselect/{roleId}")]
        public IActionResult RoleMenuTreeselect(int roleId)
        {
            long userId = HttpContext.GetUId();
            var menus = _SysMenuService.SelectMenuList(new SysMenuQueryDto(), userId);
            var checkedKeys = _SysRoleService.SelectUserRoleMenus(roleId);
            return SUCCESS(new
            {
                checkedKeys,
                menus = _SysMenuService.BuildMenuTreeSelect(menus),
            });
        }

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="SysMenuDto"></param>
        /// <returns></returns>
        [HttpPost("edit")]
        [Log(Title = "菜单管理", BusinessType = BusinessType.UPDATE)]
        [ActionPermissionFilter(Permission = "system:menu:update")]
        public IActionResult MenuEdit([FromBody] SysMenuDto SysMenuDto)
        {
            if (SysMenuDto == null) { return ToResponse(ApiResult.Error(101, "请求参数错误")); }
            //if (UserConstants.NOT_UNIQUE.Equals(sysMenuService.CheckMenuNameUnique(SysMenuDto)))
            //{
            //    return ToResponse(ApiResult.Error($"修改菜单'{SysMenuDto.menuName}'失败，菜单名称已存在"));
            //}
            var config = new TypeAdapterConfig();
            //映射规则
            config.ForType<SysMenu, SysMenuDto>()
                .NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);//忽略字段名称的大小写;//忽略除以上配置的所有字段

            var modal = SysMenuDto.Adapt<SysMenu>(config).ToUpdate(HttpContext);
            if (UserConstants.YES_FRAME.Equals(modal.IsFrame) && (!modal.Path.StartsWith("http") && !modal.Path.StartsWith("/link")))
            {
                return ToResponse(ApiResult.Error($"修改菜单'{modal.MenuName}'失败，地址必须以http(s)://开头"));
            }
            if (modal.MenuId.Equals(modal.ParentId))
            {
                return ToResponse(ApiResult.Error($"修改菜单'{modal.MenuName}'失败，上级菜单不能选择自己"));
            }
            modal.Update_by = HttpContext.GetName();
            long result = _SysMenuService.EditMenu(modal);

            return ToResponse(result);
        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="SysMenuDto"></param>
        /// <returns></returns>
        [HttpPut("add")]
        [Log(Title = "菜单管理", BusinessType = BusinessType.INSERT)]
        [ActionPermissionFilter(Permission = "system:menu:add")]
        public IActionResult MenuAdd([FromBody] SysMenuDto SysMenuDto)
        {
            var config = new TypeAdapterConfig();
            //映射规则
            config.ForType<SysMenu, SysMenuDto>()
                .NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
            var menu = SysMenuDto.Adapt<SysMenu>(config).ToCreate(HttpContext);

            if (menu == null) { return ToResponse(ApiResult.Error(101, "请求参数错误")); }
            if (UserConstants.NOT_UNIQUE.Equals(_SysMenuService.CheckMenuNameUnique(menu)))
            {
                return ToResponse(ApiResult.Error($"新增菜单'{menu.MenuName}'失败，菜单名称已存在"));
            }
            if (UserConstants.YES_FRAME.Equals(menu.IsFrame) && !menu.Path.StartsWith("http"))
            {
                return ToResponse(ApiResult.Error($"新增菜单'{menu.MenuName}'失败，地址必须以http(s)://开头"));
            }

            menu.Create_by = HttpContext.GetName();
            long result = _SysMenuService.AddMenu(menu);

            return ToResponse(result);
        }

        /// <summary>
        /// 菜单删除
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpDelete("{menuId}")]
        [Log(Title = "菜单管理", BusinessType = BusinessType.DELETE)]
        [ActionPermissionFilter(Permission = "system:menu:delete")]
        public IActionResult Remove(int menuId = 0)
        {
            if (_SysMenuService.HasChildByMenuId(menuId))
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "存在子菜单,不允许删除");
            }
            if (_SysRoleMenuService.CheckMenuExistRole(menuId))
            {
                return ToResponse(ResultCode.CUSTOM_ERROR, "菜单已分配,不允许删除");
            }
            int result = _SysMenuService.DeleteMenuById(menuId);

            return ToResponse(result);
        }

        /// <summary>
        /// 菜单删除
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        [HttpDelete("deleteAll/{menuId}")]
        [Log(Title = "菜单管理", BusinessType = BusinessType.DELETE)]
        [ActionPermissionFilter(Permission = "system:menu:delete")]
        public IActionResult RemoveAll(int menuId = 0)
        {
            int result = _SysMenuService.DeleteAllMenuById(menuId);

            return ToResponse(result);
        }

        /// <summary>
        /// 保存排序
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [ActionPermissionFilter(Permission = "system:menu:update")]
        [HttpGet("ChangeSort")]
        [Log(Title = "保存排序", BusinessType = BusinessType.UPDATE)]
        public IActionResult ChangeSort(int id = 0, int value = 0)
        {
            SysMenuDto SysMenuDto = new()
            {
                MenuId = id,
                OrderNum = value
            };
            if (SysMenuDto == null) { return ToResponse(ApiResult.Error(101, "请求参数错误")); }

            int result = _SysMenuService.ChangeSortMenu(SysMenuDto);
            return ToResponse(result);
        }
    }
}