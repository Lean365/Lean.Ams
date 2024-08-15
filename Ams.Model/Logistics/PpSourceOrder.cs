namespace Ams.Model.Logistics
{
    /// <summary>
    /// 源订单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 15:20:14
    /// </summary>
    [SugarTable("pp_source_order", "源订单")]
    public class PpSourceOrder : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long SfId { get; set; }

        /// <summary>
        /// 工厂
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma001", ColumnDescription = "工厂 ", Length = 4)]
        public string Cooisma001 { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma009", ColumnDescription = "订单类型 ", Length = 5)]
        public string Cooisma009 { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma002", ColumnDescription = "生产订单 ", Length = 10)]
        public string Cooisma002 { get; set; }

        /// <summary>
        /// 品号
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma003", ColumnDescription = "品号 ", Length = 20)]
        public string Cooisma003 { get; set; }

        /// <summary>
        /// LOT
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma004", ColumnDescription = "LOT ", Length = 40)]
        public string Cooisma004 { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma005", ColumnDescription = "数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Cooisma005 { get; set; }

        /// <summary>
        /// 已生产
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma006", ColumnDescription = "已生产 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal Cooisma006 { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma007", ColumnDescription = "开始日期 ", Length = 8)]
        public string Cooisma007 { get; set; }

        /// <summary>
        /// 作业手顺
        /// </summary>
        [SugarColumn(ColumnName = "Cooisma008", ColumnDescription = "作业手顺 ", Length = 10)]
        public string Cooisma008 { get; set; }
    }
}