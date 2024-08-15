namespace Ams.Model.Routine
{
    /// <summary>
    /// 通知公告表
    ///
    /// @author Lean365(Davis.Ching)
    /// @date 2024-05-20
    /// </summary>
    [SugarTable("routine_notice_stroage", "通知公告")]
    [Tenant(0)]
    public class NoticeStorage : SysBase
    {
        /// <summary>
        /// 公告ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "notice_id")]
        public int NoticeId { get; set; }

        /// <summary>
        /// 公告标题
        /// </summary>
        [SugarColumn(ColumnName = "notice_title", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string NoticeTitle { get; set; }

        /// <summary>
        /// 公告类型 (1通知 2公告)
        /// </summary>
        [SugarColumn(ColumnName = "notice_type", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int NoticeType { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        [SugarColumn(ColumnName = "notice_content", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string NoticeContent { get; set; }

        /// <summary>
        /// 公告附件
        /// </summary>
        [SugarColumn(ColumnName = "file_url", Length = 99)]
        public string FileUrl { get; set; }

        /// <summary>
        /// 公告状态 (0正常 1关闭)
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsStatus { get; set; }

        /// <summary>
        /// 发布人
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 弹出提示
        /// </summary>
        public int Popup { get; set; }
    }
}