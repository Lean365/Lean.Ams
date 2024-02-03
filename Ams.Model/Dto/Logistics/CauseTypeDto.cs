
namespace Ams.Model.Dto
{
    /// <summary>
    /// 原因类别
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 11:54:27)
    /// </summary>
    public class CauseTypeQueryDto : PagerInfo 
    {
        public string CtCauseType { get; set; }
        public string CtCauseText { get; set; }
    }

    /// <summary>
    /// 原因类别
    /// 输入输出对象
    /// </summary>
    public class CauseTypeDto
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

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelIgnore]
        [ExcelColumn(Name = "原因类别")]
        public string CtCauseTypeLabel { get; set; }
    }
}