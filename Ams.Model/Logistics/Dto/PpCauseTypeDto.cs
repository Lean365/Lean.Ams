namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 原因类别
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 15:57:22
    /// </summary>
    public class PpCauseTypeQueryDto : PagerInfo
    {
        public string CtCauseType { get; set; }
        public string CtCauseText { get; set; }
    }

    /// <summary>
    /// 原因类别
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/16 15:57:22
    /// </summary>
    public class PpCauseTypeDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long CtSFID { get; set; }

        [Required(ErrorMessage = "原因类别不能为空")]
        [ExcelColumn(Name = "原因类别")]
        [ExcelColumnName("原因类别")]
        public string CtCauseType { get; set; }

        [Required(ErrorMessage = "语言Key不能为空")]
        [ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string CtCauseLangCode { get; set; }

        [Required(ErrorMessage = "原因名称不能为空")]
        [ExcelColumn(Name = "原因名称")]
        [ExcelColumnName("原因名称")]
        public string CtCauseText { get; set; }

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

        [ExcelColumn(Name = "原因类别")]
        public string CtCauseTypeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}