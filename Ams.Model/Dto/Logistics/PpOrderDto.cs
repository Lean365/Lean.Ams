
namespace Ams.Model.Dto
{
    /// <summary>
    /// 生产工单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/23 17:16:30
    /// </summary>
    public class PpOrderQueryDto : PagerInfo 
    {
        public string MoPlant { get; set; }
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
    /// @Date: 2024/5/23 17:16:30
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
        public int IsStated { get; set; }

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
        [ExcelColumn(Name = "物料")]
        public string MoOrderItemLabel { get; set; }
    }
    /// <summary>
    /// 生产工单
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/5/23 17:16:30
    /// </summary>
    public class PpOrderImportTpl
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
        public int IsStated { get; set; }

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
        [ExcelColumn(Name = "物料")]
        public string MoOrderItemLabel { get; set; }
    }

}