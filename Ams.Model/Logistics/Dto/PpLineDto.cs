namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 生产班组
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/4 14:19:52
    /// </summary>
    public class PpLineQueryDto : PagerInfo
    {
        public string PlLineType { get; set; }
        public string PlLineCode { get; set; }
        public string PlLineName { get; set; }
    }

    /// <summary>
    /// 生产班组
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/4 14:19:52
    /// </summary>
    public class PpLineDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PlSFID { get; set; }

        [Required(ErrorMessage = "班组类别不能为空")]
        [ExcelColumn(Name = "班组类别")]
        [ExcelColumnName("班组类别")]
        public string PlLineType { get; set; }

        [Required(ErrorMessage = "班组代码不能为空")]
        [ExcelColumn(Name = "班组代码")]
        [ExcelColumnName("班组代码")]
        public string PlLineCode { get; set; }

        [Required(ErrorMessage = "语言Key不能为空")]
        [ExcelColumn(Name = "语言Key")]
        [ExcelColumnName("语言Key")]
        public string PlLineLangCode { get; set; }

        [Required(ErrorMessage = "班组名称不能为空")]
        [ExcelColumn(Name = "班组名称")]
        [ExcelColumnName("班组名称")]
        public string PlLineName { get; set; }

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

        [ExcelColumn(Name = "班组类别")]
        public string PlLineTypeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}