namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 通知公告输入对象
    /// </summary>
    public class NoticeStorageDto : SysBase
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

        [ExcelColumn(Name = "附件", Width = 80)]
        [ExcelColumnName("附件")]
        public string FileUrl { get; set; }

        [Required(ErrorMessage = "公告状态 (0正常 1关闭)不能为空")]
        [ExcelColumn(Name = "公告状态", Ignore = true)]
        [ExcelColumnName("公告状态")]
        public int IsStatus { get; set; }

        [ExcelColumn(Name = "公告类型")]
        public string NoticeTypeLabel { get; set; }

        [ExcelColumn(Name = "公告状态")]
        public string StatusLabel { get; set; }

        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Publisher { get; set; }
        public int Popup { get; set; }
    }

    /// <summary>
    /// 通知公告查询对象
    /// </summary>
    public class NoticeStorageQueryDto : PagerInfo
    {
        public string NoticeTitle { get; set; }
        public int? NoticeType { get; set; }
        public string CreateBy { get; set; }
        public int? IsStatus { get; set; }
    }
}