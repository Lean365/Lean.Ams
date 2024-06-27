
namespace Ams.Model.Logistics.Dto
{
    /// <summary>
    /// 生产班组查询对象
    /// </summary>
    public class PpLineQueryDto : PagerInfo 
    {
    }

    /// <summary>
    /// 生产班组输入输出对象
    /// </summary>
    public class PpLineDto
    {
        [Required(ErrorMessage = "SFID不能为空")]
        public long PlSFID { get; set; }

        [Required(ErrorMessage = "班组类别不能为空")]
        public string PlLineType { get; set; }

        [Required(ErrorMessage = "班组代码不能为空")]
        public string PlLineCode { get; set; }

        [Required(ErrorMessage = "语言Key不能为空")]
        public string PlLineLangCode { get; set; }

        [Required(ErrorMessage = "班组名称不能为空")]
        public string PlLineName { get; set; }

        [Required(ErrorMessage = "软删除不能为空")]
        public int IsDeleted { get; set; }

        public string Remark { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }



        [ExcelColumn(Name = "班组类别")]
        public string PlLineTypeLabel { get; set; }
    }
}