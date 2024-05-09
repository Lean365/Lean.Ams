namespace Ams.Model.Content
{
    /// <summary>
    /// 话题列表
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_topic", TableDescription = "话题列表")]
    [Tenant("0")]
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
        public string TopicName { get; set; }

        /// <summary>
        /// 话题描述
        /// </summary>
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
        public int TopicType { get; set; }
    }
}