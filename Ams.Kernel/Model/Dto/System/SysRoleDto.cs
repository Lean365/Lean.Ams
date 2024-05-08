namespace Ams.Kernel.Model.Dto.System
{
    /// <summary>
    /// 角色信息
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class SysRoleDto : SysBase
    {
        public long RoleId { get; set; }

        /// <summary>
        /// 要添加的菜单集合
        /// </summary>
        public List<long> MenuIds { get; set; } = new List<long>();

        public string RoleName { get; set; }
        public string RoleKey { get; set; }
        public int RoleSort { get; set; }
        public int IsStated { get; set; }
        public int DataScope { get; set; }
        public int[] DeptIds { get; set; }

        /// <summary>
        /// 减少菜单集合
        /// </summary>
        public List<long> DelMenuIds { get; set; } = new List<long>();

        public bool MenuCheckStrictly { get; set; }
        public bool DeptCheckStrictly { get; set; }
    }
}