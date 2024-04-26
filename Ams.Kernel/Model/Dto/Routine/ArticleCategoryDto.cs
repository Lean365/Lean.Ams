using System.ComponentModel.DataAnnotations;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 文章目录
    /// 查询对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class ArticleCategoryQueryDto : PagerInfo
    {
        /// <summary>
        /// 目录类别
        /// </summary>
        public int? CategoryType { get; set; }
    }

    /// <summary>
    /// 文章目录
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class ArticleCategoryDto
    {
        /// <summary>
        /// 目录id
        /// </summary>
        [Required(ErrorMessage = "目录id不能为空")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 目录名
        /// </summary>

        [Required(ErrorMessage = "目录名不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 目录图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 目录排序
        /// </summary>
        public int OrderNum { get; set; }

        /// <summary>
        /// 目录类型
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 父级目录id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 目录类别
        /// </summary>
        public int CategoryType { get; set; }
    }
}