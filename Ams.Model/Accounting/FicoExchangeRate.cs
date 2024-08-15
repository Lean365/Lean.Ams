namespace Ams.Model.Accounting
{
    /// <summary>
    /// 汇率表
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:18
    /// </summary>
    [SugarTable("fico_exchange_rate", "汇率表")]
    public class FicoExchangeRate : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FerSfId { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "FerCorp", ColumnDescription = "公司  ", Length = 4)]
        public string FerCorp { get; set; }

        /// <summary>
        /// 日期
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public DateTime? FerEffDate { get; set; }

        /// <summary>
        /// 基数
        /// </summary>
        [SugarColumn(ColumnName = "FerStd", ColumnDescription = "基数  ", DefaultValue = "0")]
        public int? FerStd { get; set; }

        /// <summary>
        /// 从币种
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "FerfmCcy", ColumnDescription = "从币种  ", Length = 3)]
        public string FerfmCcy { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        [SugarColumn(ColumnName = "FerRate", ColumnDescription = "汇率  ", DefaultValue = "0", Length = 18, DecimalDigits = 5)]
        public decimal FerRate { get; set; }

        /// <summary>
        /// 到币种
        /// </summary>
        [SugarColumn(ColumnName = "FertoCcy", ColumnDescription = "到币种  ", Length = 3)]
        public string FertoCcy { get; set; }
    }
}