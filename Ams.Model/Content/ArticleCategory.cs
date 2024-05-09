namespace Ams.Model.Content
{
    /// <summary>
    /// 文章目录
    /// 数据实体对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_category", "文章目录")]
    [Tenant("0")]
    public class ArticleCategory : SysBase
    {
        /// <summary>
        /// 目录id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "category_id")]
        public int CategoryId { get; set; }

        [SugarColumn(ColumnDescription = "目录名", Length = 20, ExtendedAttribute = EntityConstant.NOTNULL)]
        public string Name { get; set; }

        [SugarColumn(ColumnDescription = "图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 排序id
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 父ID
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 背景图
        /// </summary>
        public string BgImg { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduce { get; set; }

        /// <summary>
        /// 分类类型 0、文章  1、圈子
        /// </summary>
        public int CategoryType { get; set; }

        /// <summary>
        /// 文章数
        /// </summary>
        public int ArticleNum { get; set; }

        /// <summary>
        /// 加入人数
        /// </summary>
        public int JoinNum { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [SugarColumn(IsIgnore = true)]
        public List<ArticleCategory> Children { get; set; }
    }
}