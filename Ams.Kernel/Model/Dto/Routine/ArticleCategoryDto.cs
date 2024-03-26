using System.ComponentModel.DataAnnotations;
using Ams.Model;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 文章目录
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class ArticleCategoryDto
    {
        [Required(ErrorMessage = "目录id不能为空")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "目录名不能为空")]
        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }
        public int? ParentId { get; set; }
    }

    /// <summary>
    /// 文章目录
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class ArticleCategoryQueryDto : PagerInfo
    {
    }
}