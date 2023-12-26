
namespace Ams.Model.Dto
{
    /// <summary>
    /// 会计科目
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2023/12/26 7:53:53)
    /// </summary>
    public class FicoAccountingTitleQueryDto : PagerInfo 
    {
        public string FtCorpCode { get; set; }
        public string FtTitleCode { get; set; }
        public string FtTitleName { get; set; }
        public string FtTitleLang { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 输入输出对象
    /// </summary>
    public class FicoAccountingTitleDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FtSFID { get; set; }

        [Required(ErrorMessage = "公司名称不能为空")]
        [ExcelColumn(Name = "公司名称")]
        [ExcelColumnName("公司名称")]
        public string FtCorpCode { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FtTitleCode { get; set; }

        [Required(ErrorMessage = "科目名称不能为空")]
        [ExcelColumn(Name = "科目名称")]
        [ExcelColumnName("科目名称")]
        public string FtTitleName { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string FtTitleLang { get; set; }

        [ExcelIgnore]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
        public string Remark { get; set; }

        [ExcelIgnore]
        public DateTime? CreateTime { get; set; }

        [ExcelIgnore]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "更新者")]
        [ExcelColumnName("更新者")]
        public string UpdateBy { get; set; }

        [ExcelIgnore]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "公司名称")]
        public string FtCorpCodeLabel { get; set; }
        [ExcelColumn(Name = "语言")]
        public string FtTitleLangLabel { get; set; }
    }
}