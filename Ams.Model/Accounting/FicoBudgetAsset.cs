namespace Ams.Model.Accounting
{
    /// <summary>
    /// 资产预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:07
    /// </summary>
    [SugarTable("fico_budget_asset", "资产预算")]
    public class FicoBudgetAsset : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FbaSFID { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "FbaCorp", ColumnDescription = "公司 ", Length = 4)]
        public string FbaCorp { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "FbaDept", ColumnDescription = "部门 ", Length = 20)]
        public string FbaDept { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FbaFy", ColumnDescription = "财年 ", Length = 6)]
        public string FbaFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FbaFm", ColumnDescription = "年月 ", Length = 100)]
        public string FbaFm { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "FbaTitle", ColumnDescription = "科目 ", Length = 40)]
        public string FbaTitle { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "FbaClass", ColumnDescription = "类别 ", Length = 100)]
        public string FbaClass { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "FbaName", ColumnDescription = "名称 ", Length = 100)]
        public string FbaName { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "FbaDesc", ColumnDescription = "说明 ", Length = 250)]
        public string FbaDesc { get; set; }

        /// <summary>
        /// 年限
        /// </summary>
        [SugarColumn(ColumnName = "FbaServiceLife", ColumnDescription = "年限 ", DefaultValue = "0")]
        public int FbaServiceLife { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "FbaBudgetAmount", ColumnDescription = "预算 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbaBudgetAmount { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "FbaActualAmount", ColumnDescription = "实际 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbaActualAmount { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "FbaDifferenceAmount", ColumnDescription = "差异 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbaDifferenceAmount { get; set; }

        /// <summary>
        /// 折旧
        /// </summary>
        [SugarColumn(ColumnName = "FbaDepreciation", ColumnDescription = "折旧 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FbaDepreciation { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(ColumnName = "FbaFlag", ColumnDescription = "启用 ", DefaultValue = "0")]
        public int FbaFlag { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        [SugarColumn(ColumnName = "FbaAudit", ColumnDescription = "审核标志 ", DefaultValue = "0")]
        public int FbaAudit { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "FbaAuditName", ColumnDescription = "审核人员 ", Length = 20)]
        public string FbaAuditName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? FbaAuditDate { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "FbaUndoName", ColumnDescription = "撤消人员 ", Length = 20)]
        public string FbaUndoName { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? FbaUndoDate { get; set; }

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