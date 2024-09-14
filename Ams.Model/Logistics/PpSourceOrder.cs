namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源订单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/10 17:05:57
    /// </summary>
    [SugarTable("pp_source_order", "源订单")]
    public class PpSourceOrder : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long Id { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Zf002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zf002 { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [SugarColumn(ColumnName = "Zf003", ColumnDescription = "订单类型", Length = 5, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zf003 { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "Zf004", ColumnDescription = "生产订单", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zf004 { get; set; }

        /// <summary>
        /// 品号
        /// </summary>
        [SugarColumn(ColumnName = "Zf005", ColumnDescription = "品号", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zf005 { get; set; }

        /// <summary>
        /// LOT
        /// </summary>
        [SugarColumn(ColumnName = "Zf006", ColumnDescription = "LOT", Length = 40)]
        public string Zf006 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Zf007", ColumnDescription = "数量", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zf007 { get; set; }

        /// <summary>
        /// 已生产
        /// </summary>
        [SugarColumn(ColumnName = "Zf008", ColumnDescription = "已生产", DefaultValue = "0", Length = 18, DecimalDigits = 2, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal Zf008 { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [SugarColumn(ColumnName = "Zf009", ColumnDescription = "开始日期", Length = 8)]
        public string Zf009 { get; set; }

        /// <summary>
        /// 作业手顺
        /// </summary>
        [SugarColumn(ColumnName = "Zf010", ColumnDescription = "作业手顺", Length = 10)]
        public string Zf010 { get; set; }
    }
}