namespace Ams.Model.Accounting
{
    /// <summary>
    /// bom核算
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:12:02
    /// </summary>
    [SugarTable("fico_costing_bom", "bom核算")]
    public class FicoCostingBom : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Mk002", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mk002 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mk003", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mk003 { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Mk004", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mk004 { get; set; }

        /// <summary>
        /// 机种名称
        /// </summary>
        [SugarColumn(ColumnName = "Mk005", ColumnDescription = "机种名称", Length = 40)]
        public string Mk005 { get; set; }

        /// <summary>
        /// 成品物料
        /// </summary>
        [SugarColumn(ColumnName = "Mk006", ColumnDescription = "成品物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mk006 { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "Mk007", ColumnDescription = "物料文本", Length = 40)]
        public string Mk007 { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        [SugarColumn(ColumnName = "Mk008", ColumnDescription = "成本", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mk008 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Mk009", ColumnDescription = "币种", Length = 3)]
        public string Mk009 { get; set; }

        /// <summary>
        /// 核算日期
        /// </summary>
        public DateTime? Mk010 { get; set; }
    }
}