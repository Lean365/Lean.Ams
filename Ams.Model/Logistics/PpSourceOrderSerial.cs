namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源订单序列号
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:55
    /// </summary>
    [SugarTable("pp_source_order_serial", "源订单序列号")]
    public class PpSourceOrderSerial : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>

        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string SfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Serialc001", ColumnDescription = "工厂 ", Length = 4)]
        public string Serialc001 { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "Serialc002", ColumnDescription = "生产订单 ", Length = 10)]
        public string Serialc002 { get; set; }

        /// <summary>
        /// 品号
        /// </summary>
        [SugarColumn(ColumnName = "Serialc003", ColumnDescription = "品号 ", Length = 20)]
        public string Serialc003 { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "Serialc004", ColumnDescription = "序列号 ", Length = 40)]
        public string Serialc004 { get; set; }
    }
}