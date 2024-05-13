namespace Ams.Model.Dto.Content
{
    /// <summary>
    /// 文章目录
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/01/01
    /// </summary>
    public class ArticleCategoryQueryDto : PagerInfo
    {
        public int? CategoryType { get; set; }
        public int? ParentId { get; set; }
    }

    /// <summary>
    /// 文章目录
    /// 查询对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/01/01
    /// </summary>
    public class ArticleCategoryDto
    {
        [Required(ErrorMessage = "目录id不能为空")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "目录名不能为空")]
        public string Name { get; set; }

        public string Icon { get; set; }
        public int OrderNum { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ParentId { get; set; }
        public int CategoryType { get; set; }

        /// <summary>
        /// 背景图
        /// </summary>
        public string BgImg { get; set; }

        /// <summary>
        /// 介绍
        /// </summary>
        public string Introduce { get; set; }

        /// <summary>
        /// 文章数
        /// </summary>
        public int ArticleNum { get; set; }

        /// <summary>
        /// 加入人数
        /// </summary>
        public int JoinNum { get; set; }
    }
}