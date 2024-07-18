namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// bom成本核算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:12
    /// </summary>
    public class FicoBomCostingQueryDto : PagerInfo
    {
        public string BcPlant { get; set; }
        public string BcYm { get; set; }
        public string BcBomItem { get; set; }
        public string BcCurrency { get; set; }
        public DateTime? BeginBcBalancedate { get; set; }
        public DateTime? EndBcBalancedate { get; set; }
    }

    /// <summary>
    /// bom成本核算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:12
    /// </summary>
    public class FicoBomCostingDto
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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "工厂")]
        public string BcPlantLabel { get; set; }

        [ExcelColumn(Name = "年月")]
        public string BcYmLabel { get; set; }

        [ExcelColumn(Name = "币种")]
        public string BcCurrencyLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// bom成本核算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/18 16:26:12
    /// </summary>
    public class FicoBomCostingImportTpl
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

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "工厂")]
        public string BcPlantLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "年月")]
        public string BcYmLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "币种")]
        public string BcCurrencyLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}