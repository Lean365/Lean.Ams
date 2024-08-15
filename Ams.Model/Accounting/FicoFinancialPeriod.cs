namespace Ams.Model.Accounting
{
    /// <summary>
    /// 财务期间
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/6 13:51:07
    /// </summary>
    [SugarTable("fico_financial_period", "财务期间")]
    public class FicoFinancialPeriod : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FpSfId { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FpFinancialYear", ColumnDescription = "财年  ", Length = 6)]
        public string FpFinancialYear { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FpYearMonth", ColumnDescription = "年月  ", Length = 6)]
        public string FpYearMonth { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        [SugarColumn(ColumnName = "FpYear", ColumnDescription = "年  ", Length = 4)]
        public string FpYear { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        [SugarColumn(ColumnName = "FpMonth", ColumnDescription = "月  ", Length = 2)]
        public string FpMonth { get; set; }

        /// <summary>
        /// 季度
        /// </summary>
        [SugarColumn(ColumnName = "FpQuarter", ColumnDescription = "季度  ", Length = 2)]
        public string FpQuarter { get; set; }
    }
}