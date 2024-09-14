namespace Ams.Model.Routine
{
    /// <summary>
    /// 浏览记录
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_browsing_log", "浏览记录")]
    [Tenant("0")]
    public class ArticleBrowsingLog : SysBase
    {
        /// <summary>
        /// 浏览ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public long LogId { get; set; }

        /// <summary>
        /// 地理位置
        /// </summary>
        [SugarColumn(ColumnDescription = "地理位置", Length = 200)]
        public string Location { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        [SugarColumn(ColumnDescription = "用户IP", Length = 20)]
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