namespace Ams.Service.IService.Routine
{
    /// <summary>
    /// 文章话题service接口
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-05-20
    /// </summary>
    public interface IArticleTopicService : IBaseService<ArticleTopic>
    {
        PagedInfo<ArticleTopicDto> GetList(ArticleTopicQueryDto parm);

        ArticleTopic GetInfo(long TopicId);

        ArticleTopic AddArticleTopic(ArticleTopic parm);

        int UpdateArticleTopic(ArticleTopic parm);

        List<ArticleTopicDto> GetTopicList(ArticleTopicQueryDto parm);

        PagedInfo<ArticleTopicDto> ExportList(ArticleTopicQueryDto parm);
    }
}