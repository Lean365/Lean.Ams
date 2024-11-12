namespace Ams.Model.Logistics
{
    /// <summary>
    /// 销售价格
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/11/8 11:47:38
    /// </summary>
    [SugarTable("sd_selling_price", "销售价格")]
    public class SdSellingPrice : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long? Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Md002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md002 { get; set; }

        /// <summary>
        /// 期间
        /// </summary>
        [SugarColumn(ColumnName = "Md003", ColumnDescription = "期间", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md003 { get; set; }

        /// <summary>
        /// 年月
        /// </summary>
        [SugarColumn(ColumnName = "Md004", ColumnDescription = "年月", Length = 6, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md004 { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "Md005", ColumnDescription = "物料", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md005 { get; set; }

        /// <summary>
        /// 物料文本
        /// </summary>
        [SugarColumn(ColumnName = "Md006", ColumnDescription = "物料文本", Length = 40)]
        public string Md006 { get; set; }

        /// <summary>
        /// 原币价格
        /// </summary>
        [SugarColumn(ColumnName = "Md007", ColumnDescription = "原币价格", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md007 { get; set; }

        /// <summary>
        /// 原币种
        /// </summary>
        [SugarColumn(ColumnName = "Md008", ColumnDescription = "原币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md008 { get; set; }

        /// <summary>
        /// 原币定价单位
        /// </summary>
        [SugarColumn(ColumnName = "Md009", ColumnDescription = "原币定价单位", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md009 { get; set; }

        /// <summary>
        /// 原币利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Md010", ColumnDescription = "原币利润中心", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md010 { get; set; }

        /// <summary>
        /// 本币价格
        /// </summary>
        [SugarColumn(ColumnName = "Md011", ColumnDescription = "本币价格", DefaultValue = "0", Length = 18, DecimalDigits = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md011 { get; set; }

        /// <summary>
        /// 本币种
        /// </summary>
        [SugarColumn(ColumnName = "Md012", ColumnDescription = "本币种", Length = 3, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md012 { get; set; }

        /// <summary>
        /// 本币定价单位
        /// </summary>
        [SugarColumn(ColumnName = "Md013", ColumnDescription = "本币定价单位", DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int Md013 { get; set; }

        /// <summary>
        /// 本币利润中心
        /// </summary>
        [SugarColumn(ColumnName = "Md014", ColumnDescription = "本币利润中心", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Md014 { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        [SugarColumn(ColumnName = "Md015", ColumnDescription = "汇率", DefaultValue = "0", Length = 18, DecimalDigits = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Md015 { get; set; }

        /// <summary>
        /// 生效日期
        /// </summary>
        public DateTime? Md016 { get; set; }

        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? Md017 { get; set; }
    }
}