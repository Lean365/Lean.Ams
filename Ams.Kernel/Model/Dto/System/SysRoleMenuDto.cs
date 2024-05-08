namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 角色分配菜单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysRoleMenuDto
    {
        public long RoleId { get; set; }

        /// <summary>
        /// 角色分配菜单
        /// </summary>
        public List<long> MenuIds { get; set; } = new List<long>();

        public string RoleName { get; set; }
        public string RoleKey { get; set; }
        public string Create_by { get; set; }
        public DateTime Create_time { get; set; }
    }
}