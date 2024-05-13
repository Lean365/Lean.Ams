namespace Ams.Model.Dto.Content
{
    /// <summary>
    /// 点赞记录
    /// 输入输出对象
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024/01/01
    /// </summary>
    public class ArticlePraiseDto
    {
        public long UserId { get; set; }
        public long ArticleId { get; set; }
        public string UserIP { get; set; }
        public long ToUserId { get; set; }
        public int IsDeleted { get; set; }
        public string Location { get; set; }
    }
}