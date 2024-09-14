namespace Ams.Model.Routine
{
    /// <summary>
    /// 文章话题
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_topic", TableDescription = "文章话题")]
    [Tenant(0)]
    public class ArticleTopic : SysBase
    {
        /// <summary>
        /// 话题ID
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long TopicId { get; set; }

        /// <summary>
        /// 话题名
        /// </summary>
        [SugarColumn(Length = 40)]
        public string TopicName { get; set; }

        /// <summary>
        /// 话题描述
        /// </summary>
        [SugarColumn(Length = 200)]
        public string TopicDescription { get; set; }

        /// <summary>
        /// 参与/发起次数
        /// </summary>
        public int JoinNum { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ViewNum { get; set; }

        /// <summary>
        /// 话题分类
        /// </summary>
        public int? TopicType { get; set; }
    }
}