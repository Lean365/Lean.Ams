namespace Ams.Model.Routine
{
    /// <summary>
    /// 文章目录
    /// 数据实体对象
    /// @author lean365(Davis.Ching)
    /// @date 2024-01-01
    /// </summary>
    [SugarTable("routine_article_catalog", "文章目录")]
    [Tenant("0")]
    public class ArticleCatalog : SysBase
    {
        /// <summary>
        /// 目录id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "category_id")]
        public int CategoryId { get; set; }

        [SugarColumn(ColumnDescription = "目录名", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Name { get; set; }

        [SugarColumn(ColumnDescription = "图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 排序id
        /// </summary>
        public int SortingNum { get; set; }

        /// <summary>
        /// 父目录id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 背景图
        /// </summary>
        [SugarColumn(Length = 400)]
        public string BgImg { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        [SugarColumn(Length = 200)]
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
        public List<ArticleCatalog> Children { get; set; }
    }
}