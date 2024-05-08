namespace Ams.Model.Content
{
    [SugarTable("routine_article_browsing_log", "浏览记录")]
    [Tenant("0")]
    public class ArticleBrowsingLog
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long LogId { get; set; }

        public string Location { get; set; }
        public string UserIP { get; set; }
        public DateTime createTime { get; set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

        public long UserId { get; set; }
    }
}