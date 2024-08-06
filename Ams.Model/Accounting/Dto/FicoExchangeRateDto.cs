
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 汇率表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:18
    /// </summary>
    public class FicoExchangeRateQueryDto : PagerInfo 
    {
        public string FerCorp { get; set; }
        public DateTime? BeginFerEffDate { get; set; }
        public DateTime? EndFerEffDate { get; set; }
        public string FerfmCcy { get; set; }
        public string FertoCcy { get; set; }
    }

    /// <summary>
    /// 汇率表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:18
    /// </summary>
    public class FicoExchangeRateDto
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FerSfId { get; set; }

        [ExcelColumn(Name = "公司 ")]
        [ExcelColumnName("公司 ")]
        public string FerCorp { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FerEffDate { get; set; }

        [ExcelColumn(Name = "基数 ")]
        [ExcelColumnName("基数 ")]
        public int? FerStd { get; set; }

        [ExcelColumn(Name = "从币种 ")]
        [ExcelColumnName("从币种 ")]
        public string FerfmCcy { get; set; }

        [ExcelColumn(Name = "汇率 ")]
        [ExcelColumnName("汇率 ")]
        public decimal FerRate { get; set; }

        [ExcelColumn(Name = "到币种 ")]
        [ExcelColumnName("到币种 ")]
        public string FertoCcy { get; set; }

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



        [ExcelColumn(Name = "公司 ")]
        public string FerCorpLabel { get; set; }
        [ExcelColumn(Name = "从币种 ")]
        public string FerfmCcyLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 汇率表
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/8/5 16:43:18
    /// </summary>
    public class FicoExchangeRateImportTpl
    {
        [Required(ErrorMessage = "ID不能为空")]
        [ExcelColumn(Name = "ID")]
        [ExcelColumnName("ID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FerSfId { get; set; }

        [ExcelColumn(Name = "公司 ")]
        [ExcelColumnName("公司 ")]
        public string FerCorp { get; set; }

        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FerEffDate { get; set; }

        [ExcelColumn(Name = "基数 ")]
        [ExcelColumnName("基数 ")]
        public int? FerStd { get; set; }

        [ExcelColumn(Name = "从币种 ")]
        [ExcelColumnName("从币种 ")]
        public string FerfmCcy { get; set; }

        [ExcelColumn(Name = "汇率 ")]
        [ExcelColumnName("汇率 ")]
        public decimal FerRate { get; set; }

        [ExcelColumn(Name = "到币种 ")]
        [ExcelColumnName("到币种 ")]
        public string FertoCcy { get; set; }

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
        [ExcelColumn(Name = "公司 ")]
        public string FerCorpLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "从币种 ")]
        public string FerfmCcyLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}