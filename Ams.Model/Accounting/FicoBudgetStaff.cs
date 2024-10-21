namespace Ams.Model.Accounting
{
    /// <summary>
    /// 人员预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/16 13:50:58
    /// </summary>
    [SugarTable("fico_budget_staff", "人员预算")]
    public class FicoBudgetStaff : SysBase
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
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "Mj003", ColumnDescription = "财年", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj003 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mj004", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj004 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mj005", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj005 { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [SugarColumn(ColumnName = "Mj006", ColumnDescription = "部门", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj006 { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "Mj007", ColumnDescription = "科目", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj007 { get; set; }

        /// <summary>
        /// 费用类别
        /// </summary>
        [SugarColumn(ColumnName = "Mj008", ColumnDescription = "费用类别", Length = 2)]
        public string Mj008 { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        [SugarColumn(ColumnName = "Mj009", ColumnDescription = "原因", Length = 500, ColumnDataType = "NVARCHAR")]
        public string Mj009 { get; set; }

        /// <summary>
        /// 人员类别
        /// </summary>
        [SugarColumn(ColumnName = "Mj010", ColumnDescription = "人员类别", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj010 { get; set; }

        /// <summary>
        /// 保有
        /// </summary>
        [SugarColumn(ColumnName = "Mj011", ColumnDescription = "保有", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj011 { get; set; }

        /// <summary>
        /// 现有
        /// </summary>
        [SugarColumn(ColumnName = "Mj012", ColumnDescription = "现有", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj012 { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "Mj013", ColumnDescription = "预算", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj013 { get; set; }

        /// <summary>
        /// 职级
        /// </summary>
        [SugarColumn(ColumnName = "Mj014", ColumnDescription = "职级", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj014 { get; set; }

        /// <summary>
        /// 月薪
        /// </summary>
        [SugarColumn(ColumnName = "Mj015", ColumnDescription = "月薪", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj015 { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        [SugarColumn(ColumnName = "Mj016", ColumnDescription = "金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mj016 { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(ColumnName = "Mj017", ColumnDescription = "启用", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj017 { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "Mj018", ColumnDescription = "审核", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj018 { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [SugarColumn(ColumnName = "Mj019", ColumnDescription = "审核人", Length = 20)]
        public string Mj019 { get; set; }

        /// <summary>
        /// 审核日
        /// </summary>
        public DateTime? Mj020 { get; set; }

        /// <summary>
        /// 撤消人
        /// </summary>
        [SugarColumn(ColumnName = "Mj021", ColumnDescription = "撤消人", Length = 20)]
        public string Mj021 { get; set; }

        /// <summary>
        /// 撤消日
        /// </summary>
        public DateTime? Mj022 { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string Md009 { get; set; }
    }
}