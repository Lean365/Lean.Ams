namespace Ams.Model.Logistics
{
    /// <summary>
    /// 生产工单
    /// 数据实体
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:49
    /// </summary>
    [SugarTable("pp_order", "生产工单")]
    public class PpOrder : SysBase
    {
        /// <summary>
        /// SFID
        /// </summary>
        [JsonConverter(typeof(ValueToStringConverter))]
        [SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public long MoSFID { get; set; }

        /// <summary>
        /// 生产工厂
        /// </summary>
        public string MoPlant { get; set; }

        /// <summary>
        /// 订单类型
        /// </summary>
        public string MoOrderType { get; set; }

        /// <summary>
        /// 生产订单
        /// </summary>
        public string MoOrderNo { get; set; }

        /// <summary>
        /// 物料
        /// </summary>
        public string MoOrderItem { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string MoOrderlot { get; set; }

        /// <summary>
        /// 工单数量
        /// </summary>
        public decimal MoOrderQty { get; set; }

        /// <summary>
        /// 生产数量
        /// </summary>
        public decimal MoOrderProQty { get; set; }

        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? MoOrderDate { get; set; }

        /// <summary>
        /// 工艺路线
        /// </summary>
        public string MoOrderRoute { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        public string MoOrderSerial { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int IsStatus { get; set; }

        /// <summary>
        /// 自定义A
        /// </summary>
        public string UDF01 { get; set; }

        /// <summary>
        /// 自定义B
        /// </summary>
        public string UDF02 { get; set; }

        /// <summary>
        /// 自定义C
        /// </summary>
        public string UDF03 { get; set; }

        /// <summary>
        /// 自定义D
        /// </summary>
        public string UDF04 { get; set; }

        /// <summary>
        /// 自定义E
        /// </summary>
        public string UDF05 { get; set; }

        /// <summary>
        /// 自定义F
        /// </summary>
        public string UDF06 { get; set; }

        /// <summary>
        /// 自定义1
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF51 { get; set; }

        /// <summary>
        /// 自定义2
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF52 { get; set; }

        /// <summary>
        /// 自定义3
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF53 { get; set; }

        /// <summary>
        /// 自定义4
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF54 { get; set; }

        /// <summary>
        /// 自定义5
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF55 { get; set; }

        /// <summary>
        /// 自定义6
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public decimal UDF56 { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsDeleted { get; set; }
    }
}