namespace Ams.Model.Accounting
{
    /// <summary>
    /// 币种汇率
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 16:52:45
    /// </summary>
    [SugarTable("fico_exchange_rate", "币种汇率")]
    public class FicoExchangeRate : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mm002", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mm002 { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? Mm003 { get; set; }

        /// <summary>
        /// 从币种
        /// </summary>
        [SugarColumn(ColumnName = "Mm004", ColumnDescription = "从币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mm004 { get; set; }

        /// <summary>
        /// 基数
        /// </summary>
        [SugarColumn(ColumnName = "Mm005", ColumnDescription = "基数", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Mm005 { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        [SugarColumn(ColumnName = "Mm006", ColumnDescription = "汇率", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mm006 { get; set; }

        /// <summary>
        /// 到币种
        /// </summary>
        [SugarColumn(ColumnName = "Mm007", ColumnDescription = "到币种", Length = 3)]
        public string Mm007 { get; set; }
    }
}