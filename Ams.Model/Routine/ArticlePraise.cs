namespace Ams.Model.Routine
{
    [SugarTable("routine_article_praise", "点赞记录")]
    [Tenant("0")]
    public class ArticlePraise : SysBase
    {
        [SugarColumn(IsPrimaryKey = true)]
        public long PId { get; set; }

        public long UserId { get; set; }
        public long ArticleId { get; set; }
        public string UserIP { get; set; }
        public long ToUserId { get; set; }
        public int IsDelete { get; set; }

        public string Location { get; set; }
    }
}