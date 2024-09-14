namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源订单序列号
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/9/11 13:43:48
    /// </summary>
    [SugarTable("pp_source_order_serial", "源订单序列号")]
    public class PpSourceOrderSerial : SysBase
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
        [SugarColumn(ColumnName = "Zg002", ColumnDescription = "工厂", Length = 4, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zg002 { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "Zg003", ColumnDescription = "生产订单", Length = 10, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zg003 { get; set; }

        /// <summary>
        /// 品号
        /// </summary>
        [SugarColumn(ColumnName = "Zg004", ColumnDescription = "品号", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zg004 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Zg005", ColumnDescription = "序列号", Length = 40, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Zg005 { get; set; }
    }
}