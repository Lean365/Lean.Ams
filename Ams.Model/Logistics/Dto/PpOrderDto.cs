namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 生产工单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:49
    /// </summary>
    public class PpOrderQueryDto : PagerInfo
    {
        public string MoOrderType { get; set; }
        public string MoOrderNo { get; set; }
        public string MoOrderItem { get; set; }
        public string MoOrderlot { get; set; }
        public DateTime? BeginMoOrderDate { get; set; }
        public DateTime? EndMoOrderDate { get; set; }
    }

    /// <summary>
    /// 生产工单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:49
    /// </summary>
    public class PpOrderDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MoSFID { get; set; }

        [Required(ErrorMessage = "生产工厂不能为空")]
        [ExcelColumn(Name = "生产工厂")]
        [ExcelColumnName("生产工厂")]
        public string MoPlant { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        [ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]
        public string MoOrderType { get; set; }

        [Required(ErrorMessage = "生产订单不能为空")]
        [ExcelColumn(Name = "生产订单")]
        [ExcelColumnName("生产订单")]
        public string MoOrderNo { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MoOrderItem { get; set; }

        [ExcelColumn(Name = "批次")]
        [ExcelColumnName("批次")]
        public string MoOrderlot { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal MoOrderQty { get; set; }

        [Required(ErrorMessage = "生产数量不能为空")]
        [ExcelColumn(Name = "生产数量")]
        [ExcelColumnName("生产数量")]
        public decimal MoOrderProQty { get; set; }

        [Required(ErrorMessage = "订单日期不能为空")]
        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("订单日期")]
        public DateTime? MoOrderDate { get; set; }

        [ExcelColumn(Name = "工艺路线")]
        [ExcelColumnName("工艺路线")]
        public string MoOrderRoute { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string MoOrderSerial { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public int IsStatus { get; set; }

        [ExcelIgnore]
        public string UDF01 { get; set; }

        [ExcelIgnore]
        public string UDF02 { get; set; }

        [ExcelIgnore]
        public string UDF03 { get; set; }

        [ExcelIgnore]
        public string UDF04 { get; set; }

        [ExcelIgnore]
        public string UDF05 { get; set; }

        [ExcelIgnore]
        public string UDF06 { get; set; }

        [Required(ErrorMessage = "自定义1不能为空")]
        [ExcelIgnore]
        public decimal UDF51 { get; set; }

        [Required(ErrorMessage = "自定义2不能为空")]
        [ExcelIgnore]
        public decimal UDF52 { get; set; }

        [Required(ErrorMessage = "自定义3不能为空")]
        [ExcelIgnore]
        public decimal UDF53 { get; set; }

        [Required(ErrorMessage = "自定义4不能为空")]
        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [Required(ErrorMessage = "自定义5不能为空")]
        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [Required(ErrorMessage = "自定义6不能为空")]
        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "订单类型")]
        public string MoOrderTypeLabel { get; set; }

        [ExcelColumn(Name = "状态")]
        public string IsStatusLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}