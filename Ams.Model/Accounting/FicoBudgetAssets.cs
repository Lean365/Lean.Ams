namespace Ams.Model.Accounting
{
    /// <summary>
    /// 资产预算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/10/14 9:17:19
    /// </summary>
    [SugarTable("fico_budget_assets", "资产预算")]
    public class FicoBudgetAssets : SysBase
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
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mg003", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg003 { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public int Mg004 { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mg005", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg005 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mg006", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg006 { get; set; }

        /// <summary>
        /// 科目
        /// </summary>
        [SugarColumn(ColumnName = "Mg007", ColumnDescription = "科目", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg007 { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [SugarColumn(ColumnName = "Mg008", ColumnDescription = "类别", Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg008 { get; set; }

        /// <summary>
        /// 资产名称
        /// </summary>
        [SugarColumn(ColumnName = "Mg009", ColumnDescription = "资产名称", Length = 100, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mg009 { get; set; }

        /// <summary>
        /// 用途说明
        /// </summary>
        [SugarColumn(ColumnName = "Mg010", ColumnDescription = "用途说明", Length = 250)]
        public string Mg010 { get; set; }

        /// <summary>
        /// 年限
        /// </summary>
        [SugarColumn(ColumnName = "Mg011", ColumnDescription = "年限", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg011 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Mg012", ColumnDescription = "数量", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg012 { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [SugarColumn(ColumnName = "Mg013", ColumnDescription = "单价", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mg013 { get; set; }

        /// <summary>
        /// 预算金额
        /// </summary>
        [SugarColumn(ColumnName = "Mg014", ColumnDescription = "预算金额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mg014 { get; set; }

        /// <summary>
        /// 实际
        /// </summary>
        [SugarColumn(ColumnName = "Mg015", ColumnDescription = "实际", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mg015 { get; set; }

        /// <summary>
        /// 差异
        /// </summary>
        [SugarColumn(ColumnName = "Mg016", ColumnDescription = "差异", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mg016 { get; set; }

        /// <summary>
        /// 折旧
        /// </summary>
        [SugarColumn(ColumnName = "Mg017", ColumnDescription = "折旧", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mg017 { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        [SugarColumn(ColumnName = "Mg018", ColumnDescription = "启用", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg018 { get; set; }

        /// <summary>
        /// 审核标志
        /// </summary>
        [SugarColumn(ColumnName = "Mg019", ColumnDescription = "审核标志", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mg019 { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        [SugarColumn(ColumnName = "Mg020", ColumnDescription = "审核人员", Length = 20)]
        public string Mg020 { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? Mg021 { get; set; }

        /// <summary>
        /// 撤消人员
        /// </summary>
        [SugarColumn(ColumnName = "Mg022", ColumnDescription = "撤消人员", Length = 20)]
        public string Mg022 { get; set; }

        /// <summary>
        /// 撤消日期
        /// </summary>
        public DateTime? Mg023 { get; set; }
    }
}