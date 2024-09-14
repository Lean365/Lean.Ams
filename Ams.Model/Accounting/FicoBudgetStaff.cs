namespace Ams.Model.Accounting
{
    /// <summary>
    /// 人员预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:56:20
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
        public long? ParentId { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        public long? DeptId { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "Mj004", ColumnDescription = "财年", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj004 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mj005", ColumnDescription = "年月", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj005 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mj006", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj006 { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "Mj007", ColumnDescription = "科目", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mj007 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Mj008", ColumnDescription = "名称", Length = 100)]
        public string Mj008 { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "Mj009", ColumnDescription = "类别", Length = 100)]
        public string Mj009 { get; set; }

        /// <summary>
        /// 保有
        /// </summary>
        [SugarColumn(ColumnName = "Mj010", ColumnDescription = "保有", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj010 { get; set; }

        /// <summary>
        /// 现有
        /// </summary>
        [SugarColumn(ColumnName = "Mj011", ColumnDescription = "现有", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj011 { get; set; }

        /// <summary>
        /// 预算
        /// </summary>
        [SugarColumn(ColumnName = "Mj012", ColumnDescription = "预算", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj012 { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(ColumnName = "Mj013", ColumnDescription = "启用", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj013 { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        [SugarColumn(ColumnName = "Mj014", ColumnDescription = "审核", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mj014 { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "Mj015", ColumnDescription = "审核人员", Length = 20)]
        public string Mj015 { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? Mj016 { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "Mj017", ColumnDescription = "撤消人员", Length = 20)]
        public string Mj017 { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? Mj018 { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<FicoBudgetStaff> Children { get; set; }
    }
}