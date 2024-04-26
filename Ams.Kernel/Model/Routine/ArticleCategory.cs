namespace Ams.Model.System
{
    /// <summary>
    /// 文章目录
    /// 数据实体类：routime_article_category
    /// @Author Lean365(Davis.Ching)
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

        /// <summary>
        /// 目录名
        /// </summary>

        [SugarColumn(ColumnDescription = "目录名", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Name { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [SugarColumn(ColumnDescription = "图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 排序id
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 父目录id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 分类类型
        /// </summary>
        public int CategoryType { get; set; }

        /// <summary>
        /// 子目录
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [SugarColumn(IsIgnore = true)]
        public List<ArticleCategory> Children { get; set; }
    }
}