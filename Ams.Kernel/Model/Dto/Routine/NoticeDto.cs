using System.ComponentModel.DataAnnotations;
using Ams.Model;
using MiniExcelLibs.Attributes;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 通知公告
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class NoticeQueryDto : PagerInfo
    {
        public string NoticeTitle { get; set; }
        public int? NoticeType { get; set; }
        public string CreateBy { get; set; }
        public int? IsStated { get; set; }
    }

    /// <summary>
    /// 通知公告
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class NoticeDto
    {
        //[Required(ErrorMessage = "公告ID不能为空")]
        [ExcelColumn(Name = "公告ID")]
        [ExcelColumnName("公告ID")]
        public int NoticeId { get; set; }

        [Required(ErrorMessage = "公告标题不能为空")]
        [ExcelColumn(Name = "公告标题", Width = 40)]
        [ExcelColumnName("公告标题")]
        public string NoticeTitle { get; set; }

        [Required(ErrorMessage = "公告类型不能为空")]
        [ExcelColumn(Name = "公告类型", Ignore = true)]
        [ExcelColumnName("公告类型")]
        public int NoticeType { get; set; }

        [ExcelColumn(Name = "公告内容", Width = 80)]
        [ExcelColumnName("公告内容")]
        public string NoticeContent { get; set; }

        [Required(ErrorMessage = "公告状态 (0正常 1关闭)不能为空")]
        [ExcelColumn(Name = "公告状态", Ignore = true)]
        [ExcelColumnName("公告状态")]
        public int IsStated { get; set; }

        [ExcelColumn(Name = "创建人")]
        [ExcelColumnName("创建人")]
        public string CreateBy { get; set; }

        [ExcelColumn(Name = "创建时间", Format = "yyyy-MM-dd HH:mm:ss", Width = 20)]
        [ExcelColumnName("创建时间")]
        public DateTime? CreateTime { get; set; }

        [ExcelColumn(Name = "Remark")]
        [ExcelColumnName("Remark")]
        public string Remark { get; set; }

        [ExcelColumn(Name = "公告类型")]
        public string NoticeTypeLabel { get; set; }

        [ExcelColumn(Name = "公告状态")]
        public string StatusLabel { get; set; }

        [ExcelColumn(Name = "开始时间")]
        public DateTime BeginTime { get; set; }

        [ExcelColumn(Name = "结束时间")]
        public DateTime EndTime { get; set; }

        [ExcelColumn(Name = "发布者")]
        public string Publisher { get; set; }
    }
}