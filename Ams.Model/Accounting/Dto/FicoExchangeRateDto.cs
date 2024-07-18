namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 汇率表
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:55
    /// </summary>
    public class FicoExchangeRateQueryDto : PagerInfo
    {
        public string FerCorp { get; set; }
        public DateTime? BeginFerEffDate { get; set; }
        public DateTime? EndFerEffDate { get; set; }
        public int? FerStd { get; set; }
        public string FerfmCcy { get; set; }
        public decimal? FerRate { get; set; }
    }

    /// <summary>
    /// 汇率表
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:55
    /// </summary>
    public class FicoExchangeRateDto
    {
        [Required(ErrorMessage = "FSID不能为空")]
        [ExcelColumn(Name = "FSID")]
        [ExcelColumnName("FSID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FerSFID { get; set; }

        [Required(ErrorMessage = "公司不能为空")]
        [ExcelColumn(Name = "公司")]
        [ExcelColumnName("公司")]
        public string FerCorp { get; set; }

        [Required(ErrorMessage = "日期不能为空")]
        [ExcelColumn(Name = "日期", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("日期")]
        public DateTime? FerEffDate { get; set; }

        [Required(ErrorMessage = "基数不能为空")]
        [ExcelColumn(Name = "基数")]
        [ExcelColumnName("基数")]
        public int FerStd { get; set; }

        [Required(ErrorMessage = "从币种不能为空")]
        [ExcelColumn(Name = "从币种")]
        [ExcelColumnName("从币种")]
        public string FerfmCcy { get; set; }

        [Required(ErrorMessage = "汇率不能为空")]
        [ExcelColumn(Name = "汇率")]
        [ExcelColumnName("汇率")]
        public decimal FerRate { get; set; }

        [Required(ErrorMessage = "到币种不能为空")]
        [ExcelColumn(Name = "到币种")]
        [ExcelColumnName("到币种")]
        public string FertoCcy { get; set; }

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

        [ExcelColumn(Name = "公司")]
        public string FerCorpLabel { get; set; }

        [ExcelColumn(Name = "从币种")]
        public string FerfmCcyLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}