using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace Ams.Kernel.Model.Routine
{
    /// <summary>
    /// 文章目录
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

        [SugarColumn(ColumnDescription = "目录名", Length = 20, ExtendedAttribute = ProteryConstant.NOTNULL)]
        public string Name { get; set; }
        public int? ParentId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [SugarColumn(IsIgnore = true)]
        public List<ArticleCategory> Children { get; set; }
    }
}
