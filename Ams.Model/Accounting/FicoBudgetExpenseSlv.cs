
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 费用预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 9:30:56
    /// </summary>
    [SugarTable("fico_budget_expense_slv","费用预算")]
    public class FicoBudgetExpenseSlv
    {
        /// <summary>
        /// ID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbesSfid { get; set; }

        /// <summary>
        /// 父ID 
        /// </summary>
        public long FbesParentSfid { get; set; }

        /// <summary>
        /// 科目 
        /// </summary>
        [SugarColumn(ColumnName="FbesTitle", ColumnDescription = "科目 ",Length = 40)]
        public string FbesTitle { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        [SugarColumn(ColumnName="FbesClass", ColumnDescription = "名称 ",Length = 100)]
        public string FbesClass { get; set; }

        /// <summary>
        /// 明细科目 
        /// </summary>
        [SugarColumn(ColumnName="FbesTitlesub", ColumnDescription = "明细科目 ",Length = 40)]
        public string FbesTitlesub { get; set; }

        /// <summary>
        /// 明细名称 
        /// </summary>
        [SugarColumn(ColumnName="FbesClasssub", ColumnDescription = "明细名称 ",Length = 100)]
        public string FbesClasssub { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        [SugarColumn(ColumnName="FbesClassmemo", ColumnDescription = "说明 ",Length = 255)]
        public string FbesClassmemo { get; set; }

        /// <summary>
        /// 预算金额 
        /// </summary>
        [SugarColumn(ColumnName="FbesBudgetAmount", ColumnDescription = "预算金额 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbesBudgetAmount { get; set; }

        /// <summary>
        /// 实际发生 
        /// </summary>
        [SugarColumn(ColumnName="FbesActualAmount", ColumnDescription = "实际发生 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbesActualAmount { get; set; }

        /// <summary>
        /// 差异 
        /// </summary>
        [SugarColumn(ColumnName="FbesDifferenceAmount", ColumnDescription = "差异 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbesDifferenceAmount { get; set; }

        /// <summary>
        /// 启用标记 
        /// </summary>
        [SugarColumn(ColumnName="FbssFlag", ColumnDescription = "启用标记 ",DefaultValue = "0")]
        public int FbssFlag { get; set; }

        /// <summary>
        /// 审核 
        /// </summary>
        [SugarColumn(ColumnName="FbssAudit", ColumnDescription = "审核 ",DefaultValue = "0")]
        public int FbssAudit { get; set; }

        /// <summary>
        /// 审核人员 
        /// </summary>
        [SugarColumn(ColumnName="FbssAuditName", ColumnDescription = "审核人员 ",Length = 20)]
        public string FbssAuditName { get; set; }

        /// <summary>
        /// 审核日期 
        /// </summary>
        public DateTime? FbssAuditDate { get; set; }

        /// <summary>
        /// 撤消人员 
        /// </summary>
        [SugarColumn(ColumnName="FbssUndoName", ColumnDescription = "撤消人员 ",Length = 20)]
        public string FbssUndoName { get; set; }

        /// <summary>
        /// 撤消日期 
        /// </summary>
        public DateTime? FbssUndoDate { get; set; }

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