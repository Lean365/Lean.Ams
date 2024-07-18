namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 会计科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:04
    /// </summary>
    public class FicoAccountingTitleQueryDto : PagerInfo
    {
        public string FatCode { get; set; }
        public string FatShortName { get; set; }
        public string FatFullName { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:27:04
    /// </summary>
    public class FicoAccountingTitleDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FatSFID { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FatCode { get; set; }

        [Required(ErrorMessage = "科目简称不能为空")]
        [ExcelColumn(Name = "科目简称")]
        [ExcelColumnName("科目简称")]
        public string FatShortName { get; set; }

        [Required(ErrorMessage = "科目全称不能为空")]
        [ExcelColumn(Name = "科目全称")]
        [ExcelColumnName("科目全称")]
        public string FatFullName { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string FatLangKey { get; set; }

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

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}