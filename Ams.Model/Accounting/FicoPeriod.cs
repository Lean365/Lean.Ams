namespace Ams.Model.Accounting
{
    /// <summary>
    /// 财务期间
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:25:53
    /// </summary>
    [SugarTable("fico_period", "财务期间")]
    public class FicoPeriod : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FpSFID { get; set; }

        /// <summary>
        /// 财年
        /// </summary>
        [SugarColumn(ColumnName = "FpFy", ColumnDescription = "财年 ", Length = 6)]
        public string FpFy { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "FpYm", ColumnDescription = "年月 ", Length = 6)]
        public string FpYm { get; set; }

        /// <summary>
        /// 年
        /// </summary>
        [SugarColumn(ColumnName = "FpYear", ColumnDescription = "年 ", Length = 4)]
        public string FpYear { get; set; }

        /// <summary>
        /// 月
        /// </summary>
        [SugarColumn(ColumnName = "FpMonth", ColumnDescription = "月 ", Length = 2)]
        public string FpMonth { get; set; }

        /// <summary>
        /// 季度
        /// </summary>
        [SugarColumn(ColumnName = "FpQuarter", ColumnDescription = "季度 ", Length = 2)]
        public string FpQuarter { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(ColumnName = "IsDeleted", ColumnDescription = "软删除 ", DefaultValue = "0")]
        public int IsDeleted { get; set; }
    }
}