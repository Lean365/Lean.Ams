namespace Ams.Model.Dto.Kernel
{
    /// <summary>
    /// 角色菜单导出
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class SysRoleMenuExportDto
    {
        /// <summary>
        /// 一级目录名
        /// </summary>
        [ExcelColumn(Name = "菜单", Width = 50)]
        public string MenuName { get; set; }

        //[ExcelColumn(Name = "菜单名", Width = 20)]
        //public string MenuName1 { get; set; }
        //[ExcelColumn(Name = "权限按钮", Width = 20)]
        //public string MenuName2 { get; set; }
        [ExcelColumn(Name = "路径", Width = 20)]
        public string Path { get; set; }

        [ExcelColumn(Name = "组件名", Width = 20)]
        public string Component { get; set; }

        [ExcelColumn(Name = "权限字符", Width = 20)]
        public string Perms { get; set; }

        [ExcelColumn(Name = "菜单类型")]
        public MenuType MenuType { get; set; }

        [ExcelColumn(Name = "菜单状态")]
        public MenuStatus Status { get; set; }
    }
}