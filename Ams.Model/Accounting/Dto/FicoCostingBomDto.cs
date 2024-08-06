
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// bom成本核算
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:24
    /// </summary>
    public class FicoCostingBomQueryDto : PagerInfo 
    {
        public string BcPlant { get; set; }
        public string BcFy { get; set; }
        public string BcYm { get; set; }
        public string BcBomItem { get; set; }
        public string BcCurrency { get; set; }
    }

    /// <summary>
    /// bom成本核算
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:24
    /// </summary>
    public class FicoCostingBomDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long BcSfId { get; set; }

        [ExcelColumn(Name = "工厂 ")]
        [ExcelColumnName("工厂 ")]
        public string BcPlant { get; set; }

        [ExcelColumn(Name = "期间 ")]
        [ExcelColumnName("期间 ")]
        public string BcFy { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string BcYm { get; set; }

        [ExcelColumn(Name = "成品物料 ")]
        [ExcelColumnName("成品物料 ")]
        public string BcBomItem { get; set; }

        [ExcelColumn(Name = "物料文本 ")]
        [ExcelColumnName("物料文本 ")]
        public string BcItemText { get; set; }

        [ExcelColumn(Name = "成本 ")]
        [ExcelColumnName("成本 ")]
        public decimal BcBomCost { get; set; }

        [ExcelColumn(Name = "币种 ")]
        [ExcelColumnName("币种 ")]
        public string BcCurrency { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? BcBalancedate { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
        public decimal REF06 { get; set; }

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

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "工厂 ")]
        public string BcPlantLabel { get; set; }
        [ExcelColumn(Name = "期间 ")]
        public string BcFyLabel { get; set; }
        [ExcelColumn(Name = "年月 ")]
        public string BcYmLabel { get; set; }
        [ExcelColumn(Name = "币种 ")]
        public string BcCurrencyLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// bom成本核算
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:24
    /// </summary>
    public class FicoCostingBomImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long BcSfId { get; set; }

        [ExcelColumn(Name = "工厂 ")]
        [ExcelColumnName("工厂 ")]
        public string BcPlant { get; set; }

        [ExcelColumn(Name = "期间 ")]
        [ExcelColumnName("期间 ")]
        public string BcFy { get; set; }

        [ExcelColumn(Name = "年月 ")]
        [ExcelColumnName("年月 ")]
        public string BcYm { get; set; }

        [ExcelColumn(Name = "成品物料 ")]
        [ExcelColumnName("成品物料 ")]
        public string BcBomItem { get; set; }

        [ExcelColumn(Name = "物料文本 ")]
        [ExcelColumnName("物料文本 ")]
        public string BcItemText { get; set; }

        [ExcelColumn(Name = "成本 ")]
        [ExcelColumnName("成本 ")]
        public decimal BcBomCost { get; set; }

        [ExcelColumn(Name = "币种 ")]
        [ExcelColumnName("币种 ")]
        public string BcCurrency { get; set; }

        [ExcelColumn(Name = "核算日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("核算日期")]
        public DateTime? BcBalancedate { get; set; }

        [ExcelColumn(Name = "预留A ")]
        [ExcelColumnName("预留A ")]
        public string REF01 { get; set; }

        [ExcelColumn(Name = "预留B ")]
        [ExcelColumnName("预留B ")]
        public string REF02 { get; set; }

        [ExcelColumn(Name = "预留C ")]
        [ExcelColumnName("预留C ")]
        public string REF03 { get; set; }

        [ExcelColumn(Name = "预留1 ")]
        [ExcelColumnName("预留1 ")]
        public decimal REF04 { get; set; }

        [ExcelColumn(Name = "预留2 ")]
        [ExcelColumnName("预留2 ")]
        public decimal REF05 { get; set; }

        [ExcelColumn(Name = "预留3")]
        [ExcelColumnName("预留3")]
        public decimal REF06 { get; set; }

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

        [ExcelIgnore]
        public int? UDF51 { get; set; }

        [ExcelIgnore]
        public int? UDF52 { get; set; }

        [ExcelIgnore]
        public int? UDF53 { get; set; }

        [ExcelIgnore]
        public decimal UDF54 { get; set; }

        [ExcelIgnore]
        public decimal UDF55 { get; set; }

        [ExcelIgnore]
        public decimal UDF56 { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注说明")]
        [ExcelColumnName("备注说明")]
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
        [ExcelColumn(Name = "工厂 ")]
        public string BcPlantLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "期间 ")]
        public string BcFyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "年月 ")]
        public string BcYmLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "币种 ")]
        public string BcCurrencyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}