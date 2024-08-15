namespace Ams.Model.Accounting
{
    /// <summary>
    /// 工资率
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:12
    /// </summary>
    [SugarTable("fico_wage_rates", "工资率")]
    public class FicoWageRates : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long FwSfId { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "FwCrop", ColumnDescription = "公司  ", Length = 4)]
        public string FwCrop { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false, ColumnName = "FwYm", ColumnDescription = "年月  ", Length = 6)]
        public string FwYm { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "FwCcy", ColumnDescription = "币种  ", Length = 3)]
        public string FwCcy { get; set; }

        /// <summary>
        /// 销售额
        /// </summary>
        [SugarColumn(ColumnName = "FwSalesVolume", ColumnDescription = "销售额  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwSalesVolume { get; set; }

        /// <summary>
        /// 工作天数
        /// </summary>
        [SugarColumn(ColumnName = "FwWorkingDays", ColumnDescription = "工作天数  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwWorkingDays { get; set; }

        /// <summary>
        /// 直接工资率
        /// </summary>
        [SugarColumn(ColumnName = "FwDirectWageRate", ColumnDescription = "直接工资率  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwDirectWageRate { get; set; }

        /// <summary>
        /// 直接人数
        /// </summary>
        [SugarColumn(ColumnName = "FwDirect", ColumnDescription = "直接人数  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwDirect { get; set; }

        /// <summary>
        /// 直接加班费
        /// </summary>
        [SugarColumn(ColumnName = "FwDirectOverTime", ColumnDescription = "直接加班费  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwDirectOverTime { get; set; }

        /// <summary>
        /// 直接工资
        /// </summary>
        [SugarColumn(ColumnName = "FwDirectWages", ColumnDescription = "直接工资  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwDirectWages { get; set; }

        /// <summary>
        /// 间接工资率
        /// </summary>
        [SugarColumn(ColumnName = "FwInDirectWageRate", ColumnDescription = "间接工资率  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwInDirectWageRate { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "FwInDirect", ColumnDescription = "间接人数  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwInDirect { get; set; }

        /// <summary>
        /// 间接加班费
        /// </summary>
        [SugarColumn(ColumnName = "FwInDirectOverTime", ColumnDescription = "间接加班费  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwInDirectOverTime { get; set; }

        /// <summary>
        /// 间接工资
        /// </summary>
        [SugarColumn(ColumnName = "FwInDirectWages", ColumnDescription = "间接工资  ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal FwInDirectWages { get; set; }
    }
}