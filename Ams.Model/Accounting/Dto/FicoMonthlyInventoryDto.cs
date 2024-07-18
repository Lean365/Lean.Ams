namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 月度存货
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:45:33
    /// </summary>
    public class FicoMonthlyInventoryQueryDto : PagerInfo
    {
        public string MiPlant { get; set; }
        public string MiYm { get; set; }
        public string MiValType { get; set; }
    }

    /// <summary>
    /// 月度存货
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 11:45:33
    /// </summary>
    public class FicoMonthlyInventoryDto
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

        [ExcelColumn(Name = "工厂")]
        public string MiPlantLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string MiYmLabel { get; set; }

        [ExcelColumn(Name = "评估类")]
        public string MiValTypeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}