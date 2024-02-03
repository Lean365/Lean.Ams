
namespace Ams.Model.Dto
{
    /// <summary>
    /// bom成本核算
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 10:37:37)
    /// </summary>
    public class BomCostingQueryDto : PagerInfo 
    {
        public string BcPlant { get; set; }
        public string BcYm { get; set; }
        public string BcBomItem { get; set; }
        public string BcCurrency { get; set; }
    }

    /// <summary>
    /// bom成本核算
    /// 输入输出对象
    /// </summary>
    public class BomCostingDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long BcSFID { get; set; }

        [Required(ErrorMessage = "工厂不能为空")]
        [ExcelColumn(Name = "工厂")]
        [ExcelColumnName("工厂")]
        public string BcPlant { get; set; }

        [Required(ErrorMessage = "期间不能为空")]
        [ExcelColumn(Name = "期间")]
        [ExcelColumnName("期间")]
        public string BcFy { get; set; }

        [Required(ErrorMessage = "年月不能为空")]
        [ExcelColumn(Name = "年月")]
        [ExcelColumnName("年月")]
        public string BcYm { get; set; }

        [Required(ErrorMessage = "成品物料不能为空")]
        [ExcelColumn(Name = "成品物料")]
        [ExcelColumnName("成品物料")]
        public string BcBomItem { get; set; }

        [Required(ErrorMessage = "物料文本不能为空")]
        [ExcelColumn(Name = "物料文本")]
        [ExcelColumnName("物料文本")]
        public string BcItemText { get; set; }

        [Required(ErrorMessage = "成本不能为空")]
        [ExcelColumn(Name = "成本")]
        [ExcelColumnName("成本")]
        public decimal BcBomCost { get; set; }

        [Required(ErrorMessage = "币种不能为空")]
        [ExcelColumn(Name = "币种")]
        [ExcelColumnName("币种")]
        public string BcCurrency { get; set; }

        [Required(ErrorMessage = "核算日期不能为空")]
        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? BcBalancedate { get; set; }

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
        [ExcelColumn(Name = "工厂")]
        public string BcPlantLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "期间")]
        public string BcFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string BcYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "成品物料")]
        public string BcBomItemLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string BcCurrencyLabel { get; set; }
    }
}