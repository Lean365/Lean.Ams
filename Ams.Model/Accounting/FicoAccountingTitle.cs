namespace Ams.Model.Accounting
{
    /// <summary>
    /// 会计科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:53:13
    /// </summary>
    [SugarTable("fico_accounting_title", "会计科目")]
    public class FicoAccountingTitle : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Mb002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb002 { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Mb003", ColumnDescription = "公司代码", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb003 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Mb004", ColumnDescription = "币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb004 { get; set; }

        /// <summary>
        /// 语言Key
        /// </summary>
        [SugarColumn(ColumnName = "Mb005", ColumnDescription = "语言Key", Length = 100)]
        public string Mb005 { get; set; }

        /// <summary>
        /// 科目编号
        /// </summary>
        [SugarColumn(ColumnName = "Mb006", ColumnDescription = "科目编号", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mb006 { get; set; }

        /// <summary>
        /// 科目表
        /// </summary>
        [SugarColumn(ColumnName = "Mb007", ColumnDescription = "科目表", Length = 8)]
        public string Mb007 { get; set; }

        /// <summary>
        /// BS类别
        /// </summary>
        [SugarColumn(ColumnName = "Mb008", ColumnDescription = "BS类别", Length = 1)]
        public string Mb008 { get; set; }

        /// <summary>
        /// PL类别
        /// </summary>
        [SugarColumn(ColumnName = "Mb009", ColumnDescription = "PL类别", Length = 1)]
        public string Mb009 { get; set; }

        /// <summary>
        /// 统驭类别
        /// </summary>
        [SugarColumn(ColumnName = "Mb010", ColumnDescription = "统驭类别", Length = 2)]
        public string Mb010 { get; set; }

        /// <summary>
        /// 短文本
        /// </summary>
        [SugarColumn(ColumnName = "Mb011", ColumnDescription = "短文本", Length = 40, ColumnDataType = "NVARCHAR")]
        public string Mb011 { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Mb012", ColumnDescription = "长文本", Length = 80, ColumnDataType = "NVARCHAR")]
        public string Mb012 { get; set; }

        /// <summary>
        /// 附加文本
        /// </summary>
        [SugarColumn(ColumnName = "Mb013", ColumnDescription = "附加文本", Length = 120, ColumnDataType = "NVARCHAR")]
        public string Mb013 { get; set; }

        /// <summary>
        /// 科目组
        /// </summary>
        [SugarColumn(ColumnName = "Mb014", ColumnDescription = "科目组", Length = 8)]
        public string Mb014 { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>
        [SugarColumn(ColumnName = "Mb015", ColumnDescription = "冻结", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mb015 { get; set; }
    }
}