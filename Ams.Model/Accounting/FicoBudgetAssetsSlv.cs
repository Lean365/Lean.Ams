
namespace Ams.Model.Accounting
{
    /// <summary>
    /// 资产预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/29 8:59:42
    /// </summary>
    [SugarTable("fico_budget_assets_slv","资产预算")]
    public class FicoBudgetAssetsSlv
    {
        /// <summary>
        /// SFID 
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbasSfid { get; set; }

        /// <summary>
        /// 父ID 
        /// </summary>
        public long FbasParentSfid { get; set; }

        /// <summary>
        /// 科目 
        /// </summary>
        [SugarColumn(ColumnName="FbasTitle", ColumnDescription = "科目 ",Length = 40)]
        public string FbasTitle { get; set; }

        /// <summary>
        /// 类别 
        /// </summary>
        [SugarColumn(ColumnName="FbasClass", ColumnDescription = "类别 ",Length = 100)]
        public string FbasClass { get; set; }

        /// <summary>
        /// 名称 
        /// </summary>
        [SugarColumn(ColumnName="FbasName", ColumnDescription = "名称 ",Length = 100)]
        public string FbasName { get; set; }

        /// <summary>
        /// 说明 
        /// </summary>
        [SugarColumn(ColumnName="FbasDesc", ColumnDescription = "说明 ",Length = 250)]
        public string FbasDesc { get; set; }

        /// <summary>
        /// 年限 
        /// </summary>
        [SugarColumn(ColumnName="FbasServiceLife", ColumnDescription = "年限 ",DefaultValue = "0")]
        public int FbasServiceLife { get; set; }

        /// <summary>
        /// 预算 
        /// </summary>
        [SugarColumn(ColumnName="FbasBudgetAmount", ColumnDescription = "预算 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbasBudgetAmount { get; set; }

        /// <summary>
        /// 实际 
        /// </summary>
        [SugarColumn(ColumnName="FbasActualAmount", ColumnDescription = "实际 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbasActualAmount { get; set; }

        /// <summary>
        /// 差异 
        /// </summary>
        [SugarColumn(ColumnName="FbasDifferenceAmount", ColumnDescription = "差异 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbasDifferenceAmount { get; set; }

        /// <summary>
        /// 折旧 
        /// </summary>
        [SugarColumn(ColumnName="FbasDepreciation", ColumnDescription = "折旧 ",DefaultValue = "0",Length = 18, DecimalDigits = 2)]
        public decimal FbasDepreciation { get; set; }

        /// <summary>
        /// 启用 
        /// </summary>
        [SugarColumn(ColumnName="FbasFlag", ColumnDescription = "启用 ",DefaultValue = "0")]
        public int FbasFlag { get; set; }

        /// <summary>
        /// 审核标志 
        /// </summary>
        [SugarColumn(ColumnName="FbasAudit", ColumnDescription = "审核标志 ",DefaultValue = "0")]
        public int FbasAudit { get; set; }

        /// <summary>
        /// 审核人员 
        /// </summary>
        [SugarColumn(ColumnName="FbasAuditName", ColumnDescription = "审核人员 ",Length = 20)]
        public string FbasAuditName { get; set; }

        /// <summary>
        /// 审核日期 
        /// </summary>
        public DateTime? FbasAuditDate { get; set; }

        /// <summary>
        /// 撤消人员 
        /// </summary>
        [SugarColumn(ColumnName="FbasUndoName", ColumnDescription = "撤消人员 ",Length = 20)]
        public string FbasUndoName { get; set; }

        /// <summary>
        /// 撤消日期 
        /// </summary>
        public DateTime? FbasUndoDate { get; set; }

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