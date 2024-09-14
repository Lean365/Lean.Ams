namespace Ams.Model.Routine
{
    /// <summary>
    /// 点赞记录
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_praise", "点赞记录")]
    [Tenant("0")]
    public class ArticlePraise : SysBase
    {
        /// <summary>
        /// 点赞ID
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
        [SugarColumn(ColumnDescription = "地理位置", Length = 20)]
        public string UserIP { get; set; }

        /// <summary>
        /// 至用户ID
        /// </summary>
        public long ToUserId { get; set; }

        /// <summary>
        /// 地理位置
        /// </summary>
        [SugarColumn(ColumnDescription = "地理位置", Length = 200)]
        public string Location { get; set; }
    }
}