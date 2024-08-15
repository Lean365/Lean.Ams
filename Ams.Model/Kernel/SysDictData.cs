namespace Ams.Model.Kernel
{
    /// <summary>
    /// 字典数据表
    /// </summary>
    [Tenant("0")]
    [SugarTable("sys_dict_data", "字典数据")]
    public class SysDictData : SysBase
    {
        /// <summary>
        /// 字典ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long DictCode { get; set; }

        /// <summary>
        /// 字典排序
        /// </summary>
        public int SortingNum { get; set; }

        /// <summary>
        /// 字典标签
        /// </summary>
        [SugarColumn(Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string DictLabel { get; set; }

        /// <summary>
        /// 字典键值
        /// </summary>
        [SugarColumn(Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string DictValue { get; set; }

        /// <summary>
        /// 字典类别
        /// </summary>
        [SugarColumn(Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string DictType { get; set; }

        /// <summary>
        /// 样式属性（其他样式扩展）
        /// </summary>
        [SugarColumn(Length = 100)]
        public string CssClass { get; set; } = string.Empty;

        /// <summary>
        /// 表格回显样式
        /// </summary>
        [SugarColumn(Length = 100)]
        public string ListClass { get; set; } = string.Empty;

        /// <summary>
        /// 是否默认（Y是 N否）
        /// </summary>
        [SugarColumn(Length = 1, DefaultValue = "N")]
        public string IsDefault { get; set; }

        /// <summary>
        /// 状态（0正常 1停用）
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }

        /// <summary>
        /// 多语言翻译key值
        /// </summary>
        public string LangKey { get; set; } = string.Empty;

        /// <summary>
        /// 扩展标签
        /// </summary>
        [SugarColumn(Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string ExtLabel { get; set; }

        /// <summary>
        /// 扩展键值
        /// </summary>
        [SugarColumn(Length = 200, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string ExtValue { get; set; }
    }
}