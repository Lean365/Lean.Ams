namespace Ams.Model.Accounting
{
    /// <summary>
    /// 费用预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:29
    /// </summary>
    [SugarTable("fico_budget_expense_slv", "费用预算")]
    public class FicoBudgetExpenseSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbesSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long? FbesParentSfId { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbesYm", ColumnDescription = "年月", Length = 4)]
        public string FbesYm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "FbesTitle", ColumnDescription = "科目", Length = 40)]
        public string FbesTitle { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbesClass", ColumnDescription = "名称", Length = 100)]
        public string FbesClass { get; set; }

        /// <summary>
        /// 明细科目
        /// </summary>
        [SugarColumn(ColumnName = "FbesTitlesub", ColumnDescription = "明细科目", Length = 40)]
        public string FbesTitlesub { get; set; }

        /// <summary>
        /// 明细名称
        /// </summary>
        [SugarColumn(ColumnName = "FbesClasssub", ColumnDescription = "明细名称", Length = 100)]
        public string FbesClasssub { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "FbesClassmemo", ColumnDescription = "说明", Length = 255)]
        public string FbesClassmemo { get; set; }

        /// <summary>
        /// 预算金额
        /// </summary>
        [SugarColumn(ColumnName = "FbesBudgetAmount", ColumnDescription = "预算金额", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbesBudgetAmount { get; set; }

        /// <summary>
        /// 实际发生
        /// </summary>
        [SugarColumn(ColumnName = "FbesActualAmount", ColumnDescription = "实际发生", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbesActualAmount { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "FbesDifferenceAmount", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbesDifferenceAmount { get; set; }

        /// <summary>
        /// 启用标记
        /// </summary>
        [SugarColumn(ColumnName = "FbssFlag", ColumnDescription = "启用标记", DefaultValue = "0")]
        public int? FbssFlag { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "FbssAudit", ColumnDescription = "审核", DefaultValue = "0")]
        public int? FbssAudit { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "FbssAuditName", ColumnDescription = "审核人员", Length = 20)]
        public string FbssAuditName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? FbssAuditDate { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "FbssUndoName", ColumnDescription = "撤消人员", Length = 20)]
        public string FbssUndoName { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? FbssUndoDate { get; set; }
    }
}