using System;
using System.Collections.Generic;

namespace Ams.Model.System.Dto
{
    public class SysRoleSysMenuDto
    {
        public long RoleId { get; set; }
        /// <summary>
        /// 角色信息分配菜单信息
        /// </summary>
        public List<long> MenuIds { get; set; } = new List<long>();
        public string RoleName { get; set; }
        public string RoleKey { get; set; }
        public string Create_by { get; set; }
        public DateTime Create_time{ get; set; }
    }
}
