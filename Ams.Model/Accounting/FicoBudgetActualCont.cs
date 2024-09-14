namespace Ams.Model.Accounting
{
    /// <summary>
    /// 实际对比
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 14:38:54
    /// </summary>
    [SugarTable("fico_budget_actual_cont", "实际对比")]
    public class FicoBudgetActualCont : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Me002", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Me002 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Me003", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Me003 { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Me004", ColumnDescription = "公司代码", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Me004 { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        [SugarColumn(ColumnName = "Me005", ColumnDescription = "统计类别", Length = 4)]
        public string Me005 { get; set; }

        /// <summary>
        /// 成本科目
        /// </summary>
        [SugarColumn(ColumnName = "Me006", ColumnDescription = "成本科目", Length = 10)]
        public string Me006 { get; set; }

        /// <summary>
        /// 成本分类
        /// </summary>
        [SugarColumn(ColumnName = "Me007", ColumnDescription = "成本分类", Length = 1)]
        public string Me007 { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "Me008", ColumnDescription = "科目代码", Length = 10)]
        public string Me008 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Me009", ColumnDescription = "币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Me009 { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "Me010", ColumnDescription = "预算", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me010 { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "Me011", ColumnDescription = "实际", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me011 { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "Me012", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Me012 { get; set; }

        /// <summary>
        /// 核算人员
        /// </summary>
        [SugarColumn(ColumnName = "Me013", ColumnDescription = "核算人员", Length = 10)]
        public string Me013 { get; set; }

        /// <summary>
        /// 核算日期
        /// </summary>
        public DateTime? Me014 { get; set; }
    }
}