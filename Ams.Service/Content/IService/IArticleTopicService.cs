using Ams.Model;
using Ams.Model.Content;
using Ams.Model.Dto;

namespace Ams.Service.Content.IService
{
    /// <summary>
    /// 文章话题
    /// 业务层接口
    /// @Author: Lean365(Davis.Ching)
    /// @Date: 2024-01-01
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