namespace Ams.Model.Content
{
    /// <summary>
    /// 点赞记录
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_praise", "点赞记录")]
    [Tenant("0")]
    public class ArticlePraise : SysBase
    {
        /// <summary>
        /// 点赞记录ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long PId { get; set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public long ArticleId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP { get; set; }

        /// <summary>
        /// 到用户IP
        /// </summary>
        public long ToUserId { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 软删除
        /// </summary>
        public int IsDeleted { get; set; }
    }
}