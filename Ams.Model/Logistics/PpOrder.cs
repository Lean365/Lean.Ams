namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产工单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:07:48
    /// </summary>
    [SugarTable("pp_order", "生产工单")]
    public class PpOrder : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MoSfId { get; set; }

        /// <summary>
        /// 生产工厂
        /// </summary>
        [SugarColumn(ColumnName = "MoPlant", ColumnDescription = "生产工厂 ", Length = 4)]
        public string MoPlant { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        [SugarColumn(ColumnName = "MoType", ColumnDescription = "订单类型 ", Length = 4)]
        public string MoType { get; set; }

        /// <summary>
        /// 订单号码
        /// </summary>
        [SugarColumn(ColumnName = "MoNumber", ColumnDescription = "订单号码 ", Length = 7)]
        public string MoNumber { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        [SugarColumn(ColumnName = "MoItem", ColumnDescription = "物料 ", Length = 20)]
        public string MoItem { get; set; }

        /// <summary>
        /// 生产批次
        /// </summary>
        [SugarColumn(ColumnName = "MoLot", ColumnDescription = "生产批次 ", Length = 20)]
        public string MoLot { get; set; }

        /// <summary>
        /// 工单数量
        /// </summary>
        [SugarColumn(ColumnName = "MoPlanQty", ColumnDescription = "工单数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MoPlanQty { get; set; }

        /// <summary>
        /// 生产数量
        /// </summary>
        [SugarColumn(ColumnName = "MoProdQty", ColumnDescription = "生产数量 ", DefaultValue = "0", Length = 18, DecimalDigits = 2)]
        public decimal MoProdQty { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? MorDate { get; set; }

        /// <summary>
        /// 工艺路线
        /// </summary>
        [SugarColumn(ColumnName = "MoRoute", ColumnDescription = "工艺路线 ", Length = 8)]
        public string MoRoute { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [SugarColumn(ColumnName = "MoSerial", ColumnDescription = "序列号 ", Length = 50)]
        public string MoSerial { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [SugarColumn(ColumnName = "IsStatus", ColumnDescription = "状态 ", DefaultValue = "0")]
        public int IsStatus { get; set; }
    }
}