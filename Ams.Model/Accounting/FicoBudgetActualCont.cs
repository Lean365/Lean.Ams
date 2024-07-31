namespace Ams.Model.Accounting
{
    /// <summary>
    /// 预算实际明细
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 17:40:38
    /// </summary>
    [SugarTable("fico_budget_actual_cont", "预算实际明细")]
    public class FicoBudgetActualCont : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbSfId { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "FbFy", ColumnDescription = "期间 ", Length = 6)]
        public string FbFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbYm", ColumnDescription = "年月 ", Length = 6)]
        public string FbYm { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "FbCorpCode", ColumnDescription = "公司代码 ", Length = 4)]
        public string FbCorpCode { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        [SugarColumn(ColumnName = "FbCorpName", ColumnDescription = "公司名称 ", Length = 40)]
        public string FbCorpName { get; set; }

        /// <summary>
        /// 统计类别
        /// </summary>
        [SugarColumn(ColumnName = "FbExpCategory", ColumnDescription = "统计类别 ", Length = 10)]
        public string FbExpCategory { get; set; }

        /// <summary>
        /// 成本代码
        /// </summary>
        [SugarColumn(ColumnName = "FbCostCode", ColumnDescription = "成本代码 ", Length = 10)]
        public string FbCostCode { get; set; }

        /// <summary>
        /// 成本名称
        /// </summary>
        [SugarColumn(ColumnName = "FbCostName", ColumnDescription = "成本名称 ", Length = 20)]
        public string FbCostName { get; set; }

        /// <summary>
        /// 科目代码
        /// </summary>
        [SugarColumn(ColumnName = "FbTitleCode", ColumnDescription = "科目代码 ", Length = 10)]
        public string FbTitleCode { get; set; }

        /// <summary>
        /// 科目名称
        /// </summary>
        [SugarColumn(ColumnName = "FbTitleName", ColumnDescription = "科目名称 ", Length = 40)]
        public string FbTitleName { get; set; }

        /// <summary>
        /// 科目分类
        /// </summary>
        [SugarColumn(ColumnName = "FbTitleNote", ColumnDescription = "科目分类 ", Length = 40)]
        public string FbTitleNote { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "FbBudgetAmt", ColumnDescription = "预算 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbBudgetAmt { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "FbActualAmt", ColumnDescription = "实际 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbActualAmt { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "FbDiffAmt", ColumnDescription = "差异 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbDiffAmt { get; set; }

        /// <summary>
        /// 会计人员
        /// </summary>
        [SugarColumn(ColumnName = "FbAccountant", ColumnDescription = "会计人员 ", Length = 10)]
        public string FbAccountant { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? FbBalanceDate { get; set; }
    }
}