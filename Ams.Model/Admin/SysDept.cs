namespace Ams.Model.Admin
{
    /// <summary>
    /// 系统部门
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("sys_dept", "系统部门")]
    [Tenant("0")]
    public class SysDept : SysBase
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long DeptId { get; set; }

        /// <summary>
        /// 父部门ID
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 祖级列表
        /// </summary>
        public string Ancestors { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        [SugarColumn(Length = 30, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string DeptName { get; set; }

        /// <summary>
        /// 显示顺序
        /// </summary>
        public int SortingNum { get; set; }

        /// <summary>
        /// 负责人
        /// </summary>
        [SugarColumn(Length = 30)]
        public string Leader { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        [SugarColumn(Length = 11)]
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [SugarColumn(Length = 50)]
        public string Email { get; set; }

        /// <summary>
        /// 部门状态:0正常,1停用
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; } = 0;

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<SysDept> children = new();
    }
}