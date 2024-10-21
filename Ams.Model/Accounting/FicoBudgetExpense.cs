namespace Ams.Model.Accounting
{
    /// <summary>
    /// 费用预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 8:05:21
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
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mh003", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh003 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mh004", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh004 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mh005", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh005 { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "Mh006", ColumnDescription = "部门", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh006 { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "Mh007", ColumnDescription = "科目", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh007 { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "Mh008", ColumnDescription = "类别", Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mh008 { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        [SugarColumn(ColumnName = "Mh009", ColumnDescription = "用途", Length = 500, ColumnDataType = "NVARCHAR")]
        public string Mh009 { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [SugarColumn(ColumnName = "Mh010", ColumnDescription = "单价", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh010 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Mh011", ColumnDescription = "数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh011 { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "Mh012", ColumnDescription = "金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mh012 { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "Mh013", ColumnDescription = "实际", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mh013 { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "Mh014", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mh014 { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(ColumnName = "Mh015", ColumnDescription = "启用", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh015 { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "Mh016", ColumnDescription = "审核", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mh016 { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [SugarColumn(ColumnName = "Mh017", ColumnDescription = "审核人", Length = 20)]
        public string Mh017 { get; set; }

        /// <summary>
        /// 审核日
        /// </summary>
        public DateTime? Mh018 { get; set; }

        /// <summary>
        /// 撤消人
        /// </summary>
        [SugarColumn(ColumnName = "Mh019", ColumnDescription = "撤消人", Length = 20)]
        public string Mh019 { get; set; }

        /// <summary>
        /// 撤消日
        /// </summary>
        public DateTime? Mh020 { get; set; }
    }
}