namespace Ams.Model.Admin.Dto
{
    public class SysMenuDto : SysBase
    {
        //{"parentId":0,"menuName":"aaa","icon":"documentation","menuType":"M","orderNum":999,"visible":0,"status":0,"path":"aaa"}
        [Required(ErrorMessage = "菜单id不能为空")]
        [ExcelColumn(Name = "菜单id")]
        public int MenuId { get; set; }

        [ExcelColumn(Name = "菜单名")]
        public string MenuName { get; set; }

        /// <summary>
        /// 父菜单ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int SortingNum { get; set; }

        /// <summary>
        /// 路由地址
        /// </summary>
        [ExcelColumn(Name = "路由地址")]
        public string Path { get; set; } = "#";

        /// <summary>
        /// 组件路径
        /// </summary>
        [ExcelColumn(Name = "组件地址")]
        public string Component { get; set; }

        /// <summary>
        /// 是否缓存（1缓存 0不缓存）
        /// </summary>
        [Required(ErrorMessage = "是否缓存不能为空")]
        [ExcelColumn(Name = "是否缓存")]
        public int IsCache { get; set; }

        /// <summary>
        /// 是否外链 1、是 0、否
        /// </summary>
        public int IsFrame { get; set; }

        /// <summary>
        /// 类型（M目录 C菜单 F按钮 L链接）
        /// </summary>
        [Required(ErrorMessage = "菜单类型不能为空")]
        public string MenuType { get; set; }

        /// <summary>
        /// 显示状态（0显示 1隐藏）
        /// </summary>
        [Required(ErrorMessage = "显示状态不能为空")]
        public string Visible { get; set; }

        /// <summary>
        /// 菜单状态（0正常 1停用）
        /// </summary>
        [Required(ErrorMessage = "菜单状态不能为空")]
        public int IsStatus { get; set; }

        /// <summary>
        /// 权限字符串
        /// </summary>
        [ExcelColumn(Name = "权限字符串")]
        public string Perms { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 翻译key
        /// </summary>
        //[RegularExpression(pattern: "^[a-z][a-z]*(\\.[a-zA-Z0-9]+)*$", ErrorMessage = "翻译键值以小写字母开头、不包含数字、中间为点、后面由字母或数字组成")]
        public string MenuNameKey { get; set; }

        public List<SysMenuDto> Children { get; set; } = new List<SysMenuDto>();
    }

    public class MenuQueryDto : SysBase
    {
        public string MenuName { get; set; }
        public string Visible { get; set; }
        public int IsStatus { get; set; }
        public string MenuTypeIds { get; set; } = string.Empty;
        public int? ParentId { get; set; }

        public string[] MenuTypeIdArr
        {
            get
            {
                return MenuTypeIds?.Split(',', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}