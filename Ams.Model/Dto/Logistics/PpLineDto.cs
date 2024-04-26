
namespace Ams.Model.Dto
{
    /// <summary>
    /// 生产班组
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: 2024/4/25 17:15:19
    /// </summary>

    public class PpLineQueryDto : PagerInfo 
    {
        /// <summary>
        /// 班组类别 
        /// </summary>
        public string PlLineType { get; set; }
        /// <summary>
        /// 班组代码 
        /// </summary>
        public string PlLineCode { get; set; }
        /// <summary>
        /// 语言Key 
        /// </summary>
        public string PlLineLangCode { get; set; }
        /// <summary>
        /// 班组名称 
        /// </summary>
        public string PlLineName { get; set; }
    }

    /// <summary>
    /// 生产班组
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: 2024/4/25 17:15:19
    /// </summary>
    public class PpLineDto
    {
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long? PlSFID { get; set; }

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
        [ExcelColumn(Name = "班组类别")]
        public string PlLineTypeLabel { get; set; }
        [ExcelIgnore]
        [ExcelColumn(Name = "语言Key")]
        public string PlLineLangCodeLabel { get; set; }
    }
}