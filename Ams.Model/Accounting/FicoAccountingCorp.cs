namespace Ams.Model.Accounting
{
    /// <summary>
    /// 公司科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 16:35:01
    /// </summary>
    [SugarTable("fico_accounting_corp", "公司科目")]
    public class FicoAccountingCorp : SysBase
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
        [SugarColumn(ColumnName = "Ma002", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma002 { get; set; }

        /// <summary>
        /// 帐目表
        /// </summary>
        [SugarColumn(ColumnName = "Ma003", ColumnDescription = "帐目表", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma003 { get; set; }

        /// <summary>
        /// 总帐科目
        /// </summary>
        [SugarColumn(ColumnName = "Ma004", ColumnDescription = "总帐科目", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma004 { get; set; }

        /// <summary>
        /// 负债科目
        /// </summary>
        [SugarColumn(ColumnName = "Ma005", ColumnDescription = "负债科目", Length = 2)]
        public string Ma005 { get; set; }

        /// <summary>
        /// 总帐科目
        /// </summary>
        [SugarColumn(ColumnName = "Ma006", ColumnDescription = "总帐科目", Length = 40)]
        public string Ma006 { get; set; }

        /// <summary>
        /// 组科目号
        /// </summary>
        [SugarColumn(ColumnName = "Ma007", ColumnDescription = "组科目号", Length = 20)]
        public string Ma007 { get; set; }

        /// <summary>
        /// 损益科目
        /// </summary>
        [SugarColumn(ColumnName = "Ma008", ColumnDescription = "损益科目", Length = 4)]
        public string Ma008 { get; set; }

        /// <summary>
        /// 总帐科目组
        /// </summary>
        [SugarColumn(ColumnName = "Ma009", ColumnDescription = "总帐科目组", Length = 8)]
        public string Ma009 { get; set; }

        /// <summary>
        /// 样本科目
        /// </summary>
        [SugarColumn(ColumnName = "Ma010", ColumnDescription = "样本科目", Length = 20)]
        public string Ma010 { get; set; }

        /// <summary>
        /// 贸易伙伴
        /// </summary>
        [SugarColumn(ColumnName = "Ma011", ColumnDescription = "贸易伙伴", Length = 12)]
        public string Ma011 { get; set; }

        /// <summary>
        /// 搜索条件
        /// </summary>
        [SugarColumn(ColumnName = "Ma012", ColumnDescription = "搜索条件", Length = 50)]
        public string Ma012 { get; set; }

        /// <summary>
        /// 功能范围
        /// </summary>
        [SugarColumn(ColumnName = "Ma013", ColumnDescription = "功能范围", Length = 32)]
        public string Ma013 { get; set; }

        /// <summary>
        /// 短文本
        /// </summary>
        [SugarColumn(ColumnName = "Ma014", ColumnDescription = "短文本", Length = 40, ColumnDataType = "NVARCHAR", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Ma014 { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Ma015", ColumnDescription = "长文本", Length = 80, ColumnDataType = "NVARCHAR")]
        public string Ma015 { get; set; }

        /// <summary>
        /// 附加文本
        /// </summary>
        [SugarColumn(ColumnName = "Ma016", ColumnDescription = "附加文本", Length = -1, ColumnDataType = "NVARCHAR")]
        public string Ma016 { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>
        [SugarColumn(ColumnName = "Ma017", ColumnDescription = "冻结", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma017 { get; set; }

        /// <summary>
        /// 冻结过账
        /// </summary>
        [SugarColumn(ColumnName = "Ma018", ColumnDescription = "冻结过账", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma018 { get; set; }

        /// <summary>
        /// 冻结计划
        /// </summary>
        [SugarColumn(ColumnName = "Ma019", ColumnDescription = "冻结计划", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Ma019 { get; set; }
    }
}