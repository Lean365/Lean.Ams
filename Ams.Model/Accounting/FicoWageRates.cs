namespace Ams.Model.Accounting
{
    /// <summary>
    /// 工资率
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/5 15:26:01
    /// </summary>
    [SugarTable("fico_wage_rates", "工资率")]
    public class FicoWageRates : SysBase
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
        [SugarColumn(ColumnName = "Mr002", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mr002 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Mr003", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mr003 { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [SugarColumn(ColumnName = "Mr004", ColumnDescription = "公司", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mr004 { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        [SugarColumn(ColumnName = "Mr005", ColumnDescription = "币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Mr005 { get; set; }

        /// <summary>
        /// 销售额
        /// </summary>
        [SugarColumn(ColumnName = "Mr006", ColumnDescription = "销售额", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr006 { get; set; }

        /// <summary>
        /// 工作天数
        /// </summary>
        [SugarColumn(ColumnName = "Mr007", ColumnDescription = "工作天数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr007 { get; set; }

        /// <summary>
        /// 直接工资率
        /// </summary>
        [SugarColumn(ColumnName = "Mr008", ColumnDescription = "直接工资率", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr008 { get; set; }

        /// <summary>
        /// 直接人数
        /// </summary>
        [SugarColumn(ColumnName = "Mr009", ColumnDescription = "直接人数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr009 { get; set; }

        /// <summary>
        /// 直接加班费
        /// </summary>
        [SugarColumn(ColumnName = "Mr010", ColumnDescription = "直接加班费", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr010 { get; set; }

        /// <summary>
        /// 直接工资
        /// </summary>
        [SugarColumn(ColumnName = "Mr011", ColumnDescription = "直接工资", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr011 { get; set; }

        /// <summary>
        /// 间接工资率
        /// </summary>
        [SugarColumn(ColumnName = "Mr012", ColumnDescription = "间接工资率", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr012 { get; set; }

        /// <summary>
        /// 间接人数
        /// </summary>
        [SugarColumn(ColumnName = "Mr013", ColumnDescription = "间接人数", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr013 { get; set; }

        /// <summary>
        /// 间接加班费
        /// </summary>
        [SugarColumn(ColumnName = "Mr014", ColumnDescription = "间接加班费", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr014 { get; set; }

        /// <summary>
        /// 间接工资
        /// </summary>
        [SugarColumn(ColumnName = "Mr015", ColumnDescription = "间接工资", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Mr015 { get; set; }
    }
}