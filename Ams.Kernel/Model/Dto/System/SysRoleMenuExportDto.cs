using Ams.Model.System.Enums;
using MiniExcelLibs.Attributes;

namespace Ams.Model.System.Dto
{
    public class SysRoleMenuExportDto
    {
        /// <summary>
        /// 一级目录名
        /// </summary>
        [ExcelColumn(Name = "菜单信息", Width = 50)]
        public string MenuName { get; set; }

        //[ExcelColumn(Name = "菜单信息名", Width = 20)]
        //public string MenuName1 { get; set; }
        //[ExcelColumn(Name = "权限按钮", Width = 20)]
        //public string MenuName2 { get; set; }
        [ExcelColumn(Name = "路径", Width = 20)]
        public string Path { get; set; }

        [ExcelColumn(Name = "组件名", Width = 20)]
        public string Component { get; set; }

        [ExcelColumn(Name = "权限字符", Width = 20)]
        public string Perms { get; set; }

        [ExcelColumn(Name = "菜单信息类型")]
        public MenuType MenuType { get; set; }

        [ExcelColumn(Name = "菜单信息状态")]
        public MenuStatus Status { get; set; }
    }
}