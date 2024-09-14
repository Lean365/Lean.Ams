namespace Ams.Model.Accounting
{
    /// <summary>
    /// 财政年度
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:42:58
    /// </summary>
    [SugarTable("fico_financial_period", "财政年度")]
    public class FicoFinancialPeriod : SysBase
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
        [SugarColumn(ColumnName = "Mn002", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn002 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mn003", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn003 { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        [SugarColumn(ColumnName = "Mn004", ColumnDescription = "年", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn004 { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        [SugarColumn(ColumnName = "Mn005", ColumnDescription = "月", Length = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn005 { get; set; }

        /// <summary>
        /// 季度
        /// </summary>
        [SugarColumn(ColumnName = "Mn006", ColumnDescription = "季度", Length = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mn006 { get; set; }
    }
}