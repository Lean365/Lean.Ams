namespace Ams.Model.Accounting
{
    /// <summary>
    /// 费用预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:03
    /// </summary>
    [SugarTable("fico_budget_expense", "费用预算")]
    public class FicoBudgetExpense : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbeSFID { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FbeCorp", ColumnDescription = "公司 ", Length = 4)]
        public string FbeCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "FbeDept", ColumnDescription = "部门 ", Length = 20)]
        public string FbeDept { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FbeFy", ColumnDescription = "财年 ", Length = 6)]
        public string FbeFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbeFm", ColumnDescription = "年月 ", Length = 100)]
        public string FbeFm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "FbeTitle", ColumnDescription = "科目 ", Length = 40)]
        public string FbeTitle { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbeClass", ColumnDescription = "名称 ", Length = 100)]
        public string FbeClass { get; set; }

        /// <summary>
        /// 明细科目
        /// </summary>
        [SugarColumn(ColumnName = "FbeTitlesub", ColumnDescription = "明细科目 ", Length = 40)]
        public string FbeTitlesub { get; set; }

        /// <summary>
        /// 明细名称
        /// </summary>
        [SugarColumn(ColumnName = "FbeClasssub", ColumnDescription = "明细名称 ", Length = 100)]
        public string FbeClasssub { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "FbeClassmemo", ColumnDescription = "说明 ", Length = 255)]
        public string FbeClassmemo { get; set; }

        /// <summary>
        /// 预算金额
        /// </summary>
        [SugarColumn(ColumnName = "FbeBudgetAmount", ColumnDescription = "预算金额 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbeBudgetAmount { get; set; }

        /// <summary>
        /// 实际发生
        /// </summary>
        [SugarColumn(ColumnName = "FbeActualAmount", ColumnDescription = "实际发生 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbeActualAmount { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "FbeDifferenceAmount", ColumnDescription = "差异 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbeDifferenceAmount { get; set; }

        /// <summary>
        /// 启用标记
        /// </summary>
        [SugarColumn(ColumnName = "FbsFlag", ColumnDescription = "启用标记 ", DefaultValue = "0")]
        public int FbsFlag { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "FbsAudit", ColumnDescription = "审核 ", DefaultValue = "0")]
        public int FbsAudit { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "FbsAuditName", ColumnDescription = "审核人员 ", Length = 20)]
        public string FbsAuditName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? FbsAuditDate { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "FbsUndoName", ColumnDescription = "撤消人员 ", Length = 20)]
        public string FbsUndoName { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? FbsUndoDate { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        [SugarColumn(ColumnName = "UDF01", ColumnDescription = "自定义A ", Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        [SugarColumn(ColumnName = "UDF02", ColumnDescription = "自定义B ", Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        [SugarColumn(ColumnName = "UDF03", ColumnDescription = "自定义C ", Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        [SugarColumn(ColumnName = "UDF04", ColumnDescription = "自定义D ", Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        [SugarColumn(ColumnName = "UDF05", ColumnDescription = "自定义E ", Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        [SugarColumn(ColumnName = "UDF06", ColumnDescription = "自定义F ", Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(ColumnName = "UDF51", ColumnDescription = "自定义1 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(ColumnName = "UDF52", ColumnDescription = "自定义2 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(ColumnName = "UDF53", ColumnDescription = "自定义3 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(ColumnName = "UDF54", ColumnDescription = "自定义4 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(ColumnName = "UDF55", ColumnDescription = "自定义5 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(ColumnName = "UDF56", ColumnDescription = "自定义6 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnName = "IsDeleted", ColumnDescription = "软删除 ", DefaultValue = "0")]
        public int IsDeleted { get; set; }
    }
}