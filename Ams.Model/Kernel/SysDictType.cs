namespace Ams.Model.Kernel
{
    /// <summary>
    /// 字典类别表
    /// </summary>
    [SugarTable("sys_dict_type", "字典类别")]
    [SugarIndex("index_dict_type", nameof(DictType), OrderByType.Asc, true)]
    [Tenant("0")]
    public class SysDictType : SysBase
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long DictId { get; set; }

        /// <summary>
        /// 分类 0、系统 1、数据库
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int DictCategory { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        [SugarColumn(Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string DictName { get; set; }

        /// <summary>
        /// 字典类别
        /// </summary>
        [SugarColumn(Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string DictType { get; set; }

        /// <summary>
        /// 状态 0、正常 1、停用
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }

        /// <summary>
        /// 系统内置 Y是 N否
        /// </summary>
        [SugarColumn(Length = 1, DefaultValue = "N")]
        public string Type { get; set; }

        /// <summary>
        /// 自定义sql
        /// </summary>
        [SugarColumn(ColumnDescription = "自定义sql", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string CustomSql { get; set; }
    }
}