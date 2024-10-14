namespace Ams.Model.Accounting
{
    /// <summary>
    /// 预算科目
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/12 16:36:02
    /// </summary>
    [SugarTable("fico_budget_accounting", "预算科目")]
    public class FicoBudgetAccounting : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public long ParentId { get; set; }

        /// <summary>
        /// 集团
        /// </summary>
        [SugarColumn(ColumnName = "Md003", ColumnDescription = "集团", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md003 { get; set; }

        /// <summary>
        /// 公司代码
        /// </summary>
        [SugarColumn(ColumnName = "Md004", ColumnDescription = "公司代码", Length = 8, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md004 { get; set; }

        /// <summary>
        /// 语言Key
        /// </summary>
        [SugarColumn(ColumnName = "Md005", ColumnDescription = "语言Key", Length = 255)]
        public string Md005 { get; set; }

        /// <summary>
        /// 预算科目
        /// </summary>
        [SugarColumn(ColumnName = "Md006", ColumnDescription = "预算科目", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md006 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Md007", ColumnDescription = "币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md007 { get; set; }

        /// <summary>
        /// 会计科目
        /// </summary>
        [SugarColumn(ColumnName = "Md008", ColumnDescription = "会计科目", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md008 { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(ColumnName = "Md009", ColumnDescription = "名称", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md009 { get; set; }

        /// <summary>
        /// 长文本
        /// </summary>
        [SugarColumn(ColumnName = "Md010", ColumnDescription = "长文本", Length = 80)]
        public string Md010 { get; set; }

        /// <summary>
        /// 附加文本
        /// </summary>
        [SugarColumn(ColumnName = "Md011", ColumnDescription = "附加文本", Length = 120)]
        public string Md011 { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        [SugarColumn(ColumnName = "Md012", ColumnDescription = "费用类型", Length = 4)]
        public string Md012 { get; set; }

        /// <summary>
        /// 统驭科目
        /// </summary>
        [SugarColumn(ColumnName = "Md013", ColumnDescription = "统驭科目", Length = 2)]
        public string Md013 { get; set; }

        /// <summary>
        /// 冻结
        /// </summary>
        [SugarColumn(ColumnName = "Md014", ColumnDescription = "冻结", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md014 { get; set; }

        [SugarColumn(IsIgnore = true)]
        public List<FicoBudgetAccounting> Children { get; set; } = new();
    }
}