using System.ComponentModel.DataAnnotations;
using Ams.Model.System;

namespace Ams.Kernel.Model.Dto.Routine
{
    /// <summary>
    /// 文章管理
    /// 查询对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class ArticleQueryDto : PagerInfo
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int IsStated { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string AbstractText { get; set; }

        /// <summary>
        /// 公开
        /// </summary>
        public int? IsPublic { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public int? IsTop { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 内容类型
        /// </summary>
        public int? ArticleType { get; set; }

        /// <summary>
        /// 1、最新 2、私密 3、热门
        /// </summary>
        public int TabId { get; set; }
    }

    /// <summary>
    /// 文章管理
    /// 输入输出对象
    /// @Author Lean365(Davis.Ching)
    /// @Date 2024-01-01
    /// </summary>
    public class ArticleDto
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        [Required(ErrorMessage = "Cid不能为空")]
        public int Cid { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required(ErrorMessage = "标题不能为空")]
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [Required(ErrorMessage = "内容不能为空")]
        public string Content { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int IsStated { get; set; }

        /// <summary>
        /// 编辑器类型
        /// </summary>
        public string FmtType { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// 点击量
        /// </summary>
        public int Hits { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 封面地址
        /// </summary>
        public string CoverUrl { get; set; }

        /// <summary>
        /// 类别导航
        /// </summary>
        public ArticleCategory ArticleCategoryNav { get; set; }

        /// <summary>
        /// 标签列表
        /// </summary>
        public string[] TagList
        {
            get
            {
                return Tags?.Split(',', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
            }
        }

        /// <summary>
        /// 是否公开
        /// </summary>
        public int IsPublic { get; set; } = 1;

        /// <summary>
        /// 摘要
        /// </summary>
        public string AbstractText { get; set; }

        /// <summary>
        /// 置顶
        /// </summary>
        public int IsTop { get; set; }

        /// <summary>
        /// 内容类型
        /// </summary>
        public int ArticleType { get; set; }

        /// <summary>
        /// 点赞数
        /// </summary>
        public int PraiseNum { get; set; }

        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentNum { get; set; }

        /// <summary>
        /// 分享数
        /// </summary>
        public int ShareNum { get; set; }

        /// <summary>
        /// 用户IP
        /// </summary>
        [JsonIgnore]
        public string UserIP { get; set; }

        /// <summary>
        /// 地理位置
        /// </summary>
        [JsonIgnore]
        public string Location { get; set; }

        /// <summary>
        /// 手机型号
        /// </summary>
        public string PhoneModel { get; set; }

        /// <summary>
        /// 封面图片集合
        /// </summary>
        public string[] CoverImgList
        {
            get
            {
                return Tools.SplitAndConvert<string>(CoverUrl, ',');
            }
        }

        /// <summary>
        /// 地理位置
        /// </summary>
        public string Position
        {
            get
            {
                return Location?.Split("-")[0];
            }
        }

        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
    }
}