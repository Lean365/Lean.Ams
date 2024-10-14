namespace Ams.Model.Accounting
{
    /// <summary>
    /// 费用预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 13:28:21
    /// </summary>
    [SugarTable("fico_budget_expense", "费用预算")]
    public class FicoBudgetExpense : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mh003", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh003 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mh004", ColumnDescription = "年月", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh004 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mh005", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh005 { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "Mh006", ColumnDescription = "科目", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh006 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Mh007", ColumnDescription = "名称", Length = 100)]
        public string Mh007 { get; set; }

        /// <summary>
        /// 明细科目
        /// </summary>
        [SugarColumn(ColumnName = "Mh008", ColumnDescription = "明细科目", Length = 40)]
        public string Mh008 { get; set; }

        /// <summary>
        /// 明细名称
        /// </summary>
        [SugarColumn(ColumnName = "Mh009", ColumnDescription = "明细名称", Length = 100)]
        public string Mh009 { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [SugarColumn(ColumnName = "Mh010", ColumnDescription = "说明", Length = 255)]
        public string Mh010 { get; set; }

        /// <summary>
        /// 预算金额
        /// </summary>
        [SugarColumn(ColumnName = "Mh011", ColumnDescription = "预算金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mh011 { get; set; }

        /// <summary>
        /// 实际发生
        /// </summary>
        [SugarColumn(ColumnName = "Mh012", ColumnDescription = "实际发生", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mh012 { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "Mh013", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mh013 { get; set; }

        /// <summary>
        /// 启用标记
        /// </summary>
        [SugarColumn(ColumnName = "Mh014", ColumnDescription = "启用标记", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh014 { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "Mh015", ColumnDescription = "审核", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh015 { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "Mh016", ColumnDescription = "审核人员", Length = 20)]
        public string Mh016 { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? Mh017 { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "Mh018", ColumnDescription = "撤消人员", Length = 20)]
        public string Mh018 { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? Mh019 { get; set; }
    }
}