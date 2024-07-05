namespace Ams.Model.Routine
{
    /// <summary>
    /// 浏览记录
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    [SugarTable("routine_article_browsing_log", "浏览记录")]
    [Tenant("0")]
    public class ArticleBrowsingLog : SysBase
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long LogId { get; set; }

        public string Location { get; set; }
        public string UserIP { get; set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

        public long UserId { get; set; }
    }
}