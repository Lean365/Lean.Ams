namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 计算公式
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 10:24:50
    /// </summary>
    public class InstFormulaQueryDto : PagerInfo
    {
        public string IfType { get; set; }
    }

    /// <summary>
    /// 计算公式
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 10:24:50
    /// </summary>
    public class InstFormulaDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IfSfId { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string IfType { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IfLangKey { get; set; }

        [Required(ErrorMessage = "公式不能为空")]
        [ExcelColumn(Name = "公式")]
        [ExcelColumnName("公式")]
        public string IfFormula { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "类别")]
        public string IfTypeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 计算公式
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/17 10:24:50
    /// </summary>
    public class InstFormulaImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long IfSfId { get; set; }

        [Required(ErrorMessage = "类别不能为空")]
        [ExcelColumn(Name = "类别")]
        [ExcelColumnName("类别")]
        public string IfType { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string IfLangKey { get; set; }

        [Required(ErrorMessage = "公式不能为空")]
        [ExcelColumn(Name = "公式")]
        [ExcelColumnName("公式")]
        public string IfFormula { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "类别")]
        public string IfTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}