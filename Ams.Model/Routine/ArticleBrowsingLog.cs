namespace Ams.Model.Routine
{
    [SugarTable("routine_article_browsing_log", "浏览记录")]
    [Tenant("0")]
    public class ArticleBrowsingLog : SysBase
    {
        /// <summary>
        /// 日志ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long LogId { get; set; }

        /// <summary>
        /// 地点
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP { get; set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>

        public long UserId { get; set; }
    }
}