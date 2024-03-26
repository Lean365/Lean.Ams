using System.ComponentModel.DataAnnotations;
using Ams.Kernel.Model.Routine;
using Ams.Model;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 文章管理
    /// 查询对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class ArticleQueryDto : PagerInfo
    {
        public long? UserId { get; set; }
        public int IsState { get; set; }
        public string Title { get; set; }
        public string AbstractText { get; set; }
        public int? IsPublic { get; set; }
        public int? IsTop { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? ArticleType { get; set; }
    }

    /// <summary>
    /// 文章管理
    /// 输入输出对象
    /// @Author: Lean365(Davis.Cheng)
    /// @Date: (2024/1/22 10:55:14)
    /// </summary>
    public class ArticleDto : SysBase
    {
        [Required(ErrorMessage = "Cid不能为空")]
        public int Cid { get; set; }

        [Required(ErrorMessage = "文章标题不能为空")]
        public string Title { get; set; }

        [Required(ErrorMessage = "文章内容不能为空")]
        public string Content { get; set; }

        public long? UserId { get; set; }

        public int IsState { get; set; }

        public string FmtType { get; set; }

        public string Tags { get; set; }

        public int Hits { get; set; }

        public int? CategoryId { get; set; }

        public string AuthorName { get; set; }

        public string CoverUrl { get; set; }

        public ArticleCategory ArticleCategoryNav { get; set; }
        public string[] TagList { get; set; }
        public int IsPublic { get; set; } = 1;
        public string AbstractText { get; set; }
        public int IsTop { get; set; }
        public int? ArticleType { get; set; }
    }
}