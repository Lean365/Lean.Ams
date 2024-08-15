namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 生产班组
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:45:07
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
    /// @Date: 2024/7/26 14:45:07
    /// </summary>
    public class PpLineDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PlSfId { get; set; }

        [Required(ErrorMessage = "班组类别不能为空")]
        [ExcelColumn(Name = "班组类别")]
        [ExcelColumnName("班组类别")]
        public string PlLineType { get; set; }

        [Required(ErrorMessage = "班组代码不能为空")]
        [ExcelColumn(Name = "班组代码")]
        [ExcelColumnName("班组代码")]
        public string PlLineCode { get; set; }

        [Required(ErrorMessage = "翻译Key不能为空")]
        [ExcelColumn(Name = "翻译Key")]
        [ExcelColumnName("翻译Key")]
        public string PlLineLangCode { get; set; }

        [Required(ErrorMessage = "班组名称不能为空")]
        [ExcelColumn(Name = "班组名称")]
        [ExcelColumnName("班组名称")]
        public string PlLineName { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }

        [ExcelColumn(Name = "班组类别")]
        public string PlLineTypeLabel { get; set; }

        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 生产班组
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 14:45:07
    /// </summary>
    public class PpLineImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long PlSfId { get; set; }

        [Required(ErrorMessage = "班组类别不能为空")]
        [ExcelColumn(Name = "班组类别")]
        [ExcelColumnName("班组类别")]
        public string PlLineType { get; set; }

        [Required(ErrorMessage = "班组代码不能为空")]
        [ExcelColumn(Name = "班组代码")]
        [ExcelColumnName("班组代码")]
        public string PlLineCode { get; set; }

        [Required(ErrorMessage = "翻译Key不能为空")]
        [ExcelColumn(Name = "翻译Key")]
        [ExcelColumnName("翻译Key")]
        public string PlLineLangCode { get; set; }

        [Required(ErrorMessage = "班组名称不能为空")]
        [ExcelColumn(Name = "班组名称")]
        [ExcelColumnName("班组名称")]
        public string PlLineName { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
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
        [ExcelColumn(Name = "班组类别")]
        public string PlLineTypeLabel { get; set; }

        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}