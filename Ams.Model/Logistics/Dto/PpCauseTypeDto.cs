
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 原因类别
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:12:48
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
    /// @Date: 2024/7/26 15:12:48
    /// </summary>
    public class PpCauseTypeDto
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long CtSfId { get; set; }

        [Required(ErrorMessage = "原因类别不能为空")]
        [ExcelColumn(Name = "原因类别")]
        [ExcelColumnName("原因类别")]
        public string CtCauseType { get; set; }

        [Required(ErrorMessage = "翻译Key不能为空")]
        [ExcelColumn(Name = "翻译Key")]
        [ExcelColumnName("翻译Key")]
        public string CtCauseLangCode { get; set; }

        [Required(ErrorMessage = "原因名称不能为空")]
        [ExcelColumn(Name = "原因名称")]
        [ExcelColumnName("原因名称")]
        public string CtCauseText { get; set; }

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



        [ExcelColumn(Name = "原因类别")]
        public string CtCauseTypeLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

    /// <summary>
    /// 原因类别
    /// 导入模板输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/26 15:12:48
    /// </summary>
    public class PpCauseTypeImportTpl
    {
        [Required(ErrorMessage = "SfId不能为空")]
        [ExcelColumn(Name = "SfId")]
        [ExcelColumnName("SfId")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long CtSfId { get; set; }

        [Required(ErrorMessage = "原因类别不能为空")]
        [ExcelColumn(Name = "原因类别")]
        [ExcelColumnName("原因类别")]
        public string CtCauseType { get; set; }

        [Required(ErrorMessage = "翻译Key不能为空")]
        [ExcelColumn(Name = "翻译Key")]
        [ExcelColumnName("翻译Key")]
        public string CtCauseLangCode { get; set; }

        [Required(ErrorMessage = "原因名称不能为空")]
        [ExcelColumn(Name = "原因名称")]
        [ExcelColumnName("原因名称")]
        public string CtCauseText { get; set; }

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
        [ExcelColumn(Name = "原因类别")]
        public string CtCauseTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }

}