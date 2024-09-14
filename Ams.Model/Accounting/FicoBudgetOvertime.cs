namespace Ams.Model.Accounting
{
    /// <summary>
    /// 加班预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:57:03
    /// </summary>
    [SugarTable("fico_budget_overtime", "加班预算")]
    public class FicoBudgetOvertime : SysBase
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
        public long? ParentId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "Mi004", ColumnDescription = "财年", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mi004 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mi005", ColumnDescription = "年月", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mi005 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mi006", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mi006 { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "Mi007", ColumnDescription = "科目", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mi007 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Mi008", ColumnDescription = "名称", Length = 100)]
        public string Mi008 { get; set; }

        /// <summary>
        /// 必要工数
        /// </summary>
        [SugarColumn(ColumnName = "Mi009", ColumnDescription = "必要工数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi009 { get; set; }

        /// <summary>
        /// 保有人数
        /// </summary>
        [SugarColumn(ColumnName = "Mi010", ColumnDescription = "保有人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mi010 { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "Mi011", ColumnDescription = "间接人数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mi011 { get; set; }

        /// <summary>
        /// 上班天数
        /// </summary>
        [SugarColumn(ColumnName = "Mi012", ColumnDescription = "上班天数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mi012 { get; set; }

        /// <summary>
        /// 加班事由
        /// </summary>
        [SugarColumn(ColumnName = "Mi013", ColumnDescription = "加班事由", Length = 500)]
        public string Mi013 { get; set; }

        /// <summary>
        /// 保有工数
        /// </summary>
        [SugarColumn(ColumnName = "Mi014", ColumnDescription = "保有工数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi014 { get; set; }

        /// <summary>
        /// 工数差异
        /// </summary>
        [SugarColumn(ColumnName = "Mi015", ColumnDescription = "工数差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi015 { get; set; }

        /// <summary>
        /// 投入加班
        /// </summary>
        [SugarColumn(ColumnName = "Mi016", ColumnDescription = "投入加班", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi016 { get; set; }

        /// <summary>
        /// 平均投入加班
        /// </summary>
        [SugarColumn(ColumnName = "Mi017", ColumnDescription = "平均投入加班", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi017 { get; set; }

        /// <summary>
        /// 间接加班
        /// </summary>
        [SugarColumn(ColumnName = "Mi018", ColumnDescription = "间接加班", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi018 { get; set; }

        /// <summary>
        /// 投入总加班
        /// </summary>
        [SugarColumn(ColumnName = "Mi019", ColumnDescription = "投入总加班", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mi019 { get; set; }

        /// <summary>
        /// 启用标记
        /// </summary>
        [SugarColumn(ColumnName = "Mi020", ColumnDescription = "启用标记", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mi020 { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "Mi021", ColumnDescription = "审核", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mi021 { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "Mi022", ColumnDescription = "审核人员", Length = 20)]
        public string Mi022 { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? Mi023 { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "Mi024", ColumnDescription = "撤消人员", Length = 20)]
        public string Mi024 { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? Mi025 { get; set; }
    }
}