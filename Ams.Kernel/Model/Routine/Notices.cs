namespace Ams.Kernel.Model.Routine
{
    /// <summary>
    /// 通知公告
    /// 数据实体对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/25 13:57:42)
    /// <summary>
    [SugarTable("routine_notice", "通知公告")]
    [Tenant(0)]
    public class Notices : SysBase
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
        /// 附件内容
        /// </summary>
        [SugarColumn(ColumnName = "notice_fileurl", ColumnDataType = StaticConfig.CodeFirst_BigString)]
        public string NoticeFileurl { get; set; }

        /// <summary>
        /// 公告状态 (0正常 1关闭)
        /// </summary>
        [SugarColumn(DefaultValue = "0", ExtendedAttribute = ProteryConstant.NOTNULL)]
        public int IsState { get; set; }
    }
}