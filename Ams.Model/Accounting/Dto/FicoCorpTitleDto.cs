namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 公司科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:58
    /// </summary>
    public class FicoCorpTitleQueryDto : PagerInfo
    {
        public string FctCorp { get; set; }
        public string FctCode { get; set; }
    }

    /// <summary>
    /// 公司科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 10:26:58
    /// </summary>
    public class FicoCorpTitleDto
    {
        [Required(ErrorMessage = "FSID不能为空")]
        [ExcelColumn(Name = "FSID")]
        [ExcelColumnName("FSID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FctSFID { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string FctCorp { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FctCode { get; set; }

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

        [ExcelColumn(Name = "公司代码")]
        public string FctCorpLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}