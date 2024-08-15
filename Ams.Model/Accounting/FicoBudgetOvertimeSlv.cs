namespace Ams.Model.Accounting
{
    /// <summary>
    /// 加班预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/9 12:06:46
    /// </summary>
    [SugarTable("fico_budget_overtime_slv", "加班预算")]
    public class FicoBudgetOvertimeSlv : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbosSfId { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long? FbosParentSfId { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbosYm", ColumnDescription = "年月", Length = 4)]
        public string FbosYm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "FbosTitle", ColumnDescription = "科目", Length = 40)]
        public string FbosTitle { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbosClass", ColumnDescription = "名称", Length = 100)]
        public string FbosClass { get; set; }

        /// <summary>
        /// 必要工数
        /// </summary>
        [SugarColumn(ColumnName = "FbosRequiredst", ColumnDescription = "必要工数", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbosRequiredst { get; set; }

        /// <summary>
        /// 保有人数
        /// </summary>
        [SugarColumn(ColumnName = "FbosDirectEmployee", ColumnDescription = "保有人数", DefaultValue = "0")]
        public int? FbosDirectEmployee { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "FbosIndirectEmployee", ColumnDescription = "间接人数", DefaultValue = "0")]
        public int? FbosIndirectEmployee { get; set; }

        /// <summary>
        /// 上班天数
        /// </summary>
        [SugarColumn(ColumnName = "FbosDays", ColumnDescription = "上班天数", DefaultValue = "0")]
        public int? FbosDays { get; set; }

        /// <summary>
        /// 加班事由
        /// </summary>
        [SugarColumn(ColumnName = "FbosContent", ColumnDescription = "加班事由", Length = 500)]
        public string FbosContent { get; set; }

        /// <summary>
        /// 保有工数
        /// </summary>
        [SugarColumn(ColumnName = "FbosRetainst", ColumnDescription = "保有工数", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbosRetainst { get; set; }

        /// <summary>
        /// 工数差异
        /// </summary>
        [SugarColumn(ColumnName = "FbosRetainstdiff", ColumnDescription = "工数差异", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbosRetainstdiff { get; set; }

        /// <summary>
        /// 投入加班
        /// </summary>
        [SugarColumn(ColumnName = "FbosOvertime", ColumnDescription = "投入加班", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbosOvertime { get; set; }

        /// <summary>
        /// 平均投入加班
        /// </summary>
        [SugarColumn(ColumnName = "FbosDirectovertime", ColumnDescription = "平均投入加班", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbosDirectovertime { get; set; }

        /// <summary>
        /// 间接加班
        /// </summary>
        [SugarColumn(ColumnName = "FbosIndirectovertime", ColumnDescription = "间接加班", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbosIndirectovertime { get; set; }

        /// <summary>
        /// 投入总加班
        /// </summary>
        [SugarColumn(ColumnName = "FbosOvertimetotal", ColumnDescription = "投入总加班", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbosOvertimetotal { get; set; }

        /// <summary>
        /// 启用标记
        /// </summary>
        [SugarColumn(ColumnName = "FbosFlag", ColumnDescription = "启用标记", DefaultValue = "0")]
        public int? FbosFlag { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "FbosAudit", ColumnDescription = "审核", DefaultValue = "0")]
        public int? FbosAudit { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "FbosAuditName", ColumnDescription = "审核人员", Length = 20)]
        public string FbosAuditName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? FbosAuditDate { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "FbosUndoName", ColumnDescription = "撤消人员", Length = 20)]
        public string FbosUndoName { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? FbosUndoDate { get; set; }
    }
}