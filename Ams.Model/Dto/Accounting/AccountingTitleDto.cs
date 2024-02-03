
namespace Ams.Model.Dto
{
    /// <summary>
    /// 会计科目
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class AccountingTitleQueryDto : PagerInfo 
    {
        public string FatCode { get; set; }
        public string FatShortName { get; set; }
        public string FatFullName { get; set; }
    }

    /// <summary>
    /// 会计科目
    /// 输入输出对象
    /// </summary>
    public class AccountingTitleDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        [ExcelColumn(Name = "SFID")]
        [ExcelColumnName("SFID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FatSFID { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FatCode { get; set; }

        [Required(ErrorMessage = "科目简称不能为空")]
        [ExcelColumn(Name = "科目简称")]
        [ExcelColumnName("科目简称")]
        public string FatShortName { get; set; }

        [Required(ErrorMessage = "科目全称不能为空")]
        [ExcelColumn(Name = "科目全称")]
        [ExcelColumnName("科目全称")]
        public string FatFullName { get; set; }

        [Required(ErrorMessage = "语言不能为空")]
        [ExcelColumn(Name = "语言")]
        [ExcelColumnName("语言")]
        public string FatLangKey { get; set; }

        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int? IsDeleted { get; set; }

        [ExcelColumn(Name = "说明")]
        [ExcelColumnName("说明")]
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



    }
}