using Ams.Model;
using Ams.Model.Content;
using Ams.Model.Dto;

namespace Ams.Service.Content.IService
{
    public interface IArticleCommentService
    {
        PagedInfo<ArticleCommentDto> GetMessageList(MessageQueryDto dto);
        ArticleComment AddMessage(ArticleComment message);
        int PraiseMessage(long mid);
        int DeleteMessage(long mid, long userId);
        PagedInfo<ArticleCommentDto> GetReplyComments(long mid, MessageQueryDto pager);
        PagedInfo<ArticleCommentDto> GetMyMessageList(MessageQueryDto dto);
    }
}
