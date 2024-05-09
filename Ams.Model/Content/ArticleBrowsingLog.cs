namespace Ams.Model.Content
{
    /// <summary>
    /// 浏览记录
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_browsing_log", "浏览记录")]
    [Tenant("0")]
    public class ArticleBrowsingLog : SysBase
    {
        /// <summary>
        /// 浏览记录ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long LogId { get; set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 浏览位置
        /// </summary>
        public string Location { get; set; }
    }
}