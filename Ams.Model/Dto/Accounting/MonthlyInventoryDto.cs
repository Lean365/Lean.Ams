
namespace Ams.Model.Dto
{
    /// <summary>
    /// 月度存货
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 8:20:25)
    /// </summary>
    public class MonthlyInventoryQueryDto : PagerInfo 
    {
        public string MiPlant { get; set; }
        public string MiFy { get; set; }
        public string MiYm { get; set; }
        public string MiItem { get; set; }
        public string MiValType { get; set; }
        public string MiLocalCcy { get; set; }
    }

    /// <summary>
    /// 月度存货
    /// 输入输出对象
    /// </summary>
    public class MonthlyInventoryDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long MiSFID { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string MiPlant { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string MiFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string MiYm { get; set; }

        [Required(ErrorMessage = "物料不能为空")]
        [ExcelColumn(Name = "物料")]
        [ExcelColumnName("物料")]
        public string MiItem { get; set; }

        [Required(ErrorMessage = "评估类不能为空")]
        [ExcelColumn(Name = "评估类")]
        [ExcelColumnName("评估类")]
        public string MiValType { get; set; }

        [Required(ErrorMessage = "价格控制不能为空")]
        [ExcelColumn(Name = "价格控制")]
        [ExcelColumnName("价格控制")]
        public string MiPriceControl { get; set; }

        [Required(ErrorMessage = "移动平均价不能为空")]
        [ExcelColumn(Name = "移动平均价")]
        [ExcelColumnName("移动平均价")]
        public decimal MiMovingAverage { get; set; }

        [Required(ErrorMessage = "Per单位不能为空")]
        [ExcelColumn(Name = "Per单位")]
        [ExcelColumnName("Per单位")]
        public int MiPerUnit { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string MiLocalCcy { get; set; }

        [Required(ErrorMessage = "库存不能为空")]
        [ExcelColumn(Name = "库存")]
        [ExcelColumnName("库存")]
        public decimal MiInventoryQty { get; set; }

        [Required(ErrorMessage = "金额不能为空")]
        [ExcelColumn(Name = "金额")]
        [ExcelColumnName("金额")]
        public decimal MiInventoryAmount { get; set; }

        [Required(ErrorMessage = "登录日期不能为空")]
        [ExcelColumn(Name = "登录日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("登录日期")]
        public DateTime? MiBalancedate { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
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
        [ExcelColumn(Name = "工厂")]
        public string MiPlantLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string MiFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string MiYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "物料")]
        public string MiItemLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "评估类")]
        public string MiValTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string MiLocalCcyLabel { get; set; }
    }
}