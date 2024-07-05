namespace Ams.Model.Dto.Routine

{
    /// <summary>
    /// 文章点赞
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public class ArticlePraiseDto
    {
        public long UserId { get; set; }
        public long ArticleId { get; set; }
        public string UserIP { get; set; }
        public long ToUserId { get; set; }
        public int IsDelete { get; set; }
        public string Location { get; set; }
    }
}