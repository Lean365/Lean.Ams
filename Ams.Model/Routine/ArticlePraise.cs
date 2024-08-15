namespace Ams.Model.Routine
{
    [SugarTable("routine_article_praise", "点赞记录")]
    [Tenant("0")]
    public class ArticlePraise : SysBase
    {
        /// <summary>
        /// ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long PId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP { get; set; }

        /// <summary>
        /// 至用户ID
        /// </summary>
        public long ToUserId { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }
    }
}