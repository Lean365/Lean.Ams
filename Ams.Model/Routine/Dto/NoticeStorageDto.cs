namespace Ams.Model.Routine.Dto
{
    /// <summary>
    /// 通知公告表查询对象
    /// </summary>
    public class NoticeStorageQueryDto : PagerInfo
    {
        public string NoticeTitle { get; set; }
        public int? NoticeType { get; set; }
        public string CreateBy { get; set; }
        public int? IsStatus { get; set; }
    }

    /// <summary>
    /// 通知公告表输入对象
    /// </summary>
    public class NoticeStorageDto
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
        //[Required(ErrorMessage = "公告附件不能为空")]
        [ExcelColumn(Name = "公告附件", Width = 40)]
        [ExcelColumnName("公告附件")]
        public string FileUrl { get; set; }

        [ExcelColumn(Name = "公告内容", Width = 80)]
        [ExcelColumnName("公告内容")]
        public string NoticeContent { get; set; }

        [Required(ErrorMessage = "公告状态 (0正常 1关闭)不能为空")]
        [ExcelColumn(Name = "公告状态", Ignore = true)]
        [ExcelColumnName("公告状态")]
        public int IsStatus { get; set; }

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
        public int IsStatusLabel { get; set; }

        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Publisher { get; set; }
        public int Popup { get; set; }
    }
}