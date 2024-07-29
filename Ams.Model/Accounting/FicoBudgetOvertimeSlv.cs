
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 加班预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:28:52
    /// </summary>
    [SugarTable("fico_budget_overtime_slv","加班预算")]
    public class FicoBudgetOvertimeSlv
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbosSfid { get; set; }

        /// <summary>
        /// FbosParentSfid 
        /// </summary>
        public long FbosParentSfid { get; set; }

        /// <summary>
        /// 科目 
        /// </summary>
        [SugarColumn(ColumnName="FbosTitle", ColumnDescription = "科目 ",Length = 40)]
        public string FbosTitle { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        [SugarColumn(ColumnName="FbosClass", ColumnDescription = "名称 ",Length = 100)]
        public string FbosClass { get; set; }

        /// <summary>
        /// 必要工数 
        /// </summary>
        [SugarColumn(ColumnName="FbosRequiredst", ColumnDescription = "必要工数 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbosRequiredst { get; set; }

        /// <summary>
        /// 保有人数 
        /// </summary>
        [SugarColumn(ColumnName="FbosDirectEmployee", ColumnDescription = "保有人数 ",DefaultValue = "0")]
        public int FbosDirectEmployee { get; set; }

        /// <summary>
        /// 间接人数 
        /// </summary>
        [SugarColumn(ColumnName="FbosIndirectEmployee", ColumnDescription = "间接人数 ",DefaultValue = "0")]
        public int FbosIndirectEmployee { get; set; }

        /// <summary>
        /// 上班天数 
        /// </summary>
        [SugarColumn(ColumnName="FbosDays", ColumnDescription = "上班天数 ",DefaultValue = "0")]
        public int FbosDays { get; set; }

        /// <summary>
        /// 加班事由 
        /// </summary>
        [SugarColumn(ColumnName="FbosContent", ColumnDescription = "加班事由 ",Length = 500)]
        public string FbosContent { get; set; }

        /// <summary>
        /// 保有工数 
        /// </summary>
        [SugarColumn(ColumnName="FbosRetainst", ColumnDescription = "保有工数 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbosRetainst { get; set; }

        /// <summary>
        /// 工数差异 
        /// </summary>
        [SugarColumn(ColumnName="FbosRetainstdiff", ColumnDescription = "工数差异 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbosRetainstdiff { get; set; }

        /// <summary>
        /// 投入加班 
        /// </summary>
        [SugarColumn(ColumnName="FbosOvertime", ColumnDescription = "投入加班 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbosOvertime { get; set; }

        /// <summary>
        /// 平均投入加班 
        /// </summary>
        [SugarColumn(ColumnName="FbosDirectovertime", ColumnDescription = "平均投入加班 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbosDirectovertime { get; set; }

        /// <summary>
        /// 间接加班 
        /// </summary>
        [SugarColumn(ColumnName="FbosIndirectovertime", ColumnDescription = "间接加班 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbosIndirectovertime { get; set; }

        /// <summary>
        /// 投入总加班 
        /// </summary>
        [SugarColumn(ColumnName="FbosOvertimetotal", ColumnDescription = "投入总加班 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbosOvertimetotal { get; set; }

        /// <summary>
        /// 启用标记 
        /// </summary>
        [SugarColumn(ColumnName="FbosFlag", ColumnDescription = "启用标记 ",DefaultValue = "0")]
        public int FbosFlag { get; set; }

        /// <summary>
        /// 审核 
        /// </summary>
        [SugarColumn(ColumnName="FbosAudit", ColumnDescription = "审核 ",DefaultValue = "0")]
        public int FbosAudit { get; set; }

        /// <summary>
        /// 审核人员 
        /// </summary>
        [SugarColumn(ColumnName="FbosAuditName", ColumnDescription = "审核人员 ",Length = 20)]
        public string FbosAuditName { get; set; }

        /// <summary>
        /// 审核日期 
        /// </summary>
        public DateTime? FbosAuditDate { get; set; }

        /// <summary>
        /// 撤消人员 
        /// </summary>
        [SugarColumn(ColumnName="FbosUndoName", ColumnDescription = "撤消人员 ",Length = 20)]
        public string FbosUndoName { get; set; }

        /// <summary>
        /// 撤消日期 
        /// </summary>
        public DateTime? FbosUndoDate { get; set; }

        /// <summary>
        /// 自定义A 
        /// </summary>
        [SugarColumn(ColumnName="UDF01", ColumnDescription = "自定义A ",Length = 200)]
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B 
        /// </summary>
        [SugarColumn(ColumnName="UDF02", ColumnDescription = "自定义B ",Length = 200)]
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C 
        /// </summary>
        [SugarColumn(ColumnName="UDF03", ColumnDescription = "自定义C ",Length = 200)]
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D 
        /// </summary>
        [SugarColumn(ColumnName="UDF04", ColumnDescription = "自定义D ",Length = 200)]
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E 
        /// </summary>
        [SugarColumn(ColumnName="UDF05", ColumnDescription = "自定义E ",Length = 200)]
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F 
        /// </summary>
        [SugarColumn(ColumnName="UDF06", ColumnDescription = "自定义F ",Length = 200)]
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1 
        /// </summary>
        [SugarColumn(ColumnName="UDF51", ColumnDescription = "自定义1 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2 
        /// </summary>
        [SugarColumn(ColumnName="UDF52", ColumnDescription = "自定义2 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3 
        /// </summary>
        [SugarColumn(ColumnName="UDF53", ColumnDescription = "自定义3 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4 
        /// </summary>
        [SugarColumn(ColumnName="UDF54", ColumnDescription = "自定义4 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5 
        /// </summary>
        [SugarColumn(ColumnName="UDF55", ColumnDescription = "自定义5 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6 
        /// </summary>
        [SugarColumn(ColumnName="UDF56", ColumnDescription = "自定义6 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 备注 
        /// </summary>
        [SugarColumn(ColumnName="Remark", ColumnDescription = "备注 ",Length = 2000)]
        public string Remark { get; set; }

        /// <summary>
        /// 软删除 
        /// </summary>
        [SugarColumn(ColumnName="IsDeleted", ColumnDescription = "软删除 ",DefaultValue = "0")]
        public int IsDeleted { get; set; }

        /// <summary>
        /// 创建者 
        /// </summary>
        [SugarColumn(ColumnName = "create_by")]
        public string CreateBy { get; set; }

        /// <summary>
        /// 创建时间 
        /// </summary>
        [SugarColumn(ColumnName = "create_time")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新者 
        /// </summary>
        [SugarColumn(ColumnName = "update_by")]
        public string UpdateBy { get; set; }

        /// <summary>
        /// 更新时间 
        /// </summary>
        [SugarColumn(ColumnName = "update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}