namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// KPI
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:44:18
    /// </summary>
    public class InstKpiQueryDto : PagerInfo
    {
        public string IkAbbrName { get; set; }
        public string IkAnnual { get; set; }
    }

    /// <summary>
    /// KPI
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:44:18
    /// </summary>
    public class InstKpiDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IkSFID { get; set; }

        [Required(ErrorMessage = "公司简称不能为空")]
        [ExcelColumn(Name = "公司简称")]
        [ExcelColumnName("公司简称")]
        public string IkAbbrName { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string IkAnnual { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IkLangKey { get; set; }

        [Required(ErrorMessage = "目标不能为空")]
        [ExcelColumn(Name = "目标")]
        [ExcelColumnName("目标")]
        public string IkTarget { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "公司简称")]
        public string IkAbbrNameLabel { get; set; }

        [ExcelColumn(Name = "财年")]
        public string IkAnnualLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// KPI
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 9:44:18
    /// </summary>
    public class InstKpiImportTpl
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IkSFID { get; set; }

        [Required(ErrorMessage = "公司简称不能为空")]
        [ExcelColumn(Name = "公司简称")]
        [ExcelColumnName("公司简称")]
        public string IkAbbrName { get; set; }

        [Required(ErrorMessage = "财年不能为空")]
        [ExcelColumn(Name = "财年")]
        [ExcelColumnName("财年")]
        public string IkAnnual { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IkLangKey { get; set; }

        [Required(ErrorMessage = "目标不能为空")]
        [ExcelColumn(Name = "目标")]
        [ExcelColumnName("目标")]
        public string IkTarget { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "公司简称")]
        public string IkAbbrNameLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "财年")]
        public string IkAnnualLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}