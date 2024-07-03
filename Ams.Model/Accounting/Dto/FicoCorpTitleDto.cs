
namespace Ams.Model.Accounting.Dto
{
    /// <summary>
    /// 公司科目
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/3 15:41:55
    /// </summary>
    public class FicoCorpTitleQueryDto : PagerInfo 
    {
        public string FctCorp { get; set; }
        public string FctCode { get; set; }
    }

    /// <summary>
    /// 公司科目
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/7/3 15:41:55
    /// </summary>
    public class FicoCorpTitleDto
    {
        [Required(ErrorMessage = "FSID不能为空")]
        [ExcelColumn(Name = "FSID")]
        [ExcelColumnName("FSID")]
        [JsonConverter(typeof(ValueToStringConverter))]
        public long FctSFID { get; set; }

        [Required(ErrorMessage = "公司代码不能为空")]
        [ExcelColumn(Name = "公司代码")]
        [ExcelColumnName("公司代码")]
        public string FctCorp { get; set; }

        [Required(ErrorMessage = "科目代码不能为空")]
        [ExcelColumn(Name = "科目代码")]
        [ExcelColumnName("科目代码")]
        public string FctCode { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        [ExcelColumn(Name = "软删除")]
        [ExcelColumnName("软删除")]
        public int IsDeleted { get; set; }

        [ExcelColumn(Name = "备注")]
        [ExcelColumnName("备注")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "创建者")]
        [ExcelColumnName("创建者")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelColumn(Name = "更新者")]
        [ExcelColumnName("更新者")]
        public string UpdateBy { get; set; }

        [ExcelColumn(Name = "更新时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("更新时间")]
        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "公司代码")]
        public string FctCorpLabel { get; set; }
        [ExcelColumn(Name = "软删除")]
        public string IsDeletedLabel { get; set; }
    }
}