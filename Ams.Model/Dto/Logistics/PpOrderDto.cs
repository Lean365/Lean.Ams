
namespace Ams.Model.Dto
{
    /// <summary>
    /// 生产工单
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: 2024/4/26 9:04:35
    /// </summary>

    public class PpOrderQueryDto : PagerInfo 
    {
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
        /// 订单日期 
        /// </summary>
        public DateTime? BeginMoOrderDate { get; set; }
        public DateTime? EndMoOrderDate { get; set; }
        /// <summary>
        /// 状态 
        /// </summary>
        public int? IsState { get; set; }
    }

    /// <summary>
    /// 生产工单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: 2024/4/26 9:04:35
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
        public int IsState { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "生产工厂")]
        public string MoPlantLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "订单类型")]
        public string MoOrderTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "状态")]
        public string IsStateLabel { get; set; }
    }
}