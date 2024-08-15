namespace Ams.Model.Accounting
{
    /// <summary>
    /// 资产预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:23:49
    /// </summary>
    [SugarTable("fico_budget_assets_slv", "资产预算")]
    public class FicoBudgetAssetsSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbasSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long? FbasParentSfId { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbasYm", ColumnDescription = "年月", Length = 4)]
        public string FbasYm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "FbasTitle", ColumnDescription = "科目", Length = 40)]
        public string FbasTitle { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "FbasClass", ColumnDescription = "类别", Length = 100)]
        public string FbasClass { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbasName", ColumnDescription = "名称", Length = 100)]
        public string FbasName { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "FbasDesc", ColumnDescription = "说明", Length = 250)]
        public string FbasDesc { get; set; }

        /// <summary>
        /// 年限
        /// </summary>
        [SugarColumn(ColumnName = "FbasServiceLife", ColumnDescription = "年限", DefaultValue = "0")]
        public int? FbasServiceLife { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "FbasBudgetAmount", ColumnDescription = "预算", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbasBudgetAmount { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "FbasActualAmount", ColumnDescription = "实际", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbasActualAmount { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "FbasDifferenceAmount", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbasDifferenceAmount { get; set; }

        /// <summary>
        /// 折旧
        /// </summary>
        [SugarColumn(ColumnName = "FbasDepreciation", ColumnDescription = "折旧", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbasDepreciation { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(ColumnName = "FbasFlag", ColumnDescription = "启用", DefaultValue = "0")]
        public int? FbasFlag { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        [SugarColumn(ColumnName = "FbasAudit", ColumnDescription = "审核标志", DefaultValue = "0")]
        public int? FbasAudit { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "FbasAuditName", ColumnDescription = "审核人员", Length = 20)]
        public string FbasAuditName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? FbasAuditDate { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "FbasUndoName", ColumnDescription = "撤消人员", Length = 20)]
        public string FbasUndoName { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? FbasUndoDate { get; set; }
    }
}