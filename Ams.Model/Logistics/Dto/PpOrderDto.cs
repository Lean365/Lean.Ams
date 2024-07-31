
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 生产工单
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:07:48
    /// </summary>
    public class PpOrderQueryDto : PagerInfo 
    {
        public string MoPlant { get; set; }
        public string MoType { get; set; }
        public string MoNumber { get; set; }
        public string MoItem { get; set; }
        public DateTime? BeginMorDate { get; set; }
        public DateTime? EndMorDate { get; set; }
    }

    /// <summary>
    /// 生产工单
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:07:48
    /// </summary>
    public class PpOrderDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MoSfId { get; set; }

        [Required(ErrorMessage = "生产工厂不能为空")]
        [ExcelColumn(Name = "生产工厂")]
        [ExcelColumnName("生产工厂")]
        public string MoPlant { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        [ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]
        public string MoType { get; set; }

        [Required(ErrorMessage = "订单号码不能为空")]
        [ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]
        public string MoNumber { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MoItem { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string MoLot { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal MoPlanQty { get; set; }

        [Required(ErrorMessage = "生产数量不能为空")]
        [ExcelColumn(Name = "生产数量")]
        [ExcelColumnName("生产数量")]
        public decimal MoProdQty { get; set; }

        [Required(ErrorMessage = "订单日期不能为空")]
        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("订单日期")]
        public DateTime? MorDate { get; set; }

        [ExcelColumn(Name = "工艺路线")]
        [ExcelColumnName("工艺路线")]
        public string MoRoute { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string MoSerial { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public int IsStatus { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "生产工厂")]
        public string MoPlantLabel { get; set; }
        [ExcelColumn(Name = "订单类型")]
        public string MoTypeLabel { get; set; }
        [ExcelColumn(Name = "状态")]
        public string IsStatusLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 生产工单
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:07:48
    /// </summary>
    public class PpOrderImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MoSfId { get; set; }

        [Required(ErrorMessage = "生产工厂不能为空")]
        [ExcelColumn(Name = "生产工厂")]
        [ExcelColumnName("生产工厂")]
        public string MoPlant { get; set; }

        [Required(ErrorMessage = "订单类型不能为空")]
        [ExcelColumn(Name = "订单类型")]
        [ExcelColumnName("订单类型")]
        public string MoType { get; set; }

        [Required(ErrorMessage = "订单号码不能为空")]
        [ExcelColumn(Name = "订单号码")]
        [ExcelColumnName("订单号码")]
        public string MoNumber { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MoItem { get; set; }

        [ExcelColumn(Name = "生产批次")]
        [ExcelColumnName("生产批次")]
        public string MoLot { get; set; }

        [Required(ErrorMessage = "工单数量不能为空")]
        [ExcelColumn(Name = "工单数量")]
        [ExcelColumnName("工单数量")]
        public decimal MoPlanQty { get; set; }

        [Required(ErrorMessage = "生产数量不能为空")]
        [ExcelColumn(Name = "生产数量")]
        [ExcelColumnName("生产数量")]
        public decimal MoProdQty { get; set; }

        [Required(ErrorMessage = "订单日期不能为空")]
        [ExcelColumn(Name = "订单日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("订单日期")]
        public DateTime? MorDate { get; set; }

        [ExcelColumn(Name = "工艺路线")]
        [ExcelColumnName("工艺路线")]
        public string MoRoute { get; set; }

        [ExcelColumn(Name = "序列号")]
        [ExcelColumnName("序列号")]
        public string MoSerial { get; set; }

        [Required(ErrorMessage = "状态不能为空")]
        [ExcelColumn(Name = "状态")]
        [ExcelColumnName("状态")]
        public int IsStatus { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
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
        public string MoTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "状态")]
        public string IsStatusLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}