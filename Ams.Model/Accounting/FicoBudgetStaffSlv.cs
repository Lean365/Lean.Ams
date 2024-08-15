namespace Ams.Model.Accounting
{
    /// <summary>
    /// 人员预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 13:28:59
    /// </summary>
    [SugarTable("fico_budget_staff_slv", "人员预算")]
    public class FicoBudgetStaffSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbssSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long? FbssParentSfId { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbssYm", ColumnDescription = "年月", Length = 4)]
        public string FbssYm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "FbssTitle", ColumnDescription = "科目", Length = 40)]
        public string FbssTitle { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbssClass", ColumnDescription = "名称", Length = 100)]
        public string FbssClass { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "FbssCategory", ColumnDescription = "类别", Length = 100)]
        public string FbssCategory { get; set; }

        /// <summary>
        /// 保有
        /// </summary>
        [SugarColumn(ColumnName = "FbssKeepPersonnel", ColumnDescription = "保有", DefaultValue = "0")]
        public int? FbssKeepPersonnel { get; set; }

        /// <summary>
        /// 现有
        /// </summary>
        [SugarColumn(ColumnName = "FbssNowPersonnel", ColumnDescription = "现有", DefaultValue = "0")]
        public int? FbssNowPersonnel { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "FbssPersonnel", ColumnDescription = "预算", DefaultValue = "0")]
        public int? FbssPersonnel { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(ColumnName = "FbssFlag", ColumnDescription = "启用", DefaultValue = "0")]
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